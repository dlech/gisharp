using System;
using System.Collections.Generic;

namespace GI
{
  public partial class CallableInfo
  {
    InfoCollection<ArgInfo> args;
    public InfoCollection<ArgInfo> Args
    {
      get {
        if (args == null) {
          args = new InfoCollection<ArgInfo> (() => NArgs, GetArg);
        }
        return args;
      }
    }
  }
}

