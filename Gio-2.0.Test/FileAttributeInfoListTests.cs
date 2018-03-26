
using GISharp.Lib.Gio;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class FileAttributeInfoListTests
    {
        [Test]
        public void TestNew()
        {
            using (var list = new FileAttributeInfoList()) {
                Assert.That(list.Count, Is.Zero);
            }
        }

        [Test]
        public void TestDup()
        {
            using (var list = new FileAttributeInfoList())
            using (var list2 = list.Dup()) {
                Assert.That(list.Handle, Is.Not.EqualTo(list2.Handle));
            }
        }

        [Test]
        public void TestLookup()
        {
            using (var list = new FileAttributeInfoList()) {
                Assert.That(() => list.Lookup(null), Throws.ArgumentNullException);
                Assert.That(list.Lookup("test"), Is.Null);
            }
        }

        [Test]
        public void TestAdd()
        {
            using (var list = new FileAttributeInfoList()) {
                Assert.That(() => list.Add(null, FileAttributeType.Boolean, FileAttributeInfoFlags.None),
                    Throws.ArgumentNullException);
                
                list.Add("test", FileAttributeType.Boolean, FileAttributeInfoFlags.None);
                Assert.That(list.Count, Is.EqualTo(1));
            }
        }
    }
}
