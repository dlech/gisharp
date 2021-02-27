// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GObject
{
    public class CClosureTests : Tests
    {
        [Test]
        public void TestNew()
        {
            using var closure = new CClosure(new TestHandler((i) => i + 1));
            Assert.That(closure.Invoke<int>(1), Is.EqualTo(2));
        }

        private delegate int TestHandler(int i);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static int ManagedTestHandler(int i, IntPtr userData_)
        {
            try {
                var userData = (CClosureData)GCHandle.FromIntPtr(userData_).Target!;
                var ret = ((TestHandler)userData.Callback).Invoke(i);
                return ret;
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }
    }
}
