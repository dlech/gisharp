// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

namespace GISharp.Runtime
{
    /// <summary>
    /// GSignal emissions stages
    /// </summary>
    public enum EmissionStage
    {
        /// <summary>
        /// Invoke the object method handler in the first emission stage.
        /// </summary>
        First,
        /// <summary>
        /// Invoke the object method handler in the third emission stage.
        /// </summary>
        Last,
        /// <summary>
        /// Invoke the object method handler in the last emission stage.
        /// </summary>
        Cleanup,
    }
}
