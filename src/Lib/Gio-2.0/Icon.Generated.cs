// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon']/*" />
    [GISharp.Runtime.GTypeAttribute("GIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(IconIface))]
    public unsafe partial interface IIcon : GISharp.Lib.GObject.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Runtime.GType _GType = g_icon_get_type();

        /// <summary>
        /// Deserializes a #GIcon previously serialized using g_icon_serialize().
        /// </summary>
        /// <param name="value">
        /// a #GVariant created with g_icon_serialize()
        /// </param>
        /// <returns>
        /// a #GIcon, or %NULL when deserialization fails.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.Gio.Icon.UnmanagedStruct* g_icon_deserialize(
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.Variant.UnmanagedStruct* value);
        static partial void CheckDeserializeArgs(GISharp.Lib.GLib.Variant value);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.Deserialize(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Lib.Gio.IIcon? Deserialize(GISharp.Lib.GLib.Variant value)
        {
            CheckDeserializeArgs(value);
            var value_ = (GISharp.Lib.GLib.Variant.UnmanagedStruct*)value.UnsafeHandle;
            var ret_ = g_icon_deserialize(value_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (GISharp.Lib.Gio.IIcon?)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generate a #GIcon instance from @str. This function can fail if
        /// @str is not valid - see g_icon_to_string() for discussion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If your application or library provides one or more #GIcon
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling g_icon_new_for_string().
        /// </para>
        /// </remarks>
        /// <param name="str">
        /// A string obtained via g_icon_to_string().
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// An object implementing the #GIcon
        ///          interface or %NULL if @error is set.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.Icon.UnmanagedStruct* g_icon_new_for_string(
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* str,
        /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        GISharp.Lib.GLib.Error.UnmanagedStruct** error);
        static partial void CheckNewForStringArgs(GISharp.Runtime.UnownedUtf8 str);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.NewForString(GISharp.Runtime.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static GISharp.Lib.Gio.IIcon NewForString(GISharp.Runtime.UnownedUtf8 str)
        {
            CheckNewForStringArgs(str);
            var str_ = (byte*)str.UnsafeHandle;
            var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
            var ret_ = g_icon_new_for_string(str_,&error_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            if (error_ is not null)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Lib.GLib.Error.Exception(error);
            }

            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_icon_get_type();

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoEqual(GISharp.Lib.Gio.IIcon?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedEqual))]
        bool DoEqual(GISharp.Lib.Gio.IIcon? icon2);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoHash()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedHash))]
        uint DoHash();

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoSerialize()']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedSerialize))]
        GISharp.Lib.GLib.Variant? DoSerialize();

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoTryToTokens(GISharp.Lib.GLib.WeakPtrArray&lt;GISharp.Runtime.Utf8&gt;,int)']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedToTokens))]
        bool DoTryToTokens(GISharp.Lib.GLib.WeakPtrArray<GISharp.Runtime.Utf8> tokens, out int outVersion);
    }

    /// <summary>
    /// Extension methods for <see cref="IIcon"/>
    /// </summary>
    public static unsafe partial class Icon
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <summary>
        /// Checks if two icons are equal.
        /// </summary>
        /// <param name="icon1">
        /// pointer to the first #GIcon.
        /// </param>
        /// <param name="icon2">
        /// pointer to the second #GIcon.
        /// </param>
        /// <returns>
        /// %TRUE if @icon1 is equal to @icon2. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_icon_equal(
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Icon.UnmanagedStruct* icon1,
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.Icon.UnmanagedStruct* icon2);
        static partial void CheckEqualsArgs(this GISharp.Lib.Gio.IIcon? icon1, GISharp.Lib.Gio.IIcon? icon2);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.Equals(GISharp.Lib.Gio.IIcon?,GISharp.Lib.Gio.IIcon?)']/*" />
        public static bool Equals(this GISharp.Lib.Gio.IIcon? icon1, GISharp.Lib.Gio.IIcon? icon2)
        {
            CheckEqualsArgs(icon1, icon2);
            var icon1_ = (GISharp.Lib.Gio.Icon.UnmanagedStruct*)(icon1?.UnsafeHandle ?? System.IntPtr.Zero);
            var icon2_ = (GISharp.Lib.Gio.Icon.UnmanagedStruct*)(icon2?.UnsafeHandle ?? System.IntPtr.Zero);
            var ret_ = g_icon_equal(icon1_,icon2_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Gets a hash for an icon.
        /// </summary>
        /// <param name="icon">
        /// #gconstpointer to an icon object.
        /// </param>
        /// <returns>
        /// a #guint containing a hash for the @icon, suitable for
        /// use in a #GHashTable or similar data structure.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        private static extern uint g_icon_hash(
        /* <type name="Icon" type="gconstpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Icon.UnmanagedStruct* icon);
        static partial void CheckGetHashCodeArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.GetHashCode(GISharp.Lib.Gio.IIcon)']/*" />
        public static System.Int32 GetHashCode(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckGetHashCodeArgs(icon);
            var icon_ = (GISharp.Lib.Gio.Icon.UnmanagedStruct*)icon.UnsafeHandle;
            var ret_ = g_icon_hash(icon_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Serializes a #GIcon into a #GVariant. An equivalent #GIcon can be retrieved
        /// back by calling g_icon_deserialize() on the returned value.
        /// As serialization will avoid using raw icon data when possible, it only
        /// makes sense to transfer the #GVariant between processes on the same machine,
        /// (as opposed to over the network), and within the same file system namespace.
        /// </summary>
        /// <param name="icon">
        /// a #GIcon
        /// </param>
        /// <returns>
        /// a #GVariant, or %NULL when serialization fails. The #GVariant will not be floating.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GLib.Variant" type="GVariant*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern GISharp.Lib.GLib.Variant.UnmanagedStruct* g_icon_serialize(
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Icon.UnmanagedStruct* icon);
        static partial void CheckSerializeArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.Serialize(GISharp.Lib.Gio.IIcon)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static GISharp.Lib.GLib.Variant? Serialize(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckSerializeArgs(icon);
            var icon_ = (GISharp.Lib.Gio.Icon.UnmanagedStruct*)icon.UnsafeHandle;
            var ret_ = g_icon_serialize(icon_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GLib.Variant.GetInstance<GISharp.Lib.GLib.Variant>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Generates a textual representation of @icon that can be used for
        /// serialization such as when passing @icon to a different process or
        /// saving it to persistent storage. Use g_icon_new_for_string() to
        /// get @icon back from the returned string.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The encoding of the returned string is proprietary to #GIcon except
        /// in the following two cases
        /// </para>
        /// <para>
        /// - If @icon is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for @icon is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// </para>
        /// <para>
        /// - If @icon is a #GThemedIcon with exactly one name and no fallbacks,
        ///   the encoding is simply the name (such as `network-server`).
        /// </para>
        /// </remarks>
        /// <param name="icon">
        /// a #GIcon.
        /// </param>
        /// <returns>
        /// An allocated NUL-terminated UTF8 string or
        /// %NULL if @icon can't be serialized. Use g_free() to free.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.20")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:in */
        private static extern byte* g_icon_to_string(
        /* <type name="Icon" type="GIcon*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.Icon.UnmanagedStruct* icon);
        static partial void CheckToStringArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.ToString(GISharp.Lib.Gio.IIcon)']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static GISharp.Runtime.Utf8? ToString(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckToStringArgs(icon);
            var icon_ = (GISharp.Lib.Gio.Icon.UnmanagedStruct*)icon.UnsafeHandle;
            var ret_ = g_icon_to_string(icon_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Runtime.Utf8.GetInstance<GISharp.Runtime.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}