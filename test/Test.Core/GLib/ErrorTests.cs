using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Core.GLib
{
    public class ErrorTests : Tests
    {
        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<Error>();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GError"));
        }

        [Test]
        public void TestMatches()
        {
            const TestError code = TestError.Failed;
            using (var err = new Error(code, "Format {0}", 0)) {
                Assert.That(err.Matches(code));
            }

            var domain2 = Quark.FromString("test-error-domain-2");
            const int code2 = 99;
            using (var err = new Error(domain2, code2, "Format {0}", 0)) {
                Assert.That(err.Matches(domain2, code2));
            }
        }
    }

    [GErrorDomain("gisharp-core-test-error-domain-quark")]
    enum TestError
    {
        Failed
    }

    static class TestErrorDomain
    {
        public static Quark Quark => TestError.Failed.GetGErrorDomain();
    }
}
