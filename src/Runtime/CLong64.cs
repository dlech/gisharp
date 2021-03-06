// SPDX-License-Identifier: MIT
// Copyright (c) 2019 David Lechner <david@lechnology.com>

namespace GISharp.Runtime
{
    // platform-specific implementation
    // there should be no public members in this file!
    partial struct CLong
    {
        const long minValue = long.MinValue;

        const long maxValue = long.MaxValue;

        readonly long value;

        CLong(long value)
        {
            this.value = value;
        }
    }
}
