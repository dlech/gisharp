// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019,2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;

namespace GISharp.Lib.GObject
{
    unsafe partial struct SignalInvocationHint
    {
        /// <summary>
        /// The signal id of the signal invoking the callback.
        /// </summary>
        public uint SignalId => signalId;

        /// <summary>
        /// The detail passed on for this emission.
        /// </summary>
        public Quark Detail => detail;

        /// <summary>
        /// The stage the signal emission is currently in, this
        /// field will contain one of <see cref="SignalFlags.RunFirst"/>,
        /// <see cref="SignalFlags.RunLast"/> or <see cref="SignalFlags.RunCleanup"/>.
        /// </summary>
        public SignalFlags RunType => runType;
    }
}
