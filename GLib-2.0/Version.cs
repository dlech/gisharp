using System;

using GISharp.Core;

namespace GISharp.GLib
{
    public static partial class Version
    {
        /// <summary>
        /// The version of the GLib library that was used at compile time.
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

        /// <summary>
        /// The version of the GLib library linked against at run time.
        /// </summary>
        /// <value>The run time.</value>
        public static System.Version RunTime {
            get {
                return _RunTime.Value;
            }
        }

        static Lazy<int> _BinaryAge = new Lazy<int> (() => {
            using (var lib = new DynamicLibrary ("glib-2.0")) {
                return lib.GetInt32 ("glib_binary_age").Value;
            }
        });

        /// <summary>
        /// Defines how far back backwards compatibility reaches.
        /// </summary>
        /// <value>The binary age of the GLib library.</value>
        /// <remarks>
        /// An integer variable exported from the library linked against at
        /// application run time.
        /// </remarks>
        public static int BinaryAge {
            get {
                return _BinaryAge.Value;
            }
        }

        static Lazy<int> _InterfaceAge = new Lazy<int> (() => {
            using (var lib = new DynamicLibrary ("glib-2.0")) {
                return lib.GetInt32 ("glib_interface_age").Value;
            }
        });

        /// <summary>
        /// Defines how far back the API has last been extended.
        /// </summary>
        /// <value>The interface age of the GLib library.</value>
        /// <remarks>
        /// An integer variable exported from the library linked against at
        /// application run time.
        /// </remarks>
        public static int InterfaceAge {
            get {
                return _InterfaceAge.Value;
            }
        }
    }
}
