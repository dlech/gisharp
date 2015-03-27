using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.GI
{
    public class NamespaceCollection : IEnumerable<Namespace>
    {
        Dictionary<string, Namespace> namespaceMap;

        internal NamespaceCollection ()
        {
            namespaceMap = new Dictionary<string, Namespace> ();
        }

        Namespace EnsureNamespace (string @namespace)
        {
            if (!namespaceMap.ContainsKey (@namespace)) {
                namespaceMap [@namespace] = new Namespace (@namespace);
            }
            return namespaceMap [@namespace];
        }

        public Namespace this [int index] {
            get {
                return EnsureNamespace (Repository.LoadedNamespaces [index]);
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
            foreach (var @namespace in Repository.LoadedNamespaces) {
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

