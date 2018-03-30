// ATTENTION: This file is automatically generated. Do not edit by manually.
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// This callback type is used by g_file_measure_disk_usage() to make
    /// periodic progress reports when measuring the amount of disk spaced
    /// used by a directory.
    /// </summary>
    /// <remarks>
    /// These calls are made on a best-effort basis and not all types of
    /// #GFile will support them.  At the minimum, however, one call will
    /// always be made immediately.
    /// 
    /// In the case that there is no support, @reporting will be set to
    /// %FALSE (and the other values undefined) and no further calls will be
    /// made.  Otherwise, the @reporting will be %TRUE and the other values
    /// all-zeros during the first (immediate) call.  In this way, you can
    /// know which type of progress UI to show without a delay.
    /// 
    /// For g_file_measure_disk_usage() the callback is made directly.  For
    /// g_file_measure_disk_usage_async() the callback is made via the
    /// default main context of the calling thread (ie: the same way that the
    /// final async result would be reported).
    /// 
    /// @current_size is in the same units as requested by the operation (see
    /// %G_FILE_DISK_USAGE_APPARENT_SIZE).
    /// 
    /// The frequency of the updates is implementation defined, but is
    /// ideally about once every 200ms.
    /// 
    /// The last progress callback may or may not be equal to the final
    /// result.  Always check the async result to get the final value.
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.38")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate void UnmanagedFileMeasureProgressCallback(
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    System.Boolean reporting,
    /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
    /* transfer-ownership:none direction:in */
    System.UInt64 currentSize,
    /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
    /* transfer-ownership:none direction:in */
    System.UInt64 numDirs,
    /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
    /* transfer-ownership:none direction:in */
    System.UInt64 numFiles,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:4 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// This callback type is used by g_file_measure_disk_usage() to make
    /// periodic progress reports when measuring the amount of disk spaced
    /// used by a directory.
    /// </summary>
    /// <remarks>
    /// These calls are made on a best-effort basis and not all types of
    /// <see cref="IFile"/> will support them.  At the minimum, however, one call will
    /// always be made immediately.
    /// 
    /// In the case that there is no support, <paramref name="reporting"/> will be set to
    /// <c>false</c> (and the other values undefined) and no further calls will be
    /// made.  Otherwise, the <paramref name="reporting"/> will be <c>true</c> and the other values
    /// all-zeros during the first (immediate) call.  In this way, you can
    /// know which type of progress UI to show without a delay.
    /// 
    /// For g_file_measure_disk_usage() the callback is made directly.  For
    /// g_file_measure_disk_usage_async() the callback is made via the
    /// default main context of the calling thread (ie: the same way that the
    /// final async result would be reported).
    /// 
    /// <paramref name="currentSize"/> is in the same units as requested by the operation (see
    /// %G_FILE_DISK_USAGE_APPARENT_SIZE).
    /// 
    /// The frequency of the updates is implementation defined, but is
    /// ideally about once every 200ms.
    /// 
    /// The last progress callback may or may not be equal to the final
    /// result.  Always check the async result to get the final value.
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.38")]
    public delegate void FileMeasureProgressCallback(System.Boolean reporting, System.UInt64 currentSize, System.UInt64 numDirs, System.UInt64 numFiles);

    /// <summary>
    /// Factory for creating <see cref="FileMeasureProgressCallback"/> methods.
    /// </summary>
    public static class FileMeasureProgressCallbackFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.Gio.FileMeasureProgressCallback ManagedDelegate;
            public GISharp.Lib.Gio.UnmanagedFileMeasureProgressCallback UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.Gio.FileMeasureProgressCallback Create(GISharp.Lib.Gio.UnmanagedFileMeasureProgressCallback callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(System.Boolean reporting, System.UInt64 currentSize, System.UInt64 numDirs, System.UInt64 numFiles)
            {
                var userData_ = userData;
                var reporting_ = (System.Boolean)reporting;
                var currentSize_ = (System.UInt64)currentSize;
                var numDirs_ = (System.UInt64)numDirs;
                var numFiles_ = (System.UInt64)numFiles;
                callback(reporting_, currentSize_, numDirs_, numFiles_, userData_);
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="FileMeasureProgressCallback"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static unsafe (GISharp.Lib.Gio.UnmanagedFileMeasureProgressCallback, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.FileMeasureProgressCallback callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe void UnmanagedCallback(System.Boolean reporting_, System.UInt64 currentSize_, System.UInt64 numDirs_, System.UInt64 numFiles_, System.IntPtr userData_)
        {
            try
            {
                var reporting = (System.Boolean)reporting_;
                var currentSize = (System.UInt64)currentSize_;
                var numDirs = (System.UInt64)numDirs_;
                var numFiles = (System.UInt64)numFiles_;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                userData.ManagedDelegate(reporting, currentSize, numDirs, numFiles);
                if (userData.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(userData_);
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }
}