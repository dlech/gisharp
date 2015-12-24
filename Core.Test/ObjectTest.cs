using System;
using System.Runtime.InteropServices;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class ObjectTest
    {
        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr @object);

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr @object);

        [Test]
        public void TestReferences ()
        {
            var o1 = new Object ();
            var handle = o1.Handle;
            // getting an object that already exists should return that object
            var o2 = Opaque.GetInstance<Object> (handle, Transfer.None);
            Assert.That (ReferenceEquals (o1, o2), Is.True);

            // Simulate unmanaged code taking a reference so that the handle is
            // not freed when o1 is disposed.
            g_object_ref (handle);

            // After an object is disposed we should get a new object rather
            // than the disposed object.
            o1.Dispose ();

            // Normally, we would not dispose an object if there is a possiblity
            // that it could be used again because it will loose it's state.
            // The internal GCHandle will keep the object alive as long as
            // unmanaged code has a reference to the object.

            // Transfer.All means the new object takes ownership of the reference
            // from the manual call to g_object_ref(), so we don't need to call
            // g_object_unref() manually.
            o2 = Opaque.GetInstance<Object> (handle, Transfer.All);

            Assert.That (ReferenceEquals (o1, o2), Is.False);

            // This ensures that there are not any errors when finalizing
            // (via the log).
            o2.Dispose ();
        }

        [Test]
        public void TestToggleRef ()
        {
            WeakReference weakRef = null;

            new Action (() => weakRef = new WeakReference (new Object ())).Invoke ();

            // first make sure our testing method is sane and Object is really GC'ed
            GC.Collect ();
            GC.WaitForPendingFinalizers ();
            Assume.That (weakRef.IsAlive, Is.False);

            // Now for the actual test.

            IntPtr handle = IntPtr.Zero;
            new Action (() => {
                var o = new Object ();
                weakRef = new WeakReference (o);
                // Simulate unmanaged code taking a reference. This should trigger
                // the toggle reference which prevents the object from being GC'ed
                handle = o.Handle;
                g_object_ref (handle);
            }).Invoke ();

            GC.Collect ();
            GC.WaitForPendingFinalizers ();
            Assert.That (weakRef.IsAlive, Is.True);

            // Simulates unmanaged code releasing the last reference. This should
            // free the GCHandle.
            g_object_unref (handle);

            GC.Collect ();
            GC.WaitForPendingFinalizers ();
            Assert.That (weakRef.IsAlive, Is.False);
        }
    }
}
