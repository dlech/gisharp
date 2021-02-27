// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    public static class Helpers
    {
        public static string GLibVersion { get; }

        static Helpers()
        {
            var lib = NativeLibrary.Load(Platform.LibraryName("glib-2.0"));
            try {
                var major = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_major_version"));
                var minor = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_minor_version"));
                var micro = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_micro_version"));
                GLibVersion = $"{major}.{minor}.{micro}";
            }
            finally {
                NativeLibrary.Free(lib);
            }
        }
    }
}
