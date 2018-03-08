using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : TypeClass
    {
        new struct Struct
        {
            #pragma warning disable CS0649
            public TypeClass.Struct GTypeClass;
            public IntPtr ConstructProperties;
            public UnmanagedConstructor Constructor;
            public UnmanagedSetProperty SetProperty;
            public UnmanagedGetProperty GetProperty;
            public UnmanagedDispose Dispose;
            public UnmanagedFinalize Finalize;
            public UnmanagedDispatchPropertiesChanged DispatchPropertiesChanged;
            public UnmanagedNotify Notify;
            public UnmanagedConstructed Constructed;
            public ulong Flags;
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 6)]
            public IntPtr[] PDummy;
            #pragma warning restore CS0649

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate IntPtr UnmanagedConstructor (GType type, uint nConstructProperties, IntPtr constructProperties);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedSetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedGetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedDispose (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedFinalize (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedDispatchPropertiesChanged (IntPtr @object, uint nPspecs, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedNotify (IntPtr @object, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void UnmanagedConstructed (IntPtr @object);
        }

        public InitiallyUnownedClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotImplementedException ();
        }
    }
}
