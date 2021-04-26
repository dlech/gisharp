// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GdkPixbuf;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GdkPixbuf
{
    public class PixbufAlphaModeTests
    {
        [Test]
        [Obsolete("deprecated upstream")]
        public void PixbufAlphaModeGType()
        {
            var gtype = typeof(PixbufAlphaMode).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GdkPixbufAlphaMode"));
        }
    }
}
