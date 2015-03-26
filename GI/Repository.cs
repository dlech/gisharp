using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace GI
{
  public partial class Repository
  {
    public const string BuiltIn = "<builtin>";

    NamespaceCollection namespaces;

    internal InfoCollection<BaseInfo> GetInfos (string @namespace)
    {
      return new InfoCollection<BaseInfo> (() => GetNInfos (@namespace), (i) => GetInfo (@namespace, i));
    }

    public NamespaceCollection Namespaces {
      get {
        if (namespaces == null)
          namespaces = new NamespaceCollection (this);
        return namespaces;
      }
    }
  }
}

