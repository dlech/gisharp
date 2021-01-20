// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for double properties.
    /// </summary>
    [GType("GParamDouble", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecDouble : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecDouble"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// minimum value for the property specified
            /// </summary>
            public double Minimum;

            /// <summary>
            /// maximum value for the property specified
            /// </summary>
            public double Maximum;

            /// <summary>
            /// default value for the property specified
            /// </summary>
            public double DefaultValue;

            /// <summary>
            /// values closer than epsilon will be considered identical by
            /// g_param_values_cmp(); the default value is 1e-90.
            /// </summary>
            public double Epsilon;
#pragma warning restore CS0649
        }

        /// <summary>
        /// minimum value for the property specified
        /// </summary>
        public unsafe double Minimum => ((UnmanagedStruct*)Handle)->Minimum;

        /// <summary>
        /// maximum value for the property specified
        /// </summary>
        public unsafe double Maximum => ((UnmanagedStruct*)Handle)->Maximum;

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new double DefaultValue => ((UnmanagedStruct*)Handle)->DefaultValue;

        /// <summary>
        /// values closer than epsilon will be considered identical by
        /// g_param_values_cmp(); the default value is 1e-90.
        /// </summary>
        public unsafe double Epsilon => ((UnmanagedStruct*)Handle)->Epsilon;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecDouble(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[13];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_double(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            double min,
            double max,
            double defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
        {
            var namePtr = GMarshal.StringToUtf8Ptr(name);
            var nickPtr = GMarshal.StringToUtf8Ptr(nick);
            var blurbPtr = GMarshal.StringToUtf8Ptr(blurb);
            var ret = g_param_spec_double(namePtr, nickPtr, blurbPtr, min, max, defaultValue, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(namePtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nickPtr);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurbPtr);
            }

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecDouble"/> instance specifying a
        /// <see cref="GType.Double"/> property.
        /// </summary>
        public ParamSpecDouble(string name, string nick, string blurb, double min, double max, double defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, min, max, defaultValue, flags), Transfer.None)
        {
        }
    }
}
