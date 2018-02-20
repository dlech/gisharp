using System;
using GISharp.GLib;

using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        public void TestApplicationName()
        {
            // Utility.ApplicationName is set in TestHelpers assembly during
            // one time setup
            Assert.That(Utility.ApplicationName, Is.EqualTo("GISharp.Test"));
        }

        [Test]
        public void TestProgramName()
        {
            // Utility.ProgramName is set in TestHelpers assembly during
            // one time setup
            Assert.That(Utility.ProgramName, Is.EqualTo("GISharp.Test"));
        }
    }
}
