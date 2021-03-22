// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// Base interface for all GType interfaces
    /// </summary>
    /// <remarks>
    /// Non-classed prerequisites (i.e. interfaces) are indicated in the usual
    /// way using inheritance. Classed prerequisites (there should only be one)
    /// are passed as the generic type parameter.
    /// </remarks>
    /// <example>
    /// This shows the declaration of the GNetworkMonitor interface. It has
    /// prerequisites of GInitable and GObject.
    /// <code>
    ///     [GType("GNetworkMonitor", IsProxyForUnmanagedType = true)]
    ///     [GTypeStruct(typeof(NetworkMonitorInterface))]
    ///     public interface INetworkMonitor : IInitable, GInterface&lt;Object&gt;
    ///     {
    ///         ...
    ///     }
    /// </code>
    /// </example>
    public interface GInterface<T> : IOpaque, IDisposable where T : Object
    {
        /// <summary>
        /// Casts the interface to its prerequisite class type.
        /// </summary>
        public sealed T AsObject() => (T)this;
    }
}
