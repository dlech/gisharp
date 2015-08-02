using System;
using System.Collections.Generic;
using System.Text;

namespace GISharp.CodeGen.Wrapped
{
    public abstract class BaseInfo
    {
        internal readonly string FixupPath;

        internal GISharp.GI.BaseInfo Info { get; private set; }

        public string Namespace {
            get {
                return Info.Namespace;
            }
        }

        public string Name {
            get {
                return Info.Name;
            }
        }

        string managedName;
        public string ManagedName {
            get {
                if (managedName == null) {
                    managedName = GetManagedName ();
                }
                return managedName;
            }
        }

        public BaseInfo Container { get; private set; }

        public bool IsObsolete {
            get {
                return Info.IsDeprecated || CheckFixupPathHasKey ("obsolete");
            }
        }

        /// <summary>
        /// Checks the fixup file to see if this info should be hidden from the code generator.
        /// </summary>
        /// <value><c>true</c> if this instance is hidden; otherwise, <c>false</c>.</value>
        public bool IsHidden {
            get {
                return CheckFixupPathHasKey ("hidden");
            }
        }

        protected BaseInfo (GISharp.GI.BaseInfo info)
        {
            Info = info;
            FixupPath = BuildFixupPath ();
            Container = WrapInfo (Info.Container);
        }

        string BuildFixupPath () {
            var current = Info;
            var builder = new StringBuilder ();
            while (current != null) {
                builder.Insert (0, current.Name);
                builder.Insert (0, ".");
                builder.Insert (0, current.InfoType);
                builder.Insert (0, ".");
                current = current.Container;
            }
            builder.Insert (0, Info.Namespace);
            return builder.ToString ();
        }

        protected virtual string GetManagedName ()
        {
            return GetFixupPathValue ("name", Info.Name);
        }

        protected bool CheckFixupPathHasKey (string key)
        {
            try {
                return MainClass.fixup[FixupPath].ContainsKey (key);
            } catch (KeyNotFoundException) {
                return false;
            }
        }

        protected string GetFixupPathValue (string key, string defaultValue)
        {
            try {
                return MainClass.fixup[FixupPath][key];
            } catch (KeyNotFoundException) {
                return defaultValue;
            }
        }

        internal static BaseInfo WrapInfo (GISharp.GI.BaseInfo info)
        {
            if (info.Container == null) {
                return null;
            }
            switch (info.InfoType) {
            case GISharp.GI.InfoType.Arg:
                return new ArgInfo (info as GISharp.GI.ArgInfo);
            case GISharp.GI.InfoType.Callback:
                return new CallbackInfo (info as GISharp.GI.CallbackInfo);
            case GISharp.GI.InfoType.Constant:
                return new ConstantInfo (info as GISharp.GI.ConstantInfo);
            case GISharp.GI.InfoType.Enum:
            case GISharp.GI.InfoType.Flags:
                return new EnumInfo (info as GISharp.GI.EnumInfo);
            case GISharp.GI.InfoType.Field:
                return new FieldInfo (info as GISharp.GI.FieldInfo);
            case GISharp.GI.InfoType.Function:
                return new FunctionInfo (info as GISharp.GI.FunctionInfo);
            case GISharp.GI.InfoType.Interface:
                return new InterfaceInfo (info as GISharp.GI.InterfaceInfo);
            case GISharp.GI.InfoType.Object:
                return new ObjectInfo (info as GISharp.GI.ObjectInfo);
            case GISharp.GI.InfoType.Property:
                return new PropertyInfo (info as GISharp.GI.PropertyInfo);
            case GISharp.GI.InfoType.Signal:
                return new SignalInfo (info as GISharp.GI.SignalInfo);
            case GISharp.GI.InfoType.Struct:
                return new StructInfo (info as GISharp.GI.StructInfo);
            case GISharp.GI.InfoType.Type:
                return new TypeInfo (info as GISharp.GI.TypeInfo);
            case GISharp.GI.InfoType.Union:
                return new UnionInfo (info as GISharp.GI.UnionInfo);
            case GISharp.GI.InfoType.Value:
                return new ValueInfo (info as GISharp.GI.ValueInfo);
            case GISharp.GI.InfoType.VFunc:
                return new VFuncInfo (info as GISharp.GI.VFuncInfo);
            }
            throw new ArgumentException ("Unsupported InfoType");
        }
    }
}
