using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GObject;
using GISharp.Runtime;

using Object = GISharp.GObject.Object;
using System.Collections.Generic;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class ObjectTests
    {
        [Test]
        public void TestReferences ()
        {
            using (var o1 = new Object()) {
                var handle = o1.Handle;

                // getting an object that already exists should return that object
                var o2 = Object.GetInstance(handle, Transfer.None);
                try {
                    Assert.That (ReferenceEquals (o1, o2), Is.True);

                    // Simulate unmanaged code taking a reference so that the handle is
                    // not freed when o1 is disposed.
                    g_object_ref (handle);

                    // After an object is disposed we should get a new object rather
                    // than the disposed object.
                    o1.Dispose ();

                    // Normally, we would not dispose an object if there is a possibility
                    // that it could be used again because it will loose any state that
                    // is stored in the managed object. Instead, a GCHandle will keep
                    // the object alive as long as unmanaged code has a reference to the
                    // object.

                    // Transfer.All means the new object takes ownership of the reference
                    // from the manual call to g_object_ref(), so we don't need to call
                    // g_object_unref() manually.
                    o2 = Object.GetInstance(handle, Transfer.Full);
                    Assert.That (ReferenceEquals (o1, o2), Is.False);
                }
                finally {
                    o2.Dispose ();
                }
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestToggleRef ()
        {
            WeakReference weakRef = null;

            new Action (() => weakRef = new WeakReference(new Object())).Invoke();

            // first make sure our testing method is sane and Object is really GC'ed
            GC.Collect ();
            GC.WaitForPendingFinalizers ();
            Assume.That (weakRef.IsAlive, Is.False);

            // Now for the actual test.

            IntPtr handle = IntPtr.Zero;
            new Action (() => {
                var o = new Object();
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

            Utility.AssertNoGLibLog();
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

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestSubclassPropertyRegistration ()
        {
            using (var obj = new TestObjectPropertiesBase ()) {
                // check if setting properties from unmanged code works
                Assume.That (obj.IntValue, Is.EqualTo (0));
                obj.SetProperty(nameof(obj.IntValue), 1);
                Assert.That (obj.IntValue, Is.EqualTo (1));

                // also make sure that non-GTypes get boxed
                Assume.That (obj.ObjectProperty, Is.Null);
                var expectedObj = new object ();
                obj.SetProperty(nameof(obj.ObjectProperty), expectedObj);
                Assert.That (obj.ObjectProperty, Is.SameAs (expectedObj));
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestSubclassPropertyOverride ()
        {
            using (var obj = new TestObjectPropertiesSubclass ()) {
                // the new keyword does not override a property, just hides it...

                Assume.That (obj.IntValue, Is.EqualTo (0));
                obj.SetProperty(nameof(obj.IntValue), 1);
                Assert.That (obj.IntValue, Is.EqualTo (1));

                Assert.That (((TestObjectPropertiesBase)obj).IntValue, Is.EqualTo (0));

                using (var baseObjClass = (ObjectClass)TypeClass.Get (typeof(TestObjectPropertiesBase).GetGType ()))
                using (var subclassObjClass = (ObjectClass)TypeClass.Get (typeof(TestObjectPropertiesSubclass).GetGType ())) {
                    using (var baseIntValueProp = baseObjClass.FindProperty (nameof (obj.IntValue)))
                    using (var subclassIntValueProp = subclassObjClass.FindProperty (nameof (obj.IntValue))) {
                        // ...so ParamSpecs should not be the same
                        Assert.That (baseIntValueProp.Handle, Is.Not.EqualTo (subclassIntValueProp.Handle));
                    }

                    // But the override keyword replaces property...

                    Assume.That (obj.BoolValue, Is.False);
                    obj.SetProperty("bool-value", true);
                    Assert.That (obj.BoolValue, Is.True);

                    Assert.That (((TestObjectPropertiesBase)obj).BoolValue, Is.True);

                    using (var baseBoolValueProp = baseObjClass.FindProperty ("bool-value"))
                    using (var subclassBoolValueProp = subclassObjClass.FindProperty ("bool-value")) {
                        // ...so ParamSpecs should be the same
                        Assert.That (baseBoolValueProp.Handle, Is.EqualTo (subclassBoolValueProp.Handle));
                    }
                }
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestPropertyChangeNotification ()
        {
            using (var obj = new TestObjectPropertiesBase ()) {
                var notificationCount = 0;

                obj.PropertyChanged += (sender, e) => {
                    Assert.That (e.PropertyName == nameof (obj.DoubleValue));
                    notificationCount++;
                };

                // IntValue does not notify of property change
                obj.IntValue = 1;
                Assert.That (notificationCount, Is.EqualTo (0));

                // likewise, setting the property from unmanged code should not
                // trigger a change either
                obj.SetProperty(nameof(obj.IntValue), 1);
                Assert.That (notificationCount, Is.EqualTo (0));

                // DoubleValue does notify
                obj.DoubleValue = 1;
                Assert.That (notificationCount, Is.EqualTo (1));

                // also make sure changing the property from unmanged code
                // notifies and that it only notifies once
                obj.SetProperty(nameof(obj.DoubleValue), 1.0);
                Assert.That (notificationCount, Is.EqualTo (2));
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestPropertyComponentModelAttributes ()
        {
            // check that ComponentModel attributes map to ParamSpec
            using (var baseObj = new TestObjectPropertiesBase ())
            using (var baseObjClass = (ObjectClass)TypeClass.Get (baseObj.GetGType ()))
            using (var basePspec = baseObjClass.FindProperty ("bool-value")) {
                Assert.That (basePspec.Name, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyName));
                Assert.That (basePspec.Nick, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyNick));
                Assert.That (basePspec.Blurb, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyBlurb));
                Assert.That (basePspec.DefaultValue.Get (),
                    Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyDefaultValue));
            }

            // The subclass will inherit the values of the parent class.
            // If the subclass tries to declare an attribute again, it will
            // be ignored as is the case with DefaultValueAttribute here.
            using (var subObj = new TestObjectPropertiesSubclass ())
            using (var subObjClass = (ObjectClass)TypeClass.Get (subObj.GetGType ()))
            using (var subPspec = subObjClass.FindProperty ("bool-value")) {
                Assert.That (subPspec.Name, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyName));
                Assert.That (subPspec.Nick, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyNick));
                Assert.That (subPspec.Blurb, Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyBlurb));
                Assert.That (subPspec.DefaultValue.Get (),
                    Is.EqualTo (TestObjectPropertiesBase.BoolValuePropertyDefaultValue));
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestSignalRegistration ()
        {
            using (var obj = new TestObjectSignal ()) {
                var eventCount = 0;

                obj.EventHappened += () => eventCount++;

                // check that emitting the signal from unmanaged code fires the event
                obj.OnEventHappened ();

                Assert.That (eventCount, Is.EqualTo (1));
            }

            Utility.AssertNoGLibLog();
        }

        // This will fail because it lacks the GTypeAttribute
        class TestObject1 : Object
        {
        }

        // This will fail because it does not inherit from GISharp.Core.Object
        [GType]
        class TestObject2
        {
        }

        [GType]
        class TestObject3 : Object
        {
            public TestObject3 () : this (New<TestObject3> (), Transfer.Full)
            {
            }

            public TestObject3 (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectPropertiesBase : Object
        {
            [GProperty]
            public int IntValue { get; set; }

            public const string BoolValuePropertyName = "bool-value";
            public const string BoolValuePropertyNick = "Boolean Value";
            public const string BoolValuePropertyBlurb = "A boolean value for testing stuff.";
            public const bool BoolValuePropertyDefaultValue = true;

            [GProperty(BoolValuePropertyName)]
            [DisplayName (BoolValuePropertyNick)]
            [System.ComponentModel.Description (BoolValuePropertyBlurb)]
            [DefaultValue (BoolValuePropertyDefaultValue)]
            public virtual bool BoolValue { get; set; } = BoolValuePropertyDefaultValue;

            double _DoubleValue;
            [GProperty]
            public double DoubleValue {
                get {
                    return _DoubleValue;
                }
                set {
                    _DoubleValue = value;
                    EmitNotify(nameof(DoubleValue));
                }
            }

            [GProperty]
            public object ObjectProperty { get; set; }

            public TestObjectPropertiesBase () : this (New<TestObjectPropertiesBase> (), Transfer.Full)
            {
            }

            public TestObjectPropertiesBase (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectPropertiesSubclass : TestObjectPropertiesBase
        {
            [GProperty]
            public new int IntValue { get; set; }

            // PropertyAttribute is inherited, so GObject property name will be "bool-value"
            // ComponentModel attributes are ignored on overridden properties though,
            // so setting DefaultValueAttribute here will not have an effect on
            // the default value as far as the GObject type system is concerned.
            [DefaultValue (!BoolValuePropertyDefaultValue)]
            public override bool BoolValue { get; set; } = !BoolValuePropertyDefaultValue;

            public TestObjectPropertiesSubclass () : this (New<TestObjectPropertiesSubclass> (), Transfer.Full)
            {
            }

            public TestObjectPropertiesSubclass (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectSignal : Object
        {
            object eventHappendHandlerLock = new object ();
            Dictionary<Action, SignalHandler> eventHappendHandlers = new Dictionary<Action, SignalHandler>();

            [GSignal]
            public event Action EventHappened {
                add {
                    lock (eventHappendHandlerLock) {
                        eventHappendHandlers[value] = this.Connect(nameof(EventHappened),
                            UnmanagedEventHappenedCallbackFactory.CreateNotifyCallback, value);
                    }
                }
                remove {
                    lock (eventHappendHandlerLock) {
                        eventHappendHandlers[value].Disconnect();
                    }
                }
            }
            static class UnmanagedEventHappenedCallbackFactory
            {
                public static ValueTuple<Delegate, UnmanagedClosureNotify, IntPtr> CreateNotifyCallback(Action handler)
                {
                    Action unmangedHandler = () => {
                        try {
                            handler();
                        }
                        catch (Exception ex) {
                            ex.DumpUnhandledException();
                        }
                    };
                    var gcHandle = GCHandle.Alloc(unmangedHandler);

                    return (unmangedHandler, unmanagedNotifyDelegate, (IntPtr)gcHandle);
                }

                static UnmanagedClosureNotify unmanagedNotifyDelegate = UnmanagedNotify;

                static void UnmanagedNotify(IntPtr data_, IntPtr closure_)
                {
                    try {
                        var gcHandle = (GCHandle)data_;
                        gcHandle.Free();
                    }
                    catch (Exception ex) {
                        ex.DumpUnhandledException();
                    }
                }
            }

            readonly uint eventHappendSignalId;
            public void OnEventHappened ()
            {
                Signal.Emit (this, eventHappendSignalId);
            }

            public TestObjectSignal () : this (New<TestObjectSignal> (), Transfer.Full)
            {
            }

            public TestObjectSignal (IntPtr handle, Transfer ownership) : base (handle, ownership)
            {
                eventHappendSignalId = Signal.TryLookup<TestObjectSignal>(nameof(EventHappened));
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr @object);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr @object);
    }
}
