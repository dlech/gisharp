using System;
using System.Linq;

using NUnit.Framework;

using GISharp.Runtime;
using GISharp.Lib.GLib;
using GISharp.Lib.GIRepository;

namespace GISharp.Test.GIRepository
{
    [TestFixture]
    public class TestRepository
    {
        [OneTimeSetUp]
        public void TestGetDefault ()
        {
            // Many test require that a namespace is already loaded.
            Repository.Require ("Gio", "2.0");
        }

        [Test]
        public void TestGetDependencies ()
        {
            var deps = Repository.Namespaces ["Gio"].Dependencies;
            Assert.That (deps, Contains.Item ("GObject-2.0"));
        }

        [Test]
        public void TestGetImmediateDependencies ()
        {
            var deps = Repository.Namespaces ["Gio"].ImmediateDependencies;
            Assert.That (deps, Contains.Item ("GObject-2.0"));
        }

        [Test]
        public void TestGetLoadedNamespaces ()
        {
            var namespaces = Repository.LoadedNamespaces;
            Assert.That (namespaces, Is.EqualTo (new []{ "GLib", "GObject", "Gio" }));
        }

        [Test]
        public void TestGetInfos ()
        {
            int count = 0;
            foreach (var info in Repository.Namespaces["Gio"].Infos) {
                // make sure all infos are the proper subclass and not base
                Assert.That (info.GetType (), Is.Not.EqualTo (typeof(BaseInfo)));
                count++;
            }
            Assert.That (count, Is.GreaterThan (0));
        }

        [Test]
        public void TestEnumerateVersions ()
        {
            var versions = Repository.Namespaces ["Gio"].Versions;
            Assert.That (versions, Is.EqualTo (new [] { "2.0", "2.0" }));
        }

        [Test]
        public void TestPrependLibraryPath ()
        {
            Repository.PrependLibraryPath ("dummy");
            // TODO: figure out how to verify this.
        }

        [Test]
        public void TestPrependSearchPathAndGetSearchPath ()
        {
            var startPath = Repository.SearchPaths;
            Assert.That (startPath, Is.Not.Member ("dummy"));
            Repository.PrependSearchPath ("dummy");
            var endPath = Repository.SearchPaths;
            Assert.That (endPath, Contains.Item ("dummy"));
        }

        [Test]
        public void TestGetTypelibPath ()
        {
            var path = Repository.Namespaces ["Gio"].TypelibPath;
            Assert.That<string?>(path, Contains.Substring("Gio-2.0.typelib"));
        }

        [Test]
        public void TestIsRegistered ()
        {
            var registered = Repository.IsRegistered ("Gio", "2.0");
            Assert.That (registered, Is.True);

            registered = Repository.IsRegistered ("DoesNotExist", "9.9");
            Assert.That (registered, Is.False);
        }

        [Test]
        public void TestRequire ()
        {
            // We already know that this works because it is used in the setup function
            // so let's just test that it fails.
            TestDelegate require = () =>
                Repository.Require ("DoesNotExist", "9.9");
            var exception = Assert.Throws<GErrorException> (require);
            Assert.True (exception.Matches (RepositoryError.TypelibNotFound));
        }

        [Test]
        public void TestRequirePrivate ()
        {
            TestDelegate require = () =>
                Repository.RequirePrivate ("NonExistentDir", "DoesNotExist", "9.9");
            var exception = Assert.Throws<GErrorException> (require);
            Assert.True (exception.Matches (RepositoryError.TypelibNotFound));
        }

        [Test]
        public void TestGetCPrefix ()
        {
            var prefix = Repository.Namespaces ["Gio"].CPrefix;
            Assert.That<string?>(prefix, Is.EqualTo("G"));
        }

        [Test]
        [Ignore ("This is not the same on all installs.")]
        public void TestGetSharedLibrary ()
        {
            var library = Repository.Namespaces ["Gio"].SharedLibraries;
            Assert.That (library, Is.EqualTo (new [] { "libgio-2.0.so.0" }));
        }

        [Test]
        public void TestGetVersion ()
        {
            var version = Repository.Namespaces ["Gio"].Version;
            Assert.That<string>(version, Is.EqualTo("2.0"));
        }

        [System.Runtime.InteropServices.DllImport ("libgio-2.0")]
        static extern Quark g_io_error_quark ();

        const int G_IO_ERROR_NOT_FOUND = 1;

        [Test]
        public void TestFindByErrorDomain ()
        {
            using (var info = Repository.FindByErrorDomain (g_io_error_quark ())) {
                Assert.That (info, Is.TypeOf<EnumInfo> ());
            }
        }

        [Test]
        public void TestFindByName ()
        {
            using (var info = Repository.Namespaces ["Gio"].FindByName ("IOErrorEnum")) {
                Assert.That (info, Is.TypeOf<EnumInfo> ());
            }
        }

        [Test]
        public void TestDump ()
        {
            TestDelegate dump = () => Repository.Dump ("NonExistentFile");
            var exception = Assert.Throws<GErrorException> (dump);
            Assert.That (exception.Error.Domain, Is.EqualTo (g_io_error_quark ()));
            Assert.That (exception.Error.Code, Is.EqualTo (G_IO_ERROR_NOT_FOUND));
        }
    }
}
