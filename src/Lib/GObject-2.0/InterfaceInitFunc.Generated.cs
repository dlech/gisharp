// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A callback function used by the type system to initialize a new
    /// interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This function should initialize all internal data and* allocate any
    /// resources required by the interface.
    /// </para>
    /// <para>
    /// The members of @iface_data are guaranteed to have been filled with
    /// zeros before this function is called.
    /// </para>
    /// </remarks>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedInterfaceInitFunc(
    /* <type name="TypeInterface" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeInterface.UnmanagedStruct* gIface,
    /* <type name="gpointer" type="gpointer" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr ifaceData);

    /// <include file="InterfaceInitFunc.xmldoc" path="declaration/member[@name='InterfaceInitFunc']/*" />
    public delegate void InterfaceInitFunc(GISharp.Lib.GObject.TypeInterface gIface, System.IntPtr ifaceData);

    /// <summary>
    /// Class for marshalling <see cref="InterfaceInitFunc"/> methods.
    /// </summary>
    public static unsafe class InterfaceInitFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="InterfaceInitFunc"/>.
        /// </summary>
        public static GISharp.Lib.GObject.InterfaceInitFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeInterface.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
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