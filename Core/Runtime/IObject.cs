
using GISharp.GObject;

namespace GISharp.Runtime
{
    /// <summary>
    /// This should only be used as a base type on the GObject.Object class.
    /// It is used by GType interfaces to make sure they are only applied to
    /// GType objects.
    /// </summary>
    public interface IObject
    {
        Object.SafeHandle Handle { get; }
    }
}
