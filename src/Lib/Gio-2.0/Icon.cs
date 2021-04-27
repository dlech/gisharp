// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.Gio
{
    partial interface IIcon : IEquatable<IIcon>
    {
        bool IEquatable<IIcon>.Equals(IIcon? icon) => Icon.Equals(this, icon);
    }
}
