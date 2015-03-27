using System;
using System.Dynamic;
using System.Reflection;
using System.Linq;

using GISharp.GI;

namespace gtkdemo
{
  public class DynamicGObject : DynamicObject
  {
    static Lazy<MethodInfo> GetPropertyMethod;

    ObjectInfo info;
    GLib.Object obj;

    static DynamicGObject () {
      GetPropertyMethod = new Lazy<MethodInfo> (() =>
        typeof(GLib.Object).GetMethod ("GetProperty",
          BindingFlags.Instance | BindingFlags.NonPublic));
    }

    public DynamicGObject (ObjectInfo info, GLib.Object obj)
    {
      if (info == null)
        throw new ArgumentNullException ("info");
      if (obj == null)
        throw new ArgumentNullException ("obj");
      this.info = info;
      this.obj = obj;
    }

    public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames ()
    {
      foreach (var constant in info.Constants)
        yield return constant.Name;
      foreach (var field in info.Fields)
        yield return field.Name;
      foreach (var method in info.Methods)
        yield return method.Name;
      foreach (var property in info.Properties)
        yield return property.Name;
      foreach (var signal in info.Signals)
        yield return signal.Name;
      foreach (var vfunc in info.VFuncs)
        yield return vfunc.Name;
    }

    public override bool TryGetMember (GetMemberBinder binder, out object result)
    {
      try {
        result = GetPropertyMethod.Value.Invoke (obj, new [] { binder.Name });
        return true;
      } catch (Exception) {
        result = null;
        return false;
      }
    }

    public override bool TryInvokeMember (InvokeMemberBinder binder, object[] args, out object result)
    {
      foreach (var name in binder.CallInfo.ArgumentNames)
        Console.WriteLine (name);
      var current = info;
      while (current != null) {
        var method = current.FindMethod (binder.Name);
        if (method != null) {
          Argument resultValue;
          var inArgs = new Argument[args.Length + (method.IsMethod ? 1 : 0)];
          if (method.IsMethod)
            inArgs [0].Pointer = obj.Handle;
          method.Invoke (inArgs, null, out resultValue);
          result = resultValue;
          return true;
        }
        current = current.Parent;
      }
      result = null;
      return false;
    }
  }
}
