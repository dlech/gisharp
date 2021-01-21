// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A <see cref="ParamSpec"/> derived structure that contains the meta data for boolean properties.
    /// </summary>
    [GType("GParamBoolean", IsProxyForUnmanagedType = true)]
    public sealed class ParamSpecBoolean : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecBoolean"/>.
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
            /// default value for the property specified
            /// </summary>
            public Runtime.Boolean DefaultValue;
#pragma warning restore CS0649
        }

        /// <summary>
        /// default value for the property specified
        /// </summary>
        public unsafe new bool DefaultValue => ((UnmanagedStruct*)UnsafeHandle)->DefaultValue.IsTrue();

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecBoolean(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[2];

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr g_param_spec_boolean(
            IntPtr name,
            IntPtr nick,
            IntPtr blurb,
            Runtime.Boolean defaultValue,
            ParamFlags flags);

        static IntPtr New(string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
        {
            var name_ = GMarshal.StringToUtf8Ptr(name);
            var nick_ = GMarshal.StringToUtf8Ptr(nick);
            var blurb_ = GMarshal.StringToUtf8Ptr(blurb);
            var defaultValue_ = defaultValue.ToBoolean();
            var ret = g_param_spec_boolean(name_, nick_, blurb_, defaultValue_, flags);

            // Any strings that have the cooresponding static flag set must not
            // be freed because they are passed to g_intern_static_string().
            if (!flags.HasFlag(ParamFlags.StaticName)) {
                GMarshal.Free(name_);
            }
            if (!flags.HasFlag(ParamFlags.StaticNick)) {
                GMarshal.Free(nick_);
            }
            if (!flags.HasFlag(ParamFlags.StaticBlurb)) {
                GMarshal.Free(blurb_);
            }

            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="ParamSpecBoolean"/> instance specifying a
        /// <see cref="GType.Boolean"/> property.
        /// </summary>
        /// <remarks>
        /// In many cases, it may be more appropriate to use an enum with
        /// <see cref="ParamSpecEnum"/>, both to improve code clarity by using
        /// explicitly named values, and to allow for more values to be added
        /// in future without breaking API.
        /// </remarks>
        public ParamSpecBoolean(string name, string nick, string blurb, bool defaultValue, ParamFlags flags)
            : this(New(name, nick, blurb, defaultValue, flags), Transfer.None)
        {
        }
    }
}
