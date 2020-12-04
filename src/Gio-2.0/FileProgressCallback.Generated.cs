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

    /// <include file="FileProgressCallback.xmldoc" path="declaration/member[@name='FileProgressCallback']/*" />
    public delegate void FileProgressCallback(System.Int64 currentNumBytes, System.Int64 totalNumBytes);

    /// <summary>
    /// Class for marshalling <see cref="FileProgressCallback"/> methods.
    /// </summary>
    public static class FileProgressCallbackMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.Gio.FileProgressCallback ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.Gio.FileProgressCallback managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="FileProgressCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.FileProgressCallback FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.Gio.UnmanagedFileProgressCallback>(callback_);

            unsafe void managedCallback(System.Int64 currentNumBytes, System.Int64 totalNumBytes)
            {
                var currentNumBytes_ = (System.Int64)currentNumBytes;
                var totalNumBytes_ = (System.Int64)totalNumBytes;
                unmanagedCallback(currentNumBytes_, totalNumBytes_, userData_);
            }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="FileProgressCallback"/> in an anonymous method that can
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
        public static unsafe (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToUnmanagedFunctionPointer(GISharp.Lib.Gio.FileProgressCallback? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback == null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static unsafe void UnmanagedCallback(System.Int64 currentNumBytes_, System.Int64 totalNumBytes_, System.IntPtr userData_)
        {
            try
            {
                var currentNumBytes = (System.Int64)currentNumBytes_;
                var totalNumBytes = (System.Int64)totalNumBytes_;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target!;
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

        static readonly GISharp.Lib.Gio.UnmanagedFileProgressCallback UnmanagedCallbackDelegate = UnmanagedCallback;
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