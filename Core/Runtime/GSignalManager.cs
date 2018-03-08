
using System;
using System.Collections.Concurrent;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Runtime
{
    public class GSignalManager<TEventArgs> where TEventArgs : GSignalEventArgs
    {
        readonly ConcurrentDictionary<EventHandler<TEventArgs>, SignalHandler> notifiedHandlers =
            new ConcurrentDictionary<EventHandler<TEventArgs>, SignalHandler>();
        readonly uint notifySignalId;

        public GSignalManager(string signalName, GType type)
        {
            notifySignalId = Signal.TryLookup(signalName, type);
            if (notifySignalId == 0) {
                throw new ArgumentException("could not find matching signal");
            }
        }

        /// <summary>
        /// Connects an event handler to a GObject signal. Use this as the
        /// add accessor of an event implementation.
        /// </summary>
        public void Add(Object obj, EventHandler<TEventArgs> handler)
        {
            var closure = Closure.CreateFor(obj, handler);
            var signalHandler = obj.Connect(notifySignalId, Quark.Zero, closure);
            if (!notifiedHandlers.TryAdd(handler, signalHandler)) {
                signalHandler.Disconnect();
                throw new InvalidOperationException("delegate is already connected");
            }
        }

        /// <summary>
        /// Disconnects an event handler from a GObject signal. Use this as the
        /// remove accessor of an event implementation.
        /// </summary>
        public void Remove(EventHandler<TEventArgs> handler)
        {
            if (notifiedHandlers.TryRemove(handler, out var signalHandler)) {
                signalHandler.Disconnect();
            }
        }
    }
}
