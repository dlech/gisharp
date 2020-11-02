using NUnit.Framework;
using GISharp.Lib.GObject;

namespace GISharp.Test.Core.GObject
{
    public class BindingFlagsTests : Tests
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (BindingFlags).GetGType ();
            Assert.That<string?>(gtype.Name, Is.EqualTo("GBindingFlags"));
        }
    }
}
