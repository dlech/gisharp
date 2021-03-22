// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A callback function used by the type system to finalize an interface.
    /// This function should destroy any internal data and release any resources
    /// allocated by the corresponding GInterfaceInitFunc() function.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedInterfaceFinalizeFunc(
    /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr ifaceData);

    /// <include file="InterfaceFinalizeFunc.xmldoc" path="declaration/member[@name='InterfaceFinalizeFunc']/*" />
    public delegate void InterfaceFinalizeFunc(GISharp.Lib.GObject.TypeInterface gIface, System.IntPtr ifaceData);

    /// <summary>
    /// Class for marshalling <see cref="InterfaceFinalizeFunc"/> methods.
    /// </summary>
    public static unsafe class InterfaceFinalizeFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="InterfaceFinalizeFunc"/>.
        /// </summary>
        public static GISharp.Lib.GObject.InterfaceFinalizeFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.TypeInterface gIface, System.IntPtr ifaceData)
            {
                var gIface_ = (GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*)gIface.UnsafeHandle;
                var ifaceData_ = (System.IntPtr)ifaceData;
                callback_(gIface_, ifaceData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }
    }
}