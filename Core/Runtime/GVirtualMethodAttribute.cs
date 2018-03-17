using System;

namespace GISharp.Runtime
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class GVirtualMethodAttribute : Attribute
    {
        /// <summary>
        /// The unmanaged delegate type associated with this virtual method
        /// </summary>
        public Type DelegateType { get; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="delegateType">
        /// The unmanaged delegate type associated with this virtual method
        /// </param>
        public GVirtualMethodAttribute(Type delegateType)
        {
            DelegateType = delegateType ?? throw new ArgumentNullException(nameof(delegateType));
        }
    }
}
