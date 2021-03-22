// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2019 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial struct SignalQuery
    {
        /// <summary>
        /// The signal id of the signal being queried.
        /// </summary>
        public uint SignalId => signalId;

        /// <summary>
        /// The signal name.
        /// </summary>
        public UnownedUtf8 SignalName => new((IntPtr)signalName, -1);

        /// <summary>
        /// The interface/instance type that this signal can be emitted for.
        /// </summary>
        public GType IType => itype;

        /// <summary>
        /// The signal flags as passed in to g_signal_new().
        /// </summary>
        public SignalFlags SignalFlags => signalFlags;

        /// <summary>
        /// The signal flags as passed in to g_signal_new().
        /// </summary>
        public GType ReturnType => returnType;

        /// <summary>
        /// The individual parameter types for user callbacks.
        /// </summary>
        /// <remarks>
        /// note that the effective callback signature is:
        /// <code>
        /// ReturnType callback (IntPtr data1, [ParamTypes paramNames,] IntPtr data2);
        /// </code>
        /// </remarks>
        public ReadOnlySpan<GType> ParamTypes => new(paramTypes, (int)nParams);
    }
}
