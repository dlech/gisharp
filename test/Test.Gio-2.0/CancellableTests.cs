// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Threading;

using GISharp.Lib.Gio;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    public class CancellableTests
    {
        [Test]
        public void TestIsCancelled()
        {
            using var c = new Cancellable();
            Assert.That(c.IsCancelled, Is.False);
            c.Cancel();
            Assert.That(c.IsCancelled, Is.True);
        }

        [Test]
        public void TestSetErrorIfCancelled()
        {
            using var c = new Cancellable();
            Assert.That(() => c.ThrowIfCancelled(), Throws.Nothing);
            c.Cancel();
            Assert.That(() => c.ThrowIfCancelled(), ThrowsGErrorException(IOErrorEnum.Cancelled));
        }

        [Test]
        public void TestGetFd()
        {
            using var c = new Cancellable();
            Assert.That(c.Fd, Is.GreaterThan(-1));
            c.ReleaseFd();
        }

        [Test]
        public void TestMakePollFd()
        {
            using var c = new Cancellable();
            Assert.That(c.TryMakePollfd(out var pollFD), Is.True);
            c.ReleaseFd();
        }

        [Test]
        public void TestGetCurrentPushPop()
        {
            // have to test Push and Pop in same method since they affect a
            // global variable.

            using var c = new Cancellable();
            c.PushCurrent();
            Assert.That(Cancellable.Current, Is.SameAs(c));
            c.PopCurrent();
            Assert.That(Cancellable.Current, Is.Null);
        }

        [Test]
        public void TestReset()
        {
            using var c = new Cancellable();
            c.Reset();
        }

        [Test]
        public void TestConnectDisconnect()
        {
            using var c = new Cancellable();
            var handlerInvoked = false;
            var handler = new CancellableSourceFunc(_ => handlerInvoked = true);
            var id = c.Connect(handler);
            c.Cancel();
            Assert.That(handlerInvoked, Is.True);

            handlerInvoked = false;
            c.Reset();

            c.Disconnect(id);
            c.Cancel();
            Assert.That(handlerInvoked, Is.False);
        }

        [Test]
        public void TestCancelledSignal()
        {
            using var c = new Cancellable();
            bool handlerInvoked = false;
            c.CancelledSignal += (c) => handlerInvoked = true;
            c.Cancel();
            Assert.That(handlerInvoked, Is.True);
        }

        [Test]
        public void TestSubclassing()
        {
            using var c = TestCancellable.New();
            c.Cancel();
            Assert.That(c.Token.IsCancellationRequested, Is.True);
        }
    }

    [GType]
    sealed class TestCancellable : Cancellable
    {
        readonly CancellationTokenSource tokenSource;

        public CancellationToken Token => tokenSource.Token;

        public static TestCancellable New()
        {
            return CreateInstance<TestCancellable>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestCancellable(IntPtr handle, Transfer ownership)
            : base(handle, ownership)
        {
            tokenSource = new();
        }

        protected override void DoCancelled()
        {
            tokenSource.Cancel();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tokenSource?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
