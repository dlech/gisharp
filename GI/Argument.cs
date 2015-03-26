using System;

namespace GI
{
  public partial struct Argument
  {
    public IntPtr Pointer {
      get { return _v_pointer; }
      set { _v_pointer = value; }
    }

    public string String {
      get {
        return GLib.Marshaller.Utf8PtrToString (_v_string);
      }
      set {
        var oldString = _v_string;
        _v_string = GLib.Marshaller.StringToPtrGStrdup (value);
        GLib.Marshaller.Free (oldString);
      }
    }
  }
}

