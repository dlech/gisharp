using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// An opaque structure used as the base of all interface types.
    /// </summary>
    public abstract class TypeInterface : TypeClass
    {
        static readonly IntPtr gInstanceTypeOffset = Marshal.OffsetOf<Struct> (nameof (Struct.GInstanceType));

        protected new struct Struct
        {
            #pragma warning disable CS0649
            public TypeClass.Struct TypeClass;
            public GType GInstanceType;
            #pragma warning restore CS0649
        }

        public GType GInstanceType => Marshal.PtrToStructure<GType>(Handle + (int)gInstanceTypeOffset);

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected TypeInterface(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        static void InterfaceInit(IntPtr gIface, IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                var types = (Tuple<Type, Type>)gcHandle.Target;
                var interfaceType = types.Item1;
                var instanceType = types.Item2;
                var map = instanceType.GetInterfaceMap(interfaceType);

                for (var i = 0; i < map.InterfaceMethods.Length; i++) {
                    var ifaceMethod = map.InterfaceMethods[i];
                    var instanceMethod = map.TargetMethods[i];

                    var attr = ifaceMethod.GetCustomAttribute<GVirtualMethodAttribute>();
                    if (attr == null) {
                        continue;
                    }

                    InstallVirtualMethodOverload(gIface, attr.DelegateType, instanceMethod);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void InterfaceFinalize(IntPtr gIface, IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        internal static InterfaceInfo CreateInterfaceInfo(Type interfaceType, Type instanceType)
        {
            var types = new Tuple<Type, Type> (interfaceType, instanceType);

            var ret = new InterfaceInfo {
                InterfaceInit = InterfaceInit,
                InterfaceFinalize = InterfaceFinalize,
                InterfaceData = (IntPtr)GCHandle.Alloc(types),
            };

            return ret;
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

        ///// <summary>
        ///// Returns the #GTypePlugin structure for the dynamic interface
        ///// @interface_type which has been added to @instance_type, or %NULL
        ///// if @interface_type has not been added to @instance_type or does
        ///// not have a #GTypePlugin structure. See g_type_add_interface_dynamic().
        ///// </summary>
        ///// <param name="instanceType">
        ///// #GType of an instantiatable type
        ///// </param>
        ///// <param name="interfaceType">
        ///// #GType of an interface type
        ///// </param>
        ///// <returns>
        ///// the #GTypePlugin for the dynamic
        /////     interface @interface_type of @instance_type
        ///// </returns>
        //public static GISharp.Lib.GObject.TypePlugin GetPlugin (GType instanceType, GType interfaceType)
        //{
        //    var ret_ = g_type_interface_get_plugin (instanceType, interfaceType);
        //    var ret = default(GISharp.Lib.GObject.TypePlugin);
        //    throw new System.NotImplementedException ();
        //    return ret;
        //}

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
        static extern unsafe IntPtr g_type_interface_prerequisites(
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType interfaceType,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
            uint* nPrerequisites);

        /// <summary>
        /// Gets the prerequisites of an interfaces type.
        /// </summary>
        /// <param name="interfaceType">
        /// an interface type
        /// </param>
        /// <returns>
        /// an array of <see cref="GType"/> containing
        /// the prerequisites of <paramref name="interfaceType"/>
        /// </returns>
        [Since ("2.2")]
        public static unsafe IArray<GType> GetPrerequisites(GType interfaceType)
        {
            uint nPrerequisites_;
            var ret_ = g_type_interface_prerequisites(interfaceType, &nPrerequisites_);
            var ret = CArray.GetInstance<GType>(ret_, (int)nPrerequisites_, Transfer.Full);
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
    }

    class DefaultTypeInterface : TypeInterface
    {
        static IntPtr New (GType type) => g_type_default_interface_ref (type);

        public DefaultTypeInterface(GType type) : base (New (type), Transfer.Full)
        {
        }

        protected override void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                g_type_default_interface_unref (Handle);
            }
            base.Dispose (disposing);
        }

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
