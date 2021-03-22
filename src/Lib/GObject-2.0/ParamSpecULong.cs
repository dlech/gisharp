// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

using culong = GISharp.Runtime.CULong;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecULong
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public culong Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public culong Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public new culong DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[6];
    }
}
