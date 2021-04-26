// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GdkPixbuf;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GdkPixbuf
{
    public class PixbufErrorTests
    {
        [Test]
        public void PixbufErrorGType()
        {
            var gtype = typeof(PixbufError).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GdkPixbufError"));
        }

        [Test]
        public void TestQuark()
        {
            Assert.That(default(PixbufError).GetGErrorDomain(),
                Is.EqualTo(PixbufErrorDomain.Quark));
        }
    }
}
