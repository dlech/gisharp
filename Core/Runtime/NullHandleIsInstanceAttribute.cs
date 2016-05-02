using System;

namespace GISharp.Runtime
{
    /// <summary>
    /// Null handle is instance attribute.
    /// </summary>
    /// <remarks>>
    /// This attribute must be applied to classes where a null handle indicates
    /// a default instance rather than a null object.
    /// </remarks>
    [AttributeUsage (AttributeTargets.Class)]
    public sealed class NullHandleIsInstanceAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullHandleIsInstanceAttribute"/> class.
        /// </summary>
        public NullHandleIsInstanceAttribute()
        {
        }
    }
}

