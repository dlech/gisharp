// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// This callback type is used by g_file_measure_disk_usage() to make
    /// periodic progress reports when measuring the amount of disk spaced
    /// used by a directory.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These calls are made on a best-effort basis and not all types of
    /// #GFile will support them.  At the minimum, however, one call will
    /// always be made immediately.
    /// </para>
    /// <para>
    /// In the case that there is no support, @reporting will be set to
    /// %FALSE (and the other values undefined) and no further calls will be
    /// made.  Otherwise, the @reporting will be %TRUE and the other values
    /// all-zeros during the first (immediate) call.  In this way, you can
    /// know which type of progress UI to show without a delay.
    /// </para>
    /// <para>
    /// For g_file_measure_disk_usage() the callback is made directly.  For
    /// g_file_measure_disk_usage_async() the callback is made via the
    /// default main context of the calling thread (ie: the same way that the
    /// final async result would be reported).
    /// </para>
    /// <para>
    /// @current_size is in the same units as requested by the operation (see
    /// %G_FILE_MEASURE_APPARENT_SIZE).
    /// </para>
    /// <para>
    /// The frequency of the updates is implementation defined, but is
    /// ideally about once every 200ms.
    /// </para>
    /// <para>
    /// The last progress callback may or may not be equal to the final
    /// result.  Always check the async result to get the final value.
    /// </para>
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.38")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedFileMeasureProgressCallback(
    /* <type name="gboolean" type="gboolean" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Runtime.Boolean reporting,
    /* <type name="guint64" type="guint64" /> */
    /* transfer-ownership:none direction:in */
    ulong currentSize,
    /* <type name="guint64" type="guint64" /> */
    /* transfer-ownership:none direction:in */
    ulong numDirs,
    /* <type name="guint64" type="guint64" /> */
    /* transfer-ownership:none direction:in */
    ulong numFiles,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
    System.IntPtr userData);

    /// <include file="FileMeasureProgressCallback.xmldoc" path="declaration/member[@name='FileMeasureProgressCallback']/*" />
    [GISharp.Runtime.SinceAttribute("2.38")]
    public delegate void FileMeasureProgressCallback(bool reporting, ulong currentSize, ulong numDirs, ulong numFiles);

    /// <summary>
    /// Class for marshalling <see cref="FileMeasureProgressCallback"/> methods.
    /// </summary>
    public static unsafe class FileMeasureProgressCallbackMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="FileMeasureProgressCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.FileMeasureProgressCallback FromPointer(delegate* unmanaged[Cdecl]<GISharp.Runtime.Boolean, ulong, ulong, ulong, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(bool reporting, ulong currentSize, ulong numDirs, ulong numFiles)
            {
                var reporting_ = GISharp.Runtime.BooleanExtensions.ToBoolean(reporting);
                var currentSize_ = (ulong)currentSize;
                var numDirs_ = (ulong)numDirs;
                var numFiles_ = (ulong)numFiles;
                callback_(reporting_, currentSize_, numDirs_, numFiles_, userData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static void Callback(GISharp.Runtime.Boolean reporting_, ulong currentSize_, ulong numDirs_, ulong numFiles_, System.IntPtr userData_)
        {
            try
            {
                var reporting = GISharp.Runtime.BooleanExtensions.IsTrue(reporting_);
                var currentSize = (ulong)currentSize_;
                var numDirs = (ulong)numDirs_;
                var numFiles = (ulong)numFiles_;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((FileMeasureProgressCallback, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                userData.Invoke(reporting, currentSize, numDirs, numFiles);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }
    }
}