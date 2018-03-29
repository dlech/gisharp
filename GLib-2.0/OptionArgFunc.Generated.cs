namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none skip:1 direction:out */
    public unsafe delegate System.Boolean UnmanagedOptionArgFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr optionName,
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr value,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    System.IntPtr* error);

    /// <summary>
    /// The type of function to be passed as callback for <see cref="OptionArg.Callback"/>
    /// options.
    /// </summary>
    public delegate void OptionArgFunc(GISharp.Lib.GLib.Utf8 optionName, GISharp.Lib.GLib.Utf8 value);

    /// <summary>
    /// Factory for creating <see cref="OptionArgFunc"/> methods.
    /// </summary>
    public static class OptionArgFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.OptionArgFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedOptionArgFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.OptionArgFunc Create(GISharp.Lib.GLib.UnmanagedOptionArgFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(GISharp.Lib.GLib.Utf8 optionName, GISharp.Lib.GLib.Utf8 value)
            {
                var data_ = userData;
                var optionName_ = optionName?.Handle ?? throw new System.ArgumentNullException(nameof(optionName));
                var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
                var error_ = System.IntPtr.Zero;
                callback(optionName_, value_, data_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="OptionArgFunc"/> in an anonymous method that can
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
        public static unsafe (GISharp.Lib.GLib.UnmanagedOptionArgFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.OptionArgFunc callback, GISharp.Runtime.CallbackScope scope)
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

        static unsafe System.Boolean UnmanagedCallback(System.IntPtr optionName_, System.IntPtr value_, System.IntPtr data_, System.IntPtr* error_)
        {
            try
            {
                var optionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(optionName_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(value_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                data.ManagedDelegate(optionName, value);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
                return true;
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