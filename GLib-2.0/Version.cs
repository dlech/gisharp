using System;

using GISharp.Core;

namespace GISharp.GLib
{
    public static partial class Version
    {
        /// <summary>
        /// Gets the GLib version that was used at compile time.
        /// </summary>
        /// <value>The compile time version.</value>
        public static System.Version CompileTime {
            get {
                return new System.Version (Major, Minor, Micro, 0);
            }
        }

        static Lazy<System.Version> _RunTime = new Lazy<System.Version> (() => {
            using (var lib = new DynamicLibrary ("glib-2.0")) {
                var major = lib.GetInt32 ("glib_major_version").Value;
                var minor = lib.GetInt32 ("glib_minor_version").Value;
                var micro = lib.GetInt32 ("glib_micro_version").Value;
                return new System.Version (major, minor, micro, 0);
            }
        });

        public static System.Version RunTime {
            get {
                return _RunTime.Value;
            }
        }
    }
}
