using System;
using System.Reflection;

namespace GISharp.Runtime
{
  public static class Marshal
  {
    public static T PtrToOpaque<T> (IntPtr handle, bool ownsHandle) where T : Opaque<T>
    {
      if (handle == IntPtr.Zero) {
        return null;
      }
      return Activator.CreateInstance (typeof(T), BindingFlags.NonPublic, null,
        new object[] { handle, ownsHandle }, null) as T;
    }
  }
}

