// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecFlags
    {
        /// <summary>
        /// the <see cref="FlagsClass"/> for the flags
        /// </summary>
        public FlagsClass FlagsClass =>
            Opaque.GetInstance<FlagsClass>((IntPtr)((UnmanagedStruct*)UnsafeHandle)->FlagsClass, Transfer.None);

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public new System.Enum DefaultValue {
            get {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;
                var gType = ((UnmanagedStruct*)UnsafeHandle)->FlagsClass->GTypeClass.GType;
                var ret = (System.Enum)System.Enum.ToObject(gType.ToType(), ret_);
                return ret;
            }
        }

        static readonly GType _GType = paramSpecTypes[11];

        /// <include file="ParamSpecFlags.xmldoc" path="declaration/member[@name='ParamSpecFlags.ParamSpecFlags(GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.UnownedUtf8,GISharp.Runtime.GType,uint,GISharp.Lib.GObject.ParamFlags)']/*" />
        public ParamSpecFlags(UnownedUtf8 name, UnownedUtf8 nick, UnownedUtf8 blurb, GType flagsType, System.Enum defaultValue, ParamFlags flags)
            : this((IntPtr)New(name, nick, blurb, flagsType, Convert.ToUInt32(defaultValue), flags), Transfer.None)
        {
        }
    }
}
