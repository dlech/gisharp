using System;

namespace GISharp.Runtime
{
  /// <summary>
  /// Managed objects that wrap a unmanaged GLib struct must implement this.
  /// </summary>
  public interface INativeObject
  {
    /// <summary>
    /// Gets the pointer to the unmanaged GLib struct.
    /// </summary>
    /// <value>The pointer.</value>
    IntPtr Handle { get; }
  }
}
