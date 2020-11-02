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
            using (var b = new Bytes(new byte[0])) {
                Assert.That(b.Size, Is.EqualTo(0));
            }
            using (var b = new Bytes(new byte[] { 1 })) {
                Assert.That(b.Size, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestNewFromBytes()
        {
            using (var b1 = new Bytes(new byte[] { 1, 2, 3, 4 })) {
                using (var b2 = b1.NewFromBytes(1, 2)) {
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

                    using (var b3 = b2.NewFromBytes(0, 0)) {
                        Assert.That(b3.Size, Is.EqualTo(0));
                    }
                }
            }
        }

        [Test]
        public void TestCompare()
        {
            using (var b1 = new Bytes(1, 2, 0))
            using (var b2 = new Bytes(1, 2, 1))
            using (var b3 = new Bytes(1, 2, 2)) {
                Assert.That(b1, Is.LessThan(b2));
                Assert.That(b3, Is.GreaterThan(b2));
                Assert.That(b1 < b2);
                Assert.That(b1 <= b3);
                Assert.That(b3 > b1);
                Assert.That(b3 >= b2);
            }
        }

        [Test]
        public void TestEquals()
        {
            using (var b1 = new Bytes(1, 2, 3))
            using (var b2 = new Bytes(1, 2, 3))
            using (var b3 = new Bytes(1, 2, 4)) {
                Assert.That(b1, Is.EqualTo(b2));
                Assert.That(b1, Is.Not.EqualTo(b3));
                Assert.That(object.Equals(b1, b2), Is.True);
                Assert.That(object.Equals(b1, b3), Is.False);
                Assert.That(b1 == b2);
                Assert.That(b1 != b3);
            }
        }

        [Test]
        public void TestHash()
        {
            using (var b1 = new Bytes(1, 2, 3))
            using (var b2 = new Bytes(1, 2, 3)) {
                var set = new HashSet<object> { b1, b2 };
                Assert.That(set.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestSize()
        {
            using (var b = new Bytes(new byte[5])) {
                Assert.That(b.Size, Is.EqualTo(5));

                b.Dispose();
                Assert.That(() => b.Size, Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestIndexer()
        {
            using (var b = new Bytes(new byte[] { 1, 2, 3 })) {
                Assert.That(() => b[-1], Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(b[0], Is.EqualTo(1));
                Assert.That(b[1], Is.EqualTo(2));
                Assert.That(b[2], Is.EqualTo(3));
                Assert.That(() => b[3], Throws.TypeOf<ArgumentOutOfRangeException>());

                b.Dispose();
                Assert.That(() => b[0], Throws.TypeOf<ObjectDisposedException>());
            }
        }

        [Test]
        public void TestGetEnumerator()
        {
            using (var bytes = new Bytes(new byte[] { 1, 2, 3 })) {
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
}
