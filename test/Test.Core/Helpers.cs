// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>


using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GModule;

namespace GISharp.Test.Core
{
    public static class Helpers
    {
        public static string GLibVersion { get; }

        static Helpers() {
            using (var lib = Module.Open(Module.BuildPath(null, "glib-2.0", true), ModuleFlags.BindLazy)) {
                var major = Marshal.ReadInt32(lib.GetSymbol("glib_major_version"));
                var minor = Marshal.ReadInt32(lib.GetSymbol("glib_minor_version"));
                var micro = Marshal.ReadInt32(lib.GetSymbol("glib_micro_version"));
                GLibVersion = $"{major}.{minor}.{micro}";
            }
        }
    }
}
