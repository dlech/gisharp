using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;

namespace GISharp.GObject
{
    /// <summary>
    /// All the fields in the GInitiallyUnowned structure
    /// are private to the #GInitiallyUnowned implementation and should never be
    /// accessed directly.
    /// </summary>
    [GType ("GInitiallyUnowned", IsWrappedNativeType = true)]
    [GTypeStruct (typeof(InitiallyUnownedClass))]
    public class InitiallyUnowned : Object
    {
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_initially_unowned_get_type ();

        static GType getGType ()
        {
            return g_initially_unowned_get_type ();
        }

        protected InitiallyUnowned (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : TypeClass
    {
        struct InitiallyUnownedClassStruct
        {
            public TypeClassStruct GTypeClass;
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

        public override Type StructType {
            get {
                return typeof(InitiallyUnownedClassStruct);
            }
        }

        public InitiallyUnownedClass (IntPtr handle, bool ownsRef)
            : base (handle, ownsRef)
        {
        }

        public override TypeInfo GetTypeInfo (Type type)
        {
            throw new NotImplementedException ();
        }
    }
}
