using System;
using System.Collections;
using System.Linq;
using GISharp.GLib;
using NUnit.Framework;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class BytesTests
    {
        [Test]
        public void TestNew ()
        {
            using (var b = new Bytes ((byte[])null)) {
                Assert.That (b.Count, Is.EqualTo (0));
            }
            using (var b = new Bytes (new byte[0])) {
                Assert.That (b.Count, Is.EqualTo (0));
            }
            using (var b = new Bytes (new byte[] { 1 })) {
                Assert.That (b.Count, Is.EqualTo (1));
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestNewFromBytes ()
        {
            using (var b1 = new Bytes (new byte[] { 1, 2, 3, 4 })) {
                using (var b2 = b1.NewFromBytes (1, 2)) {
                    // b2 takes a reference to b1 in unmanaged code.
                    // to make sure this works, we release the managed
                    // refernece to b1.
                    b1.Dispose ();
                    Assert.That (b2.Count, Is.EqualTo (2));
                    Assert.That (b2[0], Is.EqualTo (2));
                    Assert.That (b2[1], Is.EqualTo (3));

                    Assert.That (() => b1.NewFromBytes (0, 1),
                                 Throws.TypeOf<ObjectDisposedException> ());

                    Assert.That (() => b2.NewFromBytes (0, 3),
                                 Throws.TypeOf<ArgumentException> ());
                    Assert.That (() => b2.NewFromBytes (-1, 0),
                                 Throws.TypeOf<ArgumentOutOfRangeException> ());
                    Assert.That (() => b2.NewFromBytes (0, -1),
                                 Throws.TypeOf<ArgumentOutOfRangeException> ());
                    
                    using (var b3 = b2.NewFromBytes (0, 0)) {
                        Assert.That (b3.Count, Is.EqualTo (0));
                    }
                }
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCount ()
        {
            using (var b = new Bytes (new byte[5])) {
                Assert.That (b.Count, Is.EqualTo (5));

                b.Dispose ();
                Assert.That(() => b.Size, Throws.TypeOf<ObjectDisposedException>());
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestIndexer ()
        {
            using (var b = new Bytes (new byte[] { 1, 2, 3 })) {
                Assert.That (b[0], Is.EqualTo (1));
                Assert.That (b[1], Is.EqualTo (2));
                Assert.That (b[2], Is.EqualTo (3));

                b.Dispose ();
                Assert.That (() => b[0], Throws.TypeOf<ObjectDisposedException> ());
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestGetEnumerator ()
        {
            using (var bytes = new Bytes (new byte[] { 1, 2, 3 })) {
                var expected = 1;
                foreach (var b in bytes) {
                    Assert.That (b, Is.EqualTo (expected++));
                }
                Assert.That (expected, Is.EqualTo (4));

                bytes.Dispose ();
                Assert.That(() => bytes.Any(), Throws.TypeOf<ObjectDisposedException>());
            }

            Utility.AssertNoGLibLog();
        }
    }
}
