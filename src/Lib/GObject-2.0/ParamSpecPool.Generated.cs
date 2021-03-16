// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool']/*" />
    public sealed unsafe partial class ParamSpecPool : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ParamSpecPool(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GParamSpecPool.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If @type_prefixing is %TRUE, lookups in the newly created pool will
        /// allow to specify the owner as a colon-separated prefix of the
        /// property name, like "GtkContainer:border-width". This feature is
        /// deprecated, so you should always set @type_prefixing to %FALSE.
        /// </para>
        /// </remarks>
        /// <param name="typePrefixing">
        /// Whether the pool will support type-prefixed property names.
        /// </param>
        /// <returns>
        /// a newly allocated #GParamSpecPool.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* g_param_spec_pool_new(
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean typePrefixing);
        static partial void CheckNewArgs(bool typePrefixing);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.New(bool)']/*" />
        public static GISharp.Lib.GObject.ParamSpecPool New(bool typePrefixing)
        {
            CheckNewArgs(typePrefixing);
            var typePrefixing_ = GISharp.Runtime.BooleanExtensions.ToBoolean(typePrefixing);
            var ret_ = g_param_spec_pool_new(typePrefixing_);
            var ret = GISharp.Lib.GObject.ParamSpecPool.GetInstance<GISharp.Lib.GObject.ParamSpecPool>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Inserts a #GParamSpec in the pool.
        /// </summary>
        /// <param name="pool">
        /// a #GParamSpecPool.
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec to insert
        /// </param>
        /// <param name="ownerType">
        /// a #GType identifying the owner of @pspec
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_pool_insert(
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* pool,
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType ownerType);
        partial void CheckInsertArgs(GISharp.Lib.GObject.ParamSpec pspec, GISharp.Lib.GObject.GType ownerType);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.Insert(GISharp.Lib.GObject.ParamSpec,GISharp.Lib.GObject.GType)']/*" />
        public void Insert(GISharp.Lib.GObject.ParamSpec pspec, GISharp.Lib.GObject.GType ownerType)
        {
            CheckInsertArgs(pspec, ownerType);
            var pool_ = (GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct*)UnsafeHandle;
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)pspec.UnsafeHandle;
            var ownerType_ = (GISharp.Lib.GObject.GType)ownerType;
            g_param_spec_pool_insert(pool_, pspec_, ownerType_);
        }

        /// <summary>
        /// Gets an array of all #GParamSpecs owned by @owner_type in
        /// the pool.
        /// </summary>
        /// <param name="pool">
        /// a #GParamSpecPool
        /// </param>
        /// <param name="ownerType">
        /// the owner to look for
        /// </param>
        /// <param name="nPspecsP">
        /// return location for the length of the returned array
        /// </param>
        /// <returns>
        /// a newly
        ///          allocated array containing pointers to all #GParamSpecs
        ///          owned by @owner_type in the pool
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GParamSpec**" managed-name="GISharp.Runtime.CArray" is-pointer="1">
*   <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" />
* </array> */
        /* transfer-ownership:container direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct** g_param_spec_pool_list(
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* pool,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType ownerType,
        /* <type name="guint" type="guint*" managed-name="System.UInt32" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        uint* nPspecsP);
        partial void CheckListArgs(GISharp.Lib.GObject.GType ownerType);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.List(GISharp.Lib.GObject.GType)']/*" />
        public GISharp.Runtime.CPtrArray<GISharp.Lib.GObject.ParamSpec> List(GISharp.Lib.GObject.GType ownerType)
        {
            CheckListArgs(ownerType);
            var pool_ = (GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct*)UnsafeHandle;
            var ownerType_ = (GISharp.Lib.GObject.GType)ownerType;
            uint nPspecsP_;
            var ret_ = g_param_spec_pool_list(pool_,ownerType_,&nPspecsP_);
            var ret = new GISharp.Runtime.CPtrArray<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)ret_, (int)nPspecsP_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Gets an #GList of all #GParamSpecs owned by @owner_type in
        /// the pool.
        /// </summary>
        /// <param name="pool">
        /// a #GParamSpecPool
        /// </param>
        /// <param name="ownerType">
        /// the owner to look for
        /// </param>
        /// <returns>
        /// a
        ///          #GList of all #GParamSpecs owned by @owner_type in
        ///          the pool#GParamSpecs.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.List" type="GList*" managed-name="GISharp.Lib.GLib.List" is-pointer="1">
*   <type name="ParamSpec" managed-name="ParamSpec" />
* </type> */
        /* transfer-ownership:container direction:in */
        private static extern GISharp.Lib.GLib.List.UnmanagedStruct* g_param_spec_pool_list_owned(
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* pool,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType ownerType);
        partial void CheckListOwnedArgs(GISharp.Lib.GObject.GType ownerType);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.ListOwned(GISharp.Lib.GObject.GType)']/*" />
        public GISharp.Lib.GLib.WeakList<GISharp.Lib.GObject.ParamSpec> ListOwned(GISharp.Lib.GObject.GType ownerType)
        {
            CheckListOwnedArgs(ownerType);
            var pool_ = (GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct*)UnsafeHandle;
            var ownerType_ = (GISharp.Lib.GObject.GType)ownerType;
            var ret_ = g_param_spec_pool_list_owned(pool_,ownerType_);
            var ret = GISharp.Lib.GLib.WeakList<GISharp.Lib.GObject.ParamSpec>.GetInstance<GISharp.Lib.GLib.WeakList<GISharp.Lib.GObject.ParamSpec>>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Container)!;
            return ret;
        }

        /// <summary>
        /// Looks up a #GParamSpec in the pool.
        /// </summary>
        /// <param name="pool">
        /// a #GParamSpecPool
        /// </param>
        /// <param name="paramName">
        /// the name to look for
        /// </param>
        /// <param name="ownerType">
        /// the owner to look for
        /// </param>
        /// <param name="walkAncestors">
        /// If %TRUE, also try to find a #GParamSpec with @param_name
        ///  owned by an ancestor of @owner_type.
        /// </param>
        /// <returns>
        /// The found #GParamSpec, or %NULL if no
        /// matching #GParamSpec was found.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* g_param_spec_pool_lookup(
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* pool,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* paramName,
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.GType ownerType,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean walkAncestors);
        partial void CheckLookupArgs(GISharp.Lib.GLib.UnownedUtf8 paramName, GISharp.Lib.GObject.GType ownerType, bool walkAncestors);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.Lookup(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GObject.GType,bool)']/*" />
        public GISharp.Lib.GObject.ParamSpec Lookup(GISharp.Lib.GLib.UnownedUtf8 paramName, GISharp.Lib.GObject.GType ownerType, bool walkAncestors)
        {
            CheckLookupArgs(paramName, ownerType, walkAncestors);
            var pool_ = (GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct*)UnsafeHandle;
            var paramName_ = (byte*)paramName.UnsafeHandle;
            var ownerType_ = (GISharp.Lib.GObject.GType)ownerType;
            var walkAncestors_ = GISharp.Runtime.BooleanExtensions.ToBoolean(walkAncestors);
            var ret_ = g_param_spec_pool_lookup(pool_,paramName_,ownerType_,walkAncestors_);
            var ret = GISharp.Lib.GObject.ParamSpec.GetInstance<GISharp.Lib.GObject.ParamSpec>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Removes a #GParamSpec from the pool.
        /// </summary>
        /// <param name="pool">
        /// a #GParamSpecPool
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec to remove
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_param_spec_pool_remove(
        /* <type name="ParamSpecPool" type="GParamSpecPool*" managed-name="ParamSpecPool" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct* pool,
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.ParamSpec.UnmanagedStruct* pspec);
        partial void CheckRemoveArgs(GISharp.Lib.GObject.ParamSpec pspec);

        /// <include file="ParamSpecPool.xmldoc" path="declaration/member[@name='ParamSpecPool.Remove(GISharp.Lib.GObject.ParamSpec)']/*" />
        public void Remove(GISharp.Lib.GObject.ParamSpec pspec)
        {
            CheckRemoveArgs(pspec);
            var pool_ = (GISharp.Lib.GObject.ParamSpecPool.UnmanagedStruct*)UnsafeHandle;
            var pspec_ = (GISharp.Lib.GObject.ParamSpec.UnmanagedStruct*)pspec.UnsafeHandle;
            g_param_spec_pool_remove(pool_, pspec_);
        }
    }
}