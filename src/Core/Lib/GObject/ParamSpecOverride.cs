// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// This is a type of <see cref="ParamSpec"/> type that simply redirects operations to
    /// another paramspec.  All operations other than getting or
    /// setting the value are redirected, including accessing the nick and
    /// blurb, validating a value, and so forth. See
    /// <see cref="ParamSpec.RedirectTarget"/> for retrieving the overidden
    /// property. <see cref="ParamSpecOverride"/> is used in implementing
    /// <see cref="ObjectClass.OverrideProperty"/>, and will not be directly useful
    /// unless you are implementing a new base type similar to GObject.
    /// </summary>
    [Since("2.4")]
    [GType("GParamOverride", IsProxyForUnmanagedType = true)]
    public sealed unsafe class ParamSpecOverride : ParamSpec
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ParamSpecOverride"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            /// <summary>
            /// private #GParamSpec portion
            /// </summary>
            public ParamSpec.UnmanagedStruct ParentInstance;

            /// <summary>
            /// The property that is being overridden
            /// </summary>
            public IntPtr Overridden;
#pragma warning restore CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ParamSpecOverride(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static readonly GType _GType = paramSpecTypes[20];
    }
}
