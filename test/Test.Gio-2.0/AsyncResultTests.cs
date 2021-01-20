// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>


using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;
using IAsyncResult = GISharp.Lib.Gio.IAsyncResult;
using System.ComponentModel;

namespace GISharp.Test.Gio
{
    public class AsyncResultTests : Tests
    {
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
