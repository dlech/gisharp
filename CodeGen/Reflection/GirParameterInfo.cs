using System;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;

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

        public override System.Type ParameterType {
            get {
                var type = arg.Type.ManagedType;
                if (type == typeof(Utf8) && arg.TransferOwnership == "none") {
                    type = typeof(UnownedUtf8);
                }
                return type;
            }
        }
    }
}
