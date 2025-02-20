// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using Silk.NET.Core;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using Silk.NET.OpenGL.Legacy;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.NVX
{
    [Extension("NVX_linked_gpu_multicast")]
    public unsafe partial class NvxLinkedGpuMulticast : NativeExtension<GL>
    {
        public const string ExtensionName = "NVX_linked_gpu_multicast";
        [NativeApi(EntryPoint = "glLGPUCopyImageSubDataNVX")]
        public partial void LgpucopyImageSubData([Flow(FlowDirection.In)] uint sourceGpu, [Flow(FlowDirection.In)] uint destinationGpuMask, [Flow(FlowDirection.In)] uint srcName, [Flow(FlowDirection.In)] NVX srcTarget, [Flow(FlowDirection.In)] int srcLevel, [Flow(FlowDirection.In)] int srcX, [Flow(FlowDirection.In)] int srxY, [Flow(FlowDirection.In)] int srcZ, [Flow(FlowDirection.In)] uint dstName, [Flow(FlowDirection.In)] NVX dstTarget, [Flow(FlowDirection.In)] int dstLevel, [Flow(FlowDirection.In)] int dstX, [Flow(FlowDirection.In)] int dstY, [Flow(FlowDirection.In)] int dstZ, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height, [Flow(FlowDirection.In)] uint depth);

        [NativeApi(EntryPoint = "glLGPUInterlockNVX")]
        public partial void Lgpuinterlock();

        [NativeApi(EntryPoint = "glLGPUNamedBufferSubDataNVX")]
        public unsafe partial void LgpunamedBufferSubData([Flow(FlowDirection.In)] uint gpuMask, [Flow(FlowDirection.In)] uint buffer, [Flow(FlowDirection.In)] nint offset, [Flow(FlowDirection.In)] nuint size, [Flow(FlowDirection.In)] void* data);

        [NativeApi(EntryPoint = "glLGPUNamedBufferSubDataNVX")]
        public partial void LgpunamedBufferSubData<T0>([Flow(FlowDirection.In)] uint gpuMask, [Flow(FlowDirection.In)] uint buffer, [Flow(FlowDirection.In)] nint offset, [Flow(FlowDirection.In)] nuint size, [Flow(FlowDirection.In)] in T0 data) where T0 : unmanaged;

        public NvxLinkedGpuMulticast(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

