using System;
using System.Linq;

using GISharp.Lib.GObject;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Runtime
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
        public sealed T AsObject() => (T)this;
    }
}
