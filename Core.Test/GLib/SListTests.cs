using System;

using NUnit.Framework;
using GISharp.GLib;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class SListTests
    {
        [Test]
        public void TestConstructor ()
        {
            var list = new SList<TestOpaque> ();
            Assert.That (list.Owned, Is.True);
        }

        [Test]
        public void TestAppend ()
        {
            var list = new SList<TestOpaque> ();
            Assume.That (list.Length, Is.EqualTo (0));
            // adding new item takes ownership of old pointer
            var newList = list.Append (null);
            Assert.That (list.Length, Is.EqualTo (0));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling append on unowned pointer is not allowed
            Assert.That (() => list.Append (null),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestPrepend ()
        {
            var list = new SList<TestOpaque> ();
            Assume.That (list.Length, Is.EqualTo (0));
            // adding new item takes ownership of old pointer
            var newList = list.Prepend (null);
            Assert.That (list.Length, Is.EqualTo (0));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling prepend on unowned pointer is not allowed
            Assert.That (() => list.Prepend (null),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestInsert ()
        {
            var list = new SList<TestOpaque> ();
            Assume.That (list.Length, Is.EqualTo (0));
            // adding new item takes ownership of old pointer
            var newList = list.Insert (null, 0);
            Assert.That (list.Length, Is.EqualTo (0));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling insert on unowned pointer is not allowed
            Assert.That (() => list.Insert (null, 0),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestInsertBefore ()
        {
            var list = new SList<TestOpaque> ();
            Assume.That (list.Length, Is.EqualTo (0));
            // adding new item takes ownership of old pointer
            var newList = list.InsertBefore (null, null);
            Assert.That (list.Length, Is.EqualTo (0));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling insert on unowned pointer is not allowed
            Assert.That (() => list.InsertBefore (null, null),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestInsertSorted ()
        {
            CompareFunc<TestOpaque> compareFunc = (a, b) =>
                a.Value.CompareTo (b.Value);
            var list = new SList<TestOpaque> ();
            Assume.That (list.Length, Is.EqualTo (0));
            // adding new item takes ownership of old pointer
            var newList = list.InsertSorted (new TestOpaque (1), compareFunc);
            Assert.That (list.Length, Is.EqualTo (0));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // check that it actually sorts items
            newList = newList.InsertSorted (new TestOpaque (3), compareFunc);
            newList = newList.InsertSorted (new TestOpaque (2), compareFunc);
            Assert.That (newList.Length, Is.EqualTo (3));
            Assert.That (newList[0].Value, Is.EqualTo (1));
            Assert.That (newList[1].Value, Is.EqualTo (2));
            Assert.That (newList[2].Value, Is.EqualTo (3));
            // calling without a sort function is not allowed
            Assert.That (() => newList.InsertSorted (new TestOpaque (4), null),
                Throws.InstanceOf<ArgumentNullException> ());
            // calling insert on unowned pointer is not allowed
            Assert.That (() => list.InsertSorted (null, compareFunc),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemove ()
        {
            var list = new SList<TestOpaque> ().Append (null);
            Assume.That (list.Length, Is.EqualTo (1));
            // removing item takes ownership of old pointer
            var newList = list.Remove (null);
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (0));
            Assert.That (newList.Owned, Is.True);
            // calling remove on unowned pointer is not allowed
            Assert.That (() => list.Remove (null),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveLink ()
        {
            var list = new SList<TestOpaque> ().Append (null);
            Assume.That (list.Length, Is.EqualTo (1));
            // removing item does not take ownership of old pointer
            var newList = list.RemoveLink (list);
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.True);
            list.Free1 ();
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (0));
            Assert.That (newList.Owned, Is.True);
            Assert.That (() => list.RemoveLink (list),
                Throws.InstanceOf<ObjectDisposedException> ());
            list = new SList<TestOpaque> ().Append (null);
            // calling remove on unowned pointer is not allowed
            Assert.That (() => list.Last.RemoveLink (newList),
                Throws.InvalidOperationException);
            // calling without a link is not allowed
            Assert.That (() => list.RemoveLink (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestDeleteLink ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2));
            Assume.That (list.Length, Is.EqualTo (2));
            // removing item takes ownership of old pointer
            var newList = list.DeleteLink (list.Last);
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // removing item disposes pointer to that item
            list = new SList<TestOpaque> ().Append (null);
            newList = list.DeleteLink (list);
            // check that deleted link is disposed
            Assert.That (() => newList.DeleteLink (list),
                Throws.InstanceOf<ObjectDisposedException> ());
            // calling remove on unowned pointer is not allowed
            list = new SList<TestOpaque> ().Append (null);
            Assert.That (() => list.Last.DeleteLink (list),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveAll ()
        {
            var list = new SList<TestOpaque> ().Append (null);
            Assume.That (list.Length, Is.EqualTo (1));
            // removing item takes ownership of old pointer
            var newList = list.RemoveAll (null);
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (0));
            Assert.That (newList.Owned, Is.True);
            // calling remove on unowned pointer is not allowed
            Assert.That (() => list.RemoveAll (null),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestCopy ()
        {
            var list = new SList<TestOpaque> ().Append (null);
            Assume.That (list.Length, Is.EqualTo (1));
            // copying does not take ownership of old pointer
            var newList = list.Copy ();
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.True);
            // return value is also owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling copy on unowned pointer is not allowed
            Assert.That (() => list.Last.Copy (),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestCopyDeep ()
        {
            var copyFuncWasCalled = false;
            CopyFunc<TestOpaque> copyFunc = (src) => {
                copyFuncWasCalled = true;
                if (src == null) {
                    return null;
                }
                var ret = new TestOpaque (src.Value);
                return ret;
            };
            var list = new SList<TestOpaque> ().Append (null);
            Assume.That (list.Length, Is.EqualTo (1));
            // copying does not take ownership of old pointer
            var newList = list.CopyDeep (copyFunc);
            Assert.That (copyFuncWasCalled);
            Assert.That (list.Length, Is.EqualTo (1));
            Assert.That (list.Owned, Is.True);
            // return value is also owned head of list
            Assert.That (newList.Length, Is.EqualTo (1));
            Assert.That (newList.Owned, Is.True);
            // calling without a copy function is not allowed
            Assert.That (() => list.CopyDeep (null),
                Throws.InstanceOf<ArgumentNullException> ());
            // calling copy on unowned pointer is not allowed
            Assert.That (() => list.Last.CopyDeep (copyFunc),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestReverse ()
        {
            var list = new SList<TestOpaque> ()
                .Prepend (new TestOpaque (1))
                .Prepend (new TestOpaque (2));
            Assume.That (list.Length, Is.EqualTo (2));
            Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)2));
            Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)1));
            // reversing takes ownership of old pointer
            var newList = list.Reverse ();
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (2));
            Assert.That (newList.Owned, Is.True);
            // make sure list was actually reversed
            Assume.That (newList[0].Handle, Is.EqualTo ((IntPtr)1));
            Assume.That (newList[1].Handle, Is.EqualTo ((IntPtr)2));
            // calling reverse on unowned pointer is not allowed
            Assert.That (() => list.Reverse (), Throws.InvalidOperationException);
        }

        [Test]
        public void TestSort ()
        {
            var compareFuncWasCalled = false;
            CompareFunc<TestOpaque> compareFunc = (a, b) => {
                compareFuncWasCalled = true;
                return a.Handle.ToInt32 ().CompareTo (b.Handle.ToInt32 ());
            };
            var list = new SList<TestOpaque> ()
                .Prepend (new TestOpaque (1))
                .Prepend (new TestOpaque (2));
            Assume.That (list.Length, Is.EqualTo (2));
            Assume.That (list[0].Handle, Is.EqualTo ((IntPtr)2));
            Assume.That (list[1].Handle, Is.EqualTo ((IntPtr)1));
            // sorting takes ownership of old pointer
            var newList = list.Sort (compareFunc);
            Assert.That (compareFuncWasCalled);
            Assert.That (list.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (2));
            Assert.That (newList.Owned, Is.True);
            Assume.That (newList[0].Handle, Is.EqualTo ((IntPtr)1));
            Assume.That (newList[1].Handle, Is.EqualTo ((IntPtr)2));
            // calling without a compare function is not allowed
            Assert.That (() => list.Sort (null),
                Throws.InstanceOf<ArgumentNullException> ());
            // calling sort on unowned pointer is not allowed
            Assert.That (() => list.Sort (compareFunc),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestConcat ()
        {
            var list1 = new SList<TestOpaque> ().Append (null);
            Assume.That (list1.Length, Is.EqualTo (1));
            Assume.That (list1.Owned, Is.True);
            var list2 = new SList<TestOpaque> ().Append (null).Append (null);
            Assume.That (list2.Length, Is.EqualTo (2));
            Assume.That (list2.Owned, Is.True);
            // concat takes ownership of both pointers
            var newList = SList<TestOpaque>.Concat (list1, list2);
            Assert.That (list1.Length, Is.EqualTo (3));
            Assert.That (list1.Owned, Is.False);
            Assert.That (list2.Length, Is.EqualTo (2));
            Assert.That (list1.Owned, Is.False);
            // return value is now owned head of list
            Assert.That (newList.Length, Is.EqualTo (3));
            Assert.That (newList.Owned, Is.True);
            // calling on unowned pointer is not allowed
            Assert.That (() => SList<TestOpaque>.Concat (list1, list2),
                Throws.InvalidOperationException);
            // make sure null values are allowed
            newList = SList<TestOpaque>.Concat (null, null);
            Assert.That (newList.Length, Is.EqualTo (0));
            Assert.That (newList.Owned, Is.True);
        }

        [Test]
        public void TestForeach ()
        {
            int foreachCallCount = 0;
            GISharp.GLib.Func<TestOpaque> foreachFunc = (data) =>
                foreachCallCount++;
            // check that callback is called
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3));
            list.Foreach (foreachFunc);
            Assert.That (foreachCallCount, Is.EqualTo (3));
            // calling without a foreach function is not allowed
            Assert.That (() => list.Foreach (null),
                Throws.InstanceOf<ArgumentNullException> ());
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.Foreach (foreachFunc),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestLast ()
        {
            var list = new SList<TestOpaque> ();
            // check that null is returned for empty list
            var last = list.Last;
            Assert.That (last, Is.Null);
            // check that unowned item is returned for non-empty list
            list = list
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3));
            last = list.Last;
            Assert.That (last.Data.Value, Is.EqualTo (3));
            Assert.That (last.Owned, Is.False);
        }

        [Test]
        public void TestNext ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that calling on tail of list returns null
            var previous = list.Last.Next;
            Assert.That (previous, Is.Null);
            // check that unowned item is returned
            previous = list.Next;
            Assert.That (previous.Data.Value, Is.EqualTo (2));
            Assert.That (previous.Owned, Is.False);
        }

        [Test]
        public void TestNth ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that calling out of bounds returns null
            var nth = list.Nth (4);
            Assert.That (nth, Is.Null);
            // check that unowned item is returned
            nth = list.Nth (2);
            Assert.That (nth.Data.Value, Is.EqualTo (3));
            Assert.That (nth.Owned, Is.False);
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.Nth (2),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestNthData ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that calling out of bounds returns null
            var nth = list[4];
            Assert.That (nth, Is.Null);
            // check that unowned item is returned
            nth = list[1];
            Assert.That (nth.Value, Is.EqualTo (2));
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last[1], Throws.InvalidOperationException);
        }

        [Test]
        public void TestFind ()
        {
            var itemInList = new TestOpaque (4);
            var itemNotInList = new TestOpaque (5);
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that finding item returns unowned item
            var found = list.Find (itemInList);
            Assert.That (found.Data.Value, Is.EqualTo (itemInList.Value));
            Assert.That (found.Owned, Is.False);
            // check that not finding item returns null
            found = list.Find (itemNotInList);
            Assert.That (found, Is.Null);
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.Find (new TestOpaque (1)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestFindCustom ()
        {
            var compareFuncWasCalled = false;
            CompareFunc<TestOpaque> compareFunc = (a, b) => {
                compareFuncWasCalled = true;
                return a.Value > b.Value ? 0 : -1;
            };
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that finding item returns unowned item
            var found = list.FindCustom (new TestOpaque (1), compareFunc);
            Assert.That (compareFuncWasCalled);
            Assert.That (found.Data.Value, Is.EqualTo (2));
            Assert.That (found.Owned, Is.False);
            // check that not finding item returns null
            found = list.FindCustom (new TestOpaque (4), compareFunc);
            Assert.That (found, Is.Null);
            // calling without compare func is not allowed
            Assert.That (() => list.FindCustom (new TestOpaque (1), null),
                Throws.InstanceOf<ArgumentNullException> ());
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.FindCustom (new TestOpaque (1), compareFunc),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestPosition ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that finding an item returns the index
            var position = list.Position (list.Last);
            Assert.That (position, Is.EqualTo (3));
            // check that not finding an item returens -1
            position = list.Position (new SList<TestOpaque> ()
                .Append (new TestOpaque (1)));
            Assert.That (position, Is.EqualTo (-1));
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.Position (list.Last),
                Throws.InvalidOperationException);
            // calling without an argument is not allowed
            Assert.That (() => list.Position (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestIndex ()
        {
            var list = new SList<TestOpaque> ()
                .Append (new TestOpaque (1))
                .Append (new TestOpaque (2))
                .Append (new TestOpaque (3))
                .Append (new TestOpaque (4));
            // check that finding an item returns the index
            var index = list.IndexOf (new TestOpaque (3));
            Assert.That (index, Is.EqualTo (2));
            // check that not finding an item retures -1
            index = list.IndexOf (new TestOpaque (5));
            Assert.That (index, Is.EqualTo (-1));
            // calling on unowned pointer is not allowed
            Assert.That (() => list.Last.IndexOf (null),
                Throws.InvalidOperationException);
        }
    }
}
