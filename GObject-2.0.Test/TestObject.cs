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

        [Test]
        public void TestGType ()
        {
            // make sure subclass has new GType
            Assert.That (Subclass.GType, Is.Not.EqualTo (Object.GType));
        }

        [Test]
        public void TestX ()
        {
            var obj = new Subclass ();
            Assert.That (obj, Is.Not.Null);
        }
    }

    public class Subclass : Object
    {
        public Subclass () : base (GType)
        {
        }
    }
}
