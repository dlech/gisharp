// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Common user data structure used by managed c-closure/signal callbacks.
    /// </summary>
    /// <param name="Callback">
    /// The user-defined signal callback.
    /// </param>
    public record CClosureData(Delegate Callback);
}
