// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecUInt
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public uint Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public uint Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new uint DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[4];
    }
}
