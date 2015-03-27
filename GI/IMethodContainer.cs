using System;

namespace GISharp.GI
{
    public interface IMethodContainer
    {
        InfoCollection<FunctionInfo> Methods { get; }
    }
}
