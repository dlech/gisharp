// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Runtime
{
    // work around compiler bug: https://github.com/dotnet/roslyn/issues/44571
    // FIXME: remove this when we get Roslyn 3.9 / dotnet 5.0.200
#pragma warning disable CS1572
#pragma warning disable CS1573
#pragma warning disable CS1591
    /// <summary>
    /// Common user data structure used by managed c-closure/signal callbacks.
    /// </summary>
    /// <param name="Callback">
    /// The user-defined signal callback.
    /// </param>
    public record CClosureData(Delegate Callback);
#pragma warning restore CS1591
#pragma warning restore CS1573
#pragma warning restore CS1572
}
