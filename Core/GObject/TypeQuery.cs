using System;

namespace GISharp.GObject
{
    /// <summary>
    /// A structure holding information for a specific type.
    /// It is filled in by the g_type_query() function.
    /// </summary>
    public struct TypeQuery
    {
        /// <summary>
        /// the #GType value of the type
        /// </summary>
        public GType Type;

        /// <summary>
        /// the name of the type
        /// </summary>
        public IntPtr TypeName;

        /// <summary>
        /// the size of the class structure
        /// </summary>
        public uint ClassSize;

        /// <summary>
        /// the size of the instance structure
        /// </summary>
        public uint InstanceSize;
    }
}
