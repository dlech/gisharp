// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    public class ByteArrayTests : IListTests<ByteArray, byte>
    {
        public ByteArrayTests() : base(GetItemAt, 0, 1, 2, 3, 4)
        {
        }

        static byte GetItemAt(ByteArray array, int index)
        {
            var data = Marshal.ReadIntPtr(array.UnsafeHandle);
            return Marshal.ReadByte(data, index);
        }

        [Test]
        public void TestNew()
        {
            using var array = new ByteArray();
            Assert.That(array.Length, Is.EqualTo(0));
        }

        [Test]
        public void TestNewTake()
        {
            using var cArray = new CArray<byte>(GMarshal.Alloc(10), 10, Transfer.Full);
            using var array = new ByteArray(cArray);
            Assert.That(() => cArray.UnsafeHandle, Throws.TypeOf<ObjectDisposedException>());
            Assert.That(array.Length, Is.EqualTo(10));
        }

        [Test]
        public void TestSizedNew()
        {
            using var array = new ByteArray(10);
            Assert.That(array.Length, Is.EqualTo(0));
        }

        [Test]
        public void TestAppend()
        {
            // check basic operation
            using var array = new ByteArray();

            array.Append(1, 2);
            Assert.That(array.Length, Is.EqualTo(2));
            Assert.That(GetItemAt(array, 0), Is.EqualTo(1));
            Assert.That(GetItemAt(array, 1), Is.EqualTo(2));

            array.Dispose();
            Assert.That(() => array.Append(0), Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestPrepend()
        {
            // check basic operation
            using var array = new ByteArray();

            array.Prepend(1, 2);
            Assert.That(array.Length, Is.EqualTo(2));
            Assert.That(GetItemAt(array, 0), Is.EqualTo(1));
            Assert.That(GetItemAt(array, 1), Is.EqualTo(2));

            array.Dispose();
            Assert.That(() => array.Prepend(0), Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestRemoveIndexFast()
        {
            // check basic operation
            using var array = new ByteArray();
            array.Append(1, 2, 3, 4);

            array.RemoveIndexFast(1);
            Assert.That(array.Length, Is.EqualTo(3));
            Assert.That(GetItemAt(array, 0), Is.EqualTo(1));
            Assert.That(GetItemAt(array, 1), Is.EqualTo(4));
            Assert.That(GetItemAt(array, 2), Is.EqualTo(3));

            // check index out of range
            Assert.That(() => array.RemoveIndexFast(3),
                         Throws.InstanceOf<ArgumentOutOfRangeException>());

            array.Dispose();
            Assert.That(() => array.RemoveIndexFast(0),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestRemoveRange()
        {
            // check basic operation
            using var array = new ByteArray();
            array.Append(1, 2, 3, 4);

            array.RemoveRange(1, 2);
            Assert.That(array.Length, Is.EqualTo(2));
            Assert.That(GetItemAt(array, 0), Is.EqualTo(1));
            Assert.That(GetItemAt(array, 1), Is.EqualTo(4));

            // check index out of range
            Assert.That(() => array.RemoveRange(3, 0),
                         Throws.InstanceOf<ArgumentOutOfRangeException>());
            // check length out of range
            Assert.That(() => array.RemoveRange(2, 2),
                         Throws.InstanceOf<ArgumentOutOfRangeException>());

            array.Dispose();
            Assert.That(() => array.RemoveRange(0, 0),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestSort()
        {
            using var array = new ByteArray();
            array.Append(2, 3, 1);

            array.Sort((x, y) => x - y);
            Assert.That(GetItemAt(array, 0), Is.EqualTo(1));
            Assert.That(GetItemAt(array, 1), Is.EqualTo(2));
            Assert.That(GetItemAt(array, 2), Is.EqualTo(3));

            array.Dispose();
            Assert.That(() => array.Sort((x, y) => 0),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestSetSize()
        {
            // check basic operation
            using var array = new ByteArray();

            array.SetSize(5);
            Assert.That(array.Length, Is.EqualTo(5));

            array.Dispose();
            Assert.That(() => array.SetSize(0),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#if false
        [Test]
        public void TestToBytes()
        {
            using var array = new ByteArray();
            array.Append(1, 2, 3, 4);

            Assume.That(array.Length, Is.EqualTo(4));

            using (var bytes = array.ToBytes()) {
                Assert.That(array.Length, Is.EqualTo(0));

                Assert.That(bytes[0], Is.EqualTo(1));
                Assert.That(bytes[1], Is.EqualTo(2));
                Assert.That(bytes[2], Is.EqualTo(3));
                Assert.That(bytes[3], Is.EqualTo(4));
            }

            array.Dispose();
            Assert.That(() => array.ToBytes(),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#endif
        [Test]
        public void TestGType()
        {
            var gtype = typeof(ByteArray).ToGType();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That(gtype.Name, Is.EqualTo("GByteArray"));
        }
    }
}
