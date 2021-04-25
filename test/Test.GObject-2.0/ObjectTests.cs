// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.GObject
{
    public class ObjectTests
    {
        [Test]
        public void TestReferences()
        {
            using var o1 = new Object();
            var handle = o1.UnsafeHandle;

            // getting an object that already exists should return that object
            var o2 = Object.GetInstance(handle, Transfer.None)!;
            try {
                Assert.That(ReferenceEquals(o1, o2), Is.True);

                // Simulate unmanaged code taking a reference so that the handle is
                // not freed when o1 is disposed.
                g_object_ref(handle);

                // After an object is disposed we should get a new object rather
                // than the disposed object.
                o1.Dispose();

                // Normally, we would not dispose an object if there is a possibility
                // that it could be used again because it will loose any state that
                // is stored in the managed object. Instead, a GCHandle will keep
                // the object alive as long as unmanaged code has a reference to the
                // object.

                // Transfer.All means the new object takes ownership of the reference
                // from the manual call to g_object_ref(), so we don't need to call
                // g_object_unref() manually.
                o2 = Object.GetInstance(handle, Transfer.Full)!;
                Assert.That(ReferenceEquals(o1, o2), Is.False);
            }
            finally {
                o2.Dispose();
            }
        }

        [Test]
        public void TestToggleRef()
        {
            WeakReference? weakRef = null;

            new Action(() => weakRef = new WeakReference(new Object())).Invoke();

            // first make sure our testing method is sane and Object is really GC'ed
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assume.That(weakRef!.IsAlive, Is.False);

            // Now for the actual test.

            IntPtr handle = IntPtr.Zero;
            new Action(() => {
                var o = new Object();
                weakRef = new(o);
                // Simulate unmanaged code taking a reference. This should trigger
                // the toggle reference which prevents the object from being GC'ed
                handle = o.UnsafeHandle;
                g_object_ref(handle);
            }).Invoke();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assert.That(weakRef!.IsAlive, Is.True);

            // Simulates unmanaged code releasing the last reference. This should
            // free the GCHandle.
            g_object_unref(handle);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assert.That(weakRef!.IsAlive, Is.False);
        }

        [Test]
        public void TestSubclass()
        {
            // Test that a subclass is properly registered with the GObject
            // type system.

            // Objects without the GType attribute will fail.
            Assert.That(() => typeof(TestObject1).ToGType(),
                Throws.ArgumentException);

            // Objects that do not inherit from GISharp.Lib.GObject.Object fail
            Assert.That(() => typeof(TestObject2).ToGType(),
                Throws.ArgumentException);

            // this one should actually work since it is setup correctly
            var testObject3GType = typeof(TestObject3).ToGType();
            Assert.That(testObject3GType, Is.Not.EqualTo(GType.Invalid));

            Assert.That(() => TestObject3.New().Dispose(), Throws.Nothing);
        }

        [Test]
        public void TestSubclassPropertyRegistration()
        {
            using var obj = TestObjectPropertiesBase.New();
            // check if setting properties from unmanged code works
            Assume.That(obj.IntValue, Is.EqualTo(0));
            obj.SetProperty(nameof(obj.IntValue), 1);
            Assert.That(obj.IntValue, Is.EqualTo(1));

            // also make sure that non-GTypes get boxed
            Assume.That(obj.ObjectProperty, Is.Null);
            var expectedObj = new object();
            obj.SetProperty(nameof(obj.ObjectProperty), new Boxed<object?>(expectedObj));
            Assert.That(obj.ObjectProperty?.Value, Is.SameAs(expectedObj));
        }

        [Test]
        public void TestSubclassPropertyOverride()
        {
            using var obj = TestObjectPropertiesSubclass.New();
            // the new keyword does not override a property, just hides it...

            Assume.That(obj.IntValue, Is.EqualTo(0));
            obj.SetProperty(nameof(obj.IntValue), 1);
            Assert.That(obj.IntValue, Is.EqualTo(1));

            Assert.That(((TestObjectPropertiesBase)obj).IntValue, Is.EqualTo(0));

            using var baseObjClass = (ObjectClass)TypeClass.Get(typeof(TestObjectPropertiesBase).ToGType());
            using var subclassObjClass = (ObjectClass)TypeClass.Get(typeof(TestObjectPropertiesSubclass).ToGType());
            using (var baseIntValueProp = baseObjClass.FindProperty(nameof(obj.IntValue))!)
            using (var subclassIntValueProp = subclassObjClass.FindProperty(nameof(obj.IntValue))!) {
                // ...so ParamSpecs should not be the same
                Assert.That(baseIntValueProp.UnsafeHandle, Is.Not.EqualTo(subclassIntValueProp.UnsafeHandle));
            }

            // But the override keyword replaces property...

            Assume.That(obj.BoolValue, Is.False);
            obj.SetProperty("bool-value", true);
            Assert.That(obj.BoolValue, Is.True);

            using var baseBoolValueProp = baseObjClass.FindProperty("bool-value")!;
            using var subclassBoolValueProp = subclassObjClass.FindProperty("bool-value")!;
            // ...so ParamSpecs should be the same
            Assert.That(baseBoolValueProp.UnsafeHandle, Is.EqualTo(subclassBoolValueProp.UnsafeHandle));
        }

        [Test]
        public void TestPropertyChangeNotification()
        {
            using var obj = TestObjectPropertiesBase.New();
            var notificationCount = 0;

            ((INotifyPropertyChanged)obj).PropertyChanged += (sender, e) => {
                Assert.That(e.PropertyName == nameof(obj.DoubleValue));
                notificationCount++;
            };

            // IntValue does not notify of property change
            obj.IntValue = 1;
            Assert.That(notificationCount, Is.EqualTo(0));

            // likewise, setting the property from unmanged code should not
            // trigger a change either
            obj.SetProperty(nameof(obj.IntValue), 1);
            Assert.That(notificationCount, Is.EqualTo(0));

            // DoubleValue does notify
            obj.DoubleValue = 1;
            Assert.That(notificationCount, Is.EqualTo(1));

            // also make sure changing the property from unmanged code
            // notifies and that it only notifies once
            obj.SetProperty(nameof(obj.DoubleValue), 1.0);
            Assert.That(notificationCount, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyComponentModelAttributes()
        {
            // check that ComponentModel attributes map to ParamSpec
            using (var baseObj = TestObjectPropertiesBase.New())
            using (var baseObjClass = TypeClass.GetInstance<ObjectClass>(baseObj.GetGType()))
            using (var basePspec = baseObjClass.FindProperty("bool-value")!) {
                Assert.That<string>(basePspec.Name, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyName));
                Assert.That<string>(basePspec.Nick, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyNick));
                Assert.That<string?>(basePspec.Blurb, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyBlurb));
                Assert.That(basePspec.DefaultValue.Get(),
                    Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyDefaultValue));
            }

            // The subclass will inherit the values of the parent class.
            // If the subclass tries to declare an attribute again, it will
            // be ignored as is the case with DefaultValueAttribute here.
            using var subObj = TestObjectPropertiesSubclass.New();
            using var subObjClass = TypeClass.GetInstance<ObjectClass>(subObj.GetGType());
            using var subPspec = subObjClass.FindProperty("bool-value")!;
            Assert.That<string>(subPspec.Name, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyName));
            Assert.That<string>(subPspec.Nick, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyNick));
            Assert.That<string?>(subPspec.Blurb, Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyBlurb));
            Assert.That(subPspec.DefaultValue.Get(),
                Is.EqualTo(TestObjectPropertiesBase.BoolValuePropertyDefaultValue));
        }

        [Test]
        public void TestEventSignal()
        {
            using var obj = new Object();
            var id = Signal.Lookup<Object>("notify");
            Assume.That(id, Is.Not.Zero);
            Assume.That(() => Signal.HandlerFind(obj, id), Throws.Exception);

            static void notify(Object gobject, ParamSpec pspec)
            {
            }

            // adding event handler should connect signal
            obj.NotifySignal += notify;
            Assert.That(Signal.HandlerFind(obj, id), Is.Not.Null);

            // removing event handler should disconnect signal
            obj.NotifySignal -= notify;
            Assert.That(() => Signal.HandlerFind(obj, id), Throws.Exception);

            // removing non-added event should throw
            Assert.That(() => obj.NotifySignal -= notify, Throws.Exception);
        }

        [Test]
        public void TestSignalRegistration()
        {
            using var obj = TestObjectSignal.New();
            var eventCount = 0;

            obj.EventHappened += () => eventCount++;

            // check that emitting the signal from unmanaged code fires the event
            obj.OnEventHappened();

            Assert.That(eventCount, Is.EqualTo(1));
        }

        // This will fail because it lacks the GTypeAttribute
        class TestObject1 : Object
        {
        }

        // This will fail because it does not inherit from GISharp.Lib.GObject.Object
        [GType]
        class TestObject2
        {
        }

        [GType]
        class TestObject3 : Object
        {
            public static TestObject3 New()
            {
                return CreateInstance<TestObject3>();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TestObject3(IntPtr handle, Transfer ownership) : base(handle, ownership)
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
            [DisplayName(BoolValuePropertyNick)]
            [System.ComponentModel.Description(BoolValuePropertyBlurb)]
            [DefaultValue(BoolValuePropertyDefaultValue)]
            public virtual bool BoolValue { get; set; } = BoolValuePropertyDefaultValue;

            double _DoubleValue;
            [GProperty]
            public double DoubleValue {
                get {
                    return _DoubleValue;
                }
                set {
                    _DoubleValue = value;
                    Notify(nameof(DoubleValue));
                }
            }

            [GProperty]
            public Boxed<object?>? ObjectProperty { get; set; }

            public static TestObjectPropertiesBase New()
            {
                return CreateInstance<TestObjectPropertiesBase>();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TestObjectPropertiesBase(IntPtr handle, Transfer ownership) : base(handle, ownership)
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
            [DefaultValue(!BoolValuePropertyDefaultValue)]
            public override bool BoolValue { get; set; } = !BoolValuePropertyDefaultValue;

            public static new TestObjectPropertiesSubclass New()
            {
                return CreateInstance<TestObjectPropertiesSubclass>();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TestObjectPropertiesSubclass(IntPtr handle, Transfer ownership) : base(handle, ownership)
            {
            }
        }

        [GType]
        class TestObjectSignal : Object
        {
            [GSignal]
            public event Action? EventHappened;

            readonly uint eventHappendSignalId;
            public void OnEventHappened()
            {
                this.Emit(eventHappendSignalId);
            }

            public static TestObjectSignal New()
            {
                return CreateInstance<TestObjectSignal>();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TestObjectSignal(IntPtr handle, Transfer ownership) : base(handle, ownership)
            {
                eventHappendSignalId = Signal.Lookup<TestObjectSignal>(nameof(EventHappened));
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref(IntPtr @object);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref(IntPtr @object);
    }
}
