using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.GObject
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
            public NativeConstructor Constructor;
            public NativeSetProperty SetProperty;
            public NativeGetProperty GetProperty;
            public NativeDispose Dispose;
            public NativeFinalize Finalize;
            public NativeDispatchPropertiesChanged DispatchPropertiesChanged;
            public NativeNotify Notify;
            public NativeConstructed Constructed;
            public ulong Flags;
            [MarshalAs (UnmanagedType.ByValArray, SizeConst = 6)]
            public IntPtr[] PDummy;
            #pragma warning restore CS0649

            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate IntPtr NativeConstructor (GType type, uint nConstructProperties, IntPtr constructProperties);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeSetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeGetProperty (IntPtr @object, uint propertyId, IntPtr value, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeDispose (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeFinalize (IntPtr @object);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeDispatchPropertiesChanged (IntPtr @object, uint nPspecs, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeNotify (IntPtr @object, IntPtr pspec);
            [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
            public delegate void NativeConstructed (IntPtr @object);
        }

        public InitiallyUnownedClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }

        public override Type StructType {
            get {
                return typeof(Struct);
            }
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotImplementedException ();
        }
    }
}
