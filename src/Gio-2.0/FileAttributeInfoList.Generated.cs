// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='FileAttributeInfoList']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeInfoList", IsProxyForUnmanagedType = true)]
    public unsafe partial class FileAttributeInfoList : GISharp.Lib.GObject.Boxed
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_info_list_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='UnmanagedStruct.Infos']/*" />
            public readonly GISharp.Lib.Gio.FileAttributeInfo* Infos;

            /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='UnmanagedStruct.NInfos']/*" />
            public readonly System.Int32 NInfos;
#pragma warning restore CS0169, CS0649
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileAttributeInfoList(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        static partial void CheckNewArgs();

        /// <summary>
        /// Creates a new file attribute info list.
        /// </summary>
        /// <returns>
        /// a #GFileAttributeInfoList.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* g_file_attribute_info_list_new();

        static GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* New()
        {
            CheckNewArgs();
            var ret_ = g_file_attribute_info_list_new();
            return ret_;
        }

        /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='FileAttributeInfoList.FileAttributeInfoList()']/*" />
        public FileAttributeInfoList() : this((System.IntPtr)New(), GISharp.Runtime.Transfer.Full)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_file_attribute_info_list_get_type();

        /// <summary>
        /// Adds a new attribute with @name to the @list, setting
        /// its @type and @flags.
        /// </summary>
        /// <param name="list">
        /// a #GFileAttributeInfoList.
        /// </param>
        /// <param name="name">
        /// the name of the attribute to add.
        /// </param>
        /// <param name="type">
        /// the #GFileAttributeType for the attribute.
        /// </param>
        /// <param name="flags">
        /// #GFileAttributeInfoFlags for the attribute.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_file_attribute_info_list_add(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* list,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* name,
        /* <type name="FileAttributeType" type="GFileAttributeType" managed-name="FileAttributeType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeType type,
        /* <type name="FileAttributeInfoFlags" type="GFileAttributeInfoFlags" managed-name="FileAttributeInfoFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoFlags flags);
        partial void CheckAddArgs(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.Gio.FileAttributeType type, GISharp.Lib.Gio.FileAttributeInfoFlags flags);

        /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='FileAttributeInfoList.Add(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.Gio.FileAttributeType,GISharp.Lib.Gio.FileAttributeInfoFlags)']/*" />
        public void Add(GISharp.Lib.GLib.UnownedUtf8 name, GISharp.Lib.Gio.FileAttributeType type, GISharp.Lib.Gio.FileAttributeInfoFlags flags)
        {
            CheckAddArgs(name, type, flags);
            var list_ = (GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct*)UnsafeHandle;
            var name_ = (System.Byte*)name.UnsafeHandle;
            var type_ = (GISharp.Lib.Gio.FileAttributeType)type;
            var flags_ = (GISharp.Lib.Gio.FileAttributeInfoFlags)flags;
            g_file_attribute_info_list_add(list_, name_, type_, flags_);
        }

        /// <summary>
        /// Makes a duplicate of a file attribute info list.
        /// </summary>
        /// <param name="list">
        /// a #GFileAttributeInfoList to duplicate.
        /// </param>
        /// <returns>
        /// a copy of the given @list.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* g_file_attribute_info_list_dup(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* list);
        partial void CheckDupArgs();

        /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='FileAttributeInfoList.Dup()']/*" />
        public GISharp.Lib.Gio.FileAttributeInfoList Dup()
        {
            CheckDupArgs();
            var list_ = (GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_file_attribute_info_list_dup(list_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileAttributeInfoList>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Gets the file attribute with the name @name from @list.
        /// </summary>
        /// <param name="list">
        /// a #GFileAttributeInfoList.
        /// </param>
        /// <param name="name">
        /// the name of the attribute to look up.
        /// </param>
        /// <returns>
        /// a #GFileAttributeInfo for the @name, or %NULL if an
        /// attribute isn't found.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfo" type="const GFileAttributeInfo*" managed-name="FileAttributeInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeInfo* g_file_attribute_info_list_lookup(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* list,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Byte* name);
        partial void CheckLookupArgs(GISharp.Lib.GLib.UnownedUtf8 name);

        /// <include file="FileAttributeInfoList.xmldoc" path="declaration/member[@name='FileAttributeInfoList.Lookup(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public ref readonly GISharp.Lib.Gio.FileAttributeInfo Lookup(GISharp.Lib.GLib.UnownedUtf8 name)
        {
            CheckLookupArgs(name);
            var list_ = (GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct*)UnsafeHandle;
            var name_ = (System.Byte*)name.UnsafeHandle;
            var ret_ = g_file_attribute_info_list_lookup(list_,name_);
            ref readonly var ret = ref System.Runtime.CompilerServices.Unsafe.AsRef<GISharp.Lib.Gio.FileAttributeInfo>(ret_);
            return ref ret;
        }

        /// <summary>
        /// References a file attribute info list.
        /// </summary>
        /// <param name="list">
        /// a #GFileAttributeInfoList to reference.
        /// </param>
        /// <returns>
        /// #GFileAttributeInfoList or %NULL on error.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* g_file_attribute_info_list_ref(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* list);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_file_attribute_info_list_ref((GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Removes a reference from the given @list. If the reference count
        /// falls to zero, the @list is deleted.
        /// </summary>
        /// <param name="list">
        /// The #GFileAttributeInfoList to unreference.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_file_attribute_info_list_unref(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoList.UnmanagedStruct* list);
    }
}