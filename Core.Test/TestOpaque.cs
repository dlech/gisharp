using System;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace Core.Test
{
    class TestOpaque : Opaque
    {
        public int Value { get { return Handle.ToInt32 (); } }

        public TestOpaque (IntPtr handle)
        {
            Handle = handle;
        }

        public TestOpaque (int value)
        {
            Handle = (IntPtr)value;
        }

        public static Type GetCustomMarshaler ()
        {
            return typeof(TestOpaqueMarshaler);
        }
    }

    public class TestOpaqueMarshaler : ICustomMarshaler
    {
        #region ICustomMarshaler implementation

        static ICustomMarshaler instance;
        public static ICustomMarshaler GetInstance (string cookie)
        {
            if (instance == null) {
                instance = new TestOpaqueMarshaler ();
            }
            return instance;
        }

        void ICustomMarshaler.CleanUpManagedData (object managedObj)
        {
        }

        void ICustomMarshaler.CleanUpNativeData (IntPtr nativeDataPtr)
        {
        }

        int ICustomMarshaler.GetNativeDataSize ()
        {
            return -1;
        }

        IntPtr ICustomMarshaler.MarshalManagedToNative (object managedObj)
        {
            if (managedObj == null) {
                return IntPtr.Zero;
            }
            var testOpaque = managedObj as TestOpaque;
            if (testOpaque == null) {
                var message = string.Format ("Requires a {0} object.",
                    typeof(TestOpaque).Name);
                throw new MarshalDirectiveException (message);
            }
            return testOpaque.Handle;
        }

        object ICustomMarshaler.MarshalNativeToManaged (IntPtr nativeDataPtr)
        {
            if (nativeDataPtr == IntPtr.Zero) {
                return null;
            }
            return new TestOpaque (nativeDataPtr);
        }

        #endregion
    }
}
