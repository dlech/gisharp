using System;
using GISharp.Lib.GLib;

using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        public void TestApplicationName()
        {
            // Utility.ApplicationName is set in TestHelpers assembly during
            // one time setup
            Assert.That<string>(Utility.ApplicationName, Is.EqualTo("GISharp.Test"));
        }

        [Test]
        public void TestProgramName()
        {
            // Utility.ProgramName is set in TestHelpers assembly during
            // one time setup
            Assert.That<string>(Utility.ProgramName, Is.EqualTo("GISharp.Test"));
        }
    }
}
