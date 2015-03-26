using System;

namespace GI
{
  public partial class FunctionInfo
  {
    public bool IsConstructor {
      get {
        return Flags.HasFlag (FunctionInfoFlags.IsConstructor);
      }
    }

    public bool IsGetter {
      get {
        return Flags.HasFlag (FunctionInfoFlags.IsGetter);
      }
    }

    public bool IsSetter {
      get {
        return Flags.HasFlag (FunctionInfoFlags.IsSetter);
      }
    }

    public bool Throws {
      get {
        return Flags.HasFlag (FunctionInfoFlags.Throws);
      }
    }

    public bool WrapsVfunc {
      get {
        return Flags.HasFlag (FunctionInfoFlags.WrapsVfunc);
      }
    }
  }
}

