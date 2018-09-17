using System;

using NUnit.Framework;
using GISharp.Lib.GObject;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class BindingFlagsTests
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (BindingFlags).GetGType ();
            Assert.That<string>(gtype.Name, Is.EqualTo("GBindingFlags"));

            AssertNoGLibLog();
        }
    }
}
