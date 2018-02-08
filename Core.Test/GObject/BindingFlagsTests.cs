using System;

using NUnit.Framework;
using GISharp.GObject;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class BindingFlagsTests
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (BindingFlags).GetGType ();
            Assert.That (gtype.Name, Is.EqualTo ("GBindingFlags"));

            AssertNoGLibLog();
        }
    }
}
