// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

﻿using System;
using System.Runtime.InteropServices;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A union holding one collected value.
    /// </summary>
    [StructLayout (LayoutKind.Explicit)]
    public struct TypeCValue
    {
        /// <summary>
        /// the field for holding integer values
        /// </summary>
        [FieldOffset (0)]
        public int VInt;

        /// <summary>
        /// the field for holding long integer values
        /// </summary>
        [FieldOffset (0)]
        public long VLong;

        /// <summary>
        /// the field for holding 64 bit integer values
        /// </summary>
        [FieldOffset (0)]
        public long VInt64;

        /// <summary>
        /// the field for holding floating point values
        /// </summary>
        [FieldOffset (0)]
        public double VDouble;

        /// <summary>
        /// the field for holding pointers
        /// </summary>
        [FieldOffset (0)]
        public IntPtr VPointer;
    }
}
