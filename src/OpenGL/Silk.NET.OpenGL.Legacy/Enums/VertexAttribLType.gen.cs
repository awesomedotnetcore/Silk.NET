// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using Silk.NET.Core.Attributes;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy
{
    [NativeName("Name", "VertexAttribLType")]
    public enum VertexAttribLType : int
    {
        [NativeName("Name", "GL_DOUBLE")]
        Double = 0x140A,
    }
}
