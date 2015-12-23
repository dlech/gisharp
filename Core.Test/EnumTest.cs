using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class EnumTest
    {
        [Test]
        public void TestRegister ()
        {
            // invalid because it does not have [GType] attribute.
            Assert.That (() => typeof (TestEnum1).GetGType (),
                         Throws.ArgumentException);

            // invalid because underlying type is too big.
            Assert.That (() => typeof (TestEnum2).GetGType (),
                         Throws.ArgumentException);

            // invalid because IsWrappedNativeType = true.
            Assert.That (() => typeof (TestEnum3).GetGType (),
                         Throws.ArgumentException);

            // this should register successfully
            var actual = typeof (TestEnum).GetGType ();
            Assert.That (actual, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register an enum");

            // make sure the type is not re-registed.
            Assert.That (actual, Is.EqualTo (typeof (TestEnum).GetGType ()));

            // a couple more GType checks
            Assert.That ((Type)actual, Is.EqualTo (typeof (TestEnum)));
            Assert.That (actual.IsA (GType.Enum), Is.True);
        }
    }

    // This type is not registered with the GType system since it does not
    // have the [GType] attribute.
    public enum TestEnum1
    {
        One,
        Two,
        Three,
    }

    // This type should not be allowed because of the underlying type
    [GType]
    public enum TestEnum2 : long
    {
        One,
        Two,
        Three,
    }

    // This type should not be allowed because of IsWrappedNativeType = true
    [GType (IsWrappedNativeType = true)]
    public enum TestEnum3
    {
        One,
        Two,
        Three,
    }

    // This type is regiseted
    [GType]
    public enum TestEnum
    {
        One = 1,
        Two = 2,
        Four = 4,
    }
}
