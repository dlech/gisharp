// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GdkPixbuf;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GdkPixbuf
{
    public class InterpTypeTests
    {
        [Test]
        public void InterpTypeGType()
        {
            var gtype = typeof(InterpType).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GdkInterpType"));
        }
    }
}
