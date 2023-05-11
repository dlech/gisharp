// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Lib.GIRepository;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using InterfaceInfo = GISharp.Lib.GIRepository.InterfaceInfo;
using Object = GISharp.Lib.GObject.Object;
using Transfer = GISharp.Runtime.Transfer;

namespace GISharp.Test.Gio
{
    public class LoadableIconTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(ILoadableIcon).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GLoadableIcon"));
            var info = (InterfaceInfo)Repository.Default.FindByGtype(gtype);
            Assert.That(
                Marshal.SizeOf<LoadableIconIface.UnmanagedStruct>(),
                Is.EqualTo(info.IfaceStruct.Size)
            );
        }

        [Test]
        public void TestLoad()
        {
            using var icon = TestLoadableIcon.New();
            using var stream = icon.Load(16, out var type);
            Assert.That(stream, Is.Not.Null);
            Assert.That<string>(type, Is.EqualTo("test"));
        }
    }

    [GType]
    class TestLoadableIcon : Object, ILoadableIcon
    {
        public static TestLoadableIcon New()
        {
            return CreateInstance<TestLoadableIcon>();
        }

        InputStream ILoadableIcon.DoLoad(int size, out Utf8 type, Cancellable? cancellable)
        {
            type = new Utf8("test");
            return TestInputStream.New();
        }

        void ILoadableIcon.DoLoadAsync(
            int size,
            AsyncReadyCallback? callback,
            Cancellable? cancellable
        )
        {
            throw new NotImplementedException();
        }

        InputStream ILoadableIcon.DoLoadFinish(Lib.Gio.IAsyncResult res, out Utf8 type)
        {
            throw new NotImplementedException();
        }

        bool IIcon.DoEqual(IIcon? icon2)
        {
            throw new NotImplementedException();
        }

        uint IIcon.DoHash()
        {
            throw new NotImplementedException();
        }

        Variant? IIcon.DoSerialize()
        {
            throw new NotImplementedException();
        }

        public TestLoadableIcon(IntPtr handle, Transfer ownership)
            : base(handle, ownership) { }
    }
}
