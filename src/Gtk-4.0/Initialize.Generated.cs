// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gtk
{
    /// <include file="Initialize.xmldoc" path="declaration/member[@name='Initialize']/*" />
    public static partial class Initialize
    {
        /// <include file="Initialize.xmldoc" path="declaration/member[@name='Initialize.IsInitialized']/*" />
        public static System.Boolean IsInitialized { get => GetIsInitialized(); }

        static partial void CheckDisableSetlocaleArgs();

        /// <summary>
        /// Prevents gtk_init(), gtk_init_check() and
        /// gtk_parse_args() from automatically
        /// calling `setlocale (LC_ALL, "")`. You would
        /// want to use this function if you wanted to set the locale for
        /// your program to something other than the user’s locale, or if
        /// you wanted to set different values for different locale categories.
        /// </summary>
        /// <remarks>
        /// Most programs should not need to call this function.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void gtk_disable_setlocale();

        /// <include file="Initialize.xmldoc" path="declaration/member[@name='Initialize.DisableSetlocale()']/*" />
        public static unsafe void DisableSetlocale()
        {
            CheckDisableSetlocaleArgs();
            gtk_disable_setlocale();
        }

        static partial void CheckInitArgs();

        /// <summary>
        /// Call this function before using any other GTK functions in your GUI
        /// applications.  It will initialize everything needed to operate the
        /// toolkit and parses some standard command line options.
        /// </summary>
        /// <remarks>
        /// If you are using #GtkApplication, you don't have to call gtk_init()
        /// or gtk_init_check(); the #GApplication::startup handler
        /// does it for you.
        /// 
        /// This function will terminate your program if it was unable to
        /// initialize the windowing system for some reason. If you want
        /// your program to fall back to a textual interface you want to
        /// call gtk_init_check() instead.
        /// 
        /// GTK calls `signal (SIGPIPE, SIG_IGN)`
        /// during initialization, to ignore SIGPIPE signals, since these are
        /// almost never wanted in graphical applications. If you do need to
        /// handle SIGPIPE for some reason, reset the handler after gtk_init(),
        /// but notice that other libraries (e.g. libdbus or gvfs) might do
        /// similar things.
        /// </remarks>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void gtk_init();

        /// <include file="Initialize.xmldoc" path="declaration/member[@name='Initialize.Init()']/*" />
        public static unsafe void Init()
        {
            CheckInitArgs();
            gtk_init();
        }

        static partial void CheckTryInitArgs();

        /// <summary>
        /// This function does the same work as gtk_init() with only a single
        /// change: It does not terminate the program if the windowing system
        /// can’t be initialized. Instead it returns %FALSE on failure.
        /// </summary>
        /// <remarks>
        /// This way the application can fall back to some other means of
        /// communication with the user - for example a curses or command line
        /// interface.
        /// </remarks>
        /// <returns>
        /// %TRUE if the windowing system has been successfully
        ///     initialized, %FALSE otherwise
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Runtime.Boolean gtk_init_check();

        /// <include file="Initialize.xmldoc" path="declaration/member[@name='Initialize.TryInit()']/*" />
        public static unsafe System.Boolean TryInit()
        {
            CheckTryInitArgs();
            var ret_ = gtk_init_check();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        static partial void CheckGetIsInitializedArgs();

        /// <summary>
        /// Use this function to check if GTK has been initialized with gtk_init()
        /// or gtk_init_check().
        /// </summary>
        /// <returns>
        /// the initialization status
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("gtk-4.1", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Runtime.Boolean gtk_is_initialized();

        private static unsafe System.Boolean GetIsInitialized()
        {
            CheckGetIsInitializedArgs();
            var ret_ = gtk_is_initialized();
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }
    }
}