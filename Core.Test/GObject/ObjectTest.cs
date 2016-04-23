using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class ObjectTest
    {
        [Test]
        public void TestReferences ()
        {
            var o1 = new GISharp.GObject.Object ();
            var handle = o1.Handle;

            // getting an object that already exists should return that object
            var o2 = Opaque.GetInstance<GISharp.GObject.Object> (handle, Transfer.None);
            Assert.That (ReferenceEquals (o1, o2), Is.True);

            // Simulate unmanaged code taking a reference so that the handle is
            // not freed when o1 is disposed.
            g_object_ref (handle);

            // After an object is disposed we should get a new object rather
            // than the disposed object.
            o1.Dispose ();

            // Normally, we would not dispose an object if there is a possiblity
            // that it could be used again because it will loose any state that
            // is stored in the managed object. Instead, a GCHandle will keep
            // the object alive as long as unmanaged code has a reference to the
            // object.

            // Transfer.All means the new object takes ownership of the reference
            // from the manual call to g_object_ref(), so we don't need to call
            // g_object_unref() manually.
            o2 = Opaque.GetInstance<GISharp.GObject.Object> (handle, Transfer.All);

            Assert.That (ReferenceEquals (o1, o2), Is.False);

            // This ensures that there are not any errors when finalizing
            // (via the log).
            o2.Dispose ();
        }

        [Test]
        public void TestToggleRef ()
        {
            WeakReference weakRef = null;

            new Action (() => weakRef = new WeakReference (new GISharp.GObject.Object ())).Invoke ();

            // first make sure our testing method is sane and Object is really GC'ed
            GC.Collect ();
            GC.WaitForPendingFinalizers ();
            Assume.That (weakRef.IsAlive, Is.False);

            // Now for the actual test.

            IntPtr handle = IntPtr.Zero;
            new Action (() => {
                var o = new GISharp.GObject.Object ();
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

        [Test]
        public void TestSubclass ()
        {
            // Test that a subclass is properly registered with the GObject
            // type system.

            // Objects without the GType attribute will fail.
            Assert.That (() => typeof(TestObject1).GetGType (),
                Throws.ArgumentException);

            // Objects that do not inherit from GISharp.Core.Object fail
            Assert.That (() => typeof(TestObject2).GetGType (),
                Throws.ArgumentException);

            // this one should actually work since it is setup correctly
            var testObject3GType = typeof(TestObject3).GetGType ();
            Assert.That (testObject3GType, Is.Not.EqualTo (GType.Invalid));

            Assert.That(() => new TestObject3 (), Throws.Nothing);
        }

        [Test]
        public void TestSubclassPropertyRegistration ()
        {
            var obj = new TestObjectPropertiesBase ();

            // check if setting properties from unmanged code works
            Assume.That (obj.IntValue, Is.EqualTo (0));
            var value = new Value (GType.Int);
            value.Set (1);
            obj.SetProperty ("IntValue", value);
            Assert.That (obj.IntValue, Is.EqualTo (1));
        }

        [Test]
        public void TestSubclassPropertyOverride ()
        {
            var obj = new TestObjectPropertiesSubclass ();

            // the new keyword does not override a property, just hides it...

            Assume.That (obj.IntValue, Is.EqualTo (0));
            var intValue = new Value (GType.Int);
            intValue.Set (1);
            obj.SetProperty (nameof (obj.IntValue), intValue);
            Assert.That (obj.IntValue, Is.EqualTo (1));

            Assert.That (((TestObjectPropertiesBase)obj).IntValue, Is.EqualTo (0));

            var baseObjClass = TypeClass.Get<ObjectClass> (typeof(TestObjectPropertiesBase).GetGType ());
            var baseIntValueProp = baseObjClass.FindProperty (nameof (obj.IntValue));

            var subclassObjClass = TypeClass.Get<ObjectClass> (typeof(TestObjectPropertiesSubclass).GetGType ());
            var subclassIntValueProp = subclassObjClass.FindProperty (nameof (obj.IntValue));

            // ...so ParamSpecs should not be the same
            Assert.That (baseIntValueProp.Handle, Is.Not.EqualTo (subclassIntValueProp.Handle));


            // But the override keyword replaces property...

            Assume.That (obj.BoolValue, Is.False);
            var value = new Value (GType.Boolean);
            value.Set (true);
            obj.SetProperty (nameof(obj.BoolValue), value);
            Assert.That (obj.BoolValue, Is.True);

            Assert.That (((TestObjectPropertiesBase)obj).BoolValue, Is.True);

            var baseBoolValueProp = baseObjClass.FindProperty (nameof(obj.BoolValue));
            var subclassBoolValueProp = subclassObjClass.FindProperty (nameof(obj.BoolValue));

            // ...so ParamSpecs should be the same
            Assert.That (baseBoolValueProp.Handle, Is.EqualTo (subclassBoolValueProp.Handle));
        }

        [Test]
        public void TestSubclassPropertyChangeNotification ()
        {
            var obj = new TestObjectPropertiesBase ();
            var notificationCount = 0;

            obj.PropertyChanged += (sender, e) => {
                Assert.That (e.PropertyName == nameof (obj.DoubleValue));
                notificationCount++;
            };

            // IntValue does not notifiy of property change
            obj.IntValue = 1;
            Assert.That (notificationCount, Is.EqualTo (0));

            // likewise, setting the property from unmange code should not
            // trigger a change either
            var intValue = new Value (GType.Int);
            intValue.Set (1);
            obj.SetProperty (nameof(obj.IntValue), intValue);
            Assert.That (notificationCount, Is.EqualTo (0));

            // DoubleValue does notify
            obj.DoubleValue = 1;
            Assert.That (notificationCount, Is.EqualTo (1));

            // also make sure changing the propery from unmanged code notifies
            // and that it only notifies once
            var doubleValue = new Value (GType.Double);
            doubleValue.Set (1.0);
            obj.SetProperty (nameof(obj.DoubleValue), doubleValue);
            Assert.That (notificationCount, Is.EqualTo (2));
        }

        // This will fail because it lacks the GTypeAttribute
        class TestObject1 : GISharp.GObject.Object
        {
        }

        // This will fail because it does not inherit from GISharp.Core.Object
        [GType]
        class TestObject2
        {
        }

        [GType]
        class TestObject3 : GISharp.GObject.Object
        {
            public TestObject3 () : this (New<TestObject3> (), Transfer.All)
            {
            }

            protected TestObject3 (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectPropertiesBase : GISharp.GObject.Object
        {
            [GISharp.Runtime.Property]
            public int IntValue { get; set; }

            [GISharp.Runtime.Property]
            public virtual bool BoolValue { get; set; }

            double _DoubleValue;
            [GISharp.Runtime.Property]
            public double DoubleValue {
                get {
                    return _DoubleValue;
                }
                set {
                    _DoubleValue = value;
                    Notify (nameof (DoubleValue));
                }
            }

            public TestObjectPropertiesBase ()
                : this (New<TestObjectPropertiesBase> (), Transfer.All)
            {
            }

            protected TestObjectPropertiesBase (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectPropertiesSubclass : TestObjectPropertiesBase
        {
            [GISharp.Runtime.Property]
            public new int IntValue { get; set; }

            [GISharp.Runtime.Property]
            public override bool BoolValue { get; set; }

            public TestObjectPropertiesSubclass ()
                : this (New<TestObjectPropertiesSubclass> (), Transfer.All)
            {
            }

            protected TestObjectPropertiesSubclass (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr @object);

        [DllImport ("gobject-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr @object);
    }
}
