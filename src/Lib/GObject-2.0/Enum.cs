// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Enum
    {
        static partial void CheckCompleteTypeInfoArgs(GType gEnumType, ReadOnlySpan<EnumValue> constValues)
        {
            if (!constValues[^1].IsZero) {
                throw new ArgumentException("Must be zero-terminated", nameof(constValues));
            }
        }

        static partial void CheckRegisterStaticArgs(UnownedUtf8 name, ReadOnlySpan<EnumValue> constStaticValues)
        {
            if (!constStaticValues[^1].IsZero) {
                throw new ArgumentException("Must be zero-terminated", nameof(constStaticValues));
            }
        }

        /// <include file="Enum.xmldoc" path="declaration/member[@name='Enum.ToString(GISharp.Runtime.GType,int)']/*" />
        [Since("2.54")]
        public static Utf8 ToString(GType gEnumType, System.Enum value)
        {
            return ToString(gEnumType, Convert.ToInt32(value));
        }
    }
}
