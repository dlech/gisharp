// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019,2021 David Lechner <david@lechnology.com>

namespace GISharp.Lib.GLib
{
    unsafe partial struct LogField
    {
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
            Key = (byte*)key.UnsafeHandle;
            Value = value.UnsafeHandle;
            Length = -1;
        }
    }
}
