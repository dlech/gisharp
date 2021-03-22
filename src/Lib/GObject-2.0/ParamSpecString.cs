// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecString
    {
        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new UnownedUtf8 DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;
                var ret = new UnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the first byte
        /// </summary>
        public NullableUnownedUtf8 CsetFirst {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->CsetFirst;
                var ret = new NullableUnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// a string containing the allowed values for the subsequent bytes
        /// </summary>
        public NullableUnownedUtf8 CsetNth {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->CsetNth;
                var ret = new NullableUnownedUtf8((IntPtr)ret_, -1);
                return ret;
            }
        }

        /// <summary>
        /// the replacement byte for bytes which don't match <see cref="CsetFirst"/>
        /// or <see cref="CsetNth"/> .
        /// </summary>
        public sbyte Substitutor => ((UnmanagedStruct*)UnsafeHandle)->Substitutor;

        uint Bitfield => ((UnmanagedStruct*)UnsafeHandle)->Bits5;

        /// <summary>
        /// replace empty string by <c>null</c>
        /// </summary>
        public bool NullFoldIfEmpty {
            get {
                var ret = Convert.ToBoolean(Bitfield & 0x1);
                return ret;
            }
        }

        /// <summary>
        /// replace <c>null</c> strings by an empty string
        /// </summary>
        public bool EnsureNonNull {
            get {
                var ret = Convert.ToBoolean(Bitfield & 0x2);
                return ret;
            }
        }

        static readonly GType _GType = paramSpecTypes[14];
    }
}
