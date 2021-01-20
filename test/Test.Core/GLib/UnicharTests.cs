// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.Core
{
    public class UnicharTests : Tests
    {
        [Test]
        public void TestSizeOf()
        {
            // it is important that we don't add any extra fields so that
            // Unichar exactly matches gunichar.
            Assert.That(Marshal.SizeOf<Unichar>(), Is.EqualTo(sizeof(uint)));
        }

        [Test]
        public void TestToString()
        {
            var c = new Unichar(0x0041); // A
            Assert.That(c.ToString(), Is.EqualTo("U+0041"));
        }
    }
}
