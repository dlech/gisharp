using System;
using System.Collections.Generic;
using System.Linq;

namespace GI.Browser
{
  public class RepositoryManager
  {
    public IEnumerable<string[]> Namespaces {
      get {
        return Repository.Namespaces.Select ((n) => new [] { n.Name, n.Version });
      }
    }

    [GLib.Signal ("typelib-loaded")]
    public event EventHandler TypelibLoaded;

    public RepositoryManager ()
    {
    }

    public void LoadTypelib (string @namespace, string version) {
      Repository.Require (@namespace, version);
      if (TypelibLoaded != null)
        TypelibLoaded (this, new EventArgs ());
    }

    public IEnumerable<string[]> GetInfos (string @namespace, InfoType infoType) {
      return Repository.Namespaces [@namespace].Infos
        .Where ((i) => i.InfoType == infoType)
        .Select ((i) => new [] { i.Name });
    }
  }
}

