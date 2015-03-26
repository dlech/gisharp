using System;
using System.Collections.Generic;

namespace GI
{
  public partial class EnumInfo : IMethodContainer
  {
    InfoCollection<ValueInfo> values;
    public InfoCollection<ValueInfo> Values {
      get {
        if (values == null) {
          values = new InfoCollection<ValueInfo> (() => NValues, GetValue);
        }
        return values;
      }
    }

    InfoCollection<FunctionInfo> methods;
    public InfoCollection<FunctionInfo> Methods {
      get {
        if (methods == null) {
          methods = new InfoCollection<FunctionInfo> (() => NMethods, GetMethod);
        }
        return methods;
      }
    }
  }
}
