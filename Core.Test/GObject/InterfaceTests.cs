using System;
using NUnit.Framework;
using GISharp.Runtime;
using GISharp.GObject;
using GISharp.GLib;
using System.ComponentModel;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class InterfaceTests
    {
        [Test]
        public void TestUnmanagedTypeRegistration ()
        {
            Assert.That (() => typeof(INetworkMonitor).GetGType (), Throws.Nothing);

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestVirtualMethod ()
        {
            using (var obj = new TestNetworkMonitor ()) {
                Assume.That (obj.CanReachCallCount, Is.EqualTo (0));
                obj.CanReach (IntPtr.Zero);
                Assert.That (obj.CanReachCallCount, Is.EqualTo (1));
            }

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestProperty()
        {
            using (var obj = new TestNetworkMonitor()) {
                var value = obj.GetProperty("connectivity");
                Assert.That(value, Is.EqualTo(NetworkConnectivity.Local));
            }

            Utility.AssertNoGLibLog();
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

            Utility.AssertNoGLibLog();
        }
    }

    [GType]
    class TestNetworkMonitor : GISharp.GObject.Object, INetworkMonitor
    {
        public int CanReachCallCount { get; private set; }

        #region INetworkMonitor implementation

        public event Action<bool> NetworkChanged;

        bool INetworkMonitor.CanReach (IntPtr connectable, IntPtr cancellable)
        {
            CanReachCallCount++;

            return false;
        }

        void INetworkMonitor.CanReachAsync (IntPtr connectable, IntPtr cancellable, Action<IntPtr> callback)
        {
            throw new InvalidOperationException ();
        }

        bool INetworkMonitor.CanReachFinish (IntPtr result)
        {
            throw new InvalidOperationException ();
        }

        void INetworkMonitor.OnNetworkChanged (bool available)
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

        public bool Init (IntPtr cancellable)
        {
            throw new InvalidOperationException ();
        }

        #endregion

        public TestNetworkMonitor () : this (New<TestNetworkMonitor> (), Transfer.Full)
        {
        }

        public TestNetworkMonitor (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
