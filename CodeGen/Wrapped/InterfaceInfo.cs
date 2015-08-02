using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class InterfaceInfo : RegisteredTypeInfo
    {
        internal new GISharp.GI.InterfaceInfo Info {
            get {
                return base.Info as GISharp.GI.InterfaceInfo;
            }
        }

        public StructInfo IfaceStruct { get; private set; }

        public InterfaceInfo (GISharp.GI.InterfaceInfo info) : base (info)
        {
            Prerequisites = info.Prerequisites.Select (p => WrapInfo (p)).ToList ().AsReadOnly ();
            Properties = info.Properties.Select (p => WrapInfo (p) as PropertyInfo).ToList ().AsReadOnly ();
            Methods = info.Methods.Select (p => WrapInfo (p) as FunctionInfo).ToList ().AsReadOnly ();
            Signals = info.Signals.Select (p => WrapInfo (p) as SignalInfo).ToList ().AsReadOnly ();
            VirtualFunctions = info.VFuncs.Select (p => WrapInfo (p) as VFuncInfo).ToList ().AsReadOnly ();
            Constants = info.Constants.Select (p => WrapInfo (p) as ConstantInfo).ToList ().AsReadOnly ();
            IfaceStruct = WrapInfo (info.IfaceStruct) as StructInfo;
        }
    }
}
