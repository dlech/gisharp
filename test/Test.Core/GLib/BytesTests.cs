using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.Core.GLib
{
    public class BytesTests : Tests
    {
        [Test]
        public void TestNew()
        {
            using (var b = new Bytes(ReadOnlySpan<byte>.Empty)) {
                Assert.That(b.Size, Is.EqualTo(0));
            }
            using (var b = new Bytes(new ReadOnlySpan<byte>(new byte[] { 1 }))) {
                Assert.That(b.Size, Is.EqualTo(1));
            }
            using (var b = new Bytes(ReadOnlyMemory<byte>.Empty)) {
                Assert.That(b.Size, Is.EqualTo(0));
            }
            using (var b = new Bytes(new ReadOnlyMemory<byte>(new byte[] { 1 }))) {
                Assert.That(b.Size, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestNewFromBytes()
        {
            ReadOnlyMemory<byte> data = new byte[] { 1, 2, 3, 4 };
            using var b1 = new Bytes(data);
            using var b2 = b1.NewFromBytes(1, 2);
            // b2 takes a reference to b1 in unmanaged code.
            // to make sure this works, we release the managed
            // reference to b1.
            b1.Dispose();
            Assert.That(b2.Size, Is.EqualTo(2));
            Assert.That(b2[0], Is.EqualTo(2));
            Assert.That(b2[1], Is.EqualTo(3));

            Assert.That(() => b1.NewFromBytes(0, 1),
                         Throws.TypeOf<ObjectDisposedException>());

            Assert.That(() => b2.NewFromBytes(0, 3),
                         Throws.TypeOf<ArgumentException>());
            Assert.That(() => b2.NewFromBytes(-1, 0),
                         Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => b2.NewFromBytes(0, -1),
                         Throws.TypeOf<ArgumentOutOfRangeException>());

            using var b3 = b2.NewFromBytes(0, 0);
            Assert.That(b3.Size, Is.EqualTo(0));
        }

        [Test]
        public void TestCompare()
        {
            ReadOnlyMemory<byte> data1 = new byte[] { 1, 2, 0 };
            ReadOnlyMemory<byte> data2 = new byte[] { 1, 2, 1 };
            ReadOnlyMemory<byte> data3 = new byte[] { 1, 2, 3 };
            using var b1 = new Bytes(data1);
            using var b2 = new Bytes(data2);
            using var b3 = new Bytes(data3);
            Assert.That(b1, Is.LessThan(b2));
            Assert.That(b3, Is.GreaterThan(b2));
            Assert.That(b1 < b2);
            Assert.That(b1 <= b3);
            Assert.That(b3 > b1);
            Assert.That(b3 >= b2);
        }

        [Test]
        public void TestEquals()
        {
            ReadOnlyMemory<byte> data1 = new byte[] { 1, 2, 3 };
            ReadOnlyMemory<byte> data2 = new byte[] { 1, 2, 4 };
            using var b1 = new Bytes(data1);
            using var b2 = new Bytes(data1);
            using var b3 = new Bytes(data2);
            Assert.That(b1, Is.EqualTo(b2));
            Assert.That(b1, Is.Not.EqualTo(b3));
            Assert.That(Equals(b1, b2), Is.True);
            Assert.That(Equals(b1, b3), Is.False);
            Assert.That(b1 == b2);
            Assert.That(b1 != b3);
        }

        [Test]
        public void TestHash()
        {
            ReadOnlyMemory<byte> data = new byte[] { 1, 2, 3 };
            using var b1 = new Bytes(data);
            using var b2 = new Bytes(data);
            var set = new HashSet<object> { b1, b2 };
            Assert.That(set.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestSize()
        {
            ReadOnlyMemory<byte> data = new byte[5];
            using var b = new Bytes(data);
            Assert.That(b.Size, Is.EqualTo(5));

            b.Dispose();
            Assert.That(() => b.Size, Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestIndexer()
        {
            ReadOnlyMemory<byte> data = new byte[] { 1, 2, 3 };
            using var b = new Bytes(data);
            Assert.That(() => b[-1], Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(b[0], Is.EqualTo(1));
            Assert.That(b[1], Is.EqualTo(2));
            Assert.That(b[2], Is.EqualTo(3));
            Assert.That(() => b[3], Throws.TypeOf<ArgumentOutOfRangeException>());

            b.Dispose();
            Assert.That(() => b[0], Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestGetEnumerator()
        {
            ReadOnlyMemory<byte> data = new byte[] { 1, 2, 3 };
            using var bytes = new Bytes(data);
            var expected = 1;
            foreach (var b in bytes) {
                Assert.That(b, Is.EqualTo(expected++));
            }
            Assert.That(expected, Is.EqualTo(4));

            bytes.Dispose();
            Assert.That(() => bytes.Any(), Throws.TypeOf<ObjectDisposedException>());
        }
    }
}
