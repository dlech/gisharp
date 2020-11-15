using System;
using System.ComponentModel;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.Core.GObject
{
    public class BindingTests : Tests
    {
        [Test]
        public void TestBindProperty()
        {
            using var obj1 = TestObject.New();
            using var obj2 = TestObject.New();
            using var binding = obj1.BindProperty(
                nameof(TestObject.IntValue), obj2, nameof(TestObject.IntValue));
            Assume.That(obj1.IntValue, Is.EqualTo(0));
            Assume.That(obj2.IntValue, Is.EqualTo(0));

            // test that binding is in effect
            obj1.IntValue = 1;
            Assert.That(obj2.IntValue, Is.EqualTo(1));

            // test that binding is no longer effect
            binding.Unbind();
            obj1.IntValue = 2;
            Assert.That(obj2.IntValue, Is.EqualTo(1));
        }

        static bool Plus5(Binding binding, ref Value fromValue, ref Value toValue)
        {
            toValue.Set((int)fromValue + 5);
            return true;
        }

        [Test]
        public void TestBindPropertyFull()
        {
            using var obj1 = TestObject.New();
            using var obj2 = TestObject.New();
            using var binding = obj1.BindProperty(
                nameof(TestObject.IntValue), obj2, nameof(TestObject.IntValue),
                BindingFlags.Default, Plus5, null);
            Assume.That(obj1.IntValue, Is.EqualTo(0));
            Assume.That(obj2.IntValue, Is.EqualTo(0));

            // test that binding is in effect
            obj1.IntValue = 1;
            Assert.That(obj2.IntValue, Is.EqualTo(6));

            // test that binding is no longer effect
            binding.Unbind();
            obj1.IntValue = 2;
            Assert.That(obj2.IntValue, Is.EqualTo(6));
        }
    }

    [GType]
    class TestObject : Object
    {
        int _IntValue;
        [GProperty]
        public int IntValue {
            get {
                return _IntValue;
            }
            set {
                _IntValue = value;
                Notify(nameof(IntValue));
            }
        }

        public static TestObject New()
        {
            return CreateInstance<TestObject>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestObject(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }
    }
}
