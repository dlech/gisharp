using System;
using System.Linq;

using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute to indicate a classed prerequisite for an interface type.
    /// </summary>
    /// <remarks>
    /// Non-classed prerequisites (i.e. interfaces) are indicated in the usual
    /// way using inheritance.
    /// </remarks>
    /// <example>
    /// This shows the declaration of the GNetworkMonitor interface. It has
    /// prerequisites of GInitable and GObject.
    /// <code>
    ///     [GType ("GNetworkMonitor", IsWrappedUnmanagedType = true)]
    ///     [GTypeStruct (typeof(NetworkMonitorInterface))]
    ///     [GTypePrerequisite (typeof(GISharp.GObject.Object))]
    ///     public interface INetworkMonitor : IInitable
    ///     {
    ///         ...
    ///     }
    /// </code>
    /// </example>
    [AttributeUsage (AttributeTargets.Interface)]
    public class GTypePrerequisiteAttribute : Attribute
    {
        /// <summary>
        /// Gets the managed type of the prerequisite.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Gets the GType of the prerequisite.
        /// </summary>
        public readonly GType GType;

        /// <summary>
        /// Creates a new attribute instance.
        /// </summary>
        /// <param name="prerequisite">
        /// The type of the prerequisite. Must be an instaniatable GType (e.g.
        /// <see cref="GISharp.GObject.Object" />).
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="prerequisite" /> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="prerequisite" /> is not a GType or it is
        /// not instaniatable.
        /// </exception>
        public GTypePrerequisiteAttribute (Type prerequisite)
        {
            if (prerequisite == null) {
                throw new ArgumentNullException (nameof(prerequisite));
            }

            Type = prerequisite;
            GType = prerequisite.GetGType ();

            if (!GType.IsInstantiatable) {
                var message = "Prerequisite type must be instantiatable";
                throw new ArgumentException (message, nameof(prerequisite));
            }
        }
    }
}
