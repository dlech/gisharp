// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace GISharp.Runtime
{
    /// <summary>
    /// Helpers for C library interop.
    /// </summary>
    public static class CLibrary
    {
        private static readonly ConcurrentDictionary<string, IntPtr> libraryHandles = new();

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

        /// <summary>
        /// Gets a pointer to a symbol in a native library.
        /// </summary>
        /// <param name="libraryName">
        /// Name of the library without "lib" prefix or file extension.
        /// </param>
        /// <param name="symbolName">
        /// The name of the symbol to look up.
        /// </param>
        /// <return>
        /// Pointer to the symbol.
        /// </return>
        public static IntPtr GetSymbol(string libraryName, string symbolName)
        {
            var libraryHandle = libraryHandles.GetOrAdd(LibraryName(libraryName), x => NativeLibrary.Load(x));
            return NativeLibrary.GetExport(libraryHandle, symbolName);
        }
    }
}
