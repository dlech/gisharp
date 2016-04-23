using System;

namespace GISharp.GObject
{
    /// <summary>
    /// This structure is used to provide the type system with the information
    /// required to initialize and destruct (finalize) a type's class and
    /// its instances.
    /// </summary>
    /// <remarks>
    /// The initialized structure is passed to the g_type_register_static() function
    /// (or is copied into the provided #GTypeInfo structure in the
    /// g_type_plugin_complete_type_info()). The type system will perform a deep
    /// copy of this structure, so its memory does not need to be persistent
    /// across invocation of g_type_register_static().
    /// </remarks>
    struct TypeInfo
    {
        /// <summary>
        /// Size of the class structure (required for interface, classed and instantiatable types)
        /// </summary>
        public ushort ClassSize;

        /// <summary>
        /// Location of the base initialization function (optional)
        /// </summary>
        public NativeBaseInitFunc BaseInit;

        /// <summary>
        /// Location of the base finalization function (optional)
        /// </summary>
        public NativeBaseFinalizeFunc BaseFinalize;

        /// <summary>
        /// Location of the class initialization function for
        ///  classed and instantiatable types. Location of the default vtable
        ///  inititalization function for interface types. (optional) This function
        ///  is used both to fill in virtual functions in the class or default vtable,
        ///  and to do type-specific setup such as registering signals and object
        ///  properties.
        /// </summary>
        public NativeClassInitFunc ClassInit;

        /// <summary>
        /// Location of the class finalization function for
        ///  classed and instantiatable types. Location of the default vtable
        ///  finalization function for interface types. (optional)
        /// </summary>
        public NativeClassFinalizeFunc ClassFinalize;

        /// <summary>
        /// User-supplied data passed to the class init/finalize functions
        /// </summary>
        public IntPtr ClassData;

        /// <summary>
        /// Size of the instance (object) structure (required for instantiatable types only)
        /// </summary>
        public ushort InstanceSize;

        /// <summary>
        /// Prior to GLib 2.10, it specified the number of pre-allocated (cached) instances to reserve memory for (0 indicates no caching). Since GLib 2.10, it is ignored, since instances are allocated with the [slice allocator][glib-Memory-Slices] now.
        /// </summary>
        public ushort NPreallocs;

        /// <summary>
        /// Location of the instance initialization function (optional, for instantiatable types only)
        /// </summary>
        public NativeInstanceInitFunc InstanceInit;

        /// <summary>
        /// A #GTypeValueTable function table for generic handling of GValues
        ///  of this type (usually only useful for fundamental types)
        /// </summary>
        public TypeValueTable ValueTable;
    }
}
