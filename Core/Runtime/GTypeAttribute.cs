using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is applied to types that need to interop with unmanaged
    /// glib code.
    /// </summary>
    /// <remarks>
    /// If <see cref="IsWrappedUnmanagedType"/> is true, then the type wraps an
    /// unmanaged type. Otherwise, the type will be registered with the GObject
    /// type system so that it can be used in unmanged code.
    /// </remarks>
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
    public sealed class GTypeAttribute : Attribute
    {
        /// <summary>
        /// The type name that is used in unmanged code.
        /// </summary>
        /// <remarks>
        /// If specified, this name will be used as the GType name. Otherwise
        /// a name will be generated from the fully qualified type name. If
        /// binding an unmanged type, this must be set to match the existing
        /// GType name.
        /// </remarks>
        public string Name { get; private set; }

        /// <summary>
        /// Indicates if the type can be registered with the GObject type system.
        /// </summary>
        /// <remarks>
        /// If you are creating a new type in managed code, this should be set
        /// to <c>true</c> (default). If you are binding a type implemented in
        /// unmanged code, then this should be set to false.
        /// </remarks>
        public bool IsWrappedUnmanagedType { get; set; }

        public GTypeAttribute (string name = null)
        {
            Name = name;
        }
    }
}
