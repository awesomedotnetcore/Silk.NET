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
using Silk.NET.OpenGLES;
using Extension = Silk.NET.Core.Attributes.ExtensionAttribute;

#pragma warning disable 1591

namespace Silk.NET.OpenGLES.Extensions.NV
{
    [Extension("NV_conservative_raster_pre_snap_triangles")]
    public unsafe partial class NVConservativeRasterPreSnapTriangles : NativeExtension<GL>
    {
        public const string ExtensionName = "NV_conservative_raster_pre_snap_triangles";
        [NativeApi(EntryPoint = "glConservativeRasterParameteriNV")]
        public partial void ConservativeRasterParameter([Flow(FlowDirection.In)] NV pname, [Flow(FlowDirection.In)] int param);

        public NVConservativeRasterPreSnapTriangles(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

