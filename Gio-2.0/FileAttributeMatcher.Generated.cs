namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Determines if a string matches a file attribute.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GFileAttributeMatcher", IsProxyForUnmanagedType = true)]
    public sealed partial class FileAttributeMatcher : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_file_attribute_matcher_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FileAttributeMatcher(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new file attribute matcher, which matches attributes
        /// against a given string. #GFileAttributeMatchers are reference
        /// counted structures, and are created with a reference count of 1. If
        /// the number of references falls to 0, the #GFileAttributeMatcher is
        /// automatically destroyed.
        /// </summary>
        /// <remarks>
        /// The @attribute string should be formatted with specific keys separated
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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_matcher_new(
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attributes);

        static unsafe System.IntPtr New(GISharp.Lib.GLib.Utf8 attributes)
        {
            var attributes_ = attributes?.Handle ?? throw new System.ArgumentNullException(nameof(attributes));
            var ret_ = g_file_attribute_matcher_new(attributes_);
            return ret_;
        }

        /// <summary>
        /// Creates a new file attribute matcher, which matches attributes
        /// against a given string. <see cref="FileAttributeMatcher"/>s are reference
        /// counted structures, and are created with a reference count of 1. If
        /// the number of references falls to 0, the <see cref="FileAttributeMatcher"/> is
        /// automatically destroyed.
        /// </summary>
        /// <remarks>
        /// The <paramref name="attribute"/> string should be formatted with specific keys separated
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
        public FileAttributeMatcher(GISharp.Lib.GLib.Utf8 attributes) : this(New(attributes), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_file_attribute_matcher_get_type();

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
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_attribute_matcher_enumerate_namespace(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr ns);

        /// <summary>
        /// Checks if the matcher will match all of the keys in a given namespace.
        /// This will always return <c>true</c> if a wildcard character is in use (e.g. if
        /// matcher was created with "standard::*" and <paramref name="ns"/> is "standard", or if matcher was created
        /// using "*" and namespace is anything.)
        /// </summary>
        /// <remarks>
        /// TODO: this is awkwardly worded.
        /// </remarks>
        /// <param name="ns">
        /// a string containing a file attribute namespace.
        /// </param>
        /// <returns>
        /// <c>true</c> if the matcher matches all of the entries
        /// in the given <paramref name="ns"/>, <c>false</c> otherwise.
        /// </returns>
        public unsafe System.Boolean EnumerateNamespace(GISharp.Lib.GLib.Utf8 ns)
        {
            var matcher_ = Handle;
            var ns_ = ns?.Handle ?? throw new System.ArgumentNullException(nameof(ns));
            var ret_ = g_file_attribute_matcher_enumerate_namespace(matcher_,ns_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Gets the next matched attribute from a #GFileAttributeMatcher.
        /// </summary>
        /// <param name="matcher">
        /// a #GFileAttributeMatcher.
        /// </param>
        /// <returns>
        /// a string containing the next attribute or %NULL if
        /// no more attribute exist.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gio-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_file_attribute_matcher_enumerate_next(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher);

        /// <summary>
        /// Gets the next matched attribute from a <see cref="FileAttributeMatcher"/>.
        /// </summary>
        /// <returns>
        /// a string containing the next attribute or <c>null</c> if
        /// no more attribute exist.
        /// </returns>
        public unsafe GISharp.Lib.GLib.Utf8 EnumerateNext()
        {
            var matcher_ = Handle;
            var ret_ = g_file_attribute_matcher_enumerate_next(matcher_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
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
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_attribute_matcher_matches(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Checks if an attribute will be matched by an attribute matcher. If
        /// the matcher was created with the "*" matching string, this function
        /// will always return <c>true</c>.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="attribute"/> matches <paramref name="matcher"/>. <c>false</c> otherwise.
        /// </returns>
        public unsafe System.Boolean Matches(GISharp.Lib.GLib.Utf8 attribute)
        {
            var matcher_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_attribute_matcher_matches(matcher_,attribute_);
            var ret = (System.Boolean)ret_;
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
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_file_attribute_matcher_matches_only(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher,
        /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr attribute);

        /// <summary>
        /// Checks if a attribute matcher only matches a given attribute. Always
        /// returns <c>false</c> if "*" was used when creating the matcher.
        /// </summary>
        /// <param name="attribute">
        /// a file attribute key.
        /// </param>
        /// <returns>
        /// <c>true</c> if the matcher only matches <paramref name="attribute"/>. <c>false</c> otherwise.
        /// </returns>
        public unsafe System.Boolean MatchesOnly(GISharp.Lib.GLib.Utf8 attribute)
        {
            var matcher_ = Handle;
            var attribute_ = attribute?.Handle ?? throw new System.ArgumentNullException(nameof(attribute));
            var ret_ = g_file_attribute_matcher_matches_only(matcher_,attribute_);
            var ret = (System.Boolean)ret_;
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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_matcher_ref(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher);
        public override System.IntPtr Take() => g_file_attribute_matcher_ref(Handle);

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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_matcher_subtract(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher,
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr subtract);

        /// <summary>
        /// Subtracts all attributes of <paramref name="subtract"/> from <paramref name="matcher"/> and returns
        /// a matcher that supports those attributes.
        /// </summary>
        /// <remarks>
        /// Note that currently it is not possible to remove a single
        /// attribute when the <paramref name="matcher"/> matches the whole namespace - or remove
        /// a namespace or attribute when the matcher matches everything. This
        /// is a limitation of the current implementation, but may be fixed
        /// in the future.
        /// </remarks>
        /// <param name="subtract">
        /// The matcher to subtract
        /// </param>
        /// <returns>
        /// A file attribute matcher matching all attributes of
        ///     <paramref name="matcher"/> that are not matched by <paramref name="subtract"/>
        /// </returns>
        public unsafe GISharp.Lib.Gio.FileAttributeMatcher Subtract(GISharp.Lib.Gio.FileAttributeMatcher subtract)
        {
            var matcher_ = Handle;
            var subtract_ = subtract?.Handle ?? throw new System.ArgumentNullException(nameof(subtract));
            var ret_ = g_file_attribute_matcher_subtract(matcher_,subtract_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.FileAttributeMatcher>(ret_, GISharp.Runtime.Transfer.Full);
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
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_file_attribute_matcher_to_string(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr matcher);

        /// <summary>
        /// Prints what the matcher is matching against. The format will be
        /// equal to the format passed to <see cref="FileAttributeMatcher.New"/>.
        /// The output however, might not be identical, as the matcher may
        /// decide to use a different order or omit needless parts.
        /// </summary>
        /// <returns>
        /// a string describing the attributes the matcher matches
        ///   against or <c>null</c> if <paramref name="matcher"/> was <c>null</c>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.32")]
        public override System.String ToString()
        {
            var matcher_ = Handle;
            var ret_ = g_file_attribute_matcher_to_string(matcher_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
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
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_file_attribute_matcher_unref(
        /* <type name="FileAttributeMatcher" type="GFileAttributeMatcher*" managed-name="FileAttributeMatcher" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr matcher);
    }
}