using System;
using System.Reflection;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    sealed class GirParameterInfo : ParameterInfo
    {
        GIArg arg;

        public GirParameterInfo(GIArg arg)
        {
            this.arg = arg ?? throw new ArgumentNullException(nameof(arg));
        }

        public override string Name => arg.ManagedName;

        public override System.Type ParameterType => arg.Type.ManagedType;
    }
}
