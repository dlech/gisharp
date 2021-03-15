// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface']/*" />
    public sealed unsafe partial class TypeInterface : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GType']/*" />
            private readonly GISharp.Lib.GObject.GType GType;

            /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='UnmanagedStruct.GInstanceType']/*" />
            private readonly GISharp.Lib.GObject.GType GInstanceType;
#pragma warning restore CS0169, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public TypeInterface(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_type_interface_add_prerequisite(
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType interfaceType,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType prerequisiteType);
        static partial void CheckAddPrerequisiteArgs(GISharp.Lib.GObject.GType interfaceType, GISharp.Lib.GObject.GType prerequisiteType);

        /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface.AddPrerequisite(GISharp.Lib.GObject.GType,GISharp.Lib.GObject.GType)']/*" />
        public static void AddPrerequisite(GISharp.Lib.GObject.GType interfaceType, GISharp.Lib.GObject.GType prerequisiteType)
        {
            CheckAddPrerequisiteArgs(interfaceType, prerequisiteType);
            var interfaceType_ = (GISharp.Lib.GObject.GType)interfaceType;
            var prerequisiteType_ = (GISharp.Lib.GObject.GType)prerequisiteType;
            g_type_interface_add_prerequisite(interfaceType_, prerequisiteType_);
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypePlugin" type="GTypePlugin*" managed-name="TypePlugin" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.TypePlugin.UnmanagedStruct* g_type_interface_get_plugin(
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType instanceType,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType interfaceType);
        static partial void CheckGetPluginArgs(GISharp.Lib.GObject.GType instanceType, GISharp.Lib.GObject.GType interfaceType);

        /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface.GetPlugin(GISharp.Lib.GObject.GType,GISharp.Lib.GObject.GType)']/*" />
        public static GISharp.Lib.GObject.ITypePlugin GetPlugin(GISharp.Lib.GObject.GType instanceType, GISharp.Lib.GObject.GType interfaceType)
        {
            CheckGetPluginArgs(instanceType, interfaceType);
            var instanceType_ = (GISharp.Lib.GObject.GType)instanceType;
            var interfaceType_ = (GISharp.Lib.GObject.GType)interfaceType;
            var ret_ = g_type_interface_get_plugin(instanceType_,interfaceType_);
            var ret = (GISharp.Lib.GObject.ITypePlugin)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* g_type_interface_peek(
        /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.TypeClass.UnmanagedStruct* instanceClass,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType ifaceType);
        static partial void CheckPeekArgs(GISharp.Lib.GObject.TypeClass instanceClass, GISharp.Lib.GObject.GType ifaceType);

        /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface.Peek(GISharp.Lib.GObject.TypeClass,GISharp.Lib.GObject.GType)']/*" />
        public static GISharp.Lib.GObject.TypeInterface Peek(GISharp.Lib.GObject.TypeClass instanceClass, GISharp.Lib.GObject.GType ifaceType)
        {
            CheckPeekArgs(instanceClass, ifaceType);
            var instanceClass_ = (GISharp.Lib.GObject.TypeClass.UnmanagedStruct*)instanceClass.UnsafeHandle;
            var ifaceType_ = (GISharp.Lib.GObject.GType)ifaceType;
            var ret_ = g_type_interface_peek(instanceClass_,ifaceType_);
            var ret = GISharp.Lib.GObject.TypeInterface.GetInstance<GISharp.Lib.GObject.TypeInterface>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

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
        [GISharp.Runtime.SinceAttribute("2.2")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GType*" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" />
* </array> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType* g_type_interface_prerequisites(
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType interfaceType,
        /* <type name="guint" type="guint*" managed-name="System.UInt32" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        uint* nPrerequisites);
        static partial void CheckPrerequisitesArgs(GISharp.Lib.GObject.GType interfaceType);

        /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface.Prerequisites(GISharp.Lib.GObject.GType)']/*" />
        [GISharp.Runtime.SinceAttribute("2.2")]
        public static GISharp.Runtime.CArray<GISharp.Lib.GObject.GType> Prerequisites(GISharp.Lib.GObject.GType interfaceType)
        {
            CheckPrerequisitesArgs(interfaceType);
            var interfaceType_ = (GISharp.Lib.GObject.GType)interfaceType;
            uint nPrerequisites_;
            var ret_ = g_type_interface_prerequisites(interfaceType_,&nPrerequisites_);
            var ret = new GISharp.Runtime.CArray<GISharp.Lib.GObject.GType>((System.IntPtr)ret_, (int)nPrerequisites_, GISharp.Runtime.Transfer.Full);
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
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* g_type_interface_peek_parent(
        /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface);
        partial void CheckPeekParentArgs();

        /// <include file="TypeInterface.xmldoc" path="declaration/member[@name='TypeInterface.PeekParent()']/*" />
        public GISharp.Lib.GObject.TypeInterface PeekParent()
        {
            CheckPeekParentArgs();
            var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_type_interface_peek_parent(gIface_);
            var ret = GISharp.Lib.GObject.TypeInterface.GetInstance<GISharp.Lib.GObject.TypeInterface>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }
    }
}