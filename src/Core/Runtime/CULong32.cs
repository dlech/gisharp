// SPDX-License-Identifier: MIT
// Copyright (c) 2019 David Lechner <david@lechnology.com>

﻿using System;

namespace GISharp.Runtime
{
    // platform-specific implementation
    // there should be no public members in this file!
    partial struct CULong
    {
        const uint minValue = uint.MinValue;

        const uint maxValue = uint.MaxValue;

        readonly uint value;

        CULong(uint value)
        {
            this.value = value;
        }
    }
}
