using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class BindingFlagsTest
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (BindingFlags).GetGType ();
            Assert.That (gtype.Name, Is.EqualTo ("GBindingFlags"));
        }
    }
}
