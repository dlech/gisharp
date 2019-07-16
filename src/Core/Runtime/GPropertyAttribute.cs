using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// GObject property attribute.
    /// </summary>
    /// <remarks>
    /// This is used to mark properties for registration with the GObject type
    /// system. If <see cref="Name"/> is specified, it will be used for the
    /// property name, otherwise a name will be automatically generated.
    /// When wrapping unmanged types, the <see cref="Name"/> value must be
    /// set to the actual value assigned in unmanaged code.
    /// </remarks>
    [AttributeUsage (AttributeTargets.Property, Inherited = true)]
    public sealed class GPropertyAttribute : Attribute
    {
        /// <summary>
        /// The name of the property that will be registered with the GObject type system.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Property construction flags
        /// </summary>
        public GPropertyConstruct Construct { get; set; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public GPropertyAttribute(string? name = null)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Enum used for <see cref="GPropertyAttribute.Construct"/>.
    /// </summary>
    public enum GPropertyConstruct
    {
        /// <summary>
        /// Indicates that a property cannot be set via the GType constructor
        /// </summary>
        No,

        /// <summary>
        /// Indicates that a property can be set via the GType constructor
        /// </summary>
        Yes,

        /// <summary>
        /// Indicates that a property <b>only</b> can be set via the GType constructor
        /// </summary>
        Only
    }
}
