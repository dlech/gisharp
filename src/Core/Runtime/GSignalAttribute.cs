// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

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
        /// Specifies the stage of a signal emission.
        /// </summary>
        public EmissionStage When { get; init; }

        /// <summary>
        /// Signals being emitted for an object while currently being in emission
        /// for this very object will not be emitted recursively, but instead cause
        /// the first emission to be restarted.
        /// </summary>
        public bool IsNoRecurse { get; init; }

        /// <summary>
        /// This signal supports "::detail" appendices to the signal name upon
        /// handler connections and emissions.
        /// </summary>
        public bool IsDetailed { get; init; }

        /// <summary>
        /// Action signals are signals that may freely be emitted on alive objects
        /// from user code via g_signal_emit() and friends, without the need of
        /// being embedded into extra code that performs pre or post emission
        /// adjustments on the object. They can also be thought of as object
        /// methods which can be called generically by third-party code.
        /// </summary>
        public bool IsAction { get; init; }

        /// <summary>
        /// No emissions hooks are supported for this signal.
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
