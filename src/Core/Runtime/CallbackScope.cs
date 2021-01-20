// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

﻿
namespace GISharp.Runtime
{
    /// <summary>
    /// Callback scope indicates how long user data must be kept alive.
    /// </summary>
    public enum CallbackScope
    {
        /// <summary>
        /// The callback scope is not known.
        /// </summary>
        Unknown,
        /// <summary>
        /// Only valid for the duration of the call.
        /// </summary>
        /// <remarks>>
        /// Can be called multiple times during the call.
        /// </remarks>
        Call,
        /// <summary>
        /// Only valid for the duration of the first callback invocation. Can only be called once.
        /// </summary>
        Async,
        /// <summary>
        /// valid until the GDestroyNotify argument is called. Can be called multiple times before the GDestroyNotify is called.
        /// </summary>
        Notified,
    }
}
