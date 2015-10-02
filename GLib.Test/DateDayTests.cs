using System;
using NUnit.Framework;

namespace GISharp.GLib.Test
{
    [TestFixture]
    public class DateDayTests
    {
        [Test]
        public void TestImplicitOperator ()
        {
            byte expected = 1;
            DateDay dateDay = expected;
            byte actual = dateDay;
            Assert.That (actual, Is.EqualTo (expected));
        }
    }
}
