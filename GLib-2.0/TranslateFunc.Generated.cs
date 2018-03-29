namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate System.IntPtr UnmanagedTranslateFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr str,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr data);

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    public delegate GISharp.Lib.GLib.Utf8 TranslateFunc(GISharp.Lib.GLib.Utf8 str);

    /// <summary>
    /// Factory for creating <see cref="TranslateFunc"/> methods.
    /// </summary>
    public static class TranslateFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.TranslateFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedTranslateFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.TranslateFunc Create(GISharp.Lib.GLib.UnmanagedTranslateFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe GISharp.Lib.GLib.Utf8 callback_(GISharp.Lib.GLib.Utf8 str)
            {
                var data_ = userData;
                var str_ = str?.Handle ?? throw new System.ArgumentNullException(nameof(str));
                var ret_ = callback(str_,data_);
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
                return ret;
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="TranslateFunc"/> in an anonymous method that can
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
        public static unsafe (GISharp.Lib.GLib.UnmanagedTranslateFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.TranslateFunc callback, GISharp.Runtime.CallbackScope scope)
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

        static unsafe System.IntPtr UnmanagedCallback(System.IntPtr str_, System.IntPtr data_)
        {
            try
            {
                var str = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(str_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                var ret = data.ManagedDelegate(str);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
                var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.IntPtr);
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