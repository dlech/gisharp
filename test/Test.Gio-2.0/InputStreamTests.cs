// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    public class InputStreamTests
    {
        [Test]
        public void TestRead()
        {
            using var stream = TestInputStream.New();
            var buffer = new byte[10];
            var count = stream.Read(buffer);
            Assert.That(count, Is.EqualTo(10));
        }

        [Test]
        public void TestReadAll()
        {
            using var stream = TestInputStream.New();
            var buffer = new byte[10];
            stream.ReadAll(buffer, out var read);
            Assert.That(read, Is.EqualTo(10));
        }

        [Test]
        public void TestSkip()
        {
            using var stream = TestInputStream.New();
            var buffer = new byte[10];
            var count = stream.Skip(10);
            Assert.That(count, Is.EqualTo(10));
        }

        [Test]
        public void TestReadAsync()
        {
            RunAsyncTest(async () => {
                using var stream = TestInputStream.New();
                var buffer = new byte[10];
                var count = await stream.ReadAsync(buffer);
                Assert.That(count, Is.EqualTo(10));
            });
        }

        [Test]
        public void TestReadAllAsync()
        {
            RunAsyncTest(async () => {
                using var stream = TestInputStream.New();
                var buffer = new byte[10];
                var count = await stream.ReadAllAsync(buffer);
                Assert.That(count, Is.EqualTo(10));
            });
        }

        [Test]
        public void TestReadBytesAsync()
        {
            RunAsyncTest(async () => {
                using var stream = TestInputStream.New();
                var actual = await stream.ReadBytesAsync(10);
                Assert.That(actual, Has.Count.EqualTo(10));
            });
        }

        [Test]
        public void TestSkipAsync()
        {
            RunAsyncTest(async () => {
                using var stream = TestInputStream.New();
                var actual = await stream.SkipAsync(10);
                Assert.That(actual, Is.EqualTo(10));
            });
        }

        [Test]
        public void TestCloseAsync()
        {
            RunAsyncTest(async () => {
                using var stream = TestInputStream.New();
                await stream.CloseAsync();
                Assert.That(stream.IsClosed, Is.True);
            });
        }
    }

    [GType]
    class TestInputStream : InputStream
    {
        public static TestInputStream New()
        {
            return CreateInstance<TestInputStream>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestInputStream(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        protected override int DoReadFn(IntPtr buffer, int count, Cancellable? cancellable = null)
        {
            for (int i = 0; i < count; i++) {
                Marshal.WriteByte(buffer + i, (byte)i);
            }
            return count;
        }

        protected override int DoSkip(int count, Cancellable? cancellable = null)
        {
            return count;
        }

        protected override void DoCloseFn(Cancellable? cancellable = null)
        {
        }
    }
}
