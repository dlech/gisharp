using System;
using System.Runtime.InteropServices;

namespace GI
{
  public partial class MappedFile
  {
    public byte[] Bytes {
      get {
        var bytes = new byte[Length];
        Marshal.Copy (Contents, bytes, 0, (int)Length);
        return bytes;
      }
    }
  }
}

