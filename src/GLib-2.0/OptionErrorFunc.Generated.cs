// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of function to be used as callback when a parse error occurs.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedOptionErrorFunc(
    /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
    /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    GISharp.Lib.GLib.Error.UnmanagedStruct** error);

    /// <include file="OptionErrorFunc.xmldoc" path="declaration/member[@name='OptionErrorFunc']/*" />
    public delegate void OptionErrorFunc(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group);

    /// <summary>
    /// Class for marshalling <see cref="OptionErrorFunc"/> methods.
    /// </summary>
    public static class OptionErrorFuncMarshal
    {
        class UserData
        {
            public readonly GISharp.Lib.GLib.OptionErrorFunc ManagedDelegate;
            public readonly GISharp.Runtime.CallbackScope Scope;

            public UserData(GISharp.Lib.GLib.OptionErrorFunc managedDelegate, GISharp.Runtime.CallbackScope scope)
            {
                ManagedDelegate = managedDelegate;
                Scope = scope;
            }
        }

        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="OptionErrorFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.OptionErrorFunc FromPointer(System.IntPtr callback_, System.IntPtr userData_)
        {
            var unmanagedCallback = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<GISharp.Lib.GLib.UnmanagedOptionErrorFunc>(callback_);
            var data_ = userData_;

            unsafe void managedCallback(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group) { var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)context.UnsafeHandle; var group_ = (GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*)group.UnsafeHandle; var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*); unmanagedCallback(context_, group_, data_, &error_); if (error_ != null) { var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full); throw new GISharp.Runtime.GErrorException(error); } }

            return managedCallback;
        }

        /// <summary>
        /// Wraps a <see cref="OptionErrorFunc"/> in an anonymous method that can
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
        public static unsafe (System.IntPtr callback_, System.IntPtr notify_, System.IntPtr userData_) ToUnmanagedFunctionPointer(GISharp.Lib.GLib.OptionErrorFunc? callback, GISharp.Runtime.CallbackScope scope)
        {
            if (callback == null)
            {
                return default;
            }

            var userData = new UserData(callback, scope);
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (callback_, destroy_, userData_);
        }

        static unsafe void UnmanagedCallback(GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context_, GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group_, System.IntPtr data_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
        {
            try
            {
                var context = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionContext>((System.IntPtr)context_, GISharp.Runtime.Transfer.None)!;
                var group = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionGroup>((System.IntPtr)group_, GISharp.Runtime.Transfer.None)!;
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target!;
                data.ManagedDelegate(context, group);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static readonly unsafe GISharp.Lib.GLib.UnmanagedOptionErrorFunc UnmanagedCallbackDelegate = UnmanagedCallback;
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