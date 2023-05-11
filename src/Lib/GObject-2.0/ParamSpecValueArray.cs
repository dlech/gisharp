// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecValueArray
    {
        /// <summary>
        /// a <see cref="ParamSpec"/> describing the elements contained in arrays
        /// of this property, may be <c>null</c>
        /// </summary>
        public ParamSpec? ElementSpec
        {
            get
            {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->ElementSpec;
                var ret = GetInstance((IntPtr)ret_, Transfer.None)!;
                return ret;
            }
        }

        /// <summary>
        /// if greater than 0, arrays of this property will always have this many elements
        /// </summary>
        public uint FixedNElements => ((UnmanagedStruct*)UnsafeHandle)->FixedNElements;

        static readonly GType _GType = paramSpecTypes[18];
    }
}
