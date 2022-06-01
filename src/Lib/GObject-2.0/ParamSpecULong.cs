// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecULong
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public CULong Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public CULong Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public new CULong DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[6];
    }
}
