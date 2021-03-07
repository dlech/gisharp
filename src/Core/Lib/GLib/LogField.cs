// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Structure representing a single field in a structured log entry. See
    /// g_log_structured() for details.
    /// </summary>
    /// <remarks>
    /// Log fields may contain arbitrary values, including binary with embedded nul
    /// bytes. If the field contains a string, the string must be UTF-8 encoded and
    /// have a trailing nul byte. Otherwise, <see cref="Length"/> must be set to a non-negative
    /// value.
    /// </remarks>
    [Since("2.50")]
    public struct LogField
    {
        /// <summary>
        /// field name (UTF-8 string)
        /// </summary>
        public IntPtr Key;

        /// <summary>
        /// field value (arbitrary bytes)
        /// </summary>
        public IntPtr Value;

        /// <summary>
        /// length of <see cref="Value"/>, in bytes, or -1 if it is nul-terminated
        /// </summary>
        public IntPtr Length;

        /// <summary>
        /// Initializes the struct.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public LogField(UnownedUtf8 key, UnownedUtf8 value)
        {
            Key = key.UnsafeHandle;
            Value = value.UnsafeHandle;
            Length = (IntPtr)(-1);
        }
    }
}
