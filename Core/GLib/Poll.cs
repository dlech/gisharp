
using System.Runtime.InteropServices;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// Represents a file descriptor, which events to poll for, and which events
    /// occurred.
    /// </summary>
    [GType ("GPollFD", IsWrappedUnmanagedType = true)]
    public partial struct PollFD
    {
        /// <summary>
        /// the file descriptor to poll (or a HANDLE on Win32)
        /// </summary>
        public int Fd;

        /// <summary>
        /// a bitwise combination from #GIOCondition, specifying which
        /// events should be polled for. Typically for reading from a file
        /// descriptor you would use %G_IO_IN | %G_IO_HUP | %G_IO_ERR, and
        /// for writing you would use %G_IO_OUT | %G_IO_ERR.
        /// </summary>
        public ushort Events;

        /// <summary>
        /// a bitwise combination of flags from #GIOCondition, returned
        /// from the poll() function to indicate which events occurred.
        /// </summary>
        public ushort Revents;

        [DllImport ("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="GType" managed-name="GType" /> */
        /* */
        static extern GType g_pollfd_get_type ();

        static GType getGType ()
        {
            var ret = g_pollfd_get_type ();
            return ret;
        }
    }
}
