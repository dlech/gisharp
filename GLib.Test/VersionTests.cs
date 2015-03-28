using NUnit.Framework;
using System;
using System.Reflection;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture ()]
    public class VersionTests
    {
        [Test ()]
        public void TestVersion ()
        {
            // This is a bit of a backwards test since it is actually verifying
            // that the assembly version is correct.
            var assembly = Assembly.GetAssembly (typeof (GLib.Version));
            var assemblyVersion = assembly.GetName ().Version;
            Assert.That (Version.Current.Major, Is.EqualTo (assemblyVersion.Major));
            Assert.That (Version.Current.MajorRevision, Is.EqualTo (assemblyVersion.MajorRevision));
        }

        [Test ()]
        public void TestCheck ()
        {
            string actual;
            actual = Version.Check ((uint)Version.Current.Major,
                (uint)Version.Current.MajorRevision, (uint)Version.Current.Minor);
            // null means version is OK
            Assert.That (actual, Is.Null);

            actual = Version.Check (0, 0, 0);
            Assert.That (actual, Is.Not.Null);
        }
    }
}
