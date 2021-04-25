// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class Enum
    {
        /// <include file="Enum.xmldoc" path="declaration/member[@name='Enum.ToString(GISharp.Runtime.GType,int)']/*" />
        [Since("2.54")]
        public static Utf8 ToString(GType gEnumType, System.Enum value)
        {
            return ToString(gEnumType, Convert.ToInt32(value));
        }
    }
}
