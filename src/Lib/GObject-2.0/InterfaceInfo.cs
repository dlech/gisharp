using System;

namespace GISharp.Lib.GObject
{
    unsafe partial struct InterfaceInfo
    {
        internal InterfaceInfo(
            delegate* unmanaged[Cdecl]<TypeInterface.UnmanagedStruct*, IntPtr, void> interfaceInit,
            delegate* unmanaged[Cdecl]<TypeInterface.UnmanagedStruct*, IntPtr, void> interfaceFinalize,
            IntPtr interfaceData)
        {
            this.interfaceInit = interfaceInit;
            this.interfaceFinalize = interfaceFinalize;
            this.interfaceData = interfaceData;
        }
    }
}
