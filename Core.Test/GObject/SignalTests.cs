
using System;
using GISharp.GObject;
using NUnit.Framework;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class SignalTests
    {
        [Test]
        public void TestValidateName()
        {
            Assert.That(() => Signal.ValidateName("4"), Throws.ArgumentException,
                "Name must start with a letter");
            Assert.That(() => Signal.ValidateName("s$"), Throws.ArgumentException,
                "$ is not allowed");
            Assert.That(() => Signal.ValidateName("s-s_s"), Throws.ArgumentException,
                "can't have both - and _");

            Assert.That(() => Signal.ValidateName("s"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("S"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s1"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s-s"), Throws.Nothing);
            Assert.That(() => Signal.ValidateName("s_s"), Throws.Nothing);
        }
    }
}
