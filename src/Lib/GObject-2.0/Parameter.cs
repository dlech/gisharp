// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial struct Parameter
    {
        internal Parameter(byte* name, Value value)
        {
            this.name = name;
            this.value = value;
        }

        internal void Free()
        {
            GMarshal.Free((IntPtr)name);
            value.Unset();
        }
    }
}
