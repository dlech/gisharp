using System;

namespace GISharp.Core
{
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class GTypeAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the GType name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the type can be registered with the GObject type system.
        /// </summary>
        /// <remarks>
        /// If you are creating a new type in managed code, this should be set
        /// to <c>true</c> (default). If you are binding a type implemented in
        /// unmanged code, then this should be set to false.
        public bool Register { get; set; } = true;
    }
}
