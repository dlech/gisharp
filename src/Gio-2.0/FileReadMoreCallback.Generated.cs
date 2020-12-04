// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// When loading the partial contents of a file with g_file_load_partial_contents_async(),
    /// it may become necessary to determine if any more data from the file should be loaded.
    /// A #GFileReadMoreCallback function facilitates this by returning %TRUE if more data
    /// should be read, or %FALSE otherwise.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedFileReadMoreCallback(
    /* <type name="utf8" type="const char*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr fileContents,
    /* <type name="gint64" type="goffset" managed-name="System.Int64" /> */
    /* transfer-ownership:none direction:in */
    System.Int64 fileSize,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr callbackData);

    /// <include file="FileReadMoreCallback.xmldoc" path="declaration/member[@name='FileReadMoreCallback']/*" />
    public delegate System.Boolean FileReadMoreCallback(GISharp.Lib.GLib.UnownedUtf8 fileContents, System.Int64 fileSize);

    /// <summary>
    /// Class for marshalling <see cref="FileReadMoreCallback"/> methods.
    /// </summary>
    public static class FileReadMoreCallbackMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.Gio.FileReadMoreCallback ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.Gio.FileReadMoreCallback managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="FileReadMoreCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.FileReadMoreCallback FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.Gio.UnmanagedFileReadMoreCallback>(callback_);
            var callbackData_ = userData_;

            unsafe System.Boolean managedCallback(GISharp.Lib.GLib.UnownedUtf8 fileContents, System.Int64 fileSize)
            {
                var fileContents_ = fileContents.Handle;
                var fileSize_ = (System.Int64)fileSize;
                var ret_ = unmanagedCallback(fileContents_,fileSize_,callbackData_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="FileReadMoreCallback"/> in an anonymous method that can
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
        public static unsafe (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToUnmanagedFunctionPointer(GISharp.Lib.Gio.FileReadMoreCallback? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback == null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static unsafe GISharp.Runtime.Boolean UnmanagedCallback(System.IntPtr fileContents_, System.Int64 fileSize_, System.IntPtr callbackData_)
        {
            try
            {
                var fileContents = new GISharp.Lib.GLib.UnownedUtf8(fileContents_, -1);
                var fileSize = (System.Int64)fileSize_;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)callbackData_;
                var callbackData = (UserData)gcHandle.Target!;
                var ret = callbackData.ManagedDelegate(fileContents, fileSize);
                if (callbackData.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(callbackData_);
                }
                var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }

        static readonly GISharp.Lib.Gio.UnmanagedFileReadMoreCallback UnmanagedCallbackDelegate = UnmanagedCallback;
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