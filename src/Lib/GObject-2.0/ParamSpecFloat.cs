// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecFloat
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public float Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public float Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new float DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        /// <summary>
        /// values closer than epsilon will be considered identical by
        /// g_param_values_cmp(); the default value is 1e-30.
        /// </summary>
        public float Epsilon => ((UnmanagedStruct*)UnsafeHandle)->Epsilon;

        static readonly GType _GType = paramSpecTypes[12];
    }
}
