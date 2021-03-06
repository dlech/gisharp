// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;

using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class UtilityTests
    {
        [Test]
        public void TestApplicationName()
        {
            // Utility.ApplicationName is set in TestHelpers assembly during
            // one time setup
            Assert.That<string?>(Utility.ApplicationName, Is.EqualTo("GISharp.Test"));
        }

        [Test]
        public void TestProgramName()
        {
            // Utility.ProgramName is set in TestHelpers assembly during
            // one time setup
            Assert.That<string?>(Utility.ProgramName, Is.EqualTo("GISharp.Test"));
        }
    }
}
