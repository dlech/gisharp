// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// The type of function to be used as callback when a parse error occurs.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedOptionErrorFunc(
    /* <type name="OptionContext" type="GOptionContext*" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context,
    /* <type name="OptionGroup" type="GOptionGroup*" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    GISharp.Lib.GLib.Error.UnmanagedStruct** error);

    /// <include file="OptionErrorFunc.xmldoc" path="declaration/member[@name='OptionErrorFunc']/*" />
    public delegate void OptionErrorFunc(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group);

    /// <summary>
    /// Class for marshalling <see cref="OptionErrorFunc"/> methods.
    /// </summary>
    public static unsafe class OptionErrorFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="OptionErrorFunc"/>.
        /// </summary>
        public static GISharp.Lib.GLib.OptionErrorFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GLib.OptionContext.UnmanagedStruct*, GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*, System.IntPtr, GISharp.Lib.GLib.Error.UnmanagedStruct**, void> callback_, System.IntPtr userData_)
        {
            var data_ = userData_;
            void managedCallback(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group)
            {
                var context_ = (GISharp.Lib.GLib.OptionContext.UnmanagedStruct*)context.UnsafeHandle;
                var group_ = (GISharp.Lib.GLib.OptionGroup.UnmanagedStruct*)group.UnsafeHandle;
                var error_ = default(GISharp.Lib.GLib.Error.UnmanagedStruct*);
                callback_(context_, group_, data_, &error_);
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
        public static void Callback(GISharp.Lib.GLib.OptionContext.UnmanagedStruct* context_, GISharp.Lib.GLib.OptionGroup.UnmanagedStruct* group_, System.IntPtr data_, GISharp.Lib.GLib.Error.UnmanagedStruct** error_)
        {
            try
            {
                var context = GISharp.Lib.GLib.OptionContext.GetInstance<GISharp.Lib.GLib.OptionContext>((System.IntPtr)context_, GISharp.Runtime.Transfer.None)!;
                var group = GISharp.Lib.GLib.OptionGroup.GetInstance<GISharp.Lib.GLib.OptionGroup>((System.IntPtr)group_, GISharp.Runtime.Transfer.None)!;
                var dataHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var (data, dataScope) = ((OptionErrorFunc, GISharp.Runtime.CallbackScope))dataHandle.Target!;
                data.Invoke(context, group);
                if (dataScope == GISharp.Runtime.CallbackScope.Async)
                {
                    dataHandle.Free();
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Runtime.GMarshal.PushUnhandledException(ex);
            }
        }
    }
}