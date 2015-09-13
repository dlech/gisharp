using NUnit.Framework;
using System;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture ()]
    public class QuarkTests
    {
        const string testQuarkPrefix = "gisharp-glib-test-quark-";

        [Test ()]
        public void TestFromString ()
        {
            Quark actual;

            actual = Quark.FromString (null);
            Assert.That (actual, Is.EqualTo (0));

            actual = Quark.FromString (testQuarkPrefix + "test-from-string");
            Assert.That (actual, Is.Not.EqualTo (0));
        }

        [Test ()]
        public void TestToString ()
        {
            string actual;

            // null always returns 0
            actual = Quark.Zero.ToString ();
            Assert.That (actual, Is.Null);

            // undefined quark creates new
            var quarkString = testQuarkPrefix + "test-to-string";
            Assume.That (Quark.TryString (quarkString), Is.EqualTo (0));
            var quark = Quark.FromString (quarkString);
            actual = quark.ToString ();
            Assert.That (actual, Is.EqualTo (quarkString));
        }


        [Test ()]
        public void TestTryString ()
        {
            Quark actual;
            var quarkString = testQuarkPrefix + "test-try-string";

            // null always returns 0
            actual = Quark.TryString (null);
            Assert.That (actual, Is.EqualTo (0));

            // undefined quark returns 0
            actual = Quark.TryString (quarkString);
            Assert.That (actual, Is.EqualTo (0));

            // defined quark returns value
            var quark = Quark.FromString (quarkString);
            actual = Quark.TryString (quarkString);
            Assert.That (actual, Is.EqualTo (quark));
        }
    }
}
