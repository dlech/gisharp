// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class ParamSpecVariant
    {
        /// <summary>
        /// A <see cref="VariantType" /> or <c>null</c>
        /// </summary>
        public VariantType? VariantType
        {
            get
            {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->Type;
                var ret = Opaque.GetInstance<VariantType>((IntPtr)ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// A <see cref="Variant" /> or <c>null</c>
        /// </summary>
        public new Variant? DefaultValue
        {
            get
            {
                var ret_ = ((UnmanagedStruct*)UnsafeHandle)->DefaultValue;
                var ret = Opaque.GetInstance<Variant>((IntPtr)ret_, Transfer.None);
                return ret;
            }
        }

        static readonly GType _GType = paramSpecTypes[22];
    }
}
