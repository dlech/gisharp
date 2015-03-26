using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GI
{
  [DebuggerDisplay("{Namespace}.{Name} ({InfoType})")]
  public partial class BaseInfo
  {
    internal static BaseInfo MarshalPtr (IntPtr raw)
    {
      if (raw == IntPtr.Zero)
        return null;
      Type type = typeof(BaseInfo);
      switch ((InfoType)g_base_info_get_type (raw)) {
      case InfoType.Arg:
        type = typeof(ArgInfo);
        break;
      case InfoType.Boxed:
        // TODO: could be struct or union
        type = typeof(StructInfo);
        break;
      case InfoType.Callback:
        type = typeof(CallbackInfo);
        break;
      case InfoType.Constant:
        type = typeof(ConstantInfo);
        break;
      case InfoType.Enum:
      case InfoType.Flags:
        type = typeof(EnumInfo);
        break;
      case InfoType.Field:
        type = typeof(FieldInfo);
        break;
      case InfoType.Function:
        type = typeof(FunctionInfo);
        break;
      case InfoType.Interface:
        type = typeof(InterfaceInfo);
        break;
      case InfoType.Object:
        type = typeof(ObjectInfo);
        break;
      case InfoType.Property:
        type = typeof(PropertyInfo);
        break;
      case InfoType.Signal:
        type = typeof(SignalInfo);
        break;
      case InfoType.Struct:
        type = typeof(StructInfo);
        break;
      case InfoType.Type:
        type = typeof(TypeInfo);
        break;
      case InfoType.Union:
        type = typeof(UnionInfo);
        break;
      case InfoType.Unresolved:
        type = typeof(UnresolvedInfo);
        break;
      case InfoType.Value:
        type = typeof(ValueInfo);
        break;
      case InfoType.VFunc:
        type = typeof(VFuncInfo);
        break;
      }
      return (GI.BaseInfo) GLib.Opaque.GetOpaque (raw, type, false);
    }

    public string Name {
      get {
        // calling g_base_info_get_name on a TypeInfo will cause a crash.
        var typeInfo = this as TypeInfo;
        if (typeInfo != null) {
          if (typeInfo.Tag == TypeTag.Interface) {
            return typeInfo.Interface.Name;
          }
          if (typeInfo.Tag == TypeTag.Array) {
            return typeInfo.ArrayType.ToString ();
          }
          if (typeInfo.Tag == TypeTag.Error) {
            return "Error";
          }
          return null;
        }
        return NameInternal;
      }
    }

    public override bool Equals (object o)
    {
      var baseInfo = o as BaseInfo;
      if (baseInfo != null) {
        return Equals (baseInfo);
      }
      return base.Equals (o);
    }

    public override int GetHashCode ()
    {
      return Handle.ToInt32 ();
    }

    public static bool operator == (BaseInfo info1, BaseInfo info2)
    {
      if ((object)info1 == null) {
        return (object)info2 == null;
      }
      if ((object)info2 == null) {
        return false;
      }
      return info1.Equals (info2);
    }

    public static bool operator != (BaseInfo info1, BaseInfo info2)
    {
      return !(info1 == info2);
    }

    public IEnumerable<KeyValuePair<string, string>> Attributes {
      get {
        AttributeIter iter = AttributeIter.Zero;
        string key, value;
        while (IterateAttributes (ref iter, out key, out value)) {
          yield return new KeyValuePair<string, string> (key, value);
        }
      }
    }
  }
}

