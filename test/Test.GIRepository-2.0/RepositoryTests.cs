// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GIRepository;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.GIRepository
{
    public class RepositoryTests
    {
        [OneTimeSetUp]
        public void TestGetDefault()
        {
            // Many test require that a namespace is already loaded.
            Repository.Default.Require("Gio", "2.0");
        }

        [Test]
        public void TestGetDependencies()
        {
            using var deps = Repository.Default.GetDependencies("Gio");
            Assert.That(deps, Contains.Item("GObject-2.0"));
        }

        [Test]
        public void TestGetImmediateDependencies()
        {
            using var deps = Repository.Default.GetImmediateDependencies("Gio");
            Assert.That(deps, Contains.Item("GObject-2.0"));
        }

        [Test]
        public void TestGetLoadedNamespaces()
        {
            using var namespaces = Repository.Default.LoadedNamespaces;
            Assert.That(namespaces.Length, Is.EqualTo(3));
            Assert.That(namespaces, Contains.Item("GLib"));
            Assert.That(namespaces, Contains.Item("GObject"));
            Assert.That(namespaces, Contains.Item("Gio"));
        }

        [Test]
        public void TestGetInfos()
        {
            int count = 0;
            foreach (var info in Repository.Default.GetInfos("Gio")) {
                // make sure all infos are the proper subclass and not base
                Assert.That(info.GetType(), Is.Not.EqualTo(typeof(BaseInfo)));
                count++;
            }
            Assert.That(count, Is.GreaterThan(0));
        }

        [Test]
        public void TestEnumerateVersions()
        {
            using var versions = Repository.Default.EnumerateVersions("Gio");
            Assert.That(versions, Is.EqualTo(new[] { "2.0", "2.0" }));
        }

        [Test]
        public void TestPrependLibraryPath()
        {
            Repository.PrependLibraryPath("dummy");
            // TODO: figure out how to verify this.
        }

        [Test]
        public void TestPrependSearchPathAndGetSearchPath()
        {
            using var dummy = (Filename)"dummy";
            var startPath = Repository.SearchPath;
            Assert.That(startPath, Is.Not.Member(dummy));
            Repository.PrependSearchPath(dummy);
            var endPath = Repository.SearchPath;
            Assert.That(endPath, Contains.Item(dummy));
        }

        [Test]
        public void TestGetTypelibPath()
        {
            var path = Repository.Default.GetTypelibPath("Gio");
            Assert.That<string?>(path, Contains.Substring("Gio-2.0.typelib"));
        }

        [Test]
        public void TestIsRegistered()
        {
            var registered = Repository.Default.IsRegistered("Gio", "2.0");
            Assert.That(registered, Is.True);

            registered = Repository.Default.IsRegistered("DoesNotExist", "9.9");
            Assert.That(registered, Is.False);
        }

        [Test]
        public void TestRequire()
        {
            // We already know that this works because it is used in the setup function
            // so let's just test that it fails.
            static void require() =>
                Repository.Default.Require("DoesNotExist", "9.9");
            var exception = Assert.Throws<Error.Exception>(require)!;
            Assert.True(exception.Matches(RepositoryError.TypelibNotFound));
        }

        [Test]
        public void TestRequirePrivate()
        {
            static void require() =>
                Repository.Default.RequirePrivate("NonExistentDir", "DoesNotExist", "9.9");
            var exception = Assert.Throws<Error.Exception>(require)!;
            Assert.True(exception.Matches(RepositoryError.TypelibNotFound));
        }

        [Test]
        public void TestGetCPrefix()
        {
            var prefix = Repository.Default.GetCPrefix("Gio");
            Assert.That<string?>(prefix, Is.EqualTo("G"));
        }

        [Test]
        [Ignore("This is not the same on all installs.")]
        public void TestGetSharedLibrary()
        {
            var library = Repository.Default.GetSharedLibrary("Gio");
            Assert.That<string?>(library, Is.EqualTo("libgio-2.0.so.0"));
        }

        [Test]
        public void TestGetVersion()
        {
            var version = Repository.Default.GetVersion("Gio");
            Assert.That<string>(version, Is.EqualTo("2.0"));
        }

        [System.Runtime.InteropServices.DllImport("libgio-2.0")]
        static extern Quark g_io_error_quark();

        const int G_IO_ERROR_NOT_FOUND = 1;

        [Test]
        public void TestFindByErrorDomain()
        {
            using var info = Repository.Default.FindByErrorDomain(g_io_error_quark());
            Assert.That(info, Is.TypeOf<EnumInfo>());
        }

        [Test]
        public void TestFindByName()
        {
            using var info = Repository.Default.FindByName("Gio", "IOErrorEnum");
            Assert.That(info, Is.TypeOf<EnumInfo>());
        }

        [Test]
        public void TestDump()
        {
            static void dump() => Repository.Dump("NonExistentFile");
            var exception = Assert.Throws<Error.Exception>(dump)!;
            Assert.That(exception.Error.Domain, Is.EqualTo(g_io_error_quark()));
            Assert.That(exception.Error.Code, Is.EqualTo(G_IO_ERROR_NOT_FOUND));
        }
    }
}
