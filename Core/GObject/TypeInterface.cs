using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all interface types.
    /// </summary>
    public abstract class TypeInterface : Opaque
    {
        public abstract class SafeTypeInterfaceHandle : SafeOpaqueHandle
        {
            internal protected struct TypeInterfaceStruct
            {
                #pragma warning disable CS0649
                public GType GType;
                public GType GInstanceType;
                #pragma warning restore CS0649
            }

            public GType GType {
                get {
                    if (IsInvalid) {
                        throw new ObjectDisposedException (null);
                    }
                    var ret = Marshal.PtrToStructure<GType> (handle);
                    return ret;
                }
            }

            public GType GInstanceType {
                get {
                    if (IsInvalid) {
                        throw new ObjectDisposedException (null);
                    }
                    var offset = Marshal.OffsetOf<TypeInterfaceStruct> (nameof (TypeInterfaceStruct.GInstanceType));
                    var ret = Marshal.PtrToStructure<GType> (handle + (int)offset);
                    return ret;
                }
            }
        }

        public sealed class SafeTypeDefaultInterfaceHandle : SafeTypeInterfaceHandle
        {
            public SafeTypeDefaultInterfaceHandle (GType type)
            {
                if (!type.IsInterface) {
                    var msg = "Type must be an interface";
                    throw new ArgumentException (msg, nameof (type));
                }
                var ret = g_type_default_interface_ref (type);
                SetHandle (ret);
            }

            protected override bool ReleaseHandle ()
            {
                try {
                    g_type_default_interface_unref (handle);
                    return true;
                } catch {
                    return false;
                }
            }
        }

        public new SafeTypeInterfaceHandle Handle {
            get {
                return (SafeTypeInterfaceHandle)base.Handle;
            }
        }

        public GType GType {
            get {
                return Handle.GType;
            }
        }
        public GType GInstanceType {
            get {
                return Handle.GInstanceType;
            }
        }

        public abstract Type StructType { get; }

        public abstract InterfaceInfo CreateInterfaceInfo (Type instanceType);

        protected TypeInterface (SafeTypeInterfaceHandle handle) : base (handle)
        {
        }

        public static TypeInterface GetDefault (GType type)
        {
            var ret_ = new SafeTypeDefaultInterfaceHandle (type);
            var ret = Activator.CreateInstance (type.GetGTypeStruct (), ret_);
            return (TypeInterface)ret;
        }

        /// <summary>
        /// Adds @prerequisite_type to the list of prerequisites of @interface_type.
        /// This means that any type implementing @interface_type must also implement
        /// @prerequisite_type. Prerequisites can be thought of as an alternative to
        /// interface derivation (which GType doesn't support). An interface can have
        /// at most one instantiatable prerequisite type.
        /// </summary>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="prerequisiteType">
        /// #GType value of an interface or instantiatable type
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_interface_add_prerequisite (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType prerequisiteType);

        /// <summary>
        /// Adds @prerequisite_type to the list of prerequisites of @interface_type.
        /// This means that any type implementing @interface_type must also implement
        /// @prerequisite_type. Prerequisites can be thought of as an alternative to
        /// interface derivation (which GType doesn't support). An interface can have
        /// at most one instantiatable prerequisite type.
        /// </summary>
        /// <param name="interfaceType">
        /// #GType value of an interface type
        /// </param>
        /// <param name="prerequisiteType">
        /// #GType value of an interface or instantiatable type
        /// </param>
        public static void AddPrerequisite (GType interfaceType, GType prerequisiteType)
        {
            g_type_interface_add_prerequisite (interfaceType, prerequisiteType);
        }

        /// <summary>
        /// Returns the #GTypePlugin structure for the dynamic interface
        /// @interface_type which has been added to @instance_type, or %NULL
        /// if @interface_type has not been added to @instance_type or does
        /// not have a #GTypePlugin structure. See g_type_add_interface_dynamic().
        /// </summary>
        /// <param name="instanceType">
        /// #GType of an instantiatable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType of an interface type
        /// </param>
        /// <returns>
        /// the #GTypePlugin for the dynamic
        ///     interface @interface_type of @instance_type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_interface_get_plugin (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType instanceType,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType);

        /// <summary>
        /// Returns the #GTypePlugin structure for the dynamic interface
        /// @interface_type which has been added to @instance_type, or %NULL
        /// if @interface_type has not been added to @instance_type or does
        /// not have a #GTypePlugin structure. See g_type_add_interface_dynamic().
        /// </summary>
        /// <param name="instanceType">
        /// #GType of an instantiatable type
        /// </param>
        /// <param name="interfaceType">
        /// #GType of an interface type
        /// </param>
        /// <returns>
        /// the #GTypePlugin for the dynamic
        ///     interface @interface_type of @instance_type
        /// </returns>
        //        public static GISharp.GObject.TypePlugin GetPlugin (GType instanceType, GType interfaceType)
        //        {
        //            var ret_ = g_type_interface_get_plugin (instanceType, interfaceType);
        //            var ret = default(GISharp.GObject.TypePlugin);
        //            throw new System.NotImplementedException ();
        //            return ret;
        //        }

        /// <summary>
        /// Returns the #GTypeInterface structure of an interface to which the
        /// passed in class conforms.
        /// </summary>
        /// <param name="instanceClass">
        /// a #GTypeClass structure
        /// </param>
        /// <param name="ifaceType">
        /// an interface ID which this class conforms to
        /// </param>
        /// <returns>
        /// the #GTypeInterface
        ///     structure of @iface_type if implemented by @instance_class, %NULL
        ///     otherwise
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        internal static extern IntPtr g_type_interface_peek (
            /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" /> */
            /* transfer-ownership:none */
            IntPtr instanceClass,
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType ifaceType);

        /// <summary>
        /// Returns the prerequisites of an interfaces type.
        /// </summary>
        /// <param name="interfaceType">
        /// an interface type
        /// </param>
        /// <param name="nPrerequisites">
        /// location to return the number
        ///     of prerequisites, or %NULL
        /// </param>
        /// <returns>
        /// a
        ///     newly-allocated zero-terminated array of #GType containing
        ///     the prerequisites of @interface_type
        /// </returns>
        [Since ("2.2")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*">
            <type name="GType" type="GType" managed-name="GType" />
            </array> */
        /* transfer-ownership:full */
        static extern IntPtr g_type_interface_prerequisites (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            out uint nPrerequisites);

        /// <summary>
        /// Returns the prerequisites of an interfaces type.
        /// </summary>
        /// <param name="interfaceType">
        /// an interface type
        /// </param>
        /// <returns>
        /// a
        ///     newly-allocated zero-terminated array of #GType containing
        ///     the prerequisites of @interface_type
        /// </returns>
        [Since ("2.2")]
        public static GType[] Prerequisites (GType interfaceType)
        {
            uint nPrerequisites_;
            var ret_ = g_type_interface_prerequisites (interfaceType, out nPrerequisites_);
            var ret = GMarshal.PtrToCArray<GType> (ret_, (int)nPrerequisites_, true);
            return ret;
        }

        /// <summary>
        /// Returns the corresponding #GTypeInterface structure of the parent type
        /// of the instance type to which @g_iface belongs. This is useful when
        /// deriving the implementation of an interface from the parent type and
        /// then possibly overriding some methods.
        /// </summary>
        /// <param name="gIface">
        /// a #GTypeInterface structure
        /// </param>
        /// <returns>
        /// the
        ///     corresponding #GTypeInterface structure of the parent type of the
        ///     instance type to which @g_iface belongs, or %NULL if the parent
        ///     type doesn't conform to the interface
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        internal static extern IntPtr g_type_interface_peek_parent (
            /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
            /* transfer-ownership:none */
            IntPtr gIface);

        /// <summary>
        /// If the interface type @g_type is currently in use, returns its
        /// default interface vtable.
        /// </summary>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface, or %NULL if the type is not currently
        ///     in use
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        internal static extern IntPtr g_type_default_interface_peek (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gType);

        /// <summary>
        /// Increments the reference count for the interface type @g_type,
        /// and returns the default interface vtable for the type.
        /// </summary>
        /// <remarks>
        /// If the type is not currently in use, then the default vtable
        /// for the type will be created and initalized by calling
        /// the base interface init and default vtable init functions for
        /// the type (the @base_init and @class_init members of #GTypeInfo).
        /// Calling g_type_default_interface_ref() is useful when you
        /// want to make sure that signals and properties for an interface
        /// have been installed.
        /// </remarks>
        /// <param name="gType">
        /// an interface type
        /// </param>
        /// <returns>
        /// the default
        ///     vtable for the interface; call g_type_default_interface_unref()
        ///     when you are done using the interface.
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_type_default_interface_ref (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType gType);
        
        /// <summary>
        /// Decrements the reference count for the type corresponding to the
        /// interface default vtable @g_iface. If the type is dynamic, then
        /// when no one is using the interface and all references have
        /// been released, the finalize function for the interface's default
        /// vtable (the @class_finalize member of #GTypeInfo) will be called.
        /// </summary>
        /// <param name="gIface">
        /// the default vtable
        ///     structure for a interface, as returned by g_type_default_interface_ref()
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_type_default_interface_unref (
            /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
            /* transfer-ownership:none */
            IntPtr gIface);
    }
}
