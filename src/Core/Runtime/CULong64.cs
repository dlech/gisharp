// SPDX-License-Identifier: MIT
// Copyright (c) 2019 David Lechner <david@lechnology.com>

﻿
using System;

namespace GISharp.Runtime
{
    // platform-specific implementation
    // there should be no public members in this file!
    partial struct CULong
    {
        const ulong minValue = ulong.MinValue;

        const ulong maxValue = ulong.MaxValue;

        readonly ulong value;

        CULong(ulong value)
        {
            this.value = value;
        }
    }
}
