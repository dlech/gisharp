using System;
using System.Collections.Generic;
using System.Linq;

namespace GI
{
  public class NamespaceCollection : IEnumerable<Namespace>
  {
    Dictionary<string, Namespace> namespaceMap;
    Repository repository;

    internal NamespaceCollection (Repository repository)
    {
      if (repository == null)
        throw new ArgumentNullException ("repository");

      namespaceMap = new Dictionary<string, Namespace> ();
      this.repository = repository;
    }

    Namespace EnsureNamespace (string @namespace) {
      if (!namespaceMap.ContainsKey (@namespace)) {
        namespaceMap [@namespace] = new Namespace (repository, @namespace);
      }
      return namespaceMap [@namespace];
    }

    public Namespace this [int index] {
      get {
        return EnsureNamespace (repository.LoadedNamespaces [index]);
      }
    }

    public Namespace this [string @namespace] {
      get {
        return EnsureNamespace (@namespace);
      }
    }

    #region IEnumerable implementation
    public IEnumerator<Namespace> GetEnumerator ()
    {
      foreach (var @namespace in repository.LoadedNamespaces) {
        yield return EnsureNamespace (@namespace);
      }
    }
    #endregion
    #region IEnumerable implementation
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
    {
      return GetEnumerator ();
    }
    #endregion
  }
}

