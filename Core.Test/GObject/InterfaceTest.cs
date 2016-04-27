﻿using System;
using NUnit.Framework;
using GISharp.Runtime;
using GISharp.GObject;
using GISharp.GLib;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class InterfaceTest
    {
        [Test]
        public void TestWrappedNativeTypeRegistration ()
        {
            Assert.That (() => typeof(INetworkMonitor).GetGType (), Throws.Nothing);
        }

        [Test]
        public void TestVirtualMethod ()
        {
            var obj = new TestNetworkMonitor ();

            Assume.That (obj.CanReachCallCount, Is.EqualTo (0));
            obj.CanReach (IntPtr.Zero);
            Assert.That (obj.CanReachCallCount, Is.EqualTo (1));
        }

        [Test]
        public void TestProperty ()
        {
            var obj = new TestNetworkMonitor ();

            var value = obj.GetProperty ("connectivity", GType.Int);
            Assert.That (value.Get (), Is.EqualTo (1));
        }

        [Test]
        public void TestSignal ()
        {
            var obj = new TestNetworkMonitor ();

            var callbackCount = 0;
            obj.NetworkChanged += (availible) => callbackCount++;

            var id = Signal.Lookup ("network-changed", typeof(INetworkMonitor).GetGType ());
            Signal.Emit (obj, id, Quark.Null, new [] { (Value)true });

            Assert.That (callbackCount, Is.EqualTo (1));
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
            throw new NotImplementedException ();
        }

        bool INetworkMonitor.CanReachFinish (IntPtr result)
        {
            throw new NotImplementedException ();
        }

        void INetworkMonitor.OnNetworkChanged (bool availible)
        {
            if (NetworkChanged != null) {
                NetworkChanged (availible);
            }
        }

        public int Connectivity {
            get {
                return 1;
            }
        }

        public bool NetworkAvailable {
            get {
                throw new NotImplementedException ();
            }
        }

        public bool NetworkMetered {
            get {
                throw new NotImplementedException ();
            }
        }

        #endregion

        #region IInitable implementation

        public bool Init (IntPtr cancellable)
        {
            throw new NotImplementedException ();
        }

        #endregion

        public TestNetworkMonitor ()
            : this (New<TestNetworkMonitor> (), Transfer.All)
        {
        }

        protected TestNetworkMonitor (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}