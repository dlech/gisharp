// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A callback called after an interface vtable is initialized.
    /// </summary>
    /// <remarks>
    /// <para>
    /// See g_type_add_interface_check().
    /// </para>
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.4")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedTypeInterfaceCheckFunc(
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr checkData,
    /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface);

    /// <include file="TypeInterfaceCheckFunc.xmldoc" path="declaration/member[@name='TypeInterfaceCheckFunc']/*" />
    [GISharp.Runtime.SinceAttribute("2.4")]
    public delegate void TypeInterfaceCheckFunc(System.IntPtr checkData, GISharp.Lib.GObject.TypeInterface gIface);

    /// <summary>
    /// Class for marshalling <see cref="TypeInterfaceCheckFunc"/> methods.
    /// </summary>
    public static unsafe class TypeInterfaceCheckFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="TypeInterfaceCheckFunc"/>.
        /// </summary>
        public static GISharp.Lib.GObject.TypeInterfaceCheckFunc FromPointer(delegate* unmanaged[Cdecl]<System.IntPtr, GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(System.IntPtr checkData, GISharp.Lib.GObject.TypeInterface gIface)
            {
                var checkData_ = (System.IntPtr)checkData;
                var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)gIface.UnsafeHandle;
                callback_(checkData_, gIface_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }
    }
}