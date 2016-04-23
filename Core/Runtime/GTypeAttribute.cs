using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// This attribute is applied to types that need to interop with unmanaged
    /// glib code.
    /// </summary>
    /// <remarks>
    /// If <see cref="IsWrappedNativeType"/> is true, then the type wraps an
    /// unmanaged type. Otherwise, the type will be registered with the GObject
    /// type system so that it can be used in unmanged code.
    /// </remarks>
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
    public class GTypeAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the GType name.
        /// </summary>
        /// <remarks>
        /// If specified, this name will be used as the GType name. Otherwise
        /// a name will be generated from the fully qualified type name. If
        /// binding an unmanged type, this must be set to match the existing
        /// GType name.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the type can be registered with the GObject type system.
        /// </summary>
        /// <remarks>
        /// If you are creating a new type in managed code, this should be set
        /// to <c>true</c> (default). If you are binding a type implemented in
        /// unmanged code, then this should be set to false.
        /// </remarks>
        public bool IsWrappedNativeType { get; set; }
    }
}
