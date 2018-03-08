using System;
using System.Runtime.InteropServices;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A structure that provides information to the type system which is
    /// used specifically for managing interface types.
    /// </summary>
    public struct InterfaceInfo
    {
        /// <summary>
        /// location of the interface initialization function
        /// </summary>
        public UnmanagedInterfaceInitFunc InterfaceInit;

        /// <summary>
        /// location of the interface finalization function
        /// </summary>
        public UnmanagedInterfaceFinalizeFunc InterfaceFinalize;

        /// <summary>
        /// user-supplied data passed to the interface init/finalize functions
        /// </summary>
        public IntPtr InterfaceData;
    }

    /// <summary>
    /// A callback function used by the type system to initialize a new
    /// interface.  This function should initialize all internal data and
    /// allocate any resources required by the interface.
    /// </summary>
    /// <remarks>
    /// The members of @iface_data are guaranteed to have been filled with
    /// zeros before this function is called.
    /// </remarks>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void UnmanagedInterfaceInitFunc (
    /* <type name="TypeInterface" type="gpointer" managed-name="TypeInterface" /> */
    /* transfer-ownership:none */
        IntPtr gIface,
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
    /* transfer-ownership:none */
        IntPtr ifaceData);

    /// <summary>
    /// A callback function used by the type system to finalize an interface.
    /// This function should destroy any internal data and release any resources
    /// allocated by the corresponding GInterfaceInitFunc() function.
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void UnmanagedInterfaceFinalizeFunc (
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
    /* transfer-ownership:none */
        IntPtr gIface,
    /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
    /* transfer-ownership:none */
        IntPtr ifaceData);
}
