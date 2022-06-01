// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;

namespace GISharp.Lib.GLib
{
    unsafe partial struct TimeVal
    {
        /// <summary>
        /// seconds
        /// </summary>
        public CLong Seconds => tvSec;

        /// <summary>
        /// microseconds
        /// </summary>
        public CLong Microseconds => tvUsec;
    }
}
