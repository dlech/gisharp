// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System.Text;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecUnichar
    {
        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new Rune DefaultValue => (Rune)((UnmanagedStruct*)UnsafeHandle)->DefaultValue;

        static readonly GType _GType = paramSpecTypes[9];
    }
}
