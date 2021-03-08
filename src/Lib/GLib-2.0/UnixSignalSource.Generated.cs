// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="UnixSignalSource.xmldoc" path="declaration/member[@name='UnixSignalSource']/*" />
    public static unsafe partial class UnixSignalSource
    {
        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added. In GLib 2.54, `SIGWINCH` was added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit ().  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created #GSource
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.30")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Source.UnmanagedStruct* g_unix_signal_source_new(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        int signum);
        static partial void CheckNewArgs(int signum);

        /// <include file="UnixSignalSource.xmldoc" path="declaration/member[@name='UnixSignalSource.New(int)']/*" />
        [GISharp.Runtime.SinceAttribute("2.30")]
        public static GISharp.Lib.GLib.Source New(int signum)
        {
            CheckNewArgs(signum);
            var signum_ = (int)signum;
            var ret_ = g_unix_signal_source_new(signum_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Source>((System.IntPtr)ret_, GISharp.Runtime.Transfer.Full)!;
            return ret;
        }
    }
}