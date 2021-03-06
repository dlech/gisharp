// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate byte* UnmanagedTranslateFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    byte* str,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr data);

    /// <include file="TranslateFunc.xmldoc" path="declaration/member[@name='TranslateFunc']/*" />
    public delegate GISharp.Lib.GLib.UnownedUtf8 TranslateFunc(GISharp.Lib.GLib.UnownedUtf8 str);

    /// <summary>
    /// Class for marshalling <see cref="TranslateFunc"/> methods.
    /// </summary>
    public static unsafe class TranslateFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="TranslateFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.TranslateFunc FromPointer(delegate* unmanaged[Cdecl]<byte*, System.IntPtr, byte*> callback_, System.IntPtr userData_)
        {
            var data_ = userData_;
            GISharp.Lib.GLib.UnownedUtf8 managedCallback(GISharp.Lib.GLib.UnownedUtf8 str)
            {
                var str_ = (byte*)str.UnsafeHandle;
                var ret_ = callback_(str_,data_);
                var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_);
                return ret;
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static byte* Callback(byte* str_, System.IntPtr data_)
        {
            try
            {
                var str = new GISharp.Lib.GLib.UnownedUtf8(str_);
                var dataHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var (data, dataScope) = ((TranslateFunc, GISharp.Runtime.CallbackScope))dataHandle.Target!;
                var ret = data.Invoke(str);
                if (dataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    dataHandle.Free();
                }

                var ret_ = (byte*)ret.UnsafeHandle;
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(byte*);
        }
    }
}