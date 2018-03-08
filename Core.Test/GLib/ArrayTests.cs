using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class ArrayTests : IListTests<Array<int>, int>
    {
        public ArrayTests() : base(ArrayTestExtensions.UnsafeItemAt, 0, 1, 2, 3, 4)
        {
        }

        [Test]
        public void TestElementSize ()
        {
            using (var array = new Array<int> ()) {
                Assert.That (array.ElementSize == sizeof (int));

                array.Dispose ();
                Assert.That (() => array.ElementSize,
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestAppend ()
        {
            using (var array = new Array<int> ()) {
                array.Append (1, 2, 3);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
                Assert.That(array.Length, Is.EqualTo(3));

                array.Dispose ();
                Assert.That (() => array.Append (1),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestPrepend ()
        {
            using (var array = new Array<int> ()) {
                array.Prepend (1);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assert.That(array.Length, Is.EqualTo(1));

                array.Prepend (2);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
                Assert.That(array.Length, Is.EqualTo(2));

                array.Dispose ();
                Assert.That (() => array.Prepend (1),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestInsertVals ()
        {
            using (var array = new Array<int> ()) {
                array.Insert (0, 1);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assert.That(array.Length, Is.EqualTo(1));

                array.Insert (0, 2);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
                Assert.That(array.Length, Is.EqualTo(2));

                array.Insert (2, 3);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (1));
                Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));
                Assert.That(array.Length, Is.EqualTo(3));

                Assert.That (() => array.Insert (-1, 0),
                             Throws.TypeOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.Insert (5, 0),
                             Throws.TypeOf<ArgumentOutOfRangeException> ());

                array.Dispose ();
                Assert.That (() => array.Insert (1),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveAtFast ()
        {
            using (var array = new Array<int> ()) {
                array.Append (1, 2, 3, 4, 5);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
                Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
                Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
                Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));

                Assert.That (() => array.RemoveAtFast (-1),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveAtFast (5),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());

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
                Assert.That (() => array.RemoveAtFast (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveRange ()
        {
            using (var array = new Array<int> ()) {
                array.Append (1, 2, 3, 4, 5);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assume.That (array.UnsafeItemAt (1), Is.EqualTo (2));
                Assume.That (array.UnsafeItemAt (2), Is.EqualTo (3));
                Assume.That (array.UnsafeItemAt (3), Is.EqualTo (4));
                Assume.That (array.UnsafeItemAt (4), Is.EqualTo (5));

                Assert.That (() => array.RemoveRange (-1, 1),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveRange (5, 1),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveRange (0, -1),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveRange (0, 6),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveRange (4, 2),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());

                array.RemoveRange (3, 2);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

                array.RemoveRange (0, 2);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (3));

                array.Dispose ();
                Assert.That (() => array.RemoveRange (0, 1),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSetSize ()
        {
            using (var array = new Array<int> ()) {
                Assume.That(array.Length, Is.EqualTo(0));

                array.SetSize (1);
                Assert.That(array.Length, Is.EqualTo(1));

                array.Dispose ();
                Assert.That (() => array.SetSize (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }
#if false
        [Test]
        public void TestSetClearFunc ()
        {
            using (var array = new Array<int> ()) {
                array.Append (1);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));

                array.RemoveAt (0);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));

                array.SetSize (1);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));

                array.SetClearFunc ((ref int item) => item = 0);
                array.RemoveAt (0);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (0));

                array.Append (1);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (1));

                array.SetClearFunc (null);
                array.RemoveAt (0);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));

                array.Dispose ();
                Assert.That (() => array.SetClearFunc (null),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }
#endif
        [Test]
        public void TestSort ()
        {
            using (var array = new Array<int> ()) {
                array.Append (3, 1, 2);
                Assume.That (array.UnsafeItemAt (0), Is.EqualTo (3));
                Assume.That (array.UnsafeItemAt (1), Is.EqualTo (1));
                Assume.That (array.UnsafeItemAt (2), Is.EqualTo (2));

                array.Sort ((x, y) => x - y);
                Assert.That (array.UnsafeItemAt (0), Is.EqualTo (1));
                Assert.That (array.UnsafeItemAt (1), Is.EqualTo (2));
                Assert.That (array.UnsafeItemAt (2), Is.EqualTo (3));

                Assert.That (() => array.Sort (null), Throws.ArgumentNullException);

                array.Dispose ();
                Assert.That (() => array.Sort ((x, y) => x - y),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestGType ()
        {
            var gtype = typeof (Array<int>).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That (gtype.Name, Is.EqualTo ("GArray"));

            AssertNoGLibLog();
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
