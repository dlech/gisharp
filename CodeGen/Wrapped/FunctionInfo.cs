using System;

namespace GISharp.CodeGen.Wrapped
{
    public class FunctionInfo : CallableInfo
    {
        internal new GISharp.GI.FunctionInfo Info {
            get {
                return base.Info as GISharp.GI.FunctionInfo;
            }
        }

        public bool IsConstructor {
            get {
                return Info.IsConstructor && !CheckFixupPathHasKey ("static constructor");
            }
        }

        bool CheckForGetterPattern ()
        {
            if (ManagedName.StartsWith ("Get", StringComparison.Ordinal) && Args.Count == 0)
                return true;
            if (ManagedName.StartsWith ("Is", StringComparison.Ordinal) && Args.Count == 0)
                return true;
            return false;
        }

        public bool IsGetter {
            get {
                return Info.IsGetter || CheckForGetterPattern ();
            }
        }

        bool CheckForSetterPattern ()
        {
            if (ManagedName.StartsWith ("Set", StringComparison.Ordinal) && Args.Count == 0)
                return true;
            return false;
        }

        public bool IsSetter {
            get {
                return Info.IsSetter || CheckForSetterPattern ();
            }
        }

        public bool IsVirtual {
            get {
                return Info.WrapsVfunc;
            }
        }

         public PropertyInfo Property { get; private set; }

        public string CName {
            get {
                return Info.Symbol;
            }
        }

        public VFuncInfo VirtualFunction { get; private set; }

        public FunctionInfo (GISharp.GI.FunctionInfo info) : base (info)
        {
            Property = WrapInfo (Info.Property) as PropertyInfo;
            VirtualFunction = WrapInfo (Info.VFunc) as VFuncInfo;
        }
    }
}
