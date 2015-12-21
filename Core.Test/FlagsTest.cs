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
            // can't have null argument
            Assert.That (() => GType.Register (null),
                         Throws.TypeOf <ArgumentNullException> ());

            // invalid because it does not have [Register] attribute.
            Assert.That (() => GType.Register (typeof (TestFlags1)),
                         Throws.InvalidOperationException);

            // invalid because underlying type is too big.
            Assert.That (() => GType.Register (typeof (TestFlags2)),
                         Throws.InvalidOperationException);

            // invalid because Register = false.
            Assert.That (() => GType.Register (typeof (TestFlags3)),
                         Throws.InvalidOperationException);

            var actual = GType.Register (typeof (TestFlags));
            Assert.That (actual, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register flags");

            Assert.That (actual, Is.EqualTo (typeof (TestFlags).GetGType ()));
            Assert.That (actual.IsA (GType.Flags), Is.True);
        }
    }

    // This type is not registered with the GType system since it does not
    // have the [Register] attribute.
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

    // This type should not be allowed because of Register = false
    [Flags, GType (Register = false)]
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
