// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    partial class DBusSignature
    {
        private static IntPtr Validate(UnownedUtf8 signature)
        {
            if (!Variant.IsSignature(signature))
            {
                throw new ArgumentException("Not a valid signature.", nameof(signature));
            }
            return signature.UnsafeHandle;
        }

        /// <summary>
        /// Creates a new D-bus signature.
        /// </summary>
        public DBusSignature(UnownedUtf8 signature)
            : this(Validate(signature), signature.MaybeLength, Transfer.None) { }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DBusSignature(IntPtr handle, int length, Transfer ownership)
            : base(handle, length, ownership) { }
    }
}
