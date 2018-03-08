using System;

using NUnit.Framework;
using GISharp.Lib.GLib;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class ByteArrayTests : IListTests<ByteArray, byte>
    {
        public ByteArrayTests() : base(getItemAt, 0, 1, 2, 3, 4)
        {
        }

        static byte getItemAt (ByteArray array, int index)
        {
            var data = Marshal.ReadIntPtr (array.Handle);
            return Marshal.ReadByte (data, index);
        }

        [Test]
        public void TestNew ()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray ()) {
                Assert.That(array.Length, Is.EqualTo(0));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestNewTake ()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray (new byte[10])) {
                Assert.That(array.Length, Is.EqualTo(10));
            }

            // null argument is not allowed
            Assert.That (() => new ByteArray ((byte[])null),
                Throws.InstanceOf<ArgumentNullException> ());

            AssertNoGLibLog();
        }

        [Test]
        public void TestSizedNew ()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray (10)) {
                Assert.That(array.Length, Is.EqualTo(0));
            }

            Assert.That (() => new ByteArray (-1),
                         Throws.TypeOf<ArgumentOutOfRangeException> ());

            AssertNoGLibLog();
        }

        [Test]
        public void TestAppend ()
        {
            // check basic operation
            using (var array = new ByteArray (new byte[] { 1 })) {
                array.Append (2, 3);
                Assert.That (array.Length, Is.EqualTo(3));
                Assert.That (getItemAt (array, 0), Is.EqualTo (1));
                Assert.That (getItemAt (array, 1), Is.EqualTo (2));
                Assert.That (getItemAt (array, 2), Is.EqualTo (3));

                // null argument is not allowed
                Assert.That (() => array.Append (null),
                    Throws.InstanceOf<ArgumentNullException> ());

                array.Dispose ();
                Assert.That (() => array.Append (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestPrepend ()
        {
            // check basic operation
            using (var array = new ByteArray (new byte[] { 1 })) {
                array.Prepend (2, 3);
                Assert.That(array.Length, Is.EqualTo(3));
                Assert.That (getItemAt (array, 0), Is.EqualTo (2));
                Assert.That (getItemAt (array, 1), Is.EqualTo (3));
                Assert.That (getItemAt (array, 2), Is.EqualTo (1));

                // null argument is not allowed
                Assert.That (() => array.Prepend (null),
                    Throws.InstanceOf<ArgumentNullException> ());

                array.Dispose ();
                Assert.That (() => array.Prepend (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveAtFast ()
        {
            // check basic operation
            using (var array = new ByteArray (new byte[] { 1, 2, 3, 4 })) {
                array.RemoveAtFast (1);
                Assert.That(array.Length, Is.EqualTo(3));
                Assert.That (getItemAt (array, 0), Is.EqualTo (1));
                Assert.That (getItemAt (array, 1), Is.EqualTo (4));
                Assert.That (getItemAt (array, 2), Is.EqualTo (3));

                // check index out of range
                Assert.That (() => array.RemoveAtFast (-1),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveAtFast (3),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());

                array.Dispose ();
                Assert.That (() => array.RemoveAtFast (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveRange ()
        {
            // check basic operation
            using (var array = new ByteArray (new byte[] { 1, 2, 3, 4 })) {
                array.RemoveRange (1, 2);
                Assert.That(array.Length, Is.EqualTo(2));
                Assert.That (getItemAt (array, 0), Is.EqualTo (1));
                Assert.That (getItemAt (array, 1), Is.EqualTo (4));

                // check index out of range
                Assert.That (() => array.RemoveRange (-1, 0),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                Assert.That (() => array.RemoveRange (3, 0),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());
                // check length out of range
                Assert.That (() => array.RemoveRange (2, 2),
                             Throws.InstanceOf<ArgumentOutOfRangeException> ());

                array.Dispose ();
                Assert.That (() => array.RemoveRange (0, 0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSort ()
        {
            using (var array = new ByteArray (new byte[] { 2, 1, 3 })) {
                array.Sort ((x, y) => x - y);
                Assert.That (getItemAt (array, 0), Is.EqualTo (1));
                Assert.That (getItemAt (array, 1), Is.EqualTo (2));
                Assert.That (getItemAt (array, 2), Is.EqualTo (3));

                // null argument is not allowed
                Assert.That (() => array.Sort (null),
                    Throws.InstanceOf<ArgumentNullException> ());

                array.Dispose ();
                Assert.That (() => array.Sort ((x, y) => 0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSetSize ()
        {
            // check basic operation
            using (var array = new ByteArray (new byte[10])) {
                array.SetSize (5);
                Assert.That(array.Length, Is.EqualTo(5));
                // negitive value now allowed
                Assert.That (() => array.SetSize (-1),
                    Throws.InstanceOf<ArgumentOutOfRangeException> ());

                array.Dispose ();
                Assert.That (() => array.SetSize (0),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }
#if false
        [Test]
        public void TestToBytes ()
        {
            using (var array = new ByteArray (new byte[] { 1, 2, 3, 4 })) {
                Assume.That(array.Length, Is.EqualTo(4));

                using (var bytes = array.ToBytes ()) {
                    Assert.That(array.Length, Is.EqualTo(0));

                    Assert.That (bytes[0], Is.EqualTo (1));
                    Assert.That (bytes[1], Is.EqualTo (2));
                    Assert.That (bytes[2], Is.EqualTo (3));
                    Assert.That (bytes[3], Is.EqualTo (4));
                }

                array.Dispose ();
                Assert.That (() => array.ToBytes (),
                             Throws.TypeOf<ObjectDisposedException> ());
            }

            AssertNoGLibLog();
        }
#endif
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (ByteArray).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That (gtype.Name, Is.EqualTo ("GByteArray"));

            AssertNoGLibLog();
        }
    }
}
