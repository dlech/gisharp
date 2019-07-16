
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    public sealed class UnixSignalSource : Source
    {
        const int SIGHUP = 1;
        const int SIGINT = 2;
        const int SIGQUIT = 3;

        /// <summary>
        /// Create a #GSource that will be dispatched upon delivery of the UNIX
        /// signal @signum.  In GLib versions before 2.36, only `SIGHUP`, `SIGINT`,
        /// `SIGTERM` can be monitored.  In GLib 2.36, `SIGUSR1` and `SIGUSR2`
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked g_unix_signal_source_new().
        /// 
        /// For example, an effective use of this function is to handle `SIGTERM`
        /// cleanly; flushing any outstanding files, and then calling
        /// g_main_loop_quit().  It is not safe to do any of this a regular
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
        [Since("2.30")]
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" /> */
        /* transfer-ownership:full */
        static extern IntPtr g_unix_signal_source_new(
            /* <type name="gint" type="gint" managed-name="Gint" /> */
            /* transfer-ownership:none */
            int signum);

        /// <summary>
        /// Create a <see cref="Source"/> that will be dispatched upon delivery of the UNIX
        /// signal <paramref name="signum"/>.  In GLib versions before 2.36, only <c>SIGHUP</c>, <c>SIGINT</c>,
        /// <c>SIGTERM</c> can be monitored.  In GLib 2.36, <c>SIGUSR1</c> and <c>SIGUSR2</c>
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked <see cref="M:UnixSignalSource.#ctor"/>.
        /// 
        /// For example, an effective use of this function is to handle <c>SIGTERM</c>
        /// cleanly; flushing any outstanding files, and then calling
        /// <see cref="MainLoop.Quit"/>.  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        /// <returns>
        /// A newly created <see cref="Source"/>
        /// </returns>
        [Since("2.30")]
        static IntPtr New(int signum)
        {
            if (signum != SIGHUP && signum != SIGINT && signum != SIGQUIT) {
                throw new ArgumentException("Only SIGHUP, SIGINT, SIGQUIT allowed", nameof(signum));
            }
            // TODO: add check for SIGUSR1, SIGUSR2, SIGWINCH based on runtime version
            var ret = g_unix_signal_source_new(signum);
            return ret;
        }

        /// <summary>
        /// Create a <see cref="Source"/> that will be dispatched upon delivery of the UNIX
        /// signal <paramref name="signum"/>.  In GLib versions before 2.36, only <c>SIGHUP</c>, <c>SIGINT</c>,
        /// <c>SIGTERM</c> can be monitored.  In GLib 2.36, <c>SIGUSR1</c> and <c>SIGUSR2</c>
        /// were added.
        /// </summary>
        /// <remarks>
        /// Note that unlike the UNIX default, all sources which have created a
        /// watch will be dispatched, regardless of which underlying thread
        /// invoked <see cref="M:UnixSignalSource.#ctor"/>.
        /// 
        /// For example, an effective use of this function is to handle <c>SIGTERM</c>
        /// cleanly; flushing any outstanding files, and then calling
        /// <see cref="MainLoop.Quit"/>.  It is not safe to do any of this a regular
        /// UNIX signal handler; your handler may be invoked while malloc() or
        /// another library function is running, causing reentrancy if you
        /// attempt to use it from the handler.  None of the GLib/GObject API
        /// is safe against this kind of reentrancy.
        /// 
        /// The interaction of this source when combined with native UNIX
        /// functions like sigprocmask() is not defined.
        /// 
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Source.Attach"/> before it will be
        /// executed.
        /// </remarks>
        /// <param name="signum">
        /// A signal number
        /// </param>
        public UnixSignalSource(int signum) : this(New(signum), Transfer.Full)
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UnixSignalSource(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public void SetCallback(SourceFunc func)
        {
            SetCallback<SourceFunc>(func, SourceFuncMarshal.ToPointer);
        }
    }
}
