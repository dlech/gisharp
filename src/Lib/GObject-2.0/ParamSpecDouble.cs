// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecDouble
    {
        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public double Minimum => ((UnmanagedStruct*)UnsafeHandle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public double Maximum => ((UnmanagedStruct*)UnsafeHandle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new double DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        /// <summary>
        /// values closer than epsilon will be considered identical by
        /// g_param_values_cmp(); the default value is 1e-90.
        /// </summary>
        public double Epsilon => ((UnmanagedStruct*)UnsafeHandle)->Epsilon;

        static readonly GType _GType = paramSpecTypes[13];
    }
}
