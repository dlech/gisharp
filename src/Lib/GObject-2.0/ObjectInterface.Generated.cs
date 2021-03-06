// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ObjectInterface.xmldoc" path="declaration/member[@name='ObjectInterface']/*" />
    public static unsafe partial class ObjectInterface
    {
        /// <summary>
        /// Find the #GParamSpec with the given name for an
        /// interface. Generally, the interface vtable passed in as @g_iface
        /// will be the default vtable from g_type_default_interface_ref(), or,
        /// if you know the interface has already been loaded,
        /// g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the
        ///  interface, or the default vtable for the interface
        /// </param>
        /// <param name="propertyName">
        /// name of a property to look up.
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property of the
        ///          interface with the name @property_name, or %NULL if no
        ///          such property exists.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_object_interface_find_property(
        /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* propertyName);
        static partial void CheckFindPropertyArgs(this GISharp.Lib.GObject.TypeInterface gIface, GISharp.Runtime.UnownedUtf8 propertyName);

        /// <include file="ObjectInterface.xmldoc" path="declaration/member[@name='ObjectInterface.FindProperty(GISharp.Lib.GObject.TypeInterface,GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.4")]
        public static GISharp.Lib.GObject.ParamSpec? FindProperty(this GISharp.Lib.GObject.TypeInterface gIface, GISharp.Runtime.UnownedUtf8 propertyName)
        {
            CheckFindPropertyArgs(gIface, propertyName);
            var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)gIface.UnsafeHandle;
            var propertyName_ = (byte*)propertyName.UnsafeHandle;
            var ret_ = g_object_interface_find_property(gIface_,propertyName_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
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
        /// <para>
        /// This function is meant to be called from the interface's default
        /// vtable initialization function (the @class_init member of
        /// #GTypeInfo.) It must not be called after after @class_init has
        /// been called for any object types implementing this interface.
        /// </para>
        /// <para>
        /// If @pspec is a floating reference, it will be consumed.
        /// </para>
        /// </remarks>
        /// <param name="gIface">
        /// any interface vtable for the
        ///    interface, or the default
        ///  vtable for the interface.
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_object_interface_install_property(
        /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface,
        /* <type name="ParamSpec" type="GParamSpec*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        static partial void CheckInstallPropertyArgs(this GISharp.Lib.GObject.TypeInterface gIface, GISharp.Lib.GObject.ParamSpec pspec);

        /// <include file="ObjectInterface.xmldoc" path="declaration/member[@name='ObjectInterface.InstallProperty(GISharp.Lib.GObject.TypeInterface,GISharp.Lib.GObject.ParamSpec)']/*" />
        [GISharp.Runtime.SinceAttribute("2.4")]
        public static void InstallProperty(this GISharp.Lib.GObject.TypeInterface gIface, GISharp.Lib.GObject.ParamSpec pspec)
        {
            CheckInstallPropertyArgs(gIface, pspec);
            var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)gIface.UnsafeHandle;
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)pspec.UnsafeHandle;
            g_object_interface_install_property(gIface_, pspec_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Lists the properties of an interface.Generally, the interface
        /// vtable passed in as @g_iface will be the default vtable from
        /// g_type_default_interface_ref(), or, if you know the interface has
        /// already been loaded, g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the
        ///  interface, or the default vtable for the interface
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
        [GISharp.Runtime.SinceAttribute("2.4")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="GParamSpec**" is-pointer="1">
*   <type name="ParamSpec" type="GParamSpec*" is-pointer="1" />
* </array> */
        /* transfer-ownership:container direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct** g_object_interface_list_properties(
        /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface,
        /* <type name="guint" type="guint*" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        uint* nPropertiesP);
        static partial void CheckListPropertiesArgs(this GISharp.Lib.GObject.TypeInterface gIface);

        /// <include file="ObjectInterface.xmldoc" path="declaration/member[@name='ObjectInterface.ListProperties(GISharp.Lib.GObject.TypeInterface)']/*" />
        [GISharp.Runtime.SinceAttribute("2.4")]
        public static GISharp.Runtime.WeakCPtrArray<GISharp.Lib.GObject.ParamSpec> ListProperties(this GISharp.Lib.GObject.TypeInterface gIface)
        {
            CheckListPropertiesArgs(gIface);
            var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)gIface.UnsafeHandle;
            uint nPropertiesP_;
            var ret_ = g_object_interface_list_properties(gIface_,&nPropertiesP_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Runtime.WeakCPtrArray<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)ret_, (int)nPropertiesP_, GISharp.Runtime.Transfer.Container);
            return ret;
        }
    }
}