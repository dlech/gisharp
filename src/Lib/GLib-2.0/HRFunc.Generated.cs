// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of the function passed to
    /// g_hash_table_foreach_remove(). It is called with each key/value
    /// pair, together with the @user_data parameter passed to
    /// g_hash_table_foreach_remove(). It should return %TRUE if the
    /// key/value pair should be removed from the #GHashTable.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedHRFunc(
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr key,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr value,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr userData);

    /// <include file="HRFunc.xmldoc" path="declaration/member[@name='HRFunc']/*" />
    public delegate bool HRFunc(System.IntPtr key, System.IntPtr value);

    /// <summary>
    /// Class for marshalling <see cref="HRFunc"/> methods.
    /// </summary>
    public static unsafe class HRFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="HRFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.HRFunc FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, System.IntPtr, System.IntPtr, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            bool managedCallback(System.IntPtr key, System.IntPtr value)
            {
                var key_ = (System.IntPtr)key;
                var value_ = (System.IntPtr)value;
                var ret_ = callback_(key_,value_,userData_);
                var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Runtime.Boolean Callback(System.IntPtr key_, System.IntPtr value_, System.IntPtr userData_)
        {
            try
            {
                var key = (System.IntPtr)key_;
                var value = (System.IntPtr)value_;
                var userDataHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                var (userData, userDataScope) = ((HRFunc, GISharp.Runtime.CallbackScope))userDataHandle.Target!;
                var ret = userData.Invoke(key, value);
                if (userDataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    userDataHandle.Free();
                }

                var ret_ = GISharp.Runtime.BooleanExtensions.ToBoolean(ret);
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.LogUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }
    }
}