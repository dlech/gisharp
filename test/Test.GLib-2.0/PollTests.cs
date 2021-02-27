// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class PollTests : Tests
    {
        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<PollFD>();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GPollFD"));
        }
    }
}
