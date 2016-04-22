using System;

using GISharp.Runtime;

namespace GISharp.GI
{
    public interface IMethodContainer
    {
        IndexedCollection<FunctionInfo> Methods { get; }
    }
}
