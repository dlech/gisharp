using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GLib;
using GISharp.GObject;
using System.Collections;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void TestElementSize ()
        {
            var array = new Array<int> ();
            Assert.That (array.ElementSize == sizeof(int));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.ElementSize.GetType ());
        }

        [Test]
        public void TestIsReadOnly ()
        {
            var array = new Array<int> ();
            Assert.That (array.IsReadOnly, Is.False);

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.IsReadOnly.GetType ());
        }

        [Test]
        public void TestAdd ()
        {
            var array = new Array<int> ();
            array.Add (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Add (1));
        }

        [Test]
        public void TestPrepend ()
        {
            var array = new Array<int> ();
            array.Prepend (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            array.Prepend (2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Prepend (1));
        }

        [Test]
        public void TestInsert ()
        {
            var array = new Array<int> ();
            Assert.That (() => array.InsertRange (-1, 0), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.InsertRange (1, 0), Throws.InstanceOf<IndexOutOfRangeException> ());

            array.Insert (0, 1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));

            array.Insert (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));

            array.Insert (1, 3);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (1));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Insert (0, 1));
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

            Assert.That (() => array.RemoveAt (-1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAt (5), Throws.InstanceOf<IndexOutOfRangeException> ());

            array.RemoveAt (4);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (4));

            array.RemoveAt (0);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (4));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.RemoveAt (0));
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

            Assert.That (array.Remove (-1), Is.False);
            Assert.That (array.Remove (6), Is.False);

            Assert.That (array.Remove (5), Is.True);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (1));

            Assert.That (array.Remove (1), Is.True);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (1));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Remove (2));
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

            Assert.That (() => array.RemoveAtFast (-1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtFast (5), Throws.InstanceOf<IndexOutOfRangeException> ());

            array.RemoveAtFast (4);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.UnsafeItemAt (3), Is.EqualTo (4));

            array.RemoveAtFast (0);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (4));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.RemoveAtFast (0));
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

            Assert.That (() => array.RemoveAtRange (-1, 1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (5, 1), Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (0, -1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (0, 6), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveAtRange (4, 2), Throws.InstanceOf<ArgumentOutOfRangeException> ());

            array.RemoveAtRange (3, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

            array.RemoveAtRange (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (3));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.RemoveAtRange (0, 1));
        }

        [Test]
        public void TestIndexer ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.Count, Is.EqualTo (2));

            Assert.That (() => array[-1], Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array[2], Throws.InstanceOf<IndexOutOfRangeException> ());

            Assert.That (array[0], Is.EqualTo (1));
            Assert.That (array[1], Is.EqualTo (2));

            array[0] = 3;
            Assert.That (array[0], Is.EqualTo (3));
            Assert.That (array[1], Is.EqualTo (2));
            Assert.That (array.Count, Is.EqualTo (2));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array[0].GetType ());
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

            Assert.That (array.IndexOf (-1), Is.EqualTo (-1));
            Assert.That (array.IndexOf (6), Is.EqualTo (-1));
            Assert.That (array.IndexOf (1), Is.EqualTo (0));
            Assert.That (array.IndexOf (5), Is.EqualTo (4));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.IndexOf (1));
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

            Assert.That (array.Contains (-1), Is.False);
            Assert.That (array.Contains (6), Is.False);
            Assert.That (array.Contains (1), Is.True);
            Assert.That (array.Contains (5), Is.True);

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Contains (1));
        }

        [Test]
        public void TestSetSize ()
        {
            var array = new Array<int> ();
            Assume.That (array.Count, Is.EqualTo (0));

            array.SetSize (1);
            Assert.That (array.Count, Is.EqualTo (1));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.SetSize (0));
        }

        [Test]
        public void TestClear ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.Count, Is.EqualTo (3));

            array.Clear ();
            Assert.That (array.Count, Is.EqualTo (0));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Clear ());
        }

        [Test]
        public void TestCopyTo ()
        {
            var array = new Array<int> ();
            array.AddRange (1, 2, 3);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.Count, Is.EqualTo (3));

            var array2 = new int[5];
            array.CopyTo (array2, 0);
            Assert.That (array2, Is.EqualTo (new[] { 1, 2, 3, 0, 0 }));

            array.CopyTo (array2, 2);
            Assert.That (array2, Is.EqualTo (new[] { 1, 2, 1, 2, 3 }));

            Assert.Throws<ArgumentNullException> (() => array.CopyTo (null, 2));
            Assert.Throws<ArgumentOutOfRangeException> (() => array.CopyTo (array2, -1));
            Assert.Throws<ArgumentException> (() => array.CopyTo (array2, 4));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.CopyTo (array2, 0));
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

            var expected = 1;
            foreach (var item in array) {
                Assert.That (item, Is.EqualTo (expected++));
            }
            Assert.That (expected, Is.EqualTo (array.Count + 1));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.GetEnumerator ());
            Assert.Throws<ObjectDisposedException> (() => ((IEnumerable)array).GetEnumerator ());
        }

        [Test]
        public void TestSort ()
        {
            var array = new Array<int> ();
            array.AddRange (3, 1, 2);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (2));

            array.Sort ((x, y) => x - y);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

            Assert.Throws<ArgumentNullException> (() => array.Sort (null));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Sort ((x, y) => x - y));
        }

        [Test]
        public void TestGType ()
        {
            var gtype = typeof (Array<int>).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That (gtype.Name, Is.EqualTo ("GArray"));
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
