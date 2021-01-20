// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using System;
using System.Runtime.CompilerServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Runtime
{
    /// <summary>
    /// Class for wiring GSignals to C# events.
    /// </summary>
    public class GSignalManager<T> where T : Delegate
    {
        readonly ConditionalWeakTable<T, SignalHandler> notifiedHandlers = new();
        readonly Utf8 signalName;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public GSignalManager(string signalName, GType type)
        {
            this.signalName = signalName;
            var notifySignalId = Signal.TryLookup(this.signalName, type);
            if (notifySignalId == 0) {
                throw new ArgumentException("could not find matching signal");
            }
        }

        /// <summary>
        /// Connects an event handler to a GObject signal. Use this as the
        /// add accessor of an event implementation.
        /// </summary>
        public void Add(Object obj, T handler)
        {
            var signalHandler = obj.Connect(signalName, handler);
            try {
                notifiedHandlers.Add(handler, signalHandler);
            }
            catch {
                signalHandler.Disconnect();
                throw;
            }
        }

        /// <summary>
        /// Disconnects an event handler from a GObject signal. Use this as the
        /// remove accessor of an event implementation.
        /// </summary>
        public void Remove(T handler)
        {
            if (notifiedHandlers.TryGetValue(handler, out var signalHandler)) {
                signalHandler.Disconnect();
                notifiedHandlers.Remove(handler);
            }
        }
    }
}
