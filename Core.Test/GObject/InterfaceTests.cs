using System;
using System.ComponentModel;
using System.Threading.Tasks;
using NUnit.Framework;
using GISharp.Runtime;
using GISharp.Lib.GObject;
using GISharp.Lib.GLib;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class InterfaceTests
    {
        [Test]
        public void TestUnmanagedTypeRegistration ()
        {
            Assert.That (() => typeof(INetworkMonitor).GetGType (), Throws.Nothing);

            AssertNoGLibLog();
        }

        [Test]
        public void TestVirtualMethod ()
        {
            using (var obj = new TestNetworkMonitor ()) {
                Assume.That (obj.CanReachCallCount, Is.EqualTo (0));
                obj.CanReach (IntPtr.Zero);
                Assert.That (obj.CanReachCallCount, Is.EqualTo (1));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestAsyncVirtualMethod()
        {
            RunAsyncTest(async () => {
                using (var obj = new TestNetworkMonitor()) {
                    var result = await obj.CanReachAsync(IntPtr.Zero);
                    Assert.That(result, Is.True);
                }
            });

            AssertNoGLibLog();
        }

        [Test]
        public void TestProperty()
        {
            using (var obj = new TestNetworkMonitor()) {
                var value = obj.GetProperty("connectivity");
                Assert.That(value, Is.EqualTo(NetworkConnectivity.Local));
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestSignal ()
        {
            using (var obj = new TestNetworkMonitor ()) {
                var callbackCount = 0;
                obj.NetworkChanged += available => callbackCount++;

                var id = Signal.TryLookup<TestNetworkMonitor> ("network-changed");
                Assume.That (id, Is.Not.EqualTo (0));
                obj.Emit(id, Quark.Zero, true);

                Assert.That (callbackCount, Is.EqualTo (1));
            }

            AssertNoGLibLog();
        }
    }

    [GType]
    class TestNetworkMonitor : GISharp.Lib.GObject.Object, INetworkMonitor
    {
        public int CanReachCallCount { get; private set; }

        #region INetworkMonitor implementation

        public event Action<bool> NetworkChanged;

        bool INetworkMonitor.DoCanReach(IntPtr connectable, IntPtr cancellable)
        {
            CanReachCallCount++;

            return false;
        }

        Task<bool> INetworkMonitor.DoCanReachAsync(IntPtr connectable, IntPtr cancellable)
        {
            return Task.FromResult(true);
        }

        void INetworkMonitor.DoNetworkChanged(bool available)
        {
            if (NetworkChanged != null) {
                NetworkChanged (available);
            }
        }

        [DefaultValue(NetworkConnectivity.Local)]
        public NetworkConnectivity Connectivity => NetworkConnectivity.Local;

        public bool NetworkAvailable {
            get {
                throw new InvalidOperationException ();
            }
        }

        public bool NetworkMetered {
            get {
                throw new InvalidOperationException ();
            }
        }

        #endregion

        #region IInitable implementation

        void IInitable.DoInit(IntPtr cancellable)
        {
            throw new InvalidOperationException ();
        }

        #endregion

        public TestNetworkMonitor () : this (New<TestNetworkMonitor> (), Transfer.Full)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestNetworkMonitor (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
