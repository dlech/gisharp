using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GLib;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class ArrayTest
    {
        [Test]
        public void TestElementSize ()
        {
            var array = new Array<int> ();
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (0), "Array not null terminated.");
            Assert.That (array.ElementSize == sizeof(int));
        }

        [Test]
        public void TestAdd ()
        {
            var array = new Array<int> ();
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            array.Add (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
        }

        [Test]
        public void TestPrepend ()
        {
            var array = new Array<int> ();
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            array.Prepend (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
            array.Prepend (2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (0));
        }

        [Test]
        public void TestInsert ()
        {
            var array = new Array<int> ();
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            Assert.That (() => array.InsertRange (-1, 0), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.InsertRange (1, 0), Throws.InstanceOf<IndexOutOfRangeException> ());
            array.Insert (0, 1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
            array.Insert (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (0));
            array.Insert (1, 3);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
        }

        [Test]
        public void TestRemoveAt ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (() => array.RemoveAt (-1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAt (5), Throws.InstanceOf<IndexOutOfRangeException> ());
            array.RemoveAt (4);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assert.That (array.UnsafeItemAt (4), Is.EqualTo (0));
            array.RemoveAt (0);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (4));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
        }

        [Test]
        public void TestRemove ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 1, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (array.Remove (-1), Is.False);
            Assert.That (array.Remove (6), Is.False);
            Assert.That (array.Remove (5), Is.True);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (4), Is.EqualTo (0));
            Assert.That (array.Remove (1), Is.True);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
        }

        [Test]
        public void TestRemoveAtFast ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (() => array.RemoveAtFast (-1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtFast (5), Throws.InstanceOf<IndexOutOfRangeException> ());
            array.RemoveAtFast (4);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assert.That (array.UnsafeItemAt (4), Is.EqualTo (0));
            array.RemoveAtFast (0);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (4));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
        }

        [Test]
        public void TestRemoveAtRange ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (() => array.RemoveAtRange (-1, 1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (5, 1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (0, -1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (0, 6), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (4, 2), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            array.RemoveAtRange (3, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
            array.RemoveAtRange (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
        }

        [Test]
        public void TestIndexer ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (0));
            Assert.That (() => array[-1], Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array[2], Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (array[0], Is.EqualTo (1));
            Assert.That (array[1], Is.EqualTo (2));
            array[0] = 3;
            Assert.That (array[0], Is.EqualTo (3));
            Assert.That (array[1], Is.EqualTo (2));
            Assert.That (array.Count, Is.EqualTo (2));
        }

        [Test]
        public void TestIndexOf ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 1, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (array.IndexOf (-1), Is.EqualTo (-1));
            Assert.That (array.IndexOf (6), Is.EqualTo (-1));
            Assert.That (array.IndexOf (1), Is.EqualTo (0));
            Assert.That (array.IndexOf (5), Is.EqualTo (4));
        }

        [Test]
        public void TestContains ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 1, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            Assert.That (array.Contains (-1), Is.False);
            Assert.That (array.Contains (6), Is.False);
            Assert.That (array.Contains (1), Is.True);
            Assert.That (array.Contains (5), Is.True);
        }

        [Test]
        public void TestSetSize ()
        {
            var array = new Array<int> ();
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            Assume.That (array.Count, Is.EqualTo (0));
            array.SetSize (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
            Assert.That (array.Count, Is.EqualTo (1));
        }

        [Test]
        public void TestClear ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (0));
            Assume.That (array.Count, Is.EqualTo (3));
            array.Clear ();
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (0));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (0));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (0));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (0));
            Assert.That (array.Count, Is.EqualTo (3));
        }

        [Test]
        public void TestGetEnumerator ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));
            Assume.That (array.UnsafeItemAt (5), Is.EqualTo (0));
            var expected = 1;
            foreach (var item in array) {
                Assert.That (item, Is.EqualTo (expected++));
            }
            Assert.That (expected, Is.EqualTo (array.Count + 1));
        }
    }

    static class ArrayTestExtensions
    {
        /// <summary>
        /// Gets the item at a given index without range checking.
        /// </summary>
        public static T UnsafeItemAt<T> (this Array<T> array, int index) where T : struct
        {
            var dataPtr = Marshal.ReadIntPtr (array.Handle);
            dataPtr += Marshal.SizeOf<T> () * index;
            var item = Marshal.PtrToStructure <T> (dataPtr);
            return item;
        }
    }
}
