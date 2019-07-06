// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// When doing file operations that may take a while, such as moving
    /// a file or copying a file, a progress callback is used to pass how
    /// far along that operation is to the application.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate void UnmanagedFileProgressCallback(
    /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
    /* transfer-ownership:none direction:in */
    System.Int64 currentNumBytes,
    /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
    /* transfer-ownership:none direction:in */
    System.Int64 totalNumBytes,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// When doing file operations that may take a while, such as moving
    /// a file or copying a file, a progress callback is used to pass how
    /// far along that operation is to the application.
    /// </summary>
    public delegate void FileProgressCallback(System.Int64 currentNumBytes, System.Int64 totalNumBytes);

    /// <summary>
    /// Factory for creating <see cref="FileProgressCallback"/> methods.
    /// </summary>
    public static class FileProgressCallbackFactory
    {
        unsafe class UserData
        {
            public readonly GISharp.Lib.Gio.FileProgressCallback ManagedDelegate;
            public readonly GISharp.Lib.Gio.UnmanagedFileProgressCallback UnmanagedDelegate;
            public readonly GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.Gio.FileProgressCallback managedDelegate, GISharp.Lib.Gio.UnmanagedFileProgressCallback unmanagedDelegate, GISharp.Lib.GLib.UnmanagedDestroyNotify destroyDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                UnmanagedDelegate = unmanagedDelegate;
                DestroyDelegate = destroyDelegate;
                Scope = scope;
            }
        }

        public static GISharp.Lib.Gio.FileProgressCallback Create(GISharp.Lib.Gio.UnmanagedFileProgressCallback callback, System.IntPtr userData)
        {
            unsafe void callback_(System.Int64 currentNumBytes, System.Int64 totalNumBytes)
            {
                var userData_  =  userData ;
                var currentNumBytes_  =  ( System . Int64 ) currentNumBytes ;
                var totalNumBytes_  =  ( System . Int64 ) totalNumBytes ;
                callback(currentNumBytes_, totalNumBytes_, userData_);
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="FileProgressCallback"/> in an anonymous method that can
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
        public static unsafe (GISharp.Lib.Gio.UnmanagedFileProgressCallback, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.FileProgressCallback callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData(callback, UnmanagedCallback, Destroy, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe void UnmanagedCallback(System.Int64 currentNumBytes_, System.Int64 totalNumBytes_, System.IntPtr userData_)
        {
            try
            {
                var currentNumBytes = (System.Int64)currentNumBytes_;
                var totalNumBytes = (System.Int64)totalNumBytes_;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                userData.ManagedDelegate(currentNumBytes, totalNumBytes);
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