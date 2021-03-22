// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class PollTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(PollFD).ToGType();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That(gtype.Name, Is.EqualTo("GPollFD"));
        }
    }
}
