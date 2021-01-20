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
        /// See <see cref="Lib.GObject.SignalFlags.RunFirst"/>
        /// </summary>
        First,
        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.RunLast"/>
        /// </summary>
        Last,
        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.RunCleanup"/>
        /// </summary>
        Cleanup,
    }
}
