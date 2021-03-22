// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecBoolean
    {
        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new bool DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue.IsTrue();

        static readonly GType _GType = paramSpecTypes[2];
    }
}
