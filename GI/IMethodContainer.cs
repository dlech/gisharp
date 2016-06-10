
namespace GISharp.GIRepository
{
    /// <summary>
    /// Method container.
    /// </summary>
    /// <remarks>
    /// Used on subclasses of <see cref="RegisteredTypeInfo"/> that have methods.
    /// </remarks>
    public interface IMethodContainer
    {
        InfoDictionary<FunctionInfo> Methods { get; }
    }
}
