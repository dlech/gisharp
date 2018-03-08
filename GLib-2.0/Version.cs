using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GModule;

namespace GISharp.Lib.GLib
{
    public static partial class Version
    {
        /// <summary>
        /// The version of the GLib library that was used at compile time.
        /// </summary>
        /// <value>The compile time version.</value>
        public static System.Version CompileTime {
            get {
                return new System.Version (major, minor, micro, 0);
            }
        }

        static Lazy<System.Version> _RunTime = new Lazy<System.Version> (() => {
            using (var lib = Module.Open(Module.BuildPath(null, "glib-2.0", true), ModuleFlags.BindLazy)) {
                var major = Marshal.ReadInt32 (lib.GetSymbol ("glib_major_version"));
                var minor = Marshal.ReadInt32 (lib.GetSymbol ("glib_minor_version"));
                var micro = Marshal.ReadInt32 (lib.GetSymbol ("glib_micro_version"));
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
            using (var lib = Module.Open(Module.BuildPath(null, "glib-2.0", true), ModuleFlags.BindLazy)) {
                return Marshal.ReadInt32 (lib.GetSymbol ("glib_binary_age"));
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
            using (var lib = Module.Open(Module.BuildPath(null, "glib-2.0", true), ModuleFlags.BindLazy)) {
                return Marshal.ReadInt32 (lib.GetSymbol ("glib_interface_age"));
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
