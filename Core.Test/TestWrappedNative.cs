using System;
using System.Runtime.InteropServices;

using GISharp.Core;

namespace Core.Test
{
    class TestWrappedNative : IWrappedNative
    {
        public IntPtr Handle { get; private set; }

        public int Value { get { return Handle.ToInt32 (); } }

        public TestWrappedNative (IntPtr handle)
        {
            Handle = handle;
        }

        public TestWrappedNative (int value)
        {
            Handle = (IntPtr)value;
        }

        public static Type GetCustomMarshaler ()
        {
            return typeof(TestWrappedNativeMarshaler);
        }

        public override bool Equals (object obj)
        {
            if ((object)this == null && obj == null) {
                return true;
            }
            var other = obj as TestWrappedNative;
            if (other != null) {
                return Handle == other.Handle;
            }
            return false;
        }

        public override int GetHashCode ()
        {
            return Handle.ToInt32 ();
        }
    }

    public class TestWrappedNativeMarshaler : ICustomMarshaler
    {
        #region ICustomMarshaler implementation

        static ICustomMarshaler instance;
        public static ICustomMarshaler GetInstance (string cookie)
        {
            if (instance == null) {
                instance = new TestWrappedNativeMarshaler ();
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
            var testWrappedNative = managedObj as TestWrappedNative;
            if (testWrappedNative == null) {
                throw new MarshalDirectiveException ("Requires a TestWrappedNative object.");
            }
            return testWrappedNative.Handle;
        }

        object ICustomMarshaler.MarshalNativeToManaged (IntPtr nativeDataPtr)
        {
            if (nativeDataPtr == IntPtr.Zero) {
                return null;
            }
            return new TestWrappedNative (nativeDataPtr);
        }

        #endregion
    }
}
