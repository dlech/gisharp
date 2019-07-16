

using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirClassType : GirType
    {
        Class @class;

        public GirClassType(Class @class) : base(@class)
        {
            this.@class = @class;
        }

        public override System.Type BaseType => @class.ParentType;
    }
}
