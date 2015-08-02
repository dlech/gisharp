using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.CodeGen.Wrapped
{
    public abstract class RegisteredTypeInfo : BaseInfo
    {
        internal new GISharp.GI.RegisteredTypeInfo Info {
            get {
                return base.Info as GISharp.GI.RegisteredTypeInfo;
            }
        }

        public string GTypeName {
            get {
                return Info.TypeName;
            }
        }

        public IReadOnlyList<BaseInfo> Prerequisites { get; protected set; }

        public IReadOnlyList<InterfaceInfo> Interfaces { get; protected set; }

        public IReadOnlyList<ConstantInfo> Constants { get; protected set; }

        public IReadOnlyList<FieldInfo> Fields { get; protected set; }

        public IReadOnlyList<PropertyInfo> Properties { get; protected set; }

        public IReadOnlyList<SignalInfo> Signals { get; protected set; }

        public IReadOnlyList<FunctionInfo> Methods { get; protected set; }

        public IReadOnlyList<VFuncInfo> VirtualFunctions { get; protected set; }

        protected RegisteredTypeInfo (GISharp.GI.RegisteredTypeInfo info) : base (info)
        {
            // Just empty lists by default. Imlementing classes will replace these as needed.
            Prerequisites = new List<BaseInfo> ().AsReadOnly ();
            Interfaces = new List<InterfaceInfo> ().AsReadOnly ();
            Constants = new List<ConstantInfo> ().AsReadOnly ();
            Fields = new List<FieldInfo> ().AsReadOnly ();
            Properties = new List<PropertyInfo> ().AsReadOnly ();
            Signals = new List<SignalInfo> ().AsReadOnly ();
            Methods = new List<FunctionInfo> ().AsReadOnly ();
            VirtualFunctions = new List<VFuncInfo> ().AsReadOnly ();
        }

        internal void AddExtraConstants (IReadOnlyList<ConstantInfo> extras)
        {
            var newList = Constants.ToList ();
            newList.AddRange (extras);
            Constants = newList.ToList ().AsReadOnly ();
        }

        internal void AddExtraMethods (IReadOnlyList<FunctionInfo> extras)
        {
            var newList = Methods.ToList ();
            newList.AddRange (extras);
            Methods = newList.ToList ().AsReadOnly ();
        }
    }
}
