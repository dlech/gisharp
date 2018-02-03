
using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
{
    public class ObjectInterface : TypeInterface
    {
        public override Type StructType => throw new NotImplementedException();

        public ObjectInterface(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Find the #GParamSpec with the given name for an
        /// interface. Generally, the interface vtable passed in as @g_iface
        /// will be the default vtable from g_type_default_interface_ref(), or,
        /// if you know the interface has already been loaded,
        /// g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <param name="propertyName">
        /// name of a property to lookup.
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property of the
        ///          interface with the name @property_name, or %NULL if no
        ///          such property exists.
        /// </returns>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_interface_find_property(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName);

        /// <summary>
        /// Find the <see cref="ParamSpec"/> with the given name for an
        /// interface.
        /// </summary>
        /// <param name="propertyName">
        /// name of a property to lookup.
        /// </param>
        /// <returns>
        /// the <see cref="ParamSpec"/> for the property of the
        /// interface with the name <paramref name="propertyName"/>, or
        /// <c>null</c> if no such property exists.
        /// </returns>
        [Since("2.4")]
        public ParamSpec FindProperty(string propertyName)
        {
            AssertNotDisposed();
            if(propertyName == null) {
                throw new ArgumentNullException(nameof(propertyName));
            }
            var propertyName_ = GMarshal.StringToUtf8Ptr(propertyName);
            var ret_ = g_object_interface_find_property(handle, propertyName_);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
            GMarshal.Free(propertyName_);
            return ret;
        }

        /// <summary>
        /// Add a property to an interface; this is only useful for interfaces
        /// that are added to GObject-derived types. Adding a property to an
        /// interface forces all objects classes with that interface to have a
        /// compatible property. The compatible property could be a newly
        /// created #GParamSpec, but normally
        /// g_object_class_override_property() will be used so that the object
        /// class only needs to provide an implementation and inherits the
        /// property description, default value, bounds, and so forth from the
        /// interface property.
        /// </summary>
        /// <remarks>
        /// This function is meant to be called from the interface's default
        /// vtable initialization function(the @class_init member of
        /// #GTypeInfo.) It must not be called after after @class_init has
        /// been called for any object types implementing this interface.
        /// </remarks>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface.
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_interface_install_property(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Add a property to an interface; this is only useful for interfaces
        /// that are added to GObject-derived types. Adding a property to an
        /// interface forces all objects classes with that interface to have a
        /// compatible property. The compatible property could be a newly
        /// created <see cref="ParamSpec"/>, but normally
        /// <see cref="ObjectClass.OverrideProperty"/> will be used so that the object
        /// class only needs to provide an implementation and inherits the
        /// property description, default value, bounds, and so forth from the
        /// interface property.
        /// </summary>
        /// <remarks>
        /// This function is meant to be called from the interface's default
        /// vtable initialization function(the @class_init member of
        /// <see cref="TypeInfo"/>.) It must not be called after after @class_init has
        /// been called for any object types implementing this interface.
        /// </remarks>
        /// <param name="pspec">
        /// the<see cref="ParamSpec"/> for the new property
        /// </param>
        [Since("2.4")]
        public void InstallProperty(ParamSpec pspec)
        {
            AssertNotDisposed();
            if(pspec == null) {
                throw new ArgumentNullException(nameof(pspec));
            }
            g_object_interface_install_property(handle, pspec.Handle);
            GC.KeepAlive(pspec);
        }

        /// <summary>
        /// Lists the properties of an interface.Generally, the interface
        /// vtable passed in as @g_iface will be the default vtable from
        /// g_type_default_interface_ref(), or, if you know the interface has
        /// already been loaded, g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <param name="nPropertiesP">
        /// location to store number of properties returned.
        /// </param>
        /// <returns>
        /// a
        ///          pointer to an array of pointers to #GParamSpec
        ///          structures. The paramspecs are owned by GLib, but the
        ///          array should be freed with g_free() when you are done with
        ///          it.
        /// </returns>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GParamSpec**">
          <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
          </array> */
        /* transfer-ownership:container */
        static extern IntPtr g_object_interface_list_properties(
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out uint nPropertiesP);

        /// <summary>
        /// Lists the properties of an interface.
        /// </summary>
        /// <returns>
        /// an array of <see cref="ParamSpec"/> structures.
        /// </returns>
        [Since("2.4")]
        public ParamSpec[] ListProperties()
        {
            AssertNotDisposed();
            var ret_ = g_object_interface_list_properties(handle, out var nProperties_);
            var ret = GMarshal.PtrToOpaqueCArray<ParamSpec>(ret_, (int)nProperties_, true);
            return ret;
        }

        public override InterfaceInfo CreateInterfaceInfo(Type instanceType)
        {
            throw new NotImplementedException();
        }
    }
}