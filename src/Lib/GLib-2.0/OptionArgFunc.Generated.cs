// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none skip:1 direction:in */
    public unsafe delegate GISharp.Runtime.Boolean UnmanagedOptionArgFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    byte* optionName,
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    byte* value,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    GISharp.Lib.GLib.Error.UnmanagedStruct** error);

    /// <include file="OptionArgFunc.xmldoc" path="declaration/member[@name='OptionArgFunc']/*" />
    public delegate void OptionArgFunc(GISharp.Lib.GLib.UnownedUtf8 optionName, GISharp.Lib.GLib.UnownedUtf8 value);

    /// <summary>
    /// Class for marshalling <see cref="OptionArgFunc"/> methods.
    /// </summary>
    public static unsafe class OptionArgFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="OptionArgFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.OptionArgFunc FromPointer(delegate* unmanaged[Cdecl]<byte*, byte*, System.IntPtr, GISharp.Lib.GLib.Error.UnmanagedStruct**, GISharp.Runtime.Boolean> callback_, System.IntPtr userData_)
        {
            var data_ = userData_;
            void managedCallback(GISharp.Lib.GLib.UnownedUtf8 optionName, GISharp.Lib.GLib.UnownedUtf8 value)
            {
                var optionName_ = (byte*)optionName.UnsafeHandle;
                var value_ = (byte*)value.UnsafeHandle;
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                callback_(optionName_, value_, data_, &error_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
                if (error_ is not null)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>((System.IntPtr)error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return managedCallback;
        }

        /// <summary>
        /// For runtime use only.
        /// </summary>
        [System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
        public static GISharp.Runtime.Boolean Callback(byte* optionName_, byte* value_, System.IntPtr data_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
        {
            try
            {
                var optionName = new GISharp.Lib.GLib.UnownedUtf8(optionName_);
                var value = new GISharp.Lib.GLib.UnownedUtf8(value_);
                var dataHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var (data, dataScope) = ((OptionArgFunc, GISharp.Runtime.CallbackScope))dataHandle.Target!;
                data.Invoke(optionName, value);
                if (dataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    dataHandle.Free();
                }

                return GISharp.Runtime.Boolean.True;
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }

            return default(GISharp.Runtime.Boolean);
        }
    }
}