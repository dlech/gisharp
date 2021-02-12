// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

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
                return new System.Version(major, minor, micro, 0);
            }
        }

        static readonly Lazy<System.Version> _RunTime = new(() => {
            var lib = NativeLibrary.Load(Platform.LibraryName("glib-2.0"));
            try {
                var major = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_major_version"));
                var minor = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_minor_version"));
                var micro = Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_micro_version"));
                return new System.Version(major, minor, micro, 0);
            }
            finally {
                NativeLibrary.Free(lib);
            }
        });

        /// <summary>
        /// The version of the GLib library linked against at run time.
        /// </summary>
        /// <value>The run time.</value>
        public static System.Version RunTime => _RunTime.Value;

        static readonly Lazy<int> _BinaryAge = new(() => {
            var lib = NativeLibrary.Load(Platform.LibraryName("glib-2.0"));
            try {
                return Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_binary_age"));
            }
            finally {
                NativeLibrary.Free(lib);
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

        static readonly Lazy<int> _InterfaceAge = new(() => {
            var lib = NativeLibrary.Load(Platform.LibraryName("glib-2.0"));
            try {
                return Marshal.ReadInt32(NativeLibrary.GetExport(lib, "glib_interface_age"));
            }
            finally {
                NativeLibrary.Free(lib);
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
        public static int InterfaceAge => _InterfaceAge.Value;
    }
}
