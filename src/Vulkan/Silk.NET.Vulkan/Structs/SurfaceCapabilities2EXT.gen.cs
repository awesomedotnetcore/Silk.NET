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

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkSurfaceCapabilities2EXT")]
    public unsafe partial struct SurfaceCapabilities2EXT
    {
        public SurfaceCapabilities2EXT
        (
            StructureType? sType = StructureType.SurfaceCapabilities2Ext,
            void* pNext = null,
            uint? minImageCount = null,
            uint? maxImageCount = null,
            Extent2D? currentExtent = null,
            Extent2D? minImageExtent = null,
            Extent2D? maxImageExtent = null,
            uint? maxImageArrayLayers = null,
            SurfaceTransformFlagsKHR? supportedTransforms = null,
            SurfaceTransformFlagsKHR? currentTransform = null,
            CompositeAlphaFlagsKHR? supportedCompositeAlpha = null,
            ImageUsageFlags? supportedUsageFlags = null,
            SurfaceCounterFlagsEXT? supportedSurfaceCounters = null
        ) : this()
        {
            if (sType is not null)
            {
                SType = sType.Value;
            }

            if (pNext is not null)
            {
                PNext = pNext;
            }

            if (minImageCount is not null)
            {
                MinImageCount = minImageCount.Value;
            }

            if (maxImageCount is not null)
            {
                MaxImageCount = maxImageCount.Value;
            }

            if (currentExtent is not null)
            {
                CurrentExtent = currentExtent.Value;
            }

            if (minImageExtent is not null)
            {
                MinImageExtent = minImageExtent.Value;
            }

            if (maxImageExtent is not null)
            {
                MaxImageExtent = maxImageExtent.Value;
            }

            if (maxImageArrayLayers is not null)
            {
                MaxImageArrayLayers = maxImageArrayLayers.Value;
            }

            if (supportedTransforms is not null)
            {
                SupportedTransforms = supportedTransforms.Value;
            }

            if (currentTransform is not null)
            {
                CurrentTransform = currentTransform.Value;
            }

            if (supportedCompositeAlpha is not null)
            {
                SupportedCompositeAlpha = supportedCompositeAlpha.Value;
            }

            if (supportedUsageFlags is not null)
            {
                SupportedUsageFlags = supportedUsageFlags.Value;
            }

            if (supportedSurfaceCounters is not null)
            {
                SupportedSurfaceCounters = supportedSurfaceCounters.Value;
            }
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "minImageCount")]
        public uint MinImageCount;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "maxImageCount")]
        public uint MaxImageCount;
/// <summary></summary>
        [NativeName("Type", "VkExtent2D")]
        [NativeName("Type.Name", "VkExtent2D")]
        [NativeName("Name", "currentExtent")]
        public Extent2D CurrentExtent;
/// <summary></summary>
        [NativeName("Type", "VkExtent2D")]
        [NativeName("Type.Name", "VkExtent2D")]
        [NativeName("Name", "minImageExtent")]
        public Extent2D MinImageExtent;
/// <summary></summary>
        [NativeName("Type", "VkExtent2D")]
        [NativeName("Type.Name", "VkExtent2D")]
        [NativeName("Name", "maxImageExtent")]
        public Extent2D MaxImageExtent;
/// <summary></summary>
        [NativeName("Type", "uint32_t")]
        [NativeName("Type.Name", "uint32_t")]
        [NativeName("Name", "maxImageArrayLayers")]
        public uint MaxImageArrayLayers;
/// <summary></summary>
        [NativeName("Type", "VkSurfaceTransformFlagsKHR")]
        [NativeName("Type.Name", "VkSurfaceTransformFlagsKHR")]
        [NativeName("Name", "supportedTransforms")]
        public SurfaceTransformFlagsKHR SupportedTransforms;
/// <summary></summary>
        [NativeName("Type", "VkSurfaceTransformFlagBitsKHR")]
        [NativeName("Type.Name", "VkSurfaceTransformFlagBitsKHR")]
        [NativeName("Name", "currentTransform")]
        public SurfaceTransformFlagsKHR CurrentTransform;
/// <summary></summary>
        [NativeName("Type", "VkCompositeAlphaFlagsKHR")]
        [NativeName("Type.Name", "VkCompositeAlphaFlagsKHR")]
        [NativeName("Name", "supportedCompositeAlpha")]
        public CompositeAlphaFlagsKHR SupportedCompositeAlpha;
/// <summary></summary>
        [NativeName("Type", "VkImageUsageFlags")]
        [NativeName("Type.Name", "VkImageUsageFlags")]
        [NativeName("Name", "supportedUsageFlags")]
        public ImageUsageFlags SupportedUsageFlags;
/// <summary></summary>
        [NativeName("Type", "VkSurfaceCounterFlagsEXT")]
        [NativeName("Type.Name", "VkSurfaceCounterFlagsEXT")]
        [NativeName("Name", "supportedSurfaceCounters")]
        public SurfaceCounterFlagsEXT SupportedSurfaceCounters;
    }
}
