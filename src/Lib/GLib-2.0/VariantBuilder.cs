// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>



using System;

namespace GISharp.Lib.GLib
{
    partial class VariantBuilder
    {
        static partial void CheckNewArgs(VariantType type)
        {
            if (type is null)
            {
                return;
            }
            if (!type.IsContainer)
            {
                const string message = "Must be a variant container type";
                throw new ArgumentException(message, nameof(type));
            }
        }
    }
}
