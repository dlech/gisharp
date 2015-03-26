using System;
using System.Collections.Generic;

namespace GI
{
  public partial class UnionInfo : IMethodContainer
  {
    InfoCollection<FieldInfo> fields;
    public InfoCollection<FieldInfo> Fields
    {
      get {
        if (fields == null) {
          fields = new InfoCollection<FieldInfo> (() => NFields, GetField);
        }
        return fields;
      }
    }

    InfoCollection<FunctionInfo> methods;
    public InfoCollection<FunctionInfo> Methods
    {
      get {
        if (methods == null) {
          methods = new InfoCollection<FunctionInfo> (() => NMethods, GetMethod);
        }
        return methods;
      }
    }
  }
}

