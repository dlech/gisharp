

using System;
using System.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.CodeGen.Reflection
{
    class GirAliasType : GirType
    {
        Alias alias;

        public GirAliasType(Alias alias) : base(alias)
        {
            this.alias = alias;
        }

        public override System.Type BaseType => typeof(ValueType);
    }
}
