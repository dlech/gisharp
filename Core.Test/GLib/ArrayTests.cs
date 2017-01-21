using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.GLib;
using GISharp.GObject;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class ArrayTests : IListTests<Array<int>, int>
    {
        public ArrayTests () : base (ArrayTestExtensions.UnsafeItemAt)
        {
        }

        [Test]
        public void TestElementSize ()
        {
            var array = new Array<int> ();
            Assert.That (array.ElementSize == sizeof(int));

            array.Dispose ();
            Assert.That (() => array.ElementSize, Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestAppend ()
        {
            var array = new Array<int> ();
            array.Append (1, 2, 3);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.Count, Is.EqualTo (3));

            array.Dispose ();
            Assert.That (() => array.Append (1), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestPrepend ()
        {
            var array = new Array<int> ();

            array.Prepend (1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.Count, Is.EqualTo (1));

            array.Prepend (2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assert.That (array.Count, Is.EqualTo (2));
            
            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.Prepend (1));
        }

        [Test]
        public void TestInsertVals ()
        {
            var array = new Array<int> ();

            array.Insert (0, 1);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.Count, Is.EqualTo (1));

            array.Insert (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assert.That (array.Count, Is.EqualTo (2));

            array.Insert (2, 3);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assert.That (array.Count, Is.EqualTo (3));

            Assert.That (() => array.Insert (-1, 0), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.Insert (5, 0), Throws.TypeOf<ArgumentOutOfRangeException> ());

            array.Dispose ();
            Assert.That (() => array.Insert (1), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestRemoveAtFast ()
        {
            var array = new Array<int> ();
            array.Append (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));

            Assert.That (() => array.RemoveAtFast (-1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveAtFast (5), Throws.InstanceOf<ArgumentOutOfRangeException> ());

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
        public void TestRemoveRange ()
        {
            var array = new Array<int> ();
            array.Append (1, 2, 3, 4, 5);
            Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
            Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
            Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));

            Assert.That (() => array.RemoveRange (-1, 1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveRange (5, 1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveRange (0, -1), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveRange (0, 6), Throws.InstanceOf<ArgumentOutOfRangeException> ());
            Assert.That (() => array.RemoveRange (4, 2), Throws.InstanceOf<ArgumentOutOfRangeException> ());

            array.RemoveRange (3, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
            Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
            Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

            array.RemoveRange (0, 2);
            Assert.That (array.UnsafeItemAt (0), Is.EqualTo (3));

            array.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => array.RemoveRange (0, 1));
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
        public void TestSort ()
        {
            var array = new Array<int> ();
            array.Append (3, 1, 2);
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
