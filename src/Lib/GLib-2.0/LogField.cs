// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019,2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

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
            this.key = (byte*)key.UnsafeHandle;
            this.value = value.UnsafeHandle;
            length = -1;
        }
    }
}
