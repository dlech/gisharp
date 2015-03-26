using System;
using System.Collections.Generic;
using System.Linq;

namespace GI.Browser
{
  public class RepositoryManager
  {
    static Repository repo;

    static RepositoryManager () {
      repo = Repository.Default;
    }
      
    public IEnumerable<string[]> Namespaces {
      get {
        return repo.Namespaces.Select ((n) => new [] { n.Name, n.Version });
      }
    }

    [GLib.Signal ("typelib-loaded")]
    public event EventHandler TypelibLoaded;

    public RepositoryManager ()
    {
    }

    public void LoadTypelib (string @namespace, string version) {
      repo.Require (@namespace, version, (RepositoryLoadFlags)0);
      if (TypelibLoaded != null)
        TypelibLoaded (this, new EventArgs ());
    }

    public IEnumerable<string[]> GetInfos (string @namespace, InfoType infoType) {
      return repo.Namespaces [@namespace].Infos
        .Where ((i) => i.InfoType == infoType)
        .Select ((i) => new [] { i.Name });
    }
  }
}

