using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GObject;
using GISharp.Runtime;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class ObjectTests
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
            o2 = Opaque.GetInstance<GISharp.GObject.Object> (handle, Transfer.Full);

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
            var value = new Value (GType.Int, 1);
            obj.SetProperty (nameof (obj.IntValue), value);
            Assert.That (obj.IntValue, Is.EqualTo (1));

            // also make sure that non-GTypes get boxed
            Assume.That (obj.ObjectProperty, Is.Null);
            var expectedObj = new object ();
            var objValue = new Value (typeof(object), expectedObj);
            obj.SetProperty (nameof (obj.ObjectProperty), objValue);
            Assert.That (obj.ObjectProperty, Is.SameAs (expectedObj));
        }

        [Test]
        public void TestSubclassPropertyOverride ()
        {
            var obj = new TestObjectPropertiesSubclass ();

            // the new keyword does not override a property, just hides it...

            Assume.That (obj.IntValue, Is.EqualTo (0));
            var intValue = new Value (GType.Int, 1);
            obj.SetProperty (nameof (obj.IntValue), intValue);
            Assert.That (obj.IntValue, Is.EqualTo (1));

            Assert.That (((TestObjectPropertiesBase)obj).IntValue, Is.EqualTo (0));

            var baseObjClass = (ObjectClass)TypeClass.Peek (typeof(TestObjectPropertiesBase).GetGType ());
            var baseIntValueProp = baseObjClass.FindProperty (nameof (obj.IntValue));

            var subclassObjClass = (ObjectClass)TypeClass.Peek (typeof(TestObjectPropertiesSubclass).GetGType ());
            var subclassIntValueProp = subclassObjClass.FindProperty (nameof (obj.IntValue));

            // ...so ParamSpecs should not be the same
            Assert.That (baseIntValueProp.Handle, Is.Not.EqualTo (subclassIntValueProp.Handle));


            // But the override keyword replaces property...

            Assume.That (obj.BoolValue, Is.False);
            var value = new Value (GType.Boolean, true);
            obj.SetProperty ("bool-value", value);
            Assert.That (obj.BoolValue, Is.True);

            Assert.That (((TestObjectPropertiesBase)obj).BoolValue, Is.True);

            var baseBoolValueProp = baseObjClass.FindProperty ("bool-value");
            var subclassBoolValueProp = subclassObjClass.FindProperty ("bool-value");

            // ...so ParamSpecs should be the same
            Assert.That (baseBoolValueProp.Handle, Is.EqualTo (subclassBoolValueProp.Handle));
        }

        [Test]
        public void TestPropertyChangeNotification ()
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
            var intValue = new Value (GType.Int, 1);
            obj.SetProperty (nameof(obj.IntValue), intValue);
            Assert.That (notificationCount, Is.EqualTo (0));

            // DoubleValue does notify
            obj.DoubleValue = 1;
            Assert.That (notificationCount, Is.EqualTo (1));

            // also make sure changing the propery from unmanged code notifies
            // and that it only notifies once
            var doubleValue = new Value (GType.Double, 1.0);
            obj.SetProperty (nameof(obj.DoubleValue), doubleValue);
            Assert.That (notificationCount, Is.EqualTo (2));
        }

        [Test]
        public void TestPropertyComponentModelAttributes ()
        {
            // check that ComponentModel attributes map to ParamSpec
            var baseObj = new TestObjectPropertiesBase ();
            var baseObjClass = (ObjectClass)TypeClass.Peek (baseObj.GetGType ());
            var basePspec = baseObjClass.FindProperty ("bool-value");
            Assert.That (basePspec.Name, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyName));
            Assert.That (basePspec.Nick, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyNick));
            Assert.That (basePspec.Blurb, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyBlurb));
            Assert.That (basePspec.DefaultValue.Get (),
                Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyDefaultValue));

            // The subclass will inherit the values of the parent class.
            // If the subclass tries to declare an attribute again, it will
            // be ignored as is the case with DefaultValueAttribute here.
            var subObj = new TestObjectPropertiesSubclass ();
            var subObjClass = (ObjectClass)TypeClass.Peek (subObj.GetGType ());
            var subPspec = subObjClass.FindProperty ("bool-value");
            Assert.That (subPspec.Name, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyName));
            Assert.That (subPspec.Nick, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyNick));
            Assert.That (subPspec.Blurb, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyBlurb));
            Assert.That (subPspec.DefaultValue.Get (),
                Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyDefaultValue));
        }

        [Test]
        public void TestSignalRegistration ()
        {
            var obj = new TestObjectSignal ();
            var eventCount = 0;

            obj.EventHappened += () => eventCount++;

            // check that emitting the signal from unmanaged code fires the event
            obj.OnEventHappened ();

            Assert.That (eventCount, Is.EqualTo (1));
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
            public TestObject3 () : this (New<TestObject3> (), Transfer.Full)
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

            public const string BoolValuePropertyName = "bool-value";
            public const string BoolValuePropertyNick = "Boolean Value";
            public const string BoolValuePropertyBlurb = "A boolean value for testing stuff.";
            public const bool BoolValuePropertyDefaultValue = true;

            [GISharp.Runtime.Property (BoolValuePropertyName)]
            [DisplayName (BoolValuePropertyNick)]
            [System.ComponentModel.Description (BoolValuePropertyBlurb)]
            [DefaultValue (BoolValuePropertyDefaultValue)]
            public virtual bool BoolValue { get; set; } = BoolValuePropertyDefaultValue;

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

            [GISharp.Runtime.Property]
            public object ObjectProperty { get; set; }

            public TestObjectPropertiesBase ()
                : this (New<TestObjectPropertiesBase> (), Transfer.Full)
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

            // PropertyAttribute is inherited, so GObject property name will be "bool-value"
            // ComponentModel attributes are ingnored on overriden properties though,
            // so setting DefaultValueAttribute here will not have an effect on
            // the default value as far as the GObject type system is concerned.
            [DefaultValue (!BoolValuePropertyDefaultValue)]
            public override bool BoolValue { get; set; } = !BoolValuePropertyDefaultValue;

            public TestObjectPropertiesSubclass ()
                : this (New<TestObjectPropertiesSubclass> (), Transfer.Full)
            {
            }

            protected TestObjectPropertiesSubclass (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectSignal : GISharp.GObject.Object
        {
            Action eventHappend;
            object eventHappendHandlerLock = new object ();
            SignalHandler eventHappendedHandler;

            [Signal]
            public event Action EventHappened {
                add {
                    lock (eventHappendHandlerLock) {
                        if (eventHappend == null) {
                            eventHappendedHandler = Signal.Connect (this,
                                nameof(EventHappened), NativeEventHappened);
                        }
                        eventHappend += value;
                    }
                }
                remove {
                    lock (eventHappendHandlerLock) {
                        eventHappend -= value;
                        if (eventHappend == null) {
                            eventHappendedHandler.Disconnect ();
                            eventHappendedHandler = null;
                        }
                    }
                }
            }

            void NativeEventHappened ()
            {
                if (eventHappend != null) {
                    eventHappend ();
                }
            }

            readonly uint eventHappendSignalId;
            public void OnEventHappened ()
            {
                Signal.Emit (this, eventHappendSignalId);
            }

            public TestObjectSignal ()
                : this (New<TestObjectSignal> (), Transfer.Full)
            {
            }

            protected TestObjectSignal (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
                eventHappendSignalId = Signal.Lookup (nameof(EventHappened), this.GetGType ());
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr @object);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr @object);
    }
}
