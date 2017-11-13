using System;
using System.Linq;

using FluentAssertions;
using Xunit;

using GISharp.Runtime;
using GISharp.GLib;

namespace GISharp.GIRepository.Test
{
    public class TestRepository
    {
        public TestRepository ()
        {
            // Many test require that a namespace is already loaded.
            Repository.Require ("Gio", "2.0");
        }

        [Fact]
        public void TestGetDependencies ()
        {
            var deps = Repository.Namespaces ["Gio"].Dependencies;
            deps.Should ().Contain ("GObject-2.0" );
        }

        [Fact]
        public void TestGetImmediateDependencies ()
        {
            var deps = Repository.Namespaces ["Gio"].ImmediateDependencies;
            deps.Should ().Contain ("GObject-2.0" );
        }

        [Fact]
        public void TestGetLoadedNamespaces ()
        {
            var namespaces = Repository.LoadedNamespaces;
            namespaces.ShouldBeEquivalentTo (new []{ "GLib", "GObject", "Gio" });
        }

        [Fact]
        public void TestGetInfos ()
        {
            int count = 0;
            foreach (var info in Repository.Namespaces["Gio"].Infos) {
                // make sure all infos are the proper subclass and not base
                info.GetType ().Should ().NotBe (typeof(BaseInfo));
                count++;
            }
            count.Should ().BeGreaterThan (0);
        }

        [Fact]
        public void TestEnumerateVersions ()
        {
            var versions = Repository.Namespaces ["Gio"].Versions;
            versions.ShouldBeEquivalentTo (new [] { "2.0", "2.0" });
        }

        [Fact]
        public void TestPrependLibraryPath ()
        {
            Repository.PrependLibraryPath ("dummy");
            // TODO: figure out how to verify this.
        }

        [Fact]
        public void TestPrependSearchPathAndGetSearchPath ()
        {
            Repository.SearchPaths.Should ().NotContain ("dummy");
            Repository.PrependSearchPath ("dummy");
            Repository.SearchPaths.Should ().Contain ("dummy");
        }

        [Fact]
        public void TestGetTypelibPath ()
        {
            var path = Repository.Namespaces ["Gio"].TypelibPath;
            path.Should ().EndWith ("Gio-2.0.typelib");
        }

        [Fact]
        public void TestIsRegistered ()
        {
            var registered = Repository.IsRegistered ("Gio", "2.0");
            registered.Should ().BeTrue ();

            registered = Repository.IsRegistered ("DoesNotExist", "9.9");
            registered.Should ().BeFalse ();
        }

        [Fact]
        public void TestRequire ()
        {
            // We already know that this works because it is used in the setup function
            // so let's just test that it fails.
            Action require = () =>
                Repository.Require ("DoesNotExist", "9.9");
            var excpetion = Assert.Throws<GErrorException> (require);
            Assert.True (excpetion.Matches (RepositoryError.TypelibNotFound));
        }

        [Fact]
        public void TestRequirePrivate ()
        {
            Action require = () =>
                Repository.RequirePrivate ("NonExistentDir", "DoesNotExist", "9.9");
            var exception = Assert.Throws<GErrorException> (require);
            Assert.True (exception.Matches (RepositoryError.TypelibNotFound));
        }

        [Fact]
        public void TestGetCPrefix ()
        {
            var prefix = Repository.Namespaces ["Gio"].CPrefix;
            prefix.Should ().Be ("G");
        }

        [Fact (Skip = "This is not the same on all installs.")]
        public void TestGetSharedLibrary ()
        {
            var library = Repository.Namespaces ["Gio"].SharedLibraries;
            library.ShouldBeEquivalentTo (new [] { "libgio-2.0.so.0" });
        }

        [Fact]
        public void TestGetVersion ()
        {
            var version = Repository.Namespaces ["Gio"].Version;
            version.Should ().Be ("2.0");
        }

        [System.Runtime.InteropServices.DllImport ("libgio-2.0")]
        static extern Quark g_io_error_quark ();

        const int G_IO_ERROR_NOT_FOUND = 1;

        [Fact]
        public void TestFindByErrorDomain ()
        {
            using (var info = Repository.FindByErrorDomain (g_io_error_quark ())) {
                info.Should ().BeOfType<EnumInfo> ();
            }
        }

        [Fact]
        public void TestFindByName ()
        {
            using (var info = Repository.Namespaces ["Gio"].FindByName ("IOErrorEnum")) {
                info.Should ().BeOfType<EnumInfo> ();
            }
        }

        [Fact]
        public void TestDump ()
        {
            Action dump = () => Repository.Dump ("NonExistentFile");
            dump.ShouldThrow<GErrorException> ().
                Where (e => e.Error.Domain == g_io_error_quark ()
                         && e.Error.Code == G_IO_ERROR_NOT_FOUND);
        }
    }
}
