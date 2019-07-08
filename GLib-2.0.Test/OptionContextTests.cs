
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.GLib
{
    [TestFixture]
    public class OptionContextTests
    {
        [Test]
        public void TestSummary()
        {
            using (var oc = new OptionContext()) {
                var expected = "summary";
                oc.Summary = expected.ToUtf8();
                Assert.That<string?>(oc.Summary, Is.EqualTo(expected));
                oc.Summary = Utf8.Null;
                Assert.That<string?>(oc.Summary, Is.EqualTo(Utf8.Null));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestDescription()
        {
            using (var oc = new OptionContext()) {
                var expected = "description";
                oc.Description = expected.ToUtf8();
                Assert.That<string?>(oc.Description, Is.EqualTo(expected));
                oc.Description = Utf8.Null;
                Assert.That<string?>(oc.Description, Is.EqualTo(Utf8.Null));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetTranslateFunc()
        {
            using (var oc = new OptionContext()) {
                var translate = new TranslateFunc(x => x.ToString().Normalize().ToUtf8());
                oc.SetTranslateFunc(translate);
                oc.SetTranslateFunc(null);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetTranslationDomain()
        {
            using (var oc = new OptionContext()) {
                oc.SetTranslationDomain("domain");
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestHelpEnabled()
        {
            using (var oc = new OptionContext()) {
                var expected = true;
                oc.HelpEnabled = expected;
                Assert.That(oc.HelpEnabled, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestIgnoreUnknownOptions()
        {
            using (var oc = new OptionContext()) {
                var expected = true;
                oc.IgnoreUnknownOptions = expected;
                Assert.That(oc.IgnoreUnknownOptions, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestStrictPosix()
        {
            using (var oc = new OptionContext()) {
                var expected = true;
                oc.StrictPosix = expected;
                Assert.That(oc.StrictPosix, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestAddGroup()
        {
            using (var og = new OptionGroup("name", "desc", "help"))
            using (var oc = new OptionContext()) {
                oc.AddGroup(og);
                Assert.That(() => og.Handle, Throws.Nothing);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestMainGroup()
        {
            using (var og = new OptionGroup("name", "desc", "help"))
            using (var oc = new OptionContext()) {
                oc.MainGroup = og;
                Assert.That(oc.MainGroup.Handle, Is.EqualTo(og.Handle));
            }
            AssertNoGLibLog();
        }
    }
}
