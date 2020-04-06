// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none skip:1 direction:out */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedOptionArgFunc(
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
    ref System.IntPtr error);

    /// <include file="OptionArgFunc.xmldoc" path="declaration/member[@name='OptionArgFunc']/*" />
    public delegate void OptionArgFunc(GISharp.Lib.GLib.UnownedUtf8 optionName, GISharp.Lib.GLib.UnownedUtf8 value);

    /// <summary>
    /// Class for marshalling <see cref="OptionArgFunc"/> methods.
    /// </summary>
    public static class OptionArgFuncMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.GLib.OptionArgFunc ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.GLib.OptionArgFunc managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="OptionArgFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.OptionArgFunc FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.GLib.UnmanagedOptionArgFunc>(callback_);
            var data_ = userData_;

            unsafe void managedCallback(GISharp.Lib.GLib.UnownedUtf8 optionName, GISharp.Lib.GLib.UnownedUtf8 value)
            {
                var optionName_ = optionName.Handle;
                var value_ = value.Handle;
                var error_ = System.IntPtr.Zero;
                unmanagedCallback(optionName_, value_, data_, ref error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="OptionArgFunc"/> in an anonymous method that can
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
        public static unsafe (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToPointer(GISharp.Lib.GLib.OptionArgFunc? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback == null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static unsafe GISharp.Runtime.Boolean UnmanagedCallback(System.IntPtr optionName_, System.IntPtr value_, System.IntPtr data_, ref System.IntPtr error_)
        {
            try
            {
                var optionName = new GISharp.Lib.GLib.UnownedUtf8(optionName_, -1);
                var value = new GISharp.Lib.GLib.UnownedUtf8(value_, -1);
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

            return default(GISharp.Runtime.Boolean);
        }

        static readonly GISharp.Lib.GLib.UnmanagedOptionArgFunc UnmanagedCallbackDelegate = UnmanagedCallback;
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