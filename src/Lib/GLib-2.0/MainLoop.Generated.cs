// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="MainLoop.xmldoc" path="declaration/member[@name='MainLoop']/*" />
    [GISharp.Runtime.GTypeAttribute("GMainLoop", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class MainLoop : GISharp.Runtime.Boxed
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_main_loop_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public struct UnmanagedStruct
        {
        }

        /// <include file="MainLoop.xmldoc" path="declaration/member[@name='MainLoop.Context']/*" />
        public GISharp.Lib.GLib.MainContext Context { get => GetContext(); }

        /// <include file="MainLoop.xmldoc" path="declaration/member[@name='MainLoop.IsRunning']/*" />
        public bool IsRunning { get => GetIsRunning(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MainLoop(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle)
        {
            if (ownership == GISharp.Runtime.Transfer.None)
            {
                this.handle = (System.IntPtr)g_main_loop_ref((UnmanagedStruct*)handle);
            }
        }

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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.MainLoop.UnmanagedStruct* g_main_loop_new(
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.MainContext.UnmanagedStruct* context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.Boolean isRunning);
        static partial void CheckNewArgs(GISharp.Lib.GLib.MainContext? context = null, bool isRunning = false);

        static GISharp.Lib.GLib.MainLoop.UnmanagedStruct* New(GISharp.Lib.GLib.MainContext? context = null, bool isRunning = false)
        {
            CheckNewArgs(context, isRunning);
            var context_ = (GISharp.Lib.GLib.MainContext.UnmanagedStruct*)(context?.UnsafeHandle ?? System.IntPtr.Zero);
            var isRunning_ = GISharp.Runtime.BooleanExtensions.ToBoolean(isRunning);
            var ret_ = g_main_loop_new(context_,isRunning_);
            return ret_;
        }

        /// <include file="MainLoop.xmldoc" path="declaration/member[@name='MainLoop.MainLoop(GISharp.Lib.GLib.MainContext?,bool)']/*" />
        public MainLoop(GISharp.Lib.GLib.MainContext? context = null, bool isRunning = false) : this((System.IntPtr)New(context, isRunning), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_main_loop_get_type();

        /// <summary>
        /// Returns the #GMainContext of @loop.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop.
        /// </param>
        /// <returns>
        /// the #GMainContext of @loop
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="MainContext" type="GMainContext*" managed-name="MainContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GLib.MainContext.UnmanagedStruct* g_main_loop_get_context(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);
        partial void CheckGetContextArgs();

        private GISharp.Lib.GLib.MainContext GetContext()
        {
            CheckGetContextArgs();
            var loop_ = (GISharp.Lib.GLib.MainLoop.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_main_loop_get_context(loop_);
            var ret = GISharp.Lib.GLib.MainContext.GetInstance<GISharp.Lib.GLib.MainContext>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Runtime.Boolean g_main_loop_is_running(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);
        partial void CheckGetIsRunningArgs();

        private bool GetIsRunning()
        {
            CheckGetIsRunningArgs();
            var loop_ = (GISharp.Lib.GLib.MainLoop.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_main_loop_is_running(loop_);
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Stops a #GMainLoop from running. Any calls to g_main_loop_run()
        /// for the loop will return.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that sources that have already been dispatched when
        /// g_main_loop_quit() is called will still be executed.
        /// </para>
        /// </remarks>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_main_loop_quit(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);
        partial void CheckQuitArgs();

        /// <include file="MainLoop.xmldoc" path="declaration/member[@name='MainLoop.Quit()']/*" />
        public void Quit()
        {
            CheckQuitArgs();
            var loop_ = (GISharp.Lib.GLib.MainLoop.UnmanagedStruct*)UnsafeHandle;
            g_main_loop_quit(loop_);
        }

        /// <summary>
        /// Increases the reference count on a #GMainLoop object by one.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        /// <returns>
        /// @loop
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.MainLoop.UnmanagedStruct* g_main_loop_ref(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);

        /// <summary>
        /// Takes ownership of the unmanaged pointer without freeing it.
        /// The managed object can no longer be used (will throw disposed exception).
        /// </summary>
        public override System.IntPtr Take() => (System.IntPtr)g_main_loop_ref((GISharp.Lib.GLib.MainLoop.UnmanagedStruct*)UnsafeHandle);

        /// <summary>
        /// Runs a main loop until g_main_loop_quit() is called on the loop.
        /// If this is called for the thread of the loop's #GMainContext,
        /// it will process events from the loop, otherwise it will
        /// simply wait.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_main_loop_run(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);

        /// <summary>
        /// Decreases the reference count on a #GMainLoop object by one. If
        /// the result is zero, free the loop and free all associated memory.
        /// </summary>
        /// <param name="loop">
        /// a #GMainLoop
        /// </param>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_main_loop_unref(
        /* <type name="MainLoop" type="GMainLoop*" managed-name="MainLoop" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.MainLoop.UnmanagedStruct* loop);

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != System.IntPtr.Zero)
            {
                g_main_loop_unref((UnmanagedStruct*)handle);
            }

            base.Dispose(disposing);
        }
    }
}