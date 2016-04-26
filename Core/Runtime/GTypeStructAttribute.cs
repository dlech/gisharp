using System;

namespace GISharp.Runtime
{
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Interface, Inherited = true)]
    public class GTypeStructAttribute : Attribute
    {
        /// <summary>
        /// The glib type struct that is used to declare this class in unmanaged
        /// code.
        /// </summary>
        /// <remarks>
        /// This type must be a derivitave of <see cref="GISharp.GObject.TypeClass"/>
        /// for objects or <see cref="GISharp.GObject.TypeInterface"/> for interfaces.
        /// </remarks>
        public Type GTypeStruct { get; private set; }

        public GTypeStructAttribute (Type gtypeStruct)
        {
            GTypeStruct = gtypeStruct;
        }
    }
}
