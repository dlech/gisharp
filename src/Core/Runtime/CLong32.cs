// SPDX-License-Identifier: MIT
// Copyright (c) 2019 David Lechner <david@lechnology.com>

﻿using System;

namespace GISharp.Runtime
{
    // platform-specific implementation
    // there should be no public members in this file!
    partial struct CLong
    {
        const int minValue = int.MinValue;

        const int maxValue = int.MaxValue;

        readonly int value;

        CLong(int value)
        {
            this.value = value;
        }
    }
}
