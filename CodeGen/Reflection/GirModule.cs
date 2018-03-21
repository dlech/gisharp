
using System;
using System.Reflection;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    public class GirModule : Module
    {
        Namespace @namespace;

        public GirModule(Namespace @namespace)
        {
            this.@namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
        }

        public override Assembly Assembly => Assembly.GetExecutingAssembly();
    }
}
