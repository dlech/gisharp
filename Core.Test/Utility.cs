using System;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Core.Test
{
    public static class Utility
    {
        static readonly Version runtimeVersion;

        static Utility () {
            using (var lib = new DynamicLibrary ("glib-2.0")) {
                var major = lib.GetInt32 ("glib_major_version").Value;
                var minor = lib.GetInt32 ("glib_minor_version").Value;
                var micro = lib.GetInt32 ("glib_micro_version").Value;
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
