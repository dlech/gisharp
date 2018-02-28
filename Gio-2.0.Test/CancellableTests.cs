
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class CancellableTests
    {
        [Test]
        public void TestIsCancelled()
        {
            using (var c = new Cancellable()) {
                Assert.That(c.IsCancelled, Is.False);
                c.Cancel();
                Assert.That(c.IsCancelled, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetErrorIfCancelled()
        {
            using (var c = new Cancellable()) {
                Assert.That(() => c.ThrowIfCancelled(), Throws.Nothing);
                c.Cancel();
                Assert.That(() => c.ThrowIfCancelled(), ThrowsGErrorException(IOErrorEnum.Cancelled));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetFd()
        {
            using (var c = new Cancellable()) {
                Assert.That(c.Fd, Is.GreaterThan(-1));
                c.ReleaseFd();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestMakePollFd()
        {
            using (var c = new Cancellable()) {
                Assert.That(c.TryMakePollfd(out var pollFD), Is.True);
                c.ReleaseFd();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetCurrentPushPop()
        {
            // have to test Push and Pop in same method since they affect a
            // global variable.

            using (var c = new Cancellable()) {
                c.PushCurrent();
                Assert.That(Cancellable.Current, Is.SameAs(c));
                c.PopCurrent();
                Assert.That(Cancellable.Current, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestReset()
        {
            using (var c = new Cancellable()) {
                c.Reset();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestConnectDisconnect()
        {
            using (var c = new Cancellable()) {
                var handlerInvoked = false;
                var handler = new Cancellable.CancelledCallback(_ => handlerInvoked = true);
                var id = c.Connect(handler);
                c.Cancel();
                Assert.That(handlerInvoked, Is.True);

                handlerInvoked = false;
                c.Reset();

                c.Disconnect(id);
                c.Cancel();
                Assert.That(handlerInvoked, Is.False);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCancelledSignal()
        {
            using (var c = new Cancellable()) {
                bool handlerInvoked = false;
                c.Cancelled += (s, a) => handlerInvoked = true;
                c.Cancel();
                Assert.That(handlerInvoked, Is.True);
            }
            AssertNoGLibLog();
        }
    }
}
