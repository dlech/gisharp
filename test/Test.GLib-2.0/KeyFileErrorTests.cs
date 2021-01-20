// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using NUnit.Framework;

using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(KeyFileError))]
    public class KeyFileErrorTests : Tests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(default(KeyFileError).GetGErrorDomain(), Is.EqualTo(KeyFileErrorDomain.Quark));
        }
    }
}
