namespace GISharp.Lib.Gio
{
    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by g_cancellable_source_new().
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate System.Boolean UnmanagedCancellableSourceFunc(
    /* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr cancellable,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr userData);

    /// <summary>
    /// This is the function type of the callback used for the #GSource
    /// returned by <see cref="CancellableSource.New"/>.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.28")]
    public delegate System.Boolean CancellableSourceFunc(GISharp.Lib.Gio.Cancellable cancellable = null);

    /// <summary>
    /// Factory for creating <see cref="CancellableSourceFunc"/> methods.
    /// </summary>
    public static class CancellableSourceFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.Gio.CancellableSourceFunc ManagedDelegate;
            public GISharp.Lib.Gio.UnmanagedCancellableSourceFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.Gio.CancellableSourceFunc Create(GISharp.Lib.Gio.UnmanagedCancellableSourceFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe System.Boolean callback_(GISharp.Lib.Gio.Cancellable cancellable)
            {
                var userData_ = userData;
                var cancellable_ = cancellable?.Handle ?? System.IntPtr.Zero;
                var ret_ = callback(cancellable_,userData_);
                var ret = (System.Boolean)ret_;
                return ret;
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="CancellableSourceFunc"/> in an anonymous method that can
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
        public static unsafe (GISharp.Lib.Gio.UnmanagedCancellableSourceFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.Gio.CancellableSourceFunc callback, GISharp.Runtime.CallbackScope scope)
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

        static unsafe System.Boolean UnmanagedCallback(System.IntPtr cancellable_, System.IntPtr userData_)
        {
            try
            {
                var cancellable = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.Gio.Cancellable>(cancellable_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var userData = (UserData)gcHandle.Target;
                var ret = userData.ManagedDelegate(cancellable);
                if (userData.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(userData_);
                }
                var ret_ = (System.Boolean)ret;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.Boolean);
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