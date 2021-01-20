// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using NUnit.Framework;
using GISharp.Runtime;
using GISharp.Lib.GObject;
using GISharp.Lib.GLib;

using Object = GISharp.Lib.GObject.Object;
using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    public class InterfaceTests : Tests
    {
        [Test]
        public void TestUnmanagedTypeRegistration()
        {
            Assert.That(() => GType.Of<INetworkMonitor>(), Throws.Nothing);
        }

        [Test]
        public void TestVirtualMethod()
        {
            using var obj = TestNetworkMonitor.New();
            Assume.That(obj.CanReachCallCount, Is.EqualTo(0));
            obj.CanReach(IntPtr.Zero);
            Assert.That(obj.CanReachCallCount, Is.EqualTo(1));
        }

        [Test]
        public void TestAsyncVirtualMethod()
        {
            RunAsyncTest(async () => {
                using var obj = TestNetworkMonitor.New();
                var result = await obj.CanReachAsync(IntPtr.Zero);
                Assert.That(result, Is.True);
            });
        }

        [Test]
        public void TestProperty()
        {
            using var obj = TestNetworkMonitor.New();
            var value = obj.GetProperty("connectivity");
            Assert.That(value, Is.EqualTo(NetworkConnectivity.Local));
        }

        [Test]
        public void TestSignal()
        {
            using var obj = TestNetworkMonitor.New();
            var callbackCount = 0;
            obj.NetworkChanged += available => callbackCount++;

            var id = Signal.TryLookup<TestNetworkMonitor>("network-changed");
            Assume.That(id, Is.Not.EqualTo(0));
            obj.Emit(id, Quark.Zero, true);

            Assert.That(callbackCount, Is.EqualTo(1));
        }
    }

    [GType]
    class TestNetworkMonitor : Object, INetworkMonitor
    {
        public int CanReachCallCount { get; private set; }

        #region INetworkMonitor implementation

        public event Action<bool>? NetworkChanged;

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
            NetworkChanged?.Invoke(available);
        }

        [DefaultValue(NetworkConnectivity.Local)]
        public NetworkConnectivity Connectivity => NetworkConnectivity.Local;

        public bool NetworkAvailable => throw new InvalidOperationException();

        public bool NetworkMetered => throw new InvalidOperationException();

        #endregion

        #region IInitable implementation

        void IInitable.DoInit(IntPtr cancellable) => throw new InvalidOperationException();

        #endregion

        public static TestNetworkMonitor New()
        {
            return CreateInstance<TestNetworkMonitor>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestNetworkMonitor(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }
    }
}
