using System;

using NUnit.Framework;
using GISharp.GObject;

namespace GISharp.GObject.Test
{
    [TestFixture]
    public class TestObject
    {
        [Test]
        public void TestConstruct ()
        {
            var obj = new Object (Object.GType);
            Assert.That (obj, Is.Not.Null);
        }
    }
}
