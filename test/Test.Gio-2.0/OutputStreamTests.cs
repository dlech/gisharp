using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class OutputStreamTests
    {
        [Test]
        public void TestWrite()
        {
            using (var buffer = new ByteArray())
            using (var stream = new TestOutputStream()) {
                buffer.SetSize(10);
                var count = stream.Write(buffer);
                Assert.That(count, Is.EqualTo(10));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestWriteAll()
        {
            using (var buffer = new ByteArray())
            using (var stream = new TestOutputStream()) {
                buffer.SetSize(10);
                stream.WriteAll(buffer, out var read);
                Assert.That(read, Is.EqualTo(10));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestWriteAllAsync()
        {
            RunAsyncTest(async () => {
                using (var buffer = new ByteArray())
                using (var stream = new TestOutputStream()) {
                    buffer.SetSize(10);
                    var count = await stream.WriteAllAsync(buffer);
                    Assert.That(count, Is.EqualTo(10));
                }
            });

            AssertNoGLibLog();
        }

        [Test]
        public void TestSplice()
        {
            using (var instream = new TestInputStream())
            using (var stream = new TestOutputStream()) {
                var count = stream.Splice(instream, OutputStreamSpliceFlags.None);
                Assert.That(count, Is.EqualTo(0));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestFlush()
        {
            using (var stream = new TestOutputStream()) {
                stream.Flush();
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestClose()
        {
            using (var stream = new TestOutputStream()) {
                stream.Close();
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestWritesync()
        {
            RunAsyncTest(async () => {
                using (var buffer = new ByteArray())
                using (var stream = new TestOutputStream()) {
                    buffer.SetSize(10);
                    var count = await stream.WriteAsync(buffer);
                    Assert.That(count, Is.EqualTo(10));
                }
            });

            AssertNoGLibLog();
        }


        [Test]
        public void TestSpliceAsync()
        {
            RunAsyncTest(async () => {
                using (var instream = new TestInputStream())
                using (var stream = new TestOutputStream()) {
                    var actual = await stream.SpliceAsync(instream, OutputStreamSpliceFlags.None);
                    Assert.That(actual, Has.Count.EqualTo(10));
                }
            });

            AssertNoGLibLog();
        }

        [Test]
        public void TestFlushAsync()
        {
            RunAsyncTest(async () => {
                using (var stream = new TestOutputStream()) {
                    await stream.FlushAsync();
                }
            });

            AssertNoGLibLog();
        }

        [Test]
        public void TestCloseAsync()
        {
            RunAsyncTest(async () => {
                using (var stream = new TestOutputStream()) {
                    await stream.CloseAsync();
                    Assert.That(stream.IsClosed, Is.True);
                }
            });

            AssertNoGLibLog();
        }
    }

    [GType]
    class TestOutputStream : OutputStream
    {
        public TestOutputStream() : this(New<TestOutputStream>(), Transfer.Full)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestOutputStream(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        protected override void DoCloseFn(Cancellable? cancellable = null)
        {
        }

        protected override void DoFlush(Cancellable? cancellable = null)
        {
        }

        protected override int DoSplice(InputStream source, OutputStreamSpliceFlags flags, Cancellable? cancellable = null)
        {
            return 0;
        }

        protected override int DoWriteFn(ReadOnlySpan<byte> buffer, Cancellable? cancellable = null)
        {
           return buffer.Length;
        }
    }
}
