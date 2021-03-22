// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecUnichar
    {
        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new Unichar DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[9];
    }
}
