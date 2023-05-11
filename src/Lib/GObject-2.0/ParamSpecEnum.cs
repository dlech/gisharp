// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecEnum
    {
        /// <summary>
        /// the <see cref="EnumClass"/> for the enum
        /// </summary>
        public EnumClass EnumClass =>
            Opaque.GetInstance<EnumClass>(
                (IntPtr)((UnmanagedStruct*)UnsafeHandle)->EnumClass,
                Transfer.None
            );

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new System.Enum DefaultValue
        {
            get
            {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;
                var gType = ((UnmanagedStruct*)UnsafeHandle)->EnumClass->GTypeClass.GType;
                var ret = (System.Enum)System.Enum.ToObject(gType.ToType(), ret_);
                return ret;
            }
        }

        static readonly GType _GType = paramSpecTypes[10];

        /// <include file="ParamSpecEnum.xmldoc" path="declaration/member[@name='ParamSpecEnum.ParamSpecEnum(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.GType,int,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecEnum(
            UnownedUtf8 name,
            UnownedUtf8 nick,
            UnownedUtf8 blurb,
            GType enumType,
            System.Enum defaultValue,
            ParamFlags flags
        )
            : this(
                (IntPtr)New(name, nick, blurb, enumType, Convert.ToInt32(defaultValue), flags),
                Transfer.None
            ) { }
    }
}
