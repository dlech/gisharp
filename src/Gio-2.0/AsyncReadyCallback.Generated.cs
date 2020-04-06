// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed. #GAsyncReadyCallback
    /// callbacks from #GTask are guaranteed to be invoked in a later
    /// iteration of the
    /// [thread-default main context][g-main-context-push-thread-default]
    /// where the #GTask was created. All other users of
    /// #GAsyncReadyCallback must likewise call it asynchronously in a
    /// later iteration of the main context.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate void UnmanagedAsyncReadyCallback(
    /* <type name="GObject.Object" type="GObject*" managed-name="GISharp.Lib.GObject.Object" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr sourceObject,
    /* <type name="AsyncResult" type="GAsyncResult*" managed-name="AsyncResult" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr res,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <include file="AsyncReadyCallback.xmldoc" path="declaration/member[@name='AsyncReadyCallback']/*" />
    public delegate void AsyncReadyCallback(GISharp.Lib.GObject.Object? sourceObject, GISharp.Lib.Gio.IAsyncResult res);

    /// <summary>
    /// Class for marshalling <see cref="AsyncReadyCallback"/> methods.
    /// </summary>
    public static class AsyncReadyCallbackMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.Gio.AsyncReadyCallback ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.Gio.AsyncReadyCallback managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="AsyncReadyCallback"/>.
        /// </summary>
        public static GISharp.Lib.Gio.AsyncReadyCallback FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.Gio.UnmanagedAsyncReadyCallback>(callback_);

            unsafe void managedCallback(GISharp.Lib.GObject.Object? sourceObject, GISharp.Lib.Gio.IAsyncResult res)
            {
                var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
                var res_ = res.Handle;
                unmanagedCallback(sourceObject_, res_, userData_);
            }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="AsyncReadyCallback"/> in an anonymous method that can
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
        public static unsafe (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToPointer(GISharp.Lib.Gio.AsyncReadyCallback? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback == null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static unsafe void UnmanagedCallback(System.IntPtr sourceObject_, System.IntPtr res_, System.IntPtr userData_)
        {
            try
            {
                var sourceObject = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(sourceObject_, GISharp.Runtime.Transfer.None);
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None)!;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                userData.ManagedDelegate(sourceObject, res);
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

        static readonly GISharp.Lib.Gio.UnmanagedAsyncReadyCallback UnmanagedCallbackDelegate = UnmanagedCallback;
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