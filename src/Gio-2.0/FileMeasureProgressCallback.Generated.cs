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
    /// %G_FILE_MEASURE_APPARENT_SIZE).
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
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedFileMeasureProgressCallback(
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Runtime.Boolean reporting,
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

    /// <include file="FileMeasureProgressCallback.xmldoc" path="declaration/member[@name='FileMeasureProgressCallback']/*" />
    [GISharp.Runtime.SinceAttribute("2.38")]
    public delegate void FileMeasureProgressCallback(System.Boolean reporting, System.UInt64 currentSize, System.UInt64 numDirs, System.UInt64 numFiles);

    /// <summary>
    /// Class for marshalling <see cref="FileMeasureProgressCallback"/> methods.
    /// </summary>
    public static unsafe class FileMeasureProgressCallbackMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.Gio.FileMeasureProgressCallback ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.Gio.FileMeasureProgressCallback managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="FileMeasureProgressCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.FileMeasureProgressCallback FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.Gio.UnmanagedFileMeasureProgressCallback>(callback_);
            void managedCallback(System.Boolean reporting, System.UInt64 currentSize, System.UInt64 numDirs, System.UInt64 numFiles) { var reporting_ = GISharp.Runtime.BooleanExtensions.ToBoolean(reporting); var currentSize_ = (System.UInt64)currentSize; var numDirs_ = (System.UInt64)numDirs; var numFiles_ = (System.UInt64)numFiles; unmanagedCallback(reporting_, currentSize_, numDirs_, numFiles_, userData_); }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="FileMeasureProgressCallback"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="callback">The managed callback method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing a pointer to the unmanaged callback, a pointer to the
        /// unmanaged notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToUnmanagedFunctionPointer(GISharp.Lib.Gio.FileMeasureProgressCallback? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback is null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static void UnmanagedCallback(GISharp.Runtime.Boolean reporting_, System.UInt64 currentSize_, System.UInt64 numDirs_, System.UInt64 numFiles_, System.IntPtr userData_)
        {
            try
            {
                var reporting = GISharp.Runtime.BooleanExtensions.IsTrue(reporting_);
                var currentSize = (System.UInt64)currentSize_;
                var numDirs = (System.UInt64)numDirs_;
                var numFiles = (System.UInt64)numFiles_;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target!;
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

        static readonly GISharp.Lib.Gio.UnmanagedFileMeasureProgressCallback UnmanagedCallbackDelegate = UnmanagedCallback;
        static readonly System.IntPtr callback_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(UnmanagedCallbackDelegate);

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

        static readonly GISharp.Lib.GLib.UnmanagedDestroyNotify UnmanagedDestroyDelegate = Destroy;
        static readonly System.IntPtr destroy_ = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(UnmanagedDestroyDelegate);
    }
}