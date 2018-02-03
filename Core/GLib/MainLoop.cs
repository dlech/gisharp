using System;
using System.Runtime.InteropServices;
using System.Threading;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The `GMainLoop` struct is an opaque data type
    /// representing the main event loop of a GLib or GTK+ application.
    /// </summary>
    [GType ("GMainLoop", IsProxyForUnmanagedType = true)]
    public sealed class MainLoop : Boxed
    {
        public MainLoop(IntPtr handle, Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_main_loop_ref (IntPtr loop);

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_main_loop_unref (IntPtr loop);

        /// <summary>
        /// Creates a new #GMainLoop structure.
        /// </summary>
        /// <param name="context">
        /// a #GMainContext  (if %NULL, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to %TRUE to indicate that the loop is running. This
        /// is not very important since calling g_main_loop_run() will set this to
        /// %TRUE anyway.
        /// </param>
        /// <returns>
        /// a new #GMainLoop.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_main_loop_new (
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
            /* transfer-ownership:none nullable:1 allow-none:1 */
            IntPtr context,
            /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
            /* transfer-ownership:none */
            bool isRunning);

        static IntPtr New (MainContext context = null, bool isRunning = false)
        {
            var ret = g_main_loop_new (context?.Handle ?? IntPtr.Zero, isRunning);
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="MainLoop"/> structure.
        /// </summary>
        /// <param name="context">
        /// a <see cref="MainContext"/>  (if <c>null</c>, the default context will be used).
        /// </param>
        /// <param name="isRunning">
        /// set to <c>true</c> to indicate that the loop is running. This
        /// is not very important since calling <see cref="Run"/> will set this to
        /// <c>true</c> anyway.
        /// </param>
        public MainLoop (MainContext context = null, bool isRunning = false)
            : this (New (context, isRunning), Transfer.Full)
        {
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_main_loop_get_type ();

        static readonly GType _GType = g_main_loop_get_type();

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_main_loop_get_context (
            /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" /> */
            /* transfer-ownership:none */
            IntPtr loop);

        /// <summary>
        /// Returns the <see cref="MainContext"/> of this loop.
        /// </summary>
        /// <returns>
        /// the <see cref="MainContext"/> of this loop
        /// </returns>
        public MainContext Context {
            get {
                AssertNotDisposed ();
                var ret_ = g_main_loop_get_context (handle);
                var ret = GetInstance<MainContext> (ret_, Transfer.None);
                return ret;
            }
        }

        /// <summary>
        /// Checks to see if the main loop is currently being run via g_main_loop_run().
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// %TRUE if the mainloop is currently being run.
        /// </returns>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        static extern bool g_main_loop_is_running (
            /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" /> */
            /* transfer-ownership:none */
            IntPtr loop);

        /// <summary>
        /// Checks to see if the main loop is currently being run via <see cref="Run"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the mainloop is currently being run.
        /// </returns>
        public bool IsRunning {
            get {
                AssertNotDisposed ();
                var ret = g_main_loop_is_running (handle);
                return ret;
            }
        }

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </remarks>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_loop_quit (
            /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" /> */
            /* transfer-ownership:none */
            IntPtr loop);

        /// <summary>
        /// Stops a <see cref="MainLoop"/> from running. Any calls to <see cref="Run"/>
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// Note that sources that have already been dispatched when
        /// <see cref="Quit"/> is called will still be executed.
        /// </remarks>
        public void Quit ()
        {
            AssertNotDisposed ();
            g_main_loop_quit (handle);
        }

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_main_loop_run (
            /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" /> */
            /* transfer-ownership:none */
            IntPtr loop);

        /// <summary>
        /// Runs a main loop until <see cref="Quit"/> is called on the loop.
        /// If this is called for the thread of the loop's <see cref="MainContext"/>
        /// it will process events from the loop, otherwise it will simply wait.
        /// </summary>
        /// <remarks>
        /// This also has the effect of setting the <see cref="SynchronizationContext"/>
        /// so that .NET async works transparently with the <see cref="MainLoop"/>.
        /// </remarks>
        public void Run ()
        {
            AssertNotDisposed ();
            var oldSyncContext = SynchronizationContext.Current;
            try {
                var newSyncContext = Context.SynchronizationContext;
                SynchronizationContext.SetSynchronizationContext (newSyncContext);
                g_main_loop_run (handle);
            } finally {
                SynchronizationContext.SetSynchronizationContext (oldSyncContext);
            }
        }
    }
}
