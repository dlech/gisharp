using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;

namespace GISharp.Test.Core.GLib
{
    public class ArrayTests : IListTests<Array<int>, int>
    {
        public ArrayTests() : base(ArrayTestExtensions.UnsafeItemAt, 0, 1, 2, 3, 4)
        {
        }

        [Test]
        public void TestConstructor()
        {
            using (var a = new Array<int>()) {
                Assert.That(a.UnsafeLength(), Is.Zero);
            }

            Assert.That(() => new Array<int>(false, false, -1), Throws.TypeOf<ArgumentOutOfRangeException>());

            using (var a = new Array<int>(false, false)) {
                Assert.That(a.UnsafeLength(), Is.Zero);
            }
        }

        [Test]
        public void TestElementSize()
        {
            using (var array = new Array<int>()) {
                Assert.That(array.ElementSize == sizeof(int));

                array.Dispose();
                Assert.That(() => array.ElementSize,
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestAppend()
        {
            using (var array = new Array<int>()) {
                array.Append(1, 2, 3);
                Assert.That(array.UnsafeLength(), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));

                ReadOnlySpan<int> data = stackalloc int[] { 4, 5, 6 };
                array.Append(data);
                Assert.That(array.UnsafeLength(), Is.EqualTo(6));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(3), Is.EqualTo(4));
                Assert.That(array.UnsafeItemAt(4), Is.EqualTo(5));
                Assert.That(array.UnsafeItemAt(5), Is.EqualTo(6));

                array.Dispose();
                Assert.That(() => array.Append(1),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestPrepend()
        {
            using (var array = new Array<int>()) {
                array.Prepend(1);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeLength(), Is.EqualTo(1));

                array.Prepend(2);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(1));
                Assert.That(array.UnsafeLength(), Is.EqualTo(2));

                ReadOnlySpan<int> data = stackalloc int[] { 3, 4, 5 };
                array.Prepend(data);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(4));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(5));
                Assert.That(array.UnsafeItemAt(3), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(4), Is.EqualTo(1));
                Assert.That(array.UnsafeLength(), Is.EqualTo(5));

                array.Dispose();
                Assert.That(() => array.Prepend(1),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestInsertVals()
        {
            using (var array = new Array<int>()) {
                array.Insert(0, 1);
                Assert.That(array.UnsafeLength(), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));

                array.Insert(0, 2);
                Assert.That(array.UnsafeLength(), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(1));

                array.Insert(2, 3, 4);
                Assert.That(array.UnsafeLength(), Is.EqualTo(4));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(3), Is.EqualTo(4));

                Assert.That(() => array.Insert(-1, 0),
                             Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.Insert(5, 0),
                             Throws.TypeOf<ArgumentOutOfRangeException>());

                ReadOnlySpan<int> data = stackalloc int[] { 5, 6, 7 };
                array.Insert(0, data);
                Assert.That(array.UnsafeLength(), Is.EqualTo(7));
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(5));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(6));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(7));
                Assert.That(array.UnsafeItemAt(3), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(4), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(5), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(6), Is.EqualTo(4));

                array.Dispose();
                Assert.That(() => array.Insert(1),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestRemoveAtFast()
        {
            using (var array = new Array<int>()) {
                array.Append(1, 2, 3, 4, 5);
                Assume.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assume.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assume.That(array.UnsafeItemAt(2), Is.EqualTo(3));
                Assume.That(array.UnsafeItemAt(3), Is.EqualTo(4));
                Assume.That(array.UnsafeItemAt(4), Is.EqualTo(5));

                Assert.That(() => array.RemoveAtFast(-1),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveAtFast(5),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());

                array.RemoveAtFast(4);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));
                Assert.That(array.UnsafeItemAt(3), Is.EqualTo(4));

                array.RemoveAtFast(0);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(4));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));

                array.Dispose();
                Assert.That(() => array.RemoveAtFast(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestRemoveRange()
        {
            using (var array = new Array<int>()) {
                array.Append(1, 2, 3, 4, 5);
                Assume.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assume.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assume.That(array.UnsafeItemAt(2), Is.EqualTo(3));
                Assume.That(array.UnsafeItemAt(3), Is.EqualTo(4));
                Assume.That(array.UnsafeItemAt(4), Is.EqualTo(5));

                Assert.That(() => array.RemoveRange(-1, 1),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveRange(5, 1),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveRange(0, -1),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveRange(0, 6),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveRange(4, 2),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());

                array.RemoveRange(3, 2);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));

                array.RemoveRange(0, 2);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(3));

                array.Dispose();
                Assert.That(() => array.RemoveRange(0, 1),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestSetSize()
        {
            using (var array = new Array<int>()) {
                Assume.That(array.UnsafeLength(), Is.EqualTo(0));

                array.SetSize(1);
                Assert.That(array.UnsafeLength(), Is.EqualTo(1));

                Assert.That(() => array.SetSize(-1), Throws.TypeOf<ArgumentOutOfRangeException>());

                array.Dispose();
                Assert.That(() => array.SetSize(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
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
        }
#endif
        [Test]
        public void TestSort()
        {
            using (var array = new Array<int>()) {
                array.Append(3, 1, 2);
                Assume.That(array.UnsafeItemAt(0), Is.EqualTo(3));
                Assume.That(array.UnsafeItemAt(1), Is.EqualTo(1));
                Assume.That(array.UnsafeItemAt(2), Is.EqualTo(2));

                array.Sort((x, y) => x - y);
                Assert.That(array.UnsafeItemAt(0), Is.EqualTo(1));
                Assert.That(array.UnsafeItemAt(1), Is.EqualTo(2));
                Assert.That(array.UnsafeItemAt(2), Is.EqualTo(3));

                array.Dispose();
                Assert.That(() => array.Sort((x, y) => x - y),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public unsafe void TestSpan()
        {
            Span<int> s = default(Array<int>);
            Assert.That(s.Length, Is.Zero);
            fixed (int* p = s) {
                Assert.That((IntPtr)p, Is.EqualTo(IntPtr.Zero));
            }

            using (var a = new Array<int> { 1 }) {
                s = a;
                Assert.That(s.Length, Is.EqualTo(1));
                Assert.That(s[0], Is.EqualTo(1));
                fixed (int* p = s) {
                    Assert.That((IntPtr)p, Is.EqualTo(Marshal.ReadIntPtr(a.Handle)));
                }
            }
        }

        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<Array<int>>();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GArray"));
        }
    }

    static class ArrayTestExtensions
    {
        /// <summary>
        /// Gets the item at a given index without range checking.
        /// </summary>
        public static T UnsafeItemAt<T>(this Array<T> array, int index) where T : unmanaged
        {
            var dataPtr = Marshal.ReadIntPtr(array.Handle);
            dataPtr += Marshal.SizeOf<T>() * index;
            var item = Marshal.PtrToStructure<T>(dataPtr);
            return item;
        }

        public static int UnsafeLength<T>(this Array<T> array) where T : unmanaged
        {
            var len = Marshal.ReadInt32(array.Handle, IntPtr.Size);
            return len;
        }
    }
}
