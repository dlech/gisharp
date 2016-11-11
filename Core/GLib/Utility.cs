using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GLib
{
    public static class Utility
    {
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_get_application_name ();

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_set_application_name (IntPtr applicationName);

        /// <summary>
        /// Gets or sets a human-readable name for the application.
        /// </summary>
        /// <remarks>
        /// This name should be localized if possible, and is intended for
        /// display to the user. Contrast with <see cref="ProgramName"/>, which
        /// sets a non-localized name. <see cref="ProgramName"/> will be set
        /// automatically by <see cref="Gtk.Init"/>, but <see cref="ApplicationName"/>
        /// will not be set.
        ///
        /// Note that for thread safety reasons, this can only be set once.
        ///
        /// The application name will be used in contexts such as error messages,
        /// or when displaying an application's name in the task list.
        /// </remarks>
        /// <value>Localized, name of the application.</value>
        public static string ApplicationName {
            get {
                var ret_ = g_get_application_name ();
                var ret = MarshalG.Utf8PtrToString (ret_);
                return ret;
            }
            set {
                var value_ = MarshalG.StringToUtf8Ptr (value);
                g_set_application_name (value_);
                MarshalG.Free (value_);
            }
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_get_prgname ();

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_set_prgname (IntPtr applicationName);

        /// <summary>
        /// Gets or sets the name of the program. This name should not be
        /// localized, in contrast to <see cref="ApplicationName"/>.
        /// </summary>
        /// <remarks>
        /// If you are using GDK or GTK+ the program name is set in <see cref="Gdk.Init"/>,
        /// which is called by <see cref="Gtk.Init"/>. The program name is found
        /// by taking the last component of <c>argv [0]</c>.
        /// </remarks>
        /// <value>The name of the program.</value>
        public static string ProgramName {
            get {
                var ret_ = g_get_prgname ();
                var ret = MarshalG.Utf8PtrToString (ret_);
                return ret;
            }
            set {
                var value_ = MarshalG.StringToUtf8Ptr (value);
                g_set_prgname (value_);
                MarshalG.Free (value_);
            }
        }
    }
}
