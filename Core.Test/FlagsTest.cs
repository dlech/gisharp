using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class FlagsTest
    {
        [Test]
        public void TestRegister ()
        {
            // invalid because it does not have [GType] attribute.
            Assert.That (() => typeof (TestFlags1).GetGType (),
                         Throws.ArgumentException);

            // invalid because underlying type is too big.
            Assert.That (() => typeof (TestFlags2).GetGType (),
                         Throws.ArgumentException);

            // invalid because IsWrappedNativeType = true.
            Assert.That (() => typeof (TestFlags3).GetGType (),
                         Throws.ArgumentException);

            // this should register successfully
            var actual = typeof (TestFlags).GetGType ();
            Assert.That (actual, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register flags");

            // make sure the type is not re-registed.
            Assert.That (actual, Is.EqualTo (typeof (TestFlags).GetGType ()));

            // a couple more GType checks
            Assert.That ((Type)actual, Is.EqualTo (typeof (TestFlags)));
            Assert.That (actual.IsA (GType.Flags), Is.True);
        }
    }

    // This type is not registered with the GType system since it does not
    // have the [GType] attribute.
    [Flags]
    public enum TestFlags1
    {
        One,
        Two,
        Three,
    }

    // This type should not be allowed because of the underlying type
    [Flags, GType]
    public enum TestFlags2 : long
    {
        One,
        Two,
        Three,
    }

    // This type should not be allowed because of IsWrappedNativeType = true
    [Flags, GType (IsWrappedNativeType = true)]
    public enum TestFlags3
    {
        One,
        Two,
        Three,
    }

    // This type is regiseted
    [Flags, GType]
    public enum TestFlags
    {
        One = 1,
        Two = 2,
        Four = 4,
    }
}
