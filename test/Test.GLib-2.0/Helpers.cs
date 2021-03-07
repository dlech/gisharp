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
            var major = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_major_version"));
            var minor = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_minor_version"));
            var micro = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_micro_version"));
            GLibVersion = $"{major}.{minor}.{micro}";
        }
    }
}
