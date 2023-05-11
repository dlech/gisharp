// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    [TestOf(typeof(KeyFileError))]
    public class KeyFileErrorTests
    {
        [Test]
        public void TestQuark()
        {
            Assert.That(
                default(KeyFileError).GetGErrorDomain(),
                Is.EqualTo(KeyFileErrorDomain.Quark)
            );
        }
    }
}
