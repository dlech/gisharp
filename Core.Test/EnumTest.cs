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
            // can't have null argument
            Assert.That (() => GType.Register (null),
                         Throws.TypeOf <ArgumentNullException> ());

            // invalid because it does not have [Register] attribute.
            Assert.That (() => GType.Register (typeof (TestEnum1)),
                         Throws.InvalidOperationException);

            // invalid because underlying type is too big.
            Assert.That (() => GType.Register (typeof (TestEnum2)),
                         Throws.InvalidOperationException);

            // invalid because Register = false.
            Assert.That (() => GType.Register (typeof (TestEnum3)),
                         Throws.InvalidOperationException);

            var actual = GType.Register (typeof (TestEnum));
            Assert.That (actual, Is.Not.EqualTo (GType.Invalid),
                         "Failed to register an enum");

            Assert.That (actual, Is.EqualTo (typeof (TestEnum).GetGType ()));
            Assert.That (actual.IsA (GType.Enum), Is.True);
        }
    }

    // This type is not registered with the GType system since it does not
    // have the [Register] attribute.
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

    // This type should not be allowed because of Register = false
    [GType (Register = false)]
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
