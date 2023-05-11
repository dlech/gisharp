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
        public static System.Version CompileTime
        {
            get { return new System.Version(major, minor, micro, 0); }
        }

        static readonly Lazy<System.Version> _RunTime =
            new(() =>
            {
                var major = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_major_version"));
                var minor = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_minor_version"));
                var micro = Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_micro_version"));
                return new System.Version(major, minor, micro, 0);
            });

        /// <summary>
        /// The version of the GLib library linked against at run time.
        /// </summary>
        /// <value>The run time.</value>
        public static System.Version RunTime => _RunTime.Value;

        static readonly Lazy<int> _BinaryAge =
            new(() =>
            {
                return Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_binary_age"));
            });

        /// <summary>
        /// Defines how far back backwards compatibility reaches.
        /// </summary>
        /// <value>The binary age of the GLib library.</value>
        /// <remarks>
        /// An integer variable exported from the library linked against at
        /// application run time.
        /// </remarks>
        public static int BinaryAge
        {
            get { return _BinaryAge.Value; }
        }

        static readonly Lazy<int> _InterfaceAge =
            new(() =>
            {
                return Marshal.ReadInt32(CLibrary.GetSymbol("glib-2.0", "glib_interface_age"));
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
