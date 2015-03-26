using System;

namespace GI
{
    public interface IMethodContainer
    {
        InfoCollection<FunctionInfo> Methods { get; }
    }
}
