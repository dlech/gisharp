// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;

using NUnit.Framework;
using GISharp.Lib.GLib;
using System.Runtime.InteropServices;
using GISharp.Lib.GObject;

namespace GISharp.Test.GLib
{
    public class ByteArrayTests : IListTests<ByteArray, byte>
    {
        public ByteArrayTests() : base(getItemAt, 0, 1, 2, 3, 4)
        {
        }

        static byte getItemAt(ByteArray array, int index)
        {
            var data = Marshal.ReadIntPtr(array.UnsafeHandle);
            return Marshal.ReadByte(data, index);
        }

        [Test]
        public void TestNew()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray()) {
                Assert.That(array.Count, Is.EqualTo(0));
            }
        }

        [Test]
        public void TestNewTake()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray(new byte[10])) {
                Assert.That(array.Count, Is.EqualTo(10));
            }
        }

        [Test]
        public void TestSizedNew()
        {
            // just make sure it doesn't crash
            using (var array = new ByteArray(10)) {
                Assert.That(array.Count, Is.EqualTo(0));
            }

            Assert.That(() => new ByteArray(-1),
                         Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestAppend()
        {
            // check basic operation
            using (var array = new ByteArray(new byte[] { 1 })) {
                array.Append(2, 3);
                Assert.That(array.Count, Is.EqualTo(3));
                Assert.That(getItemAt(array, 0), Is.EqualTo(1));
                Assert.That(getItemAt(array, 1), Is.EqualTo(2));
                Assert.That(getItemAt(array, 2), Is.EqualTo(3));

                array.Dispose();
                Assert.That(() => array.Append(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestPrepend()
        {
            // check basic operation
            using (var array = new ByteArray(new byte[] { 1 })) {
                array.Prepend(2, 3);
                Assert.That(array.Count, Is.EqualTo(3));
                Assert.That(getItemAt(array, 0), Is.EqualTo(2));
                Assert.That(getItemAt(array, 1), Is.EqualTo(3));
                Assert.That(getItemAt(array, 2), Is.EqualTo(1));

                array.Dispose();
                Assert.That(() => array.Prepend(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestRemoveAtFast()
        {
            // check basic operation
            using (var array = new ByteArray(new byte[] { 1, 2, 3, 4 })) {
                array.RemoveAtFast(1);
                Assert.That(array.Count, Is.EqualTo(3));
                Assert.That(getItemAt(array, 0), Is.EqualTo(1));
                Assert.That(getItemAt(array, 1), Is.EqualTo(4));
                Assert.That(getItemAt(array, 2), Is.EqualTo(3));

                // check index out of range
                Assert.That(() => array.RemoveAtFast(-1),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveAtFast(3),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());

                array.Dispose();
                Assert.That(() => array.RemoveAtFast(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestRemoveRange()
        {
            // check basic operation
            using (var array = new ByteArray(new byte[] { 1, 2, 3, 4 })) {
                array.RemoveRange(1, 2);
                Assert.That(array.Count, Is.EqualTo(2));
                Assert.That(getItemAt(array, 0), Is.EqualTo(1));
                Assert.That(getItemAt(array, 1), Is.EqualTo(4));

                // check index out of range
                Assert.That(() => array.RemoveRange(-1, 0),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                Assert.That(() => array.RemoveRange(3, 0),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());
                // check length out of range
                Assert.That(() => array.RemoveRange(2, 2),
                             Throws.InstanceOf<ArgumentOutOfRangeException>());

                array.Dispose();
                Assert.That(() => array.RemoveRange(0, 0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestSort()
        {
            using (var array = new ByteArray(new byte[] { 2, 1, 3 })) {
                array.Sort((x, y) => x - y);
                Assert.That(getItemAt(array, 0), Is.EqualTo(1));
                Assert.That(getItemAt(array, 1), Is.EqualTo(2));
                Assert.That(getItemAt(array, 2), Is.EqualTo(3));

                array.Dispose();
                Assert.That(() => array.Sort((x, y) => 0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestSetSize()
        {
            // check basic operation
            using (var array = new ByteArray(new byte[10])) {
                array.SetSize(5);
                Assert.That(array.Count, Is.EqualTo(5));
                // negative value now allowed
                Assert.That(() => array.SetSize(-1),
                    Throws.InstanceOf<ArgumentOutOfRangeException>());

                array.Dispose();
                Assert.That(() => array.SetSize(0),
                             Throws.TypeOf<ObjectDisposedException>());
            }
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
        }
#endif
        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<ByteArray>();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GByteArray"));
        }
    }
}