// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="Utility.xmldoc" path="declaration/member[@name='Utility']/*" />
    public static unsafe partial class Utility
    {
        /// <include file="Utility.xmldoc" path="declaration/member[@name='Utility.ApplicationName']/*" />
        [GISharp.Runtime.SinceAttribute("2.2")]
        public static GISharp.Lib.GLib.NullableUnownedUtf8 ApplicationName { get => GetApplicationName(); set => SetApplicationName(value.Value); }

        /// <include file="Utility.xmldoc" path="declaration/member[@name='Utility.ProgramName']/*" />
        public static GISharp.Lib.GLib.NullableUnownedUtf8 ProgramName { get => GetProgramName(); set => SetProgramName(value.Value); }

        /// <summary>
        /// Gets a human-readable name for the application, as set by
        /// g_set_application_name(). This name should be localized if
        /// possible, and is intended for display to the user.  Contrast with
        /// g_get_prgname(), which gets a non-localized name. If
        /// g_set_application_name() has not been called, returns the result of
        /// g_get_prgname() (which may be %NULL if g_set_prgname() has also not
        /// been called).
        /// </summary>
        /// <returns>
        /// human-readable application
        ///   name. May return %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.2")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_get_application_name();
        static partial void CheckGetApplicationNameArgs();

        [GISharp.Runtime.SinceAttribute("2.2")]
        private static GISharp.Lib.GLib.NullableUnownedUtf8 GetApplicationName()
        {
            CheckGetApplicationNameArgs();
            var ret_ = g_get_application_name();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Sets a human-readable name for the application. This name should be
        /// localized if possible, and is intended for display to the user.
        /// Contrast with g_set_prgname(), which sets a non-localized name.
        /// g_set_prgname() will be called automatically by gtk_init(),
        /// but g_set_application_name() will not.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that for thread safety reasons, this function can only
        /// be called once.
        /// </para>
        /// <para>
        /// The application name will be used in contexts such as error messages,
        /// or when displaying an application's name in the task list.
        /// </para>
        /// </remarks>
        /// <param name="applicationName">
        /// localized name of the application
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.2")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_set_application_name(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* applicationName);
        static partial void CheckSetApplicationNameArgs(GISharp.Lib.GLib.UnownedUtf8 applicationName);

        [GISharp.Runtime.SinceAttribute("2.2")]
        private static void SetApplicationName(GISharp.Lib.GLib.UnownedUtf8 applicationName)
        {
            CheckSetApplicationNameArgs(applicationName);
            var applicationName_ = (byte*)applicationName.UnsafeHandle;
            g_set_application_name(applicationName_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Gets the name of the program. This name should not be localized,
        /// in contrast to g_get_application_name().
        /// </summary>
        /// <remarks>
        /// <para>
        /// If you are using #GApplication the program name is set in
        /// g_application_run(). In case of GDK or GTK+ it is set in
        /// gdk_init(), which is called by gtk_init() and the
        /// #GtkApplication::startup handler. The program name is found by
        /// taking the last component of @argv[0].
        /// </para>
        /// </remarks>
        /// <returns>
        /// the name of the program,
        ///   or %NULL if it has not been set yet. The returned string belongs
        ///   to GLib and must not be modified or freed.
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern byte* g_get_prgname();
        static partial void CheckGetProgramNameArgs();

        private static GISharp.Lib.GLib.NullableUnownedUtf8 GetProgramName()
        {
            CheckGetProgramNameArgs();
            var ret_ = g_get_prgname();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = new GISharp.Lib.GLib.NullableUnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Sets the name of the program. This name should not be localized,
        /// in contrast to g_set_application_name().
        /// </summary>
        /// <remarks>
        /// <para>
        /// If you are using #GApplication the program name is set in
        /// g_application_run(). In case of GDK or GTK+ it is set in
        /// gdk_init(), which is called by gtk_init() and the
        /// #GtkApplication::startup handler. The program name is found by
        /// taking the last component of @argv[0].
        /// </para>
        /// <para>
        /// Note that for thread-safety reasons this function can only be called once.
        /// </para>
        /// </remarks>
        /// <param name="prgname">
        /// the name of the program.
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_set_prgname(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* prgname);
        static partial void CheckSetProgramNameArgs(GISharp.Lib.GLib.UnownedUtf8 prgname);

        private static void SetProgramName(GISharp.Lib.GLib.UnownedUtf8 prgname)
        {
            CheckSetProgramNameArgs(prgname);
            var prgname_ = (byte*)prgname.UnsafeHandle;
            g_set_prgname(prgname_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}