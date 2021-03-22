// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using clong = GISharp.Runtime.CLong;

namespace GISharp.Lib.GLib
{
    unsafe partial struct TimeVal
    {
        /// <summary>
        /// seconds
        /// </summary>
        public clong Seconds => tvSec;

        /// <summary>
        /// microseconds
        /// </summary>
        public clong Microseconds => tvUsec;
    }
}
