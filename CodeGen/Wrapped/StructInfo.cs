using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class StructInfo : RegisteredTypeInfo
    {
        internal new GISharp.GI.StructInfo Info {
            get {
                return base.Info as GISharp.GI.StructInfo;
            }
        }

        public int Size {
            get {
                return (int)Info.Size;
            }
        }

        public bool IsGTypeStruct {
            get {
                return Info.IsGtypeStruct;
            }
        }

        public bool IsForeign {
            get {
                return Info.IsForeign;
            }
        }

        public StructInfo (GISharp.GI.StructInfo info) : base (info)
        {
            Fields = info.Fields.Where (f => !f.IsHidden ()).Select (f => WrapInfo (f) as FieldInfo).ToList ().AsReadOnly ();
            Methods = info.Methods.Where (f => !f.IsHidden ()).Select (m => WrapInfo (m) as FunctionInfo).ToList ().AsReadOnly ();
        }
    }
}
