// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

﻿
using System.Collections.Generic;

namespace GISharp.Lib.GIRepository
{
    public sealed class NamespaceCollection : IEnumerable<Namespace>
    {
        Dictionary<string, Namespace> namespaceMap;

        internal NamespaceCollection ()
        {
            namespaceMap = new();
        }

        Namespace EnsureNamespace (string @namespace)
        {
            if (!namespaceMap.ContainsKey (@namespace)) {
                namespaceMap[@namespace] = new(@namespace);
            }
            return namespaceMap[@namespace];
        }

        public Namespace this[string @namespace] {
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

