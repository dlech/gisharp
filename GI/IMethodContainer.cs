using System;

using GISharp.Core;

namespace GISharp.GI
{
    public interface IMethodContainer
    {
        IndexedCollection<FunctionInfo> Methods { get; }
    }
}
