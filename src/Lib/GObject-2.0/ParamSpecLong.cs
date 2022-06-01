// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecLong
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public CLong Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public CLong Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new CLong DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[5];
    }
}
