using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public class ObjectInfo : RegisteredTypeInfo
    {
        internal new GISharp.GI.ObjectInfo Info {
            get {
                return base.Info as GISharp.GI.ObjectInfo;
            }
        }

        public bool IsAbstract {
            get {
                return Info.Abstract;
            }
        }

        public bool IsFundamental {
            get {
                return Info.Fundamental;
            }
        }

        public string UnmanagedTypeName {
            get {
                return Info.TypeName;
            }
        }

        public string TypeInitFunctionCName {
            get {
                return Info.TypeInit;
            }
        }

        public ObjectInfo Parent { get; private set; }

        public StructInfo ClassStruct { get; private set; }

        public ObjectInfo (GISharp.GI.ObjectInfo info) : base (info)
        {
            Parent = WrapInfo (info.Parent) as ObjectInfo;
            Constants = info.Constants.Where (f => !f.IsHidden ()).Select (c => WrapInfo (c) as ConstantInfo).ToList ().AsReadOnly ();
            Fields = info.Fields.Where (f => !f.IsHidden ()).Select (c => WrapInfo (c) as FieldInfo).ToList ().AsReadOnly ();
            Interfaces = info.Interfaces.Select (c => WrapInfo (c) as InterfaceInfo).ToList ().AsReadOnly ();
            Methods = info.Methods.Where (f => !f.IsHidden ()).Select (c => WrapInfo (c) as FunctionInfo).ToList ().AsReadOnly ();
            Properties = info.Properties.Where (f => !f.IsHidden ()).Select (c => WrapInfo (c) as PropertyInfo).ToList ().AsReadOnly ();
            VirtualFunctions = info.VFuncs.Where (f => !f.IsHidden ()).Select (c => WrapInfo (c) as VFuncInfo).ToList ().AsReadOnly ();
            ClassStruct = WrapInfo (info.ClassStruct) as StructInfo;
        }
    }
}
