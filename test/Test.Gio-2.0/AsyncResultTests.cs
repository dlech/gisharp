// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Lib.GIRepository;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using IAsyncResult = GISharp.Lib.Gio.IAsyncResult;
using InterfaceInfo = GISharp.Lib.GIRepository.InterfaceInfo;
using Object = GISharp.Lib.GObject.Object;
using Transfer = GISharp.Runtime.Transfer;

namespace GISharp.Test.Gio
{
    public class AsyncResultTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(IAsyncResult).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GAsyncResult"));
            var info = (InterfaceInfo)Repository.Default.FindByGtype(gtype);
            Assert.That(Marshal.SizeOf<AsyncResultIface.UnmanagedStruct>(), Is.EqualTo(info.IfaceStruct.Size));
        }

        [Test]
        public void TestGetSourceObject()
        {
            using var source = new Object();
            using var ar = TestAsyncResult.New(source);
            Assert.That(ar.GetSourceObject(), Is.SameAs(source));
        }
    }

    [GType]
    class TestAsyncResult : Object, IAsyncResult
    {
        Object? source;

        public static TestAsyncResult New(Object? source)
        {
            var instance = CreateInstance<TestAsyncResult>();
            instance.source = source;
            return instance;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestAsyncResult(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        Object? IAsyncResult.DoGetSourceObject() => source;

        IntPtr IAsyncResult.DoGetUserData() => throw new NotImplementedException();

        bool IAsyncResult.DoIsTagged(IntPtr sourceTag) => throw new NotImplementedException();
    }
}
