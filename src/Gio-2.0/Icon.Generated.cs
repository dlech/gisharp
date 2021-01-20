// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon']/*" />
    [GISharp.Runtime.GTypeAttribute("GIcon", IsProxyForUnmanagedType = true)]
    [GISharp.Runtime.GTypeStructAttribute(typeof(IconIface))]
    public partial interface IIcon : GISharp.Runtime.GInterface<GISharp.Lib.GObject.Object>
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_icon_get_type();

        static partial void CheckDeserializeArgs(GISharp.Lib.GLib.Variant value);

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
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_icon_deserialize(
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.Deserialize(GISharp.Lib.GLib.Variant)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public static unsafe GISharp.Lib.Gio.IIcon Deserialize(GISharp.Lib.GLib.Variant value)
        {
            CheckDeserializeArgs(value);
            var value_ = value.Handle;
            var ret_ = g_icon_deserialize(value_);
            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        static partial void CheckNewForStringArgs(GISharp.Lib.GLib.UnownedUtf8 str);

        /// <summary>
        /// Generate a #GIcon instance from @str. This function can fail if
        /// @str is not valid - see g_icon_to_string() for discussion.
        /// </summary>
        /// <remarks>
        /// If your application or library provides one or more #GIcon
        /// implementations you need to ensure that each #GType is registered
        /// with the type system prior to calling g_icon_new_for_string().
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
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_icon_new_for_string(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr str,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        ref System.IntPtr error);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.NewForString(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        public static unsafe GISharp.Lib.Gio.IIcon NewForString(GISharp.Lib.GLib.UnownedUtf8 str)
        {
            CheckNewForStringArgs(str);
            var str_ = str.Handle;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_icon_new_for_string(str_,ref error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (GISharp.Lib.Gio.IIcon)GISharp.Lib.GObject.Object.GetInstance(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe GISharp.Lib.GObject.GType g_icon_get_type();

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoEqual(GISharp.Lib.Gio.IIcon?)']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedEqual))]
        System.Boolean DoEqual(GISharp.Lib.Gio.IIcon? icon2);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoHash()']/*" />
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedHash))]
        System.UInt32 DoHash();

        /// <include file="Icon.xmldoc" path="declaration/member[@name='IIcon.DoSerialize()']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        [GISharp.Runtime.GVirtualMethodAttribute(typeof(IconIface.UnmanagedSerialize))]
        GISharp.Lib.GLib.Variant DoSerialize();
    }

    /// <summary>
    /// Extension methods for <see cref="IIcon"/>
    /// </summary>
    public static partial class Icon
    {
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
        /* transfer-ownership:none direction:out */
        private static extern unsafe System.UInt32 g_icon_hash(
        /* <type name="Icon" type="gconstpointer" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);
        static partial void CheckGetHashCodeArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.GetHashCode(GISharp.Lib.Gio.IIcon)']/*" />
        public unsafe static System.Int32 GetHashCode(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckGetHashCodeArgs(icon);
            var icon_ = icon.Handle;
            var ret_ = g_icon_hash(icon_);
            var ret = (System.Int32)ret_;
            return ret;
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
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Runtime.Boolean g_icon_equal(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon1,
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr icon2);
        static partial void CheckEqualsArgs(this GISharp.Lib.Gio.IIcon? icon1, GISharp.Lib.Gio.IIcon? icon2);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.Equals(GISharp.Lib.Gio.IIcon?,GISharp.Lib.Gio.IIcon?)']/*" />
        public unsafe static System.Boolean Equals(this GISharp.Lib.Gio.IIcon? icon1, GISharp.Lib.Gio.IIcon? icon2)
        {
            CheckEqualsArgs(icon1, icon2);
            var icon1_ = icon1?.Handle ?? System.IntPtr.Zero;
            var icon2_ = icon2?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_icon_equal(icon1_,icon2_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
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
        /* <type name="GLib.Variant" type="GVariant*" managed-name="GISharp.Lib.GLib.Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        private static extern unsafe System.IntPtr g_icon_serialize(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);
        static partial void CheckSerializeArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.Serialize(GISharp.Lib.Gio.IIcon)']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public unsafe static GISharp.Lib.GLib.Variant Serialize(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckSerializeArgs(icon);
            var icon_ = icon.Handle;
            var ret_ = g_icon_serialize(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Generates a textual representation of @icon that can be used for
        /// serialization such as when passing @icon to a different process or
        /// saving it to persistent storage. Use g_icon_new_for_string() to
        /// get @icon back from the returned string.
        /// </summary>
        /// <remarks>
        /// The encoding of the returned string is proprietary to #GIcon except
        /// in the following two cases
        /// 
        /// - If @icon is a #GFileIcon, the returned string is a native path
        ///   (such as `/path/to/my icon.png`) without escaping
        ///   if the #GFile for @icon is a native file.  If the file is not
        ///   native, the returned string is the result of g_file_get_uri()
        ///   (such as `sftp://path/to/my%20icon.png`).
        /// 
        /// - If @icon is a #GThemedIcon with exactly one name and no fallbacks,
        ///   the encoding is simply the name (such as `network-server`).
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
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        private static extern unsafe System.IntPtr g_icon_to_string(
        /* <type name="Icon" type="GIcon*" managed-name="Icon" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr icon);
        static partial void CheckToStringArgs(this GISharp.Lib.Gio.IIcon icon);

        /// <include file="Icon.xmldoc" path="declaration/member[@name='Icon.ToString(GISharp.Lib.Gio.IIcon)']/*" />
        [GISharp.Runtime.SinceAttribute("2.20")]
        public unsafe static GISharp.Lib.GLib.Utf8? ToString(this GISharp.Lib.Gio.IIcon icon)
        {
            CheckToStringArgs(icon);
            var icon_ = icon.Handle;
            var ret_ = g_icon_to_string(icon_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}