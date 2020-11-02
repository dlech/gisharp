using System;

using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.Core.GLib
{
    public class SListTests : Tests
    {
        [Test]
        public void TestConstructor ()
        {
            using (var list = new SList<OpaqueInt> ()) {
                Assert.That (list, Is.Not.Null);
            }
        }

        [Test]
        public void TestAppend ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                Assume.That (list.Length, Is.EqualTo (0));
                list.Append (null);
                Assert.That (list.Length, Is.EqualTo (1));
            }
        }

        [Test]
        public void TestPrepend ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                Assume.That (list.Length, Is.EqualTo (0));
                list.Prepend (null);
                Assert.That (list.Length, Is.EqualTo (1));
            }
        }

        [Test]
        public void TestInsert ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                Assume.That (list.Length, Is.EqualTo (0));
                list.Insert (null, 0);
                Assert.That (list.Length, Is.EqualTo (1));
            }
        }

        [Test]
        public void TestInsertBefore ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                Assume.That (list.Length, Is.EqualTo (0));
                list.InsertBefore (null, null);
                Assert.That (list.Length, Is.EqualTo (1));
            }
        }

        [Test]
        public void TestInsertSorted ()
        {
            Comparison<OpaqueInt> compareFunc = (a, b) =>
                a.Value.CompareTo (b.Value);
            using (var list = new SList<OpaqueInt> ()) {
                Assume.That (list.Length, Is.EqualTo (0));
                list.InsertSorted (new OpaqueInt (1), compareFunc);
                Assert.That (list.Length, Is.EqualTo (1));

                // check that it actually sorts items
                list.InsertSorted (new OpaqueInt (3), compareFunc);
                list.InsertSorted (new OpaqueInt (2), compareFunc);
                Assert.That (list.Length, Is.EqualTo (3));
                Assert.That (list[0].Value, Is.EqualTo (1));
                Assert.That (list[1].Value, Is.EqualTo (2));
                Assert.That (list[2].Value, Is.EqualTo (3));
            }
        }

        [Test]
        public void TestRemove ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                list.Append (null);
                Assume.That (list.Length, Is.EqualTo (1));
                list.Remove (null);
                Assert.That (list.Length, Is.EqualTo (0));
            }
        }

        [Test]
        public void TestRemoveAll ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                list.Append (null);
                Assume.That (list.Length, Is.EqualTo (1));
                list.RemoveAll (null);
                Assert.That (list.Length, Is.EqualTo (0));
            }
        }

        [Test]
        public void TestCopy ()
        {
            using (var list = new SList<OpaqueInt?>()) {
                list.Append (null);
                Assume.That (list.Length, Is.EqualTo (1));
                var newList = list.Copy ();
                Assert.That (list.Length, Is.EqualTo (1));
                Assert.That (newList.Length, Is.EqualTo (1));
            }
        }

        [Test]
        public void TestReverse ()
        {
            using (var list = new SList<OpaqueInt> ()) {
                list.Prepend (new OpaqueInt (1));
                list.Prepend (new OpaqueInt (2));
                Assume.That (list.Length, Is.EqualTo (2));
                Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)2));
                Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)1));
                list.Reverse ();
                Assert.That (list.Length, Is.EqualTo (2));
                Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)1));
                Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)2));
            }
        }

        [Test]
        public void TestSort ()
        {
            var compareFuncWasCalled = false;
            Comparison<OpaqueInt> compareFunc = (a, b) => {
                compareFuncWasCalled = true;
                return a.Handle.ToInt32 ().CompareTo (b.Handle.ToInt32 ());
            };
            using (var list = new SList<OpaqueInt> ()) {
                list.Prepend (new OpaqueInt (1));
                list.Prepend (new OpaqueInt (2));
                Assume.That (list.Length, Is.EqualTo (2));
                Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)2));
                Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)1));
                list.Sort (compareFunc);
                Assert.That (compareFuncWasCalled);
                Assert.That (list.Length, Is.EqualTo (2));
                Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)1));
                Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)2));
            }
        }

        [Test]
        public void TestConcat ()
        {
            using (var list1 = new SList<OpaqueInt?>())
            using (var list2 = new SList<OpaqueInt?>()) {
                list1.Append (null);
                Assume.That (list1.Length, Is.EqualTo (1));
                list2.Append (null);
                list2.Append (null);
                Assume.That (list2.Length, Is.EqualTo (2));
                list1.Concat (list2);
                Assert.That (list1.Length, Is.EqualTo (3));
                Assert.That (list2.Length, Is.EqualTo (0));
            }
        }

        [Test]
        public void TestEnumerator ()
        {
            // check that callback is called
            using (var list = new SList<OpaqueInt> ()) {
                list.Append (new OpaqueInt (1));
                list.Append (new OpaqueInt (2));
                list.Append (new OpaqueInt (3));
                int i = 1;
                foreach (var n in list) {
                    Assert.That (n.Value, Is.EqualTo (i++));
                }
            }
        }

        [Test]
        public void TestIndex ()
        {
            using (var list = new SList<OpaqueInt> ()) {
                list.Append (new OpaqueInt (1));
                list.Append (new OpaqueInt (2));
                list.Append (new OpaqueInt (3));
                list.Append (new OpaqueInt (4));
                // check that finding an item returns the index
                var index = list.IndexOf (new OpaqueInt (3));
                Assert.That (index, Is.EqualTo (2));
                // check that not finding an item returns -1
                index = list.IndexOf (new OpaqueInt (5));
                Assert.That (index, Is.EqualTo (-1));
            }
        }
    }
}
