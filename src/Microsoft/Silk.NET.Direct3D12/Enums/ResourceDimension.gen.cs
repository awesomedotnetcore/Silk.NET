// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_RESOURCE_DIMENSION")]
    public enum ResourceDimension : int
    {
        [NativeName("Name", "D3D12_RESOURCE_DIMENSION_UNKNOWN")]
        ResourceDimensionUnknown = 0x0,
        [NativeName("Name", "D3D12_RESOURCE_DIMENSION_BUFFER")]
        ResourceDimensionBuffer = 0x1,
        [NativeName("Name", "D3D12_RESOURCE_DIMENSION_TEXTURE1D")]
        ResourceDimensionTexture1D = 0x2,
        [NativeName("Name", "D3D12_RESOURCE_DIMENSION_TEXTURE2D")]
        ResourceDimensionTexture2D = 0x3,
        [NativeName("Name", "D3D12_RESOURCE_DIMENSION_TEXTURE3D")]
        ResourceDimensionTexture3D = 0x4,
    }
}
