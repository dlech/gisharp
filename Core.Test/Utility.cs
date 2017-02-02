using System;
using System.Runtime.InteropServices;
using GISharp.GModule;
using NUnit.Framework;

namespace GISharp.Core.Test
{
    public static class Utility
    {
        static readonly Version runtimeVersion;

        static Utility () {
            using (var lib = Module.Open (Module.BuildPath (null, "glib-2.0", true), ModuleFlags.BindLazy)) {
                var major = Marshal.ReadInt32 (lib.GetSymbol ("glib_major_version"));
                var minor = Marshal.ReadInt32 (lib.GetSymbol ("glib_minor_version"));
                var micro = Marshal.ReadInt32 (lib.GetSymbol ("glib_micro_version"));
                runtimeVersion = new Version (major, minor, micro);
            }
        }

        /// <summary>
        /// Throws an IgnoreException if the system GLib version is less than
        /// the value specified.
        /// </summary>
        public static void IgnoreTestWhenGLibVersionIsLessThan (string version)
        {
            var testVersion = new Version (version);
            if (runtimeVersion < testVersion) {
                throw new IgnoreException ($"Skipping test since glib-2.0 v{runtimeVersion} < v{testVersion}");
            }
        }
    }
}
