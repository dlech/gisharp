using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class EnumInfo : RegisteredTypeInfo
    {
        internal new GISharp.GI.EnumInfo Info {
            get {
                return base.Info as GISharp.GI.EnumInfo;
            }
        }

        public bool IsFlags {
            get {
                return Info.InfoType == GISharp.GI.InfoType.Flags;
            }
        }

        public IReadOnlyList<ValueInfo> Values { get; private set; }

        public string StorageType {
            get {
                return Info.StorageType.ToBuiltInManagedType ();
            }
        }

        public string ErrorDomain {
            get {
                return Info.ErrorDomain;
            }
        }

        public EnumInfo (GISharp.GI.EnumInfo info) : base (info)
        {
            Values = info.Values.Where (f => !f.IsHidden ()).Select (v => WrapInfo (v) as ValueInfo).ToList ().AsReadOnly ();
            Methods = info.Methods.Where (f => !f.IsHidden ()).Select (m => WrapInfo (m) as FunctionInfo).ToList ().AsReadOnly ();
        }
    }
}
