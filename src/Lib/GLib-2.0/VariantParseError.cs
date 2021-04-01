// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GLib
{
    partial class VariantParseErrorDomain
    {
        static partial void CheckPrintContextArgs(Error error, UnownedUtf8 sourceStr)
        {
            if (error.Domain != Quark) {
                throw new ArgumentException("Requires VariantParseError", nameof(error));
            }
        }
    }
}
