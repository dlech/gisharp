// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher']/*" />
    [GISharp.Runtime.GTypeAttribute("GFileAttributeMatcher", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class FileAttributeMatcher : GISharp.Lib.GObject.Boxed
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_matcher_get_type();

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
        public FileAttributeMatcher(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_file_attribute_matcher_ref((UnmanagedStruct*)handle);
            }
        }

        static partial void CheckNewArgs(GISharp.Lib.GLib.UnownedUtf8 attributes);

        /// <summary>
        /// Creates a new file attribute matcher, which matches attributes
        /// against a given string. #GFileAttributeMatchers are reference
        /// counted structures, and are created with a reference count of 1. If
        /// the number of references falls to 0, the #GFileAttributeMatcher is
        /// automatically destroyed.
        /// </summary>
        /// <remarks>
        /// The @attributes string should be formatted with specific keys separated
        /// from namespaces with a double colon. Several "namespace::key" strings may be
        /// concatenated with a single comma (e.g. "standard::type,standard::is-hidden").
        /// The wildcard "*" may be used to match all keys and namespaces, or
        /// "namespace::*" will match all keys in a given namespace.
        /// 
        /// ## Examples of file attribute matcher strings and results
        /// 
        /// - `"*"`: matches all attributes.
        /// - `"standard::is-hidden"`: matches only the key is-hidden in the
        ///   standard namespace.
        /// - `"standard::type,unix::*"`: matches the type key in the standard
        ///   namespace and all keys in the unix namespace.
        /// </remarks>
        /// <param name="attributes">
        /// an attribute string to match.
        /// </param>
        /// <returns>
        /// a #GFileAttributeMatcher
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* g_file_attribute_matcher_new(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* attributes);

        static GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* New(GISharp.Lib.GLib.UnownedUtf8 attributes)
        {
            CheckNewArgs(attributes);
            var attributes_ = (byte*)attributes.UnsafeHandle;
            var ret_ = g_file_attribute_matcher_new(attributes_);
            return ret_;
        }

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.FileAttributeMatcher(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public FileAttributeMatcher(GISharp.Lib.GLib.UnownedUtf8 attributes) : this((System.IntPtr)New(attributes), GISharp.Runtime.Transfer.Full)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_file_attribute_matcher_get_type();

        /// <summary>
        /// Checks if the matcher will match all of the keys in a given namespace.
        /// This will always return %TRUE if a wildcard character is in use (e.g. if
        /// matcher was created with "standard::*" and @ns is "standard", or if matcher was created
        /// using "*" and namespace is anything.)
        /// </summary>
        /// <remarks>
        /// TODO: this is awkwardly worded.
        /// </remarks>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <param name="ns">
        /// a string containing a file attribute namespace.
        /// </param>
        /// <returns>
        /// %TRUE if the matcher matches all of the entries
        /// in the given @ns, %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_file_attribute_matcher_enumerate_namespace(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* ns);
        partial void CheckEnumerateNamespaceArgs(GISharp.Lib.GLib.UnownedUtf8 ns);

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.EnumerateNamespace(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public System.Boolean EnumerateNamespace(GISharp.Lib.GLib.UnownedUtf8 ns)
        {
            CheckEnumerateNamespaceArgs(ns);
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var ns_ = (byte*)ns.UnsafeHandle;
            var ret_ = g_file_attribute_matcher_enumerate_namespace(matcher_,ns_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Gets the next matched attribute from a #GFileAttributeMatcher.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <returns>
        /// a string containing the next attribute or, %NULL if
        /// no more attribute exist.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_file_attribute_matcher_enumerate_next(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher);
        partial void CheckEnumerateNextArgs();

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.EnumerateNext()']/*" />
        public GISharp.Lib.GLib.NullableUnownedUtf8 EnumerateNext()
        {
            CheckEnumerateNextArgs();
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_file_attribute_matcher_enumerate_next(matcher_);
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Checks if an attribute will be matched by an attribute matcher. If
        /// the matcher was created with the "*" matching string, this function
        /// will always return %TRUE.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// %TRUE if @attribute matches @matcher. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_file_attribute_matcher_matches(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* attribute);
        partial void CheckMatchesArgs(GISharp.Lib.GLib.UnownedUtf8 attribute);

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.Matches(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public System.Boolean Matches(GISharp.Lib.GLib.UnownedUtf8 attribute)
        {
            CheckMatchesArgs(attribute);
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var attribute_ = (byte*)attribute.UnsafeHandle;
            var ret_ = g_file_attribute_matcher_matches(matcher_,attribute_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Checks if a attribute matcher only matches a given attribute. Always
        /// returns %FALSE if "*" was used when creating the matcher.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// %TRUE if the matcher only matches @attribute. %FALSE otherwise.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_file_attribute_matcher_matches_only(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* attribute);
        partial void CheckMatchesOnlyArgs(GISharp.Lib.GLib.UnownedUtf8 attribute);

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.MatchesOnly(GISharp.Lib.GLib.UnownedUtf8)']/*" />
        public System.Boolean MatchesOnly(GISharp.Lib.GLib.UnownedUtf8 attribute)
        {
            CheckMatchesOnlyArgs(attribute);
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var attribute_ = (byte*)attribute.UnsafeHandle;
            var ret_ = g_file_attribute_matcher_matches_only(matcher_,attribute_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// References a file attribute matcher.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <returns>
        /// a #GFileAttributeMatcher.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* g_file_attribute_matcher_ref(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_file_attribute_matcher_ref((GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Subtracts all attributes of @subtract from @matcher and returns
        /// a matcher that supports those attributes.
        /// </summary>
        /// <remarks>
        /// Note that currently it is not possible to remove a single
        /// attribute when the @matcher matches the whole namespace - or remove
        /// a namespace or attribute when the matcher matches everything. This
        /// is a limitation of the current implementation, but may be fixed
        /// in the future.
        /// </remarks>
        /// <param name="matcher">
        /// Matcher to subtract from
        /// </param>
        /// <param name="subtract">
        /// The matcher to subtract
        /// </param>
        /// <returns>
        /// A file attribute matcher matching all attributes of
        ///     @matcher that are not matched by @subtract
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* g_file_attribute_matcher_subtract(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher,
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* subtract);
        partial void CheckSubtractArgs(GISharp.Lib.Gio.FileAttributeMatcher subtract);

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.Subtract(GISharp.Lib.Gio.FileAttributeMatcher)']/*" />
        public GISharp.Lib.Gio.FileAttributeMatcher Subtract(GISharp.Lib.Gio.FileAttributeMatcher subtract)
        {
            CheckSubtractArgs(subtract);
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var subtract_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)subtract.UnsafeHandle;
            var ret_ = g_file_attribute_matcher_subtract(matcher_,subtract_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileAttributeMatcher>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Prints what the matcher is matching against. The format will be
        /// equal to the format passed to g_file_attribute_matcher_new().
        /// The output however, might not be identical, as the matcher may
        /// decide to use a different order or omit needless parts.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <returns>
        /// a string describing the attributes the matcher matches
        ///   against or %NULL if @matcher was %NULL.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern byte* g_file_attribute_matcher_to_string(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher);
        partial void CheckToStringArgs();

        /// <include file="FileAttributeMatcher.xmldoc" path="declaration/member[@name='FileAttributeMatcher.ToString()']/*" />
        [GISharp.Runtime.SinceAttribute("2.32")]
        public override System.String ToString()
        {
            CheckToStringArgs();
            var matcher_ = (GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_file_attribute_matcher_to_string(matcher_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Unreferences @matcher. If the reference count falls below 1,
        /// the @matcher is automatically freed.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_file_attribute_matcher_unref(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.Gio.FileAttributeMatcher.UnmanagedStruct* matcher);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_file_attribute_matcher_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }
    }
}