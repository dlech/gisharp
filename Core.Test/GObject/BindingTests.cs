using System;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class BindingTests
    {
        [Test]
        public void TestBindProperty ()
        {
            using (var obj1 = new TestObject ())
            using (var obj2 = new TestObject ())
            using (var binding = obj1.BindProperty (nameof(TestObject.IntValue),
                                                    obj2, nameof(TestObject.IntValue))) {
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

            AssertNoGLibLog();
        }

        static bool Plus5 (Binding binding, ref Value fromValue, ref Value toValue)
        {
            toValue.Set ((int)fromValue + 5);
            return true;
        }

        [Test]
        public void TestBindPropertyFull ()
        {
            using (var obj1 = new TestObject ())
            using (var obj2 = new TestObject ())
            using (var binding = obj1.BindProperty (nameof(TestObject.IntValue),
                                                    obj2, nameof(TestObject.IntValue),
                                                    BindingFlags.Default, Plus5, null)) {
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

            AssertNoGLibLog();
        }
    }

    [GType]
    class TestObject : GISharp.Lib.GObject.Object
    {
        int _IntValue;
        [GProperty]
        public int IntValue {
            get {
                return _IntValue;
            }
            set {
                _IntValue = value;
                EmitNotify(nameof(IntValue));
            }
        }

        public TestObject () : this (New<TestObject> (), Transfer.Full)
        {
        }

        public TestObject (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
