// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial struct FlagsValue
    {
        /// <summary>
        /// the flags value
        /// </summary>
        public uint Value => value;

        /// <summary>
        /// the name of the value
        /// </summary>
        public UnownedUtf8 Name => new((IntPtr)valueName, -1);

        /// <summary>
        /// the nickname of the value
        /// </summary>
        public UnownedUtf8 Nick => new((IntPtr)valueNick, -1);

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public FlagsValue(uint value, Utf8 name, Utf8 nick)
        {
            this.value = value;
            valueName = (byte*)name.Take();
            valueNick = (byte*)nick.Take();
        }
    }
}
