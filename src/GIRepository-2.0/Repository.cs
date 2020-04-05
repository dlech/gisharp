// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using GISharp.Runtime;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;

namespace GISharp.Lib.GIRepository
{
    public static class Repository
    {
        static NamespaceCollection? namespaces;

        internal static InfoDictionary<BaseInfo> GetInfos(Utf8 @namespace)
        {
            return new InfoDictionary<BaseInfo> (GetNInfos (@namespace), (i) => GetInfo (@namespace, i));
        }

        public static NamespaceCollection Namespaces {
            get {
                if (namespaces == null) {
                    namespaces = new NamespaceCollection();
                }
                return namespaces!; // shouldn't need ! here (compiler bug?)
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_default ();

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_irepository_dump(IntPtr arg, out IntPtr error);

        public static void Dump(UnownedUtf8 arg)
        {
            IntPtr error_ = IntPtr.Zero;
            g_irepository_dump(arg.Handle, out error_);
            if (error_ != IntPtr.Zero) {
                var error = new Error (error_, Runtime.Transfer.Full);
                throw new GErrorException (error);
            }
        }

        public static void Dump(string arg)
        {
            using var argUtf8 = arg.ToUtf8();
            Dump(argUtf8);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_enumerate_versions (IntPtr raw, IntPtr @namespace);

        internal static string[] GetVersions(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_enumerate_versions(IntPtr.Zero, @namespace.Handle);
            var ret = GMarshal.GListToStringArray(ret_, freePtr: true);
            return ret!;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_find_by_error_domain (IntPtr raw, Quark domain);

        /// <summary>
        /// Searches for the enum type corresponding to the given GError domain.
        /// </summary>
        /// <returns>EnumInfo representing metadata about domain's enum type, or <c>null</c>.</returns>
        /// <param name="domain">A GError domain.</param>
        public static EnumInfo? FindByErrorDomain(Quark domain)
        {
            var ret_ = g_irepository_find_by_error_domain(IntPtr.Zero, domain);
            var ret = BaseInfo.GetInstanceOrNull<EnumInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_find_by_name (IntPtr raw, IntPtr @namespace, IntPtr name);

        internal static BaseInfo? FindByName(UnownedUtf8 @namespace, UnownedUtf8 name)
        {
            var ret_ = g_irepository_find_by_name(IntPtr.Zero, @namespace.Handle, name.Handle);
            var ret = BaseInfo.GetInstanceOrNull<BaseInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_find_by_gtype (IntPtr raw, GType gtype);

        public static BaseInfo? FindByGType(GType gtype)
        {
            var ret_ = g_irepository_find_by_gtype(IntPtr.Zero, gtype);
            var ret = BaseInfo.GetInstanceOrNull<BaseInfo>(ret_);

            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_c_prefix (IntPtr raw, IntPtr @namespace);

        internal static NullableUnownedUtf8 GetCPrefix(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_c_prefix(IntPtr.Zero, @namespace.Handle);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_dependencies (IntPtr raw, IntPtr @namespace);

        internal static Strv GetDependencies(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_dependencies(IntPtr.Zero, @namespace.Handle);
            var ret = Opaque.GetInstance<Strv>(ret_, Runtime.Transfer.Full);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        [Since ("1.44")]
        static extern IntPtr g_irepository_get_immediate_dependencies (IntPtr raw, IntPtr @namespace);

        [Since ("1.44")]
        internal static Strv GetImmediateDependencies(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_immediate_dependencies(IntPtr.Zero, @namespace.Handle);
            var ret = Opaque.GetInstance<Strv>(ret_, Runtime.Transfer.Full);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_info (IntPtr raw, IntPtr @namespace, int index);

        internal static BaseInfo GetInfo(UnownedUtf8 @namespace, int index)
        {
            var ret_ = g_irepository_get_info(IntPtr.Zero, @namespace.Handle, index);
            var ret = BaseInfo.GetInstance<BaseInfo>(ret_);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_loaded_namespaces (IntPtr raw);

        /// <summary>
        /// Return the list of currently loaded namespaces.
        /// </summary>
        /// <value>List of namespaces.</value>
        public static Strv LoadedNamespaces {
            get {
                IntPtr raw_ret = g_irepository_get_loaded_namespaces (IntPtr.Zero);
                var ret = Opaque.GetInstance<Strv>(raw_ret, Runtime.Transfer.Full);
                return ret;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern int g_irepository_get_n_infos (IntPtr raw, IntPtr @namespace);

        static int GetNInfos(UnownedUtf8 @namespace)
        {
            var ret = g_irepository_get_n_infos(IntPtr.Zero, @namespace.Handle);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_search_path ();

        /// <summary>
        /// Returns the current search path GIRepository will use when loading typelib files.
        /// </summary>
        /// <value>The search path.</value>
        public static string[] SearchPaths {
            get {
                IntPtr raw_ret = g_irepository_get_search_path ();
                if (raw_ret == IntPtr.Zero) {
                    // if no method has been called yet that uses the native
                    // GIRepository object, g_irepository_get_search_path will
                    // return null. If that is the case, we call g_irepository_get_default
                    // to create the instance and try again.
                    g_irepository_get_default ();
                    raw_ret = g_irepository_get_search_path ();
                }
                var ret = GMarshal.GSListToStringArray (raw_ret);
                return ret!;
            }
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_shared_library (IntPtr raw, IntPtr @namespace);

        internal static NullableUnownedUtf8 GetSharedLibrary(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_shared_library(IntPtr.Zero, @namespace.Handle);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_typelib_path (IntPtr raw, IntPtr @namespace);

        internal static NullableUnownedUtf8 GetTypelibPath(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_typelib_path(IntPtr.Zero, @namespace.Handle);
            var ret = new NullableUnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_get_version (IntPtr raw, IntPtr @namespace);

        internal static UnownedUtf8 GetVersion(UnownedUtf8 @namespace)
        {
            var ret_ = g_irepository_get_version(IntPtr.Zero, @namespace.Handle);
            var ret = new UnownedUtf8(ret_, -1);
            return ret;
        }

        [DllImport("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_irepository_is_registered(IntPtr raw, IntPtr @namespace, IntPtr version);

        /// <summary>
        /// Check whether a particular namespace (and optionally, a specific
        /// version thereof) is currently loaded.
        /// </summary>
        /// <returns><c>true</c> if is registered the specified <c>namespace-version</c>
        /// was loaded; otherwise, <c>false</c>.</returns>
        /// <param name="namespace">Namespace of interest.</param>
        /// <param name="version">Required version or <c>null</c> for latest.</param>
        public static bool IsRegistered(UnownedUtf8 @namespace, NullableUnownedUtf8 version = default)
        {
            var ret = g_irepository_is_registered(IntPtr.Zero, @namespace.Handle, version.Handle);
            return ret;
        }

        /// <summary>
        /// Check whether a particular namespace (and optionally, a specific
        /// version thereof) is currently loaded.
        /// </summary>
        /// <returns><c>true</c> if is registered the specified <c>namespace-version</c>
        /// was loaded; otherwise, <c>false</c>.</returns>
        /// <param name="namespace">Namespace of interest.</param>
        /// <param name="version">Required version or <c>null</c> for latest.</param>
        public static bool IsRegistered(string @namespace, string? version = default)
        {
            using var namespaceUtf8 = @namespace.ToUtf8();
            using var versionUtf8 = version?.ToUtf8();
            return IsRegistered(namespaceUtf8, versionUtf8);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_irepository_prepend_library_path (IntPtr directory);

        /// <summary>
        /// Prepends <paramref name="directory"/> to the search path that is used
        /// to search shared libraries referenced by imported namespaces.
        /// </summary>
        /// <param name="directory">A single directory to scan for shared libraries.</param>
        /// <remarks>
        /// Multiple calls to this function all contribute to the final list of
        /// paths. The list of paths is unique and shared for all GIRepository
        /// instances across the process, but it doesn't affect namespaces imported
        /// before the call.
        ///
        /// If the library is not found in the directories configured in this way,
        /// loading will fall back to the system library path (ie. LD_LIBRARY_PATH
        /// and DT_RPATH in ELF systems). See the documentation of your dynamic
        /// linker for full details.
        /// </remarks>
        public static void PrependLibraryPath(Filename directory)
        {
            g_irepository_prepend_library_path(directory.Handle);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_irepository_prepend_search_path (IntPtr directory);

        /// <summary>
        /// Prepends directory to the typelib search path.
        /// </summary>
        /// <param name="directory">Directory name to prepend to the typelib search path.</param>
        /// <seealso cref="PrependLibraryPath"/>
        public static void PrependSearchPath(Filename directory)
        {
            g_irepository_prepend_search_path(directory.Handle);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_require (IntPtr raw, IntPtr @namespace, IntPtr version, int flags, out IntPtr error);

        /// <summary>
        /// Force the namespace <paramref name="namespace"/> to be loaded if it
        /// isn't already.
        /// </summary>
        /// <param name="namespace">Namespace.</param>
        /// <param name="version">Version.</param>
        /// <param name="flags">Flags.</param>
        /// <exception cref="GErrorException">On failure.</exception>
        /// <remarks>
        /// If <paramref name="namespace"/> is not loaded, this function will
        /// search for a ".typelib" file using the repository search path. In
        /// addition, a version version of namespace may be specified. If version
        /// is not specified, the latest will be used.
        /// </remarks>
        public static void Require(UnownedUtf8 @namespace, NullableUnownedUtf8 version = default,
            RepositoryLoadFlags flags = default)
        {
            g_irepository_require(IntPtr.Zero, @namespace.Handle, version.Handle, (int)flags, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = new Error (error_, Runtime.Transfer.Full);
                throw new GErrorException (error);
            }
        }

        /// <summary>
        /// Force the namespace <paramref name="namespace"/> to be loaded if it
        /// isn't already.
        /// </summary>
        /// <param name="namespace">Namespace.</param>
        /// <param name="version">Version.</param>
        /// <param name="flags">Flags.</param>
        /// <exception cref="GErrorException">On failure.</exception>
        /// <remarks>
        /// If <paramref name="namespace"/> is not loaded, this function will
        /// search for a ".typelib" file using the repository search path. In
        /// addition, a version version of namespace may be specified. If version
        /// is not specified, the latest will be used.
        /// </remarks>
        public static void Require(string @namespace, string? version = default,
            RepositoryLoadFlags flags = default)
        {
            using var namespaceUtf8 = @namespace.ToUtf8();
            using var versionUtf8 = version?.ToUtf8();
            Require(namespaceUtf8, versionUtf8, flags);
        }

        [DllImport ("libgirepository-1.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_irepository_require_private (IntPtr raw, IntPtr typelibDir, IntPtr @namespace, IntPtr version, int flags, out IntPtr error);

        /// <summary>
        /// Force the namespace namespace_ to be loaded if it isn't already.
        /// </summary>
        /// <param name="typelibDir">Private directory where to find the requested typelib.</param>
        /// <param name="namespace">Namespace.</param>
        /// <param name="version">Version of namespace, may be <c>null</c> for latest.</param>
        /// <param name="flags">Flags.</param>
        /// <exception cref="GErrorException">On failure.</exception>
        /// <remarks>
        /// If <paramref name="namespace"/> is not loaded, this function will
        /// search for a ".typelib" file within the private directory only. In
        /// addition, a version <paramref name="version"/> of namespace may be
        /// specified. If <paramref name="version"/> is not specified, the latest
        /// will be used.
        /// </remarks>
        public static void RequirePrivate(UnownedUtf8 typelibDir, UnownedUtf8 @namespace,
            NullableUnownedUtf8 version = default, RepositoryLoadFlags flags = default)
        {
            g_irepository_require_private(IntPtr.Zero, typelibDir.Handle, @namespace.Handle, version.Handle, (int)flags, out var error_);
            if (error_ != IntPtr.Zero) {
                var error = new Error (error_, Runtime.Transfer.Full);
                throw new GErrorException (error);
            }
        }

        /// <summary>
        /// Force the namespace namespace_ to be loaded if it isn't already.
        /// </summary>
        /// <param name="typelibDir">Private directory where to find the requested typelib.</param>
        /// <param name="namespace">Namespace.</param>
        /// <param name="version">Version of namespace, may be <c>null</c> for latest.</param>
        /// <param name="flags">Flags.</param>
        /// <exception cref="GErrorException">On failure.</exception>
        /// <remarks>
        /// If <paramref name="namespace"/> is not loaded, this function will
        /// search for a ".typelib" file within the private directory only. In
        /// addition, a version <paramref name="version"/> of namespace may be
        /// specified. If <paramref name="version"/> is not specified, the latest
        /// will be used.
        /// </remarks>
        public static void RequirePrivate(string typelibDir, string @namespace,
            string? version = default, RepositoryLoadFlags flags = default)
        {
            using var typelibDirUtf8 = typelibDir.ToUtf8();
            using var namespaceUtf8 = @namespace.ToUtf8();
            using var versionUtf8 = version?.ToUtf8();
            RequirePrivate(typelibDirUtf8, namespaceUtf8, versionUtf8, flags);
        }
    }
}
