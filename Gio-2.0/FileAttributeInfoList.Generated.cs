namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Acts as a lightweight registry for possible valid file attributes.
    /// The registry stores Key-Value pair formats as #GFileAttributeInfos.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileAttributeInfoList", IsProxyForUnmanagedType = true)]
    public sealed partial class FileAttributeInfoList : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_info_list_get_type();

        unsafe struct Struct
        {
#pragma warning disable CS0649
            /// <summary>
            /// an array of #GFileAttributeInfos.
            /// </summary>
            public GISharp.Lib.Gio.FileAttributeInfo* Infos;

            /// <summary>
            /// the number of values in the array.
            /// </summary>
            public System.Int32 NInfos;
#pragma warning restore CS0649
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileAttributeInfoList(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new file attribute info list.
        /// </summary>
        /// <returns>
        /// a #GFileAttributeInfoList.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_info_list_new();

        static unsafe System.IntPtr New()
        {
            var ret_ = g_file_attribute_info_list_new();
            return ret_;
        }

        /// <summary>
        /// Creates a new file attribute info list.
        /// </summary>
        public FileAttributeInfoList() : this(New(), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_info_list_get_type();

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
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_attribute_info_list_add(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="FileAttributeType" type="GFileAttributeType" managed-name="FileAttributeType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeType type,
        /* <type name="FileAttributeInfoFlags" type="GFileAttributeInfoFlags" managed-name="FileAttributeInfoFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeInfoFlags flags);

        /// <summary>
        /// Adds a new attribute with <paramref name="name"/> to the <paramref name="list"/>, setting
        /// its <paramref name="type"/> and <paramref name="flags"/>.
        /// </summary>
        /// <param name="name">
        /// the name of the attribute to add.
        /// </param>
        /// <param name="type">
        /// the <see cref="FileAttributeType"/> for the attribute.
        /// </param>
        /// <param name="flags">
        /// <see cref="FileAttributeInfoFlags"/> for the attribute.
        /// </param>
        public unsafe void Add(GISharp.Lib.GLib.Utf8 name, GISharp.Lib.Gio.FileAttributeType type, GISharp.Lib.Gio.FileAttributeInfoFlags flags)
        {
            var list_ = Handle;
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_info_list_dup(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list);

        /// <summary>
        /// Makes a duplicate of a file attribute info list.
        /// </summary>
        /// <returns>
        /// a copy of the given <paramref name="list"/>.
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileAttributeInfoList Dup()
        {
            var list_ = Handle;
            var ret_ = g_file_attribute_info_list_dup(list_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileAttributeInfoList>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gets the file attribute with the name @name from @list.
        /// </summary>
        /// <param name="list">
        /// a #GFileAttributeInfoList.
        /// </param>
        /// <param name="name">
        /// the name of the attribute to lookup.
        /// </param>
        /// <returns>
        /// a #GFileAttributeInfo for the @name, or %NULL if an
        /// attribute isn't found.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeInfo" type="const GFileAttributeInfo*" managed-name="FileAttributeInfo" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.Gio.FileAttributeInfo* g_file_attribute_info_list_lookup(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name);

        /// <summary>
        /// Gets the file attribute with the name <paramref name="name"/> from <paramref name="list"/>.
        /// </summary>
        /// <param name="name">
        /// the name of the attribute to lookup.
        /// </param>
        /// <returns>
        /// a <see cref="FileAttributeInfo"/> for the <paramref name="name"/>, or <c>null</c> if an
        /// attribute isn't found.
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileAttributeInfo? Lookup(GISharp.Lib.GLib.Utf8 name)
        {
            var list_ = Handle;
            var name_ = name?.Handle ?? throw new System.ArgumentNullException(nameof(name));
            var ret_ = g_file_attribute_info_list_lookup(list_,name_);
            var ret = (ret_ == null) ? default(GISharp.Lib.Gio.FileAttributeInfo?) : (GISharp.Lib.Gio.FileAttributeInfo)(*ret_);
            return ret;
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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_info_list_ref(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list);
        public override System.IntPtr Take() => g_file_attribute_info_list_ref(Handle);

        /// <summary>
        /// Removes a reference from the given @list. If the reference count
        /// falls to zero, the @list is deleted.
        /// </summary>
        /// <param name="list">
        /// The #GFileAttributeInfoList to unreference.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_attribute_info_list_unref(
        /* <type name="FileAttributeInfoList" type="GFileAttributeInfoList*" managed-name="FileAttributeInfoList" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list);
    }
}