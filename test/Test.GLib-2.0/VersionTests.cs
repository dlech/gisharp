using NUnit.Framework;
using System;
using System.Reflection;

using GISharp.Lib.GLib;
using Version = GISharp.Lib.GLib.Version;

namespace GISharp.Test.GLib
{
    [TestFixture]
    public class VersionTests
    {
        [Test, Ignore ("This depends on the system we are running on")]
        public void TestCompileTime ()
        {
            // This is a bit of a backwards test since it is actually verifying
            // that the assembly version is correct.
            var assembly = Assembly.GetAssembly(typeof(Version))!;
            var assemblyVersion = assembly.GetName().Version!;
            Assert.That (Version.CompileTime.Major, Is.EqualTo (assemblyVersion.Major));
            Assert.That (Version.CompileTime.Minor, Is.EqualTo (assemblyVersion.Minor));
        }

        [Test, Ignore ("This depends on the system we a running on")]
        public void TestRuntimeTime ()
        {
            // This is a bit of a backwards test since it is actually verifying
            // that the assembly version is correct.
            var assembly = Assembly.GetAssembly(typeof(Version))!;
            var assemblyVersion = assembly.GetName().Version!;
            Assert.That (Version.RunTime.Major, Is.EqualTo (assemblyVersion.Major));
            Assert.That (Version.RunTime.Minor, Is.EqualTo (assemblyVersion.Minor));
        }

        [Test]
        public void TestCheck()
        {
            var actual = Version.Check (
                (uint)Version.CompileTime.Major,
                (uint)Version.CompileTime.Minor,
                (uint)Version.CompileTime.Revision);
            // null means version is OK
            Assert.That<string?>(actual, Is.Null);

            actual = Version.Check(0, 0, 0);
            Assert.That<string?>(actual, Is.Not.Null);
        }
    }
}
