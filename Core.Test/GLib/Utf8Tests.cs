using System;
using GISharp.GLib;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class Utf8Tests
    {
        const string testString = "test-string-with-ůŋįçøđê";

        [Test]
        public void TestNewAndToString()
        {
            using (var utf8 = new Utf8(testString)) {
                Assert.That(utf8.Length, Is.EqualTo(testString.Length));
                Assert.That(utf8.ToString(), Is.EqualTo(testString));
            }
        }

        [Test]
        public void TestEnumerator()
        {
            using (var utf8 = new Utf8(testString)) {
                var expected = testString.GetEnumerator();
                foreach (var c in utf8) {
                    Assert.That(expected.MoveNext(), Is.True);
                    Assert.That(c, Is.EqualTo(expected.Current));
                }
            }
        }
    }
}
