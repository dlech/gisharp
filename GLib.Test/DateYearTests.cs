using System;
using NUnit.Framework;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class DateYearTests
    {
        [Test]
        public void TestImplicitOperator ()
        {
            ushort expected = 1;
            DateYear dateYear = expected;
            ushort actual = dateYear;
            Assert.That (actual, Is.EqualTo (expected));
        }
    }
}
