using System;

namespace GISharp.Core
{
    /// <summary>
    /// Static opaque wraps a struct that is not reference counted and cannot
    /// be freed or copied.
    /// </summary>
    public abstract class StaticOpaque : Opaque
    {
    }
}
