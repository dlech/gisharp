// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Flags
    {
        /// <include file="Flags.xmldoc" path="declaration/member[@name='Flags.ToString(GISharp.Runtime.GType,uint)']/*" />
        [Since("2.54")]
        public static Utf8 ToString(GType flagsType, System.Enum value)
        {
            return ToString(flagsType, Convert.ToUInt32(value));
        }
    }
}
