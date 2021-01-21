// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using GISharp.Lib.GLib;

namespace GISharp.Runtime
{
    /// <summary>
    /// Wraps an integer in an Opaque.
    /// </summary>
    /// <remarks>
    /// This is the equivalent of GLib's GINT_TO_POINTER() and GPOINTER_TO_INT()
    /// macros.
    /// </remarks>
    public sealed class OpaqueInt : Opaque
    {
        [PtrArrayCopyFunc]
        static IntPtr DummyCopyFunc(IntPtr handle) => handle;

        [PtrArrayFreeFunc]
        static void DummyFreeFunc(IntPtr handle) { }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        public int Value => (int)UnsafeHandle;

        /// <inheritdoc />
        public override IntPtr UnsafeHandle => handle;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OpaqueInt(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static IntPtr New(int value)
        {
            return new IntPtr(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpaqueInt"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public OpaqueInt(int value) : this(New(value), Transfer.Full)
        {
        }

        /// <summary>
        /// Converts a pointer to an integer.
        /// </summary>
        public static implicit operator int(OpaqueInt instance)
        {
            return instance.Value;
        }

        /// <summary>
        /// Converts an integer to a pointer.
        /// </summary>
        public static implicit operator OpaqueInt(int value)
        {
            return new OpaqueInt(value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("[OpaqueInt: Value={0}]", Value);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is OpaqueInt other) {
                return Value == other.Value;
            }
            return base.Equals(obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            // there is nothing to free
        }
    }
}
