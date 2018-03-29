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

    /// <summary>
    /// Type definition for a function that will be called back when an asynchronous
    /// operation within GIO has been completed. <see cref="AsyncReadyCallback"/>
    /// callbacks from <see cref="Task"/> are guaranteed to be invoked in a later
    /// iteration of the
    /// [thread-default main context][g-main-context-push-thread-default]
    /// where the <see cref="Task"/> was created. All other users of
    /// <see cref="AsyncReadyCallback"/> must likewise call it asynchronously in a
    /// later iteration of the main context.
    /// </summary>
    public delegate void AsyncReadyCallback(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.IAsyncResult res);

    /// <summary>
    /// Factory for creating <see cref="AsyncReadyCallback"/> methods.
    /// </summary>
    public static class AsyncReadyCallbackFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.Gio.AsyncReadyCallback ManagedDelegate;
            public GISharp.Lib.Gio.UnmanagedAsyncReadyCallback UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.Gio.AsyncReadyCallback Create(GISharp.Lib.Gio.UnmanagedAsyncReadyCallback callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(GISharp.Lib.GObject.Object sourceObject, GISharp.Lib.Gio.IAsyncResult res)
            {
                var userData_ = userData;
                var sourceObject_ = sourceObject?.Handle ?? System.IntPtr.Zero;
                var res_ = res?.Handle ?? throw new System.ArgumentNullException(nameof(res));
                callback(sourceObject_, res_, userData_);
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="AsyncReadyCallback"/> in an anonymous method that can
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
        public static unsafe (GISharp.Lib.Gio.UnmanagedAsyncReadyCallback, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.AsyncReadyCallback callback, GISharp.Runtime.CallbackScope scope)
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

        static unsafe void UnmanagedCallback(System.IntPtr sourceObject_, System.IntPtr res_, System.IntPtr userData_)
        {
            try
            {
                var sourceObject = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>(sourceObject_, GISharp.Runtime.Transfer.None);
                var res = (GISharp.Lib.Gio.IAsyncResult)GISharp.Lib.GObject.Object.GetInstance(res_, GISharp.Runtime.Transfer.None);
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