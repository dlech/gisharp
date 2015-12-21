using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class GTypeTest
    {
        [Test]
        public void TestGetGTypeName ()
        {
            Assert.That (typeof (GType).GetGTypeName (), Is.EqualTo ("GType"));
        }

        [Test]
        public void TestName ()
        {
            Assert.That (() => GType.Invalid.Name, Throws.InvalidOperationException);
            Assert.That (GType.None.Name, Is.EqualTo ("void"));
        }

        [Test]
        public void TestParent ()
        {
            Assert.That (() => GType.Invalid.Parent, Throws.InvalidOperationException);
            Assert.That (GType.None.Parent, Is.EqualTo (GType.Invalid));
            // TODO: would be nice to have a test case that does not return Invalid
        }

        [Test]
        public void TestChildren ()
        {
            Assert.That (() => GType.Invalid.Children, Throws.InvalidOperationException);
            Assert.That (GType.None.Children, Is.Empty);
        }

        [Test]
        public void TestIsA ()
        {
            Assert.That (() => GType.Invalid.IsA (GType.None), Throws.InvalidOperationException);
            Assert.That (() => GType.None.IsA (GType.Invalid), Throws.ArgumentException);
            Assert.That (GType.None.IsA (GType.None), Is.True);
            Assert.That (GType.None.IsA (GType.Boolean), Is.False);
        }

        [Test]
        public void TestFromName ()
        {
            Assert.That (GType.FromName ("void"), Is.EqualTo (GType.None));
            Assert.That (GType.FromName ("there-should-never-be-a-type-with-this-name"),
                         Is.EqualTo (GType.Invalid));
            Assert.That (() => GType.FromName ("name has invalid characters"),
                         Throws.TypeOf<InvalidGTypeNameException> ());
            Assert.That (() => GType.FromName (null),
                         Throws.TypeOf<ArgumentNullException> ());
        }

        [Test]
        public void TestEqualityOperator ()
        {
            Assert.That (GType.Invalid == GType.Invalid, Is.True);
            Assert.That (GType.Invalid == GType.None, Is.False);
        }

        [Test]
        public void TestInequalityOperator ()
        {
            Assert.That (GType.Invalid != GType.None, Is.True);
            Assert.That (GType.Invalid != GType.Invalid, Is.False);
        }

        [Test]
        public void TestEquals ()
        {
            Assert.That (GType.Invalid.Equals (GType.Invalid), Is.True);
            Assert.That (GType.Invalid.Equals (GType.None), Is.False);
            Assert.That (GType.Invalid.Equals (new object ()), Is.False);
            Assert.That (GType.Invalid.Equals (null), Is.False);
        }
    }
}
