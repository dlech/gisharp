using System;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class BindingTests
    {
        [Test]
        public void TestBindProperty ()
        {
            var obj1 = new TestObject ();
            var obj2 = new TestObject ();
            var binding = obj1.BindProperty (nameof (TestObject.IntValue),
                                             obj2, nameof (TestObject.IntValue));
            Assume.That (obj1.IntValue, Is.EqualTo (0));
            Assume.That (obj2.IntValue, Is.EqualTo (0));

            // test that binding is in effect
            obj1.IntValue = 1;
            Assert.That (obj2.IntValue, Is.EqualTo (1));

            // test that binding is no longer effect
            binding.Unbind ();
            obj1.IntValue = 2;
            Assert.That (obj2.IntValue, Is.EqualTo (1));
        }

        static bool Plus5 (Binding binding, ref Value fromValue, ref Value toValue)
        {
            toValue.Set ((int)fromValue + 5);
            return true;
        }

        [Test]
        public void TestBindPropertyFull ()
        {
            var obj1 = new TestObject ();
            var obj2 = new TestObject ();
            var binding = obj1.BindProperty (nameof (TestObject.IntValue),
                                             obj2, nameof (TestObject.IntValue),
                                             BindingFlags.Default, Plus5, null);
            Assume.That (obj1.IntValue, Is.EqualTo (0));
            Assume.That (obj2.IntValue, Is.EqualTo (0));

            // test that binding is in effect
            obj1.IntValue = 1;
            Assert.That (obj2.IntValue, Is.EqualTo (6));

            // test that binding is no longer effect
            binding.Unbind ();
            obj1.IntValue = 2;
            Assert.That (obj2.IntValue, Is.EqualTo (6));
        }
    }

    [GType]
    class TestObject : GISharp.GObject.Object
    {
        int _IntValue;
        [Runtime.Property]
        public int IntValue {
            get {
                return _IntValue;
            }
            set {
                _IntValue = value;
                Notify (nameof (IntValue));
            }
        }

        public TestObject ()
                : this (New<TestObject> (), Transfer.Full)
            {
        }

        protected TestObject (IntPtr handle, Transfer ownership)
                : base (handle, ownership)
            {
        }
    }
}
