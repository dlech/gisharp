// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    partial class DBusObjectPath
    {
        private static IntPtr Validate(UnownedUtf8 path)
        {
            if (!Variant.IsObjectPath(path))
            {
                throw new ArgumentException("Not a valid object path.", nameof(path));
            }
            return path.UnsafeHandle;
        }

        /// <summary>
        /// Creates a new D-Bus object path.
        /// </summary>
        public DBusObjectPath(UnownedUtf8 path)
            : this(Validate(path), path.MaybeLength, Transfer.None) { }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DBusObjectPath(IntPtr handle, int length, Transfer ownership)
            : base(handle, length, ownership) { }
    }
}
