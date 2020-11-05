using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is used to decorate events that should be registered
    /// as signals with the GObject type system.
    /// </summary>
    [AttributeUsage(AttributeTargets.Event, Inherited = true)]
    public sealed class GSignalAttribute : Attribute
    {
        /// <summary>
        /// Gets the signal name.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.RunFirst"/>,
        /// <see cref="Lib.GObject.SignalFlags.RunLast"/> and
        /// <see cref="Lib.GObject.SignalFlags.RunCleanup"/>
        /// </summary>
        public EmissionStage When { get; init; }

        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.NoRecurse"/>
        /// </summary>
        public bool IsNoRecurse { get; init; }

        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.Detailed"/>
        /// </summary>
        public bool IsDetailed { get; init; }

        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.Action"/>
        /// </summary>
        public bool IsAction { get; init; }

        /// <summary>
        /// See <see cref="Lib.GObject.SignalFlags.IsNoHooks"/>
        /// </summary>
        public bool IsNoHooks { get; init; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="name">The GSignal name.</param>
        /// <remarks>
        /// <paramref name="name"/> must exactly match the signal name of wrapped
        /// objects. New signals an use <c>null</c> in which case a name will
        /// be derived from the event name.
        /// </remarks>
        public GSignalAttribute(string? name = null)
        {
            Name = name;
        }
    }
}
