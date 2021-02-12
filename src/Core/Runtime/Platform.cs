// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Helpers for dealing with differences in operating systems.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Adds platform-specific prefix and suffix to library name.
        /// </summary>
        /// <remarks>
        /// Windows: no prefix, ".dll" suffix
        /// Mac: "lib" prefix, ".dylib" suffix
        /// Linux: "lib" prefix, ".so" suffix
        /// </remarks>
        public static string LibraryName(string name)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                return $"{name}.dll";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                return $"lib{name}.dylib";
            }

            return $"lib{name}.so";
        }
    }
}
