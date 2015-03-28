using System;

namespace GISharp.Core
{
  /// <summary>
  /// Base class for wrapping opaque unmanaged GLib struts.
  /// </summary>
  public abstract class Opaque<T> : INativeObject, IDisposable where T : Opaque<T>
  {
    bool freeOnDispose;
    bool isDisposed;

    /// <summary>
    /// Gets the pointer to the unmanaged GLib struct.
    /// </summary>
    /// <value>The pointer.</value>
    public IntPtr Handle { get; protected set; }

    // dummy default constructor for now
    protected Opaque ()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Opaque"/> class.
    /// </summary>
    /// <param name="handle">Pointer to the unmanage GLib struct.</param>
    /// <param name="ownsHandle">Should be set to true if the type is reference counted
    /// and we already own a reference or if the type has a free function and it should
    /// be freed when the managed object is disposed. If set to false a reference will
    /// be taken for referenced counted types and types will a free function will not
    /// be freed when the managed object is disposed.</param>
    protected Opaque (IntPtr handle, bool ownsHandle)
    {
      Handle = handle;
      if (ownsHandle) {
        freeOnDispose = true;
      } else if (handle != IntPtr.Zero) {
        Ref ();
      }
    }

    ~Opaque ()
    {
      Dispose (false);
    }

    /// <summary>
    /// Releases all resource used by the <see cref="Opaque"/> object.
    /// </summary>
    /// <remarks>
    /// Call <see cref="Dispose"/> when you are finished using the <see cref="Opaque"/>. The <see cref="Dispose"/>
    /// method leaves the <see cref="Opaque"/> in an unusable state. After calling <see cref="Dispose"/>, you must
    /// release all references to the <see cref="Opaque"/> so the garbage collector can reclaim the memory that the
    /// <see cref="Opaque"/> was occupying.
    ///
    /// For reference counted unmanaged types, the unmanged object will be unrefed.
    /// If the unmanaged object has a free function and we owned the object, the
    /// unmanaged object will be freed.
    /// </remarks>
    public void Dispose ()
    {
      Dispose (true);
      GC.SuppressFinalize (this);
    }

    protected virtual void Dispose (bool disposing)
    {
      if (isDisposed) {
        return;
      }
      isDisposed = true;
      if (Handle != IntPtr.Zero) {
        Unref ();
        if (freeOnDispose) {
          Free ();
        }
        Handle = IntPtr.Zero;
      }
    }

    /// <summary>
    /// Assert that the object has not been disposed.
    /// </summary>
    /// <exception cref="ObjectDisposedException">Thrown if this object has already been disposed.</exception>
    /// <remarks>
    /// All public methods should call this so we don't operate on a disposed object.
    /// </remarks>
    protected void AssertNotDisposed ()
    {
      if (isDisposed) {
        throw new ObjectDisposedException (GetType ().Name);
      }
    }

    /// <summary>
    /// Inrease the reference count of a reference counted object.
    /// </summary>
    /// <remarks>
    /// Types that are reference counted must override this method.
    /// Has no effect for other types.
    /// </remarks>
    protected virtual T Ref ()
    {
      return (T)this;
    }

    /// <summary>
    /// Decrease the reference count of a reference counted object.
    /// </summary>
    /// <remarks>
    /// Types that are reference counted must override this method.
    /// Has no effect for other types.
    /// </remarks>
    protected virtual void Unref ()
    {
    }

    protected virtual T Copy ()
    {
      AssertNotDisposed ();
      return (T)this;
    }

    /// <summary>
    /// Free the specified handle.
    /// </summary>
    /// <remarks>
    /// Opaque types with a free function should override this.
    /// Has no effect for other types.
    /// </remarks>
    protected virtual void Free ()
    {
    }

    public override bool Equals (object obj)
    {
      var otherOpaque = obj as Opaque<T>;
      if (otherOpaque != null) {
        return this.Handle == otherOpaque.Handle;
      }
      return false;
    }

    public override int GetHashCode ()
    {
      return Handle.GetHashCode ();
    }
  }
}
