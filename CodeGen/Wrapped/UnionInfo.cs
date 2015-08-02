using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class UnionInfo : RegisteredTypeInfo
    {
        internal new GISharp.GI.UnionInfo Info {
            get {
                return base.Info as GISharp.GI.UnionInfo;
            }
        }

        public bool IsDiscriminated {
            get {
                return Info.IsDiscriminated;
            }
        }

        public int DiscriminatorOffset {
            get {
                return Info.DiscriminatorOffset;
            }
        }

        public TypeInfo DiscriminatorType { get; private set; }

        public IReadOnlyList<ConstantInfo> Discriminators { get; private set; }

        public int Size {
            get {
                return (int)Info.Size;
            }
        }

        public UnionInfo (GISharp.GI.UnionInfo info) : base (info)
        {
            Fields = info.Fields.Where (f => !f.IsHidden ()).Select (f => WrapInfo (f) as FieldInfo).ToList ().AsReadOnly ();
            Methods = info.Methods.Where (f => !f.IsHidden ()).Select (f => WrapInfo (f) as FunctionInfo).ToList ().AsReadOnly ();
            DiscriminatorType = WrapInfo (info.DiscriminatorType) as TypeInfo;
            Discriminators = info.Discriminators.Select (f => WrapInfo (f) as ConstantInfo).ToList ().AsReadOnly ();
        }
    }
}
