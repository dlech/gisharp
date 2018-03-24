using System;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class InputStreamTests
    {
        [Test]
        public void TestRead()
        {
            using (var buffer = new ByteArray())
            using (var stream = new TestInputStream()) {
                buffer.SetSize(10);
                var count = stream.Read(buffer);
                Assert.That(count, Is.EqualTo(10));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestReadAll()
        {
            using (var buffer = new ByteArray())
            using (var stream = new TestInputStream()) {
                buffer.SetSize(10);
                stream.ReadAll(buffer, out var read);
                Assert.That(read, Is.EqualTo(10));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSkip()
        {
            using (var buffer = new ByteArray())
            using (var stream = new TestInputStream()) {
                buffer.SetSize(10);
                var count = stream.Skip(10);
                Assert.That(count, Is.EqualTo(10));
            }

            AssertNoGLibLog();
        }

    }

    [GType]
    class TestInputStream : InputStream
    {
        public TestInputStream() : this(New<TestInputStream>(), Transfer.Full)
        {
        }

        public TestInputStream(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        protected override int DoReadFn(IntPtr buffer, int count, Cancellable cancellable = null)
        {
           for (int i = 0; i < count; i++) {
               Marshal.WriteByte(buffer + i, (byte)i);
           }
           return count;
        }

        protected override int DoSkip(int count, Cancellable cancellable = null)
        {
            return count;
        }

        protected override void DoCloseFn(Cancellable cancellable = null)
        {
        }
    }
}