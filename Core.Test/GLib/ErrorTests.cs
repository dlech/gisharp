using GISharp.GLib;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (Error).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That (gtype.Name, Is.EqualTo ("GError"));
        }

        static Quark ErrorQuark {
            get {
                return TestErrorDomain.Failed.GetErrorDomain ();
            }
        }
    }

    [ErrorDomain ("gisharp-core-test-error-domain-quark")]
    enum TestErrorDomain
    {
        Failed
    }
}
