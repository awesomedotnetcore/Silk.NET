﻿// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Silk.NET.Core.Native
{
    /// <summary>
    /// Represents a block of global memory. That is, memory that is pinned and is valid so long as this object is alive.
    /// </summary>
    public sealed class GlobalMemory : IDisposable
    {    
        // Actual object
        private readonly object _memoryObject;

        internal GlobalMemory(object memoryObject, int length)
        {
            _memoryObject = memoryObject;
            Length = length;
        }

        /// <summary>
        /// Gets the length of this block of global memory.
        /// </summary>
        public int Length { get; }
        
        /// <summary>
        /// Gets a reference to a specific index of this block of global memory.
        /// </summary>
        /// <param name="index">The index.</param>
        public ref byte this[int index] => ref Unsafe.Add(ref GetPinnableReference(), index);

#if NETCOREAPP3_1 || NET5_0
        /// <summary>
        /// Gets a reference to a specific index of this block of global memory.
        /// </summary>
        /// <param name="index">The index.</param>
        public ref byte this[Index index] => ref Unsafe.Add(ref GetPinnableReference(), index.GetOffset(Length));

        /// <summary>
        /// Gets a span representing a specific area of this block of global memory.
        /// </summary>
        /// <param name="range">The range.</param>
        public Span<byte> this[Range range]
            => AsSpan().Slice(range.Start.GetOffset(Length), range.End.GetOffset(Length));
#endif

        /// <summary>
        /// Gets a handle to this block of global memory.
        /// </summary>
        public unsafe nint Handle => (nint)Unsafe.AsPointer(ref GetPinnableReference());

        /// <summary>
        /// Gets a span representing this block of global memory.
        /// </summary>
        /// <returns>A span of global memory.</returns>
        public unsafe Span<byte> AsSpan() => _memoryObject is IGlobalMemory hGlobal
            ? new Span<byte>((byte*) hGlobal.Handle, Length)
            : new Span<byte>((byte[]) _memoryObject);

        /// <summary>
        /// Gets a span of the given type representing this block of global memory.
        /// </summary>
        /// <returns>A span of global memory.</returns>
        public unsafe Span<T> AsSpan<T>() where T : unmanaged
            => new Span<T>(Unsafe.AsPointer(ref GetPinnableReference()), Length / sizeof(T));

        /// <summary>
        /// Gets a span representing this block of global memory.
        /// </summary>
        /// <returns>A span of global memory.</returns>
        public static implicit operator Span<byte>(GlobalMemory left) => left.AsSpan();

        /// <summary>
        /// Gets a handle to this block of global memory.
        /// </summary>
        /// <returns>A handle to this block of global memory.</returns>
        public static unsafe implicit operator void*(GlobalMemory left) => (void*) left.Handle;


        /// <summary>
        /// Gets a handle to this block of global memory.
        /// </summary>
        /// <returns>A handle to this block of global memory.</returns>
        public static implicit operator nint(GlobalMemory left) => left.Handle;

        /// <summary>
        /// Gets a reference to the global memory. This reference is valid until this object is disposed or finalized.
        /// </summary>
        /// <returns>A reference to the global memory.</returns>
        public unsafe ref byte GetPinnableReference()
            => ref _memoryObject is IGlobalMemory hGlobal
                ? ref *(byte*) hGlobal.Handle
                : ref ((byte[]) _memoryObject)[0];

        private void Free()
        {
            switch (_memoryObject)
            {
                case HGlobal hGlobal:
                {
                    Marshal.FreeHGlobal(hGlobal.Handle);
                    break;
                }
                case BStr bStr:
                {
                    Marshal.FreeBSTR(bStr.Handle);
                    break;
                }
                case GCHandleByteArray byteArray:
                {
                    byteArray.GCHandle.Free();
                    break;
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Free();
            GC.SuppressFinalize(this);
        }

        ~GlobalMemory()
        {
            Free();
        }
        
        // Allocation methods
        /// <summary>
        /// Allocates a block of global memory of the given length.
        /// </summary>
        /// <param name="length">The number of bytes to allocate.</param>
        /// <returns>A block of global memory.</returns>
        public static GlobalMemory Allocate(int length) =>
#if !NET5_0
            new GlobalMemory(new GCHandleByteArray(length), length);
#else
            new GlobalMemory(GC.AllocateUninitializedArray<byte>(length, true), length);
#endif

        // Encapsulations different kinds of memory
        private interface IGlobalMemory
        {
            nint Handle { get; }
        }
        
        private struct GCHandleByteArray : IGlobalMemory
        {
            public GCHandleByteArray(int length) => GCHandle = GCHandle.Alloc(new byte[length], GCHandleType.Pinned);
            public GCHandle GCHandle { get; }
            public nint Handle => GCHandle.AddrOfPinnedObject();
        }

        private struct HGlobal : IGlobalMemory
        {
            public HGlobal(int length) => Handle = Marshal.AllocHGlobal(length);
            public HGlobal(nint val) => Handle = val;
            public nint Handle { get; }
        }

        private struct BStr : IGlobalMemory
        {
            public BStr(int length) => Handle = SilkMarshal.AllocBStr(length);
            public BStr(nint val) => Handle = val;
            public nint Handle { get; }
        }
        
        private struct Other : IGlobalMemory
        {
            // used for "unsafe" marshalling of a pointer to our neat GlobalMemory class if that's your thing.
            public Other(nint val) => Handle = val;
            public nint Handle { get; }
        }
        
        // "Unsafe" methods
        internal static GlobalMemory FromHGlobal(nint hGlobal, int len)
            => new GlobalMemory(new HGlobal(hGlobal), len);
        
        internal static GlobalMemory FromBStr(nint bStr, int len)
            => new GlobalMemory(new BStr(bStr), len);
        
        internal static GlobalMemory FromAnyPtr(nint val, int len)
            => new GlobalMemory(new Other(val), len);
    }
}
