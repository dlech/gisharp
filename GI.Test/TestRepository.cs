using NUnit.Framework;
using System;
using System.Linq;

namespace GI
{
  [TestFixture ()]
  public class TestRepository
  {
    Repository repository;
    Typelib GioTypeLib;

    [TestFixtureSetUp ()]
    public void TestGetDefault ()
    {
      // The default repository is process global, so we must initalize it only once.
      // It will be used all of the tests
      repository = Repository.Default;
      Assert.That (repository, Is.Not.Null);
      // Many test require that a namespace is already loaded.
      GioTypeLib = repository.Require ("Gio", "2.0", (RepositoryLoadFlags)0);
    }

    [Test ()]
    public void TestGetDependencies ()
    {
      var deps = repository.Namespaces["Gio"].Dependencies;
      Assert.That (deps, Is.EqualTo (new []{ "GObject-2.0" }));
    }

    [Test ()]
    public void TestGetLoadedNamespaces ()
    {
      var namespaces = repository.LoadedNamespaces;
      Assert.That (namespaces, Is.EqualTo (new []{ "GLib", "GObject", "Gio" }));
    }

    [Test ()]
    public void TestGetInfos ()
    {
      int count = 0;
      foreach (var info in repository.Namespaces["Gio"].Infos) {
        // make sure all infos are the proper subclass and not base
        Assert.That (info.GetType(), Is.Not.EqualTo (typeof(BaseInfo)));
        count++;
      }
      Assert.That (count, Is.GreaterThan (0));
    }

    [Test ()]
    public void TestGetOptionGroup ()
    {
      var group = Repository.OptionGroup;
      Assert.That (group, Is.Not.Null);
    }

    [Test ()]
    public void TestEnumerateVersions ()
    {
      var versions = repository.Namespaces["Gio"].Versions;
      Assert.That (versions, Is.EqualTo (new [] { "2.0", "2.0" }));
    }

    [Test ()]
    public void TestPrependLibraryPath ()
    {
      Repository.PrependLibraryPath ("dummy");
      // TODO: figure out how to verify this.
    }

    [Test ()]
    public void TestPrependSearchPathAndGetSearchPath ()
    {
      var startPath = Repository.SearchPath;
      Assert.That (startPath, Is.Not.Member ("dummy"));
      Repository.PrependSearchPath ("dummy");
      var endPath = Repository.SearchPath;
      Assert.That (endPath, Contains.Item ("dummy"));
    }

    [Test ()]
    public void TestLoadTypelib ()
    {
      var name = repository.LoadTypelib (GioTypeLib, (RepositoryLoadFlags)0);
      Assert.That (name, Is.EqualTo ("Gio"));
      // TODO: create our own typelib and load it.
    }

    [Test ()]
    public void TestGetTypelibPath ()
    {
      var path = repository.Namespaces["Gio"].TypelibPath;
      Assert.That (path, Is.EqualTo ("/usr/lib/girepository-1.0/Gio-2.0.typelib"));
    }

    [Test ()]
    public void TestIsRegistered ()
    {
      var registered = repository.IsRegistered ("Gio", "2.0");
      Assert.That (registered, Is.True);

      registered = repository.IsRegistered ("DoesNotExist", "9.9");
      Assert.That (registered, Is.False);
    }

    [Test ()]
    public void TestRequire ()
    {
      // We already know that this works because it is used in the setup function
      // so let's just test that it fails.
      TestDelegate require = () =>
        repository.Require ("DoesNotExist", "9.9", (RepositoryLoadFlags)0);
      Assert.That (require, Throws.Exception.TypeOf<GLib.GException> ()
        .With.Property ("Domain").EqualTo (Repository.ErrorDomain)
        .And.Property ("Code").EqualTo ((int)RepositoryError.TypelibNotFound));
    }

    [Test ()]
    public void TestRequirePrivate ()
    {
      TestDelegate require = () =>
        repository.RequirePrivate ("NonExistentDir", "DoesNotExist", "9.9", (RepositoryLoadFlags)0);
      Assert.That (require, Throws.Exception.TypeOf<GLib.GException> ()
        .With.Property ("Domain").EqualTo (Repository.ErrorDomain)
        .And.Property ("Code").EqualTo ((int)RepositoryError.TypelibNotFound));
    }

    [Test ()]
    public void TestGetCPrefix ()
    {
      var prefix = repository.Namespaces["Gio"].CPrefix;
      Assert.That (prefix, Is.EqualTo ("G"));
    }

    [Test ()]
    public void TestGetSharedLibrary ()
    {
      var library = repository.Namespaces["Gio"].SharedLibraries;
      Assert.That (library, Is.EqualTo (new [] { "libgio-2.0.so.0" }));
    }

    [Test ()]
    public void TestGetVersion ()
    {
      var version = repository.Namespaces["Gio"].Version;
      Assert.That (version, Is.EqualTo ("2.0"));
    }

    [Test ()]
    public void TestFindByGType ()
    {
      var info = repository.FindByGType (GLib.GType.Object);
      Assert.That (info, Is.TypeOf<ObjectInfo> ());
    }

    [System.Runtime.InteropServices.DllImport ("libgio-2.0.dll")]
    static extern int g_io_error_quark ();

    [Test ()]
    public void TestFindByErrorDomain ()
    {
      var info = repository.FindByErrorDomain (g_io_error_quark ());
      Assert.That (info, Is.TypeOf<EnumInfo> ());
    }

    [Test ()]
    public void TestFindByName ()
    {
      var info = repository.Namespaces["Gio"].FindByName ("IOErrorEnum");
      Assert.That (info, Is.TypeOf<EnumInfo> ());
    }

    [Test ()]
    public void TestDump ()
    {
      TestDelegate dump = () => Repository.Dump ("NonExistentFile");
      Assert.That (dump, Throws.Exception.TypeOf<GLib.GException> ()
        .With.Property ("Domain").EqualTo (g_io_error_quark ())
        .And.Property ("Code").EqualTo ((int)GLib.IOErrorEnum.NotFound));
    }
  }
}

