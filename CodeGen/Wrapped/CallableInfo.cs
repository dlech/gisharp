using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class CallableInfo : BaseInfo
    {
        internal new GISharp.GI.CallableInfo Info {
            get {
                return base.Info as GISharp.GI.CallableInfo;
            }
        }

        public bool CanThrowException {
            get {
                return Info.CanThrowGError;
            }
        }

        public IReadOnlyList<ArgInfo> Args { get; private set; }

        public bool OwnsContainer {
            get {
                return Info.CallerOwns != GISharp.GI.Transfer.Nothing;
            }
        }

        public bool OwnsElements {
            get {
                return Info.CallerOwns == GISharp.GI.Transfer.Everything;
            }
        }

        public TypeInfo ReturnType { get; private set; }

        public bool IsStatic {
            get {
                return !Info.IsMethod;
            }
        }

        public bool MayReturnNull {
            get {
                return Info.MayReturnNull;
            }
        }

        public bool SkipReturn {
            get {
                return Info.SkipReturn;
            }
        }

        public CallableInfo (GISharp.GI.CallableInfo info) : base (info)
        {
            Args = Info.Args.Select (a => WrapInfo (a) as ArgInfo).ToList ().AsReadOnly ();
            ReturnType = WrapInfo (info.ReturnTypeInfo) as TypeInfo;
        }

        protected override string GetManagedName ()
        {
            return GetFixupPathValue ("name", Info.Name.ToPascalCase ());
        }
    }
}
