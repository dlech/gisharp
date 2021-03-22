// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecGType
    {
        /// <summary>
        /// a <see cref="GType"/> whose subtypes can occur as values
        /// </summary>
        public GType IsAType => ((UnmanagedStruct*)UnsafeHandle)->IsAType;

        static readonly GType _GType = paramSpecTypes[21];
    }
}
