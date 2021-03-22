// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Flags
    {
        static partial void CheckCompleteTypeInfoArgs(GType gFlagsType, ReadOnlySpan<FlagsValue> constValues)
        {
            if (!constValues[^1].IsZero) {
                throw new ArgumentException("Must be zero-terminated", nameof(constValues));
            }
        }

        static partial void CheckRegisterStaticArgs(UnownedUtf8 name, ReadOnlySpan<FlagsValue> constStaticValues)
        {
            if (!constStaticValues[^1].IsZero) {
                throw new ArgumentException("Must be zero-terminated", nameof(constStaticValues));
            }
        }

        /// <include file="Flags.xmldoc" path="declaration/member[@name='Flags.ToString(GISharp.Runtime.GType,uint)']/*" />
        [Since("2.54")]
        public static Utf8 ToString(GType flagsType, System.Enum value)
        {
            return ToString(flagsType, Convert.ToUInt32(value));
        }
    }
}
