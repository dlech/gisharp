using System;

using GISharp.Runtime;

namespace GISharp.GI
{
    public interface IMethodContainer
    {
        InfoDictionary<FunctionInfo> Methods { get; }
    }
}
