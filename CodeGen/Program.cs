using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using GISharp.GI;
using TypeInfo = GISharp.GI.TypeInfo;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using FixupDictionary = System.Collections.Generic.Dictionary<string,
System.Collections.Generic.Dictionary<string, string>>;

namespace GISharp.CodeGen
{
    class MainClass
    {
        internal const string parentNamespace = "GISharp";

        internal static FixupDictionary fixup;

        public static void Main (string[] args)
        {
            using (var fs = File.OpenRead ("GLib.yaml")) {
                using (var sr = new StreamReader (fs)) {
                    var deserializer = new Deserializer (namingConvention: new CamelCaseNamingConvention ());
                    fixup = deserializer.Deserialize<FixupDictionary> (sr);
                }
            }
            var namespaceName = "GLib";
            Environment.CurrentDirectory = string.Format ("../../../{0}/Generated", namespaceName);
            foreach (var file in Directory.EnumerateFiles (Environment.CurrentDirectory, "*.cs")) {
                File.Delete (file);
            }
            Repository.Require (namespaceName);
            var @namespace = Repository.Namespaces [namespaceName];

            // infoPool starts with copy of all infos. As we generate code for each item
            // the item will be removed from the pool.
            var infoPool = @namespace.Infos.ToList ();

            // iterate copy of infoPool since we are removing items from infoPool in the loop
            foreach (var info in infoPool.ToList ()) {
                var fixupPath = info.GetFixupPath ();
                if (fixupPath.IsHidden ()) {
                    infoPool.Remove (info);
                    continue;
                }
                // this means we are just handling Enum, Object, Struct and Union
                var methodContainer = info as IMethodContainer;
                if (methodContainer == null) {
                    continue;
                }
                var constantNames = fixupPath.GetExtras (@namespace.Name, "Constant");
                var constants = (from i in infoPool
                    where i.InfoType == InfoType.Constant && constantNames.Contains (i.Name)
                    select (ConstantInfo)i).ToList ();

                var extraFunctionNames = fixupPath.GetExtras (@namespace.Name, "Function");
                var extraFunctions = (from i in infoPool
                    where i.InfoType == InfoType.Function && extraFunctionNames.Contains (i.Name)
                    select (FunctionInfo)i).ToList ();
                using (var fs = File.OpenWrite (info.Name + ".cs")) {
                    using (var sw = new StreamWriter (fs)) {
                        sw.WriteClass (info, constants, extraFunctions);
                    }
                }
                infoPool.RemoveAll (i => constants.Contains (i as ConstantInfo));
                infoPool.RemoveAll (i => extraFunctions.Contains (i as FunctionInfo));
                // remove duplicate functions from infoPool
                infoPool.RemoveAll (i => i.InfoType == InfoType.Function && methodContainer.Methods.Any (m => m.Symbol == (i as FunctionInfo).Symbol));
                infoPool.Remove (info);
            }

            // handle static classes defined by the fixup file
            var fixupPrefix = string.Join (".", @namespace.Name, "StaticClass", "");
            var staticClasses = fixup
                .Where (x => x.Key.StartsWith (@namespace.Name + ".", StringComparison.Ordinal) && x.Value.Keys.Contains ("class") && x.Value["class"].StartsWith (fixupPrefix))
                .GroupBy (x => x.Value ["class"]);
            foreach (var staticClass in staticClasses) {
                var staticClassName = staticClass.Key.Remove (0, fixupPrefix.Length);

                var constantNames = staticClass.Key.GetExtras (@namespace.Name, "Constant");
                var constants = (from i in infoPool
                    where i.InfoType == InfoType.Constant && constantNames.Contains (i.Name)
                    select (ConstantInfo)i).ToList ();

                var functionNames = staticClass.Key.GetExtras (@namespace.Name, "Function");
                var functions = infoPool
                    .Where (i => i.InfoType == InfoType.Function && functionNames.Contains (i.Name))
                    .Cast<FunctionInfo> ().ToList ();

                using (var fs = File.OpenWrite (staticClassName + ".cs")) {
                    using (var sw = new StreamWriter (fs)) {
                        sw.WriteStaticClass (@namespace.Name, staticClassName, constants, functions);
                    }
                }
                infoPool.RemoveAll (i => constants.Contains (i as ConstantInfo));
                infoPool.RemoveAll (i => functions.Contains (i as FunctionInfo));
            }

            var generalConstants = infoPool.Where (i => i.InfoType == InfoType.Constant).Cast<ConstantInfo> ().ToList ();
            if (generalConstants.Any ()) {
                using (var fs = File.OpenWrite ("Constants.cs")) {
                    using (var sw = new StreamWriter (fs)) {
                        sw.WriteConstants (@namespace.SharedLibraries[0], generalConstants);
                    }
                }
            }
            infoPool.RemoveAll (i => generalConstants.Contains (i));

            var generalCallbacks = infoPool.Where (i => i.InfoType == InfoType.Callback).Cast<CallbackInfo> ().ToList ();
            if (generalCallbacks.Any ()) {
                using (var fs = File.OpenWrite ("Delegates.cs")) {
                    using (var sw = new StreamWriter (fs)) {
                        sw.WriteCallbacks (generalCallbacks);
                    }
                }
            }
            infoPool.RemoveAll (i => generalCallbacks.Contains (i));

            //var generalFunctions = infoPool.Where (i => i.InfoType == InfoType.Function).Cast<FunctionInfo> ().ToList ();

            foreach (var info in infoPool) {
                Console.Error.WriteLine ("Unhandled info: {0}.{1}.{2}", info.Namespace, info.InfoType, info.Name);
            }
        }
    }

    static class ExtensionMethods
    {
        public static string GetFixupPath (this BaseInfo info)
        {
            var builder = new StringBuilder ();
            var currentInfo = info;
            while (currentInfo != null) {
                builder.Insert (0, string.Join (".", string.Empty, currentInfo.InfoType, currentInfo.Name));
                currentInfo = currentInfo.Container;
            }
            builder.Insert (0, info.Namespace);
            return builder.ToString ();
        }

        public static void WriteHeader (this TextWriter writer, string @namespace)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @namespace);
            writer.WriteLine ("{");
        }

        public static string GetAccessModifier (this string fixupPath)
        {
            var modifier = MainClass.fixup.
                Where (x => x.Key == fixupPath && x.Value.ContainsKey ("access_modifier")).
                Select (x => x.Value["access_modifier"]).SingleOrDefault ()
                ?? "public";
            modifier = modifier.Replace ("private", "");
            if (modifier.Length > 0) {
                modifier += " ";
            }
            return modifier;
        }

        public static void WriteStaticClass (this TextWriter writer, string @namespace,
            string name, List<ConstantInfo> constants, List<FunctionInfo> functions)
        {
            var fixupPath = string.Join (".", @namespace, "StaticClass", name);
            writer.WriteHeader (@namespace);
            writer.Write ("\t{0}", fixupPath.GetAccessModifier ());
            writer.WriteLine ("static partial class {0}", name);
            writer.WriteLine ("\t{");
            foreach (var constant in constants) {
                writer.WriteConstant (constant, name);
            }
            writer.WriteFunctions (functions, name);
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteObject (this TextWriter writer, BaseInfo info,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            throw new NotImplementedException ();
        }

        public static bool IsOpaque (this StructInfo @struct)
        {
            var fixupPath = @struct.GetFixupPath ();
            return !@struct.Fields.Any () || fixupPath.IsOpaque ();
        }

        public static bool IsReferenceCountedOpaque (this StructInfo @struct)
        {
            return @struct.FindMethod ("ref") != null && @struct.FindMethod ("unref") != null;
        }

        public static void WriteClass (this TextWriter writer, BaseInfo info,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var @enum = info as EnumInfo;
            if (@enum != null) {
                if (constants.Count > 0) {
                    throw new Exception ("Enums can't have extra constants");
                }
                writer.WriteEnum (@enum, extraFunctions);
                return;
            }
            var @object = info as ObjectInfo;
            if (@object != null) {
                writer.WriteObject (@object, constants, extraFunctions);
                return;
            }
            var @struct = info as StructInfo;
            if (@struct != null) {
                if (@struct.IsOpaque ()) {
                    writer.WriteOpaque (@struct, constants, extraFunctions);
                } else {
                    writer.WriteStruct (@struct, constants, extraFunctions);
                }
                return;
            }
            var union = info as UnionInfo;
            if (union != null) {
                writer.WriteUnion (union, constants, extraFunctions);
                return;
            }
        }

        public static bool IsHidden (this string fixupPath)
        {
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("hidden"));
        }

        public static List<string> GetExtras (this string fixupPath, string @namespace, string infoType)
        {
            var prefix = string.Join (".", @namespace, infoType, string.Empty);
            var items = from i in MainClass.fixup
                where i.Key.StartsWith (prefix, StringComparison.Ordinal) && i.Value.ContainsKey ("class") && i.Value ["class"] == fixupPath
                select i.Key.Remove (0, prefix.Length);
            return items.ToList ();
        }

        public static void WriteCallback (this TextWriter writer, CallbackInfo callback, bool native = false)
        {
            var fixupPath = callback.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            if (callback.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            writer.Write ("\t{0}", native ? "" : fixupPath.GetAccessModifier ());
            writer.Write ("delegate ");
            writer.WriteType (callback.ReturnTypeInfo);
            writer.Write (" {0}{1} (", native ? "Native" : "", callback.Name);
            writer.WriteArgs (callback.Args.ToList (), native);
            writer.WriteLine (");");
            writer.WriteLine ();
        }

        public static void WriteCallbacks (this TextWriter writer, List<CallbackInfo> callbacks)
        {
            writer.WriteHeader (callbacks[0].Namespace);
            foreach (var callback in callbacks) {
                writer.WriteCallback (callback);
                writer.WriteCallback (callback, true);
            }
            writer.WriteLine ("}");
        }

        public static void WriteValue (this TextWriter writer, ValueInfo value)
        {
            var fixupPath = value.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            if (value.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            writer.WriteLine ("\t\t{0} = {1},", value.Name.ToPascalCase (), value.Value);
        }

        public static string GetManagedName (this string fixupPath, string defaultValue)
        {
            if (MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("name"))) {
                return MainClass.fixup [fixupPath] ["name"];
            }
            return defaultValue;
        }

        public static void WriteConstant (this TextWriter writer, ConstantInfo constant, string stripPrefix = null)
        {
            var fixupPath = constant.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }

            var constantName = constant.Name.ToPascalCase ();
            if (stripPrefix != null && constantName.StartsWith (stripPrefix, StringComparison.Ordinal)) {
                constantName = constantName.Remove (0, stripPrefix.Length);
            }
            constantName = fixupPath.GetManagedName (constantName);

            if (constant.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            writer.Write ("\t\t{0}", fixupPath.GetAccessModifier ());
            writer.Write ("const {0} {1} = ",
                constant.TypeInfo.ToManagedType (),
                constantName);

            Argument arg;
            constant.GetValue (out arg);
            switch (constant.TypeInfo.Tag) {
            case TypeTag.Boolean:
                writer.Write ("{0}", arg.Boolean ? "true" : "false");
                break;
            case TypeTag.Int8:
                writer.Write ("{0}", arg.Int8);
                break;
            case TypeTag.UInt8:
                writer.Write ("{0}", arg.UInt8);
                break;
            case TypeTag.Int16:
                writer.Write ("{0}", arg.Int16);
                break;
            case TypeTag.UInt16:
                writer.Write ("{0}", arg.UInt16);
                break;
            case TypeTag.Int32:
                writer.Write ("{0}", arg.Int32);
                break;
            case TypeTag.UInt32:
                writer.Write ("{0}", arg.UInt32);
                break;
            case TypeTag.Int64:
                writer.Write ("{0}", arg.Int64);
                break;
            case TypeTag.UInt64:
                writer.Write ("{0}", arg.UInt64);
                break;
            case TypeTag.Float:
                writer.Write ("{0}", arg.Float);
                break;
            case TypeTag.Double:
                writer.Write ("{0}", arg.Double);
                break;
            case TypeTag.UTF8:
                writer.Write ("\"{0}\"", arg.String.Escape ());
                break;
            }
            constant.FreeValue (ref arg);
            writer.WriteLine ("; // {0}", constant.Name);
            writer.WriteLine ();
        }

        public static string Escape (this string str)
        {
            str = str.Replace ("\\", @"\\");
            str = str.Replace ("\"", @"\""");
            str = str.Replace ("\n", @"\n");
            str = str.Replace ("\t", @"\t");
            return str;
        }

        public static void WriteConstants (this TextWriter writer, string dllName, List<ConstantInfo> constants)
        {
            writer.WriteHeader (constants[0].Namespace);
            writer.WriteLine ("\tpublic static class Constants");
            writer.WriteLine ("\t{");
            writer.WriteLine ("\t\tpublic const string ExternDllName = \"{0}\";", dllName);
            writer.WriteLine ();
            foreach (var constant in constants) {
                writer.WriteConstant (constant);
            }
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteEnum (this TextWriter writer, EnumInfo @enum, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @enum.GetFixupPath ();
            writer.WriteHeader (@enum.Namespace);
            if (@enum.InfoType == InfoType.Flags) {
                writer.WriteLine ("\t[Flags]");
            }
            if (@enum.IsDeprecated) {
                writer.WriteLine ("\t[Obsolete]");
            }
            writer.WriteLine ("\t{0}", fixupPath.GetAccessModifier ());
            writer.WriteLine ("enum {0} : {1}", @enum.Name, @enum.StorageType.ToBuiltInManagedType ());
            writer.WriteLine ("\t{");
            foreach (var value in @enum.Values) {
                writer.WriteValue (value);
            }
            writer.WriteLine ("\t}");

            if (@enum.Methods.Count > 0 || extraFunctions.Count > 0) {
                writer.WriteLine ();
                writer.Write ("\t{0}", fixupPath.GetAccessModifier ());
                writer.WriteLine ("static class {0}Extensions", @enum.Name);
                writer.WriteLine ("\t{");
                writer.WriteFunctions (@enum.Methods);
                writer.WriteFunctions (extraFunctions, @enum.Name);
                writer.WriteLine ("\t}");
            }

            writer.WriteLine ("}");
        }

        public static string ToBuiltInManagedType (this TypeTag tag)
        {
            switch (tag) {
            case TypeTag.Void:
                return "void";
            case TypeTag.Boolean:
                return "bool";
            case TypeTag.Int8:
                return "sbyte";
            case TypeTag.UInt8:
                return "byte";
            case TypeTag.Int16:
                return "short";
            case TypeTag.UInt16:
                return "ushort";
            case TypeTag.Int32:
                return "int";
            case TypeTag.UInt32:
                return "uint";
            case TypeTag.Int64:
                return "long";
            case TypeTag.UInt64:
                return "ulong";
            case TypeTag.Float:
                return "float";
            case TypeTag.Double:
                return "double";
            case TypeTag.Unichar:
                return "char";
            }
            throw new ArgumentException ("Must be a basic type.", "tag");
        }

        public static string ToManagedType (this TypeInfo type)
        {
            if (type.Tag.IsBasicValueType () && !type.IsPointer) {
                return type.Tag.ToBuiltInManagedType ();
            }
            switch (type.Tag) {
            case TypeTag.Void:
                // case of !IsPointer is handled above.
                return "IntPtr";
            case TypeTag.GType:
                return "GISharp.Core.GType";
            case TypeTag.UTF8:
            case TypeTag.Filename:
            case TypeTag.Unichar:
                if (type.IsPointer) {
                    return "string";
                }
                return "char";
            case TypeTag.Interface:
                return string.Join (".", MainClass.parentNamespace, type.Interface.Namespace, type.Interface.Name);
            case TypeTag.Array:
                return type.GetParamType (0).ToManagedType () + "[]";
            case TypeTag.GList:
            case TypeTag.GSList:
                return "System.Collections.List";
            case TypeTag.GHash:
                return "GLib.HashTable";
            default:
                throw new Exception ("unexpected type");
            }
        }

        public static bool NeedsMarshal (this TypeInfo type)
        {
            if (type.Tag.IsBasicValueType ()) {
                return false;
            }
            if (type.Tag == TypeTag.Interface) {
                switch (type.Interface.InfoType) {
                case InfoType.Enum:
                case InfoType.Flags:
                case InfoType.Union:
                    return false;
                case InfoType.Struct:
                    return (type.Interface as StructInfo).IsOpaque ();
                }
            } else if (type.Tag == TypeTag.Array) {
                return type.ArrayType != ArrayType.C;
            }
            return true;
        }

        public static void WriteType (this TextWriter writer, TypeInfo type, bool forPinvoke = false)
        {
            if (forPinvoke && type.NeedsMarshal ()) {
                writer.Write ("IntPtr");
                return;
            }
            if (type.Tag == TypeTag.Array && type.ArrayType == ArrayType.C) {
                var typeInfo = type.GetParamType (0);
                writer.Write ("{0}.{1}.{2}[]", MainClass.parentNamespace, typeInfo.Namespace, typeInfo.Name);
                return;
            }
            if (type.Tag == TypeTag.Interface) {
                writer.Write ("{0}.{1}.{2}", MainClass.parentNamespace, type.Interface.Namespace, type.Interface.Name);
            } else {
                writer.Write ("{0}", type.ToManagedType ());
            }
        }

        public static void WriteField (this TextWriter writer, GISharp.GI.FieldInfo field)
        {
            var fixupPath = field.GetFixupPath ();
            writer.WriteLine ("\t\t[FieldOffset({0})]", field.Offset);
            if (field.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            var marshalNeeded = !field.TypeInfo.Tag.IsBasicValueType ();

            writer.Write ("\t\t{0}", marshalNeeded ? "" : fixupPath.GetAccessModifier ());
            writer.WriteType (field.TypeInfo, true);
            writer.WriteLine (" {0};", marshalNeeded ? field.Name.ToCamelCase () : field.Name.ToPascalCase ());
            writer.WriteLine ();
            if (marshalNeeded) {
//        writer.WriteLine ("\tpublic ");
//        writer.WriteLine (field_type);
//        writer.WriteLine (" %s {\n", field.get_name ());
//        writer.WriteLine ("\t\tget {\n");
//        print_marshal_type_to_managed (field_type, field_name);
//        writer.WriteLine ("\t\t}\n");
//        writer.WriteLine ("\t\tset {\n");
//        print_marshal_type_from_managed (field_type, field_name, "value");
//        writer.WriteLine ("\t\t}\n");
//        writer.WriteLine ("\t}\n");
//        writer.WriteLine ("\n");
            }
        }

        public static void WriteArg (this TextWriter writer, ArgInfo arg, bool forPinvoke = false)
        {
            if (arg.IsCallerAllocates) {
                throw new NotImplementedException ();
            }
            if (arg.IsReturnValue) {
                throw new NotImplementedException ();
            }
            if (arg.Direction == Direction.Inout) {
                writer.Write ("ref ");
            } else if (arg.Direction == Direction.Out) {
                writer.Write ("out ");
            }
            writer.WriteType (arg.TypeInfo, forPinvoke);
            writer.Write (" {0}", arg.Name.ToCamelCase ());
        }

        public static void FilterForManaged (this List<ArgInfo> args)
        {
            var closureArgs = args.Where (a => a.Closure >= 0).Select (a => args[a.Closure]);
            var destryoArgs = args.Where (a => a.Destroy >= 0).Select (a => args[a.Destroy]);
            var arrayLengthArgs = args.Where (a => a.TypeInfo.ArrayLength >= 0).Select (a => args[a.TypeInfo.ArrayLength]);
            foreach (var arg in closureArgs.Union (destryoArgs).Union (arrayLengthArgs).ToList ()) {
                args.Remove (arg);
            }
        }

        public static string GetDefaultValue (this string fixupPath)
        {
            try {
                return MainClass.fixup[fixupPath]["default"];
            } catch (Exception) {
                return null;
            }
        }

        public static void WriteArgs (this TextWriter writer, List<ArgInfo> args, bool forPinvoke = false)
        {
            if (!forPinvoke) {
                args.FilterForManaged ();
            }
            if (args.Count == 0) {
                return;
            }
            var lastArg = args [args.Count - 1];
            foreach (var arg in args) {
                var fixupPath = arg.GetFixupPath ();
                writer.WriteArg (arg, forPinvoke);
                if (!forPinvoke) {
                    var defaultValue = fixupPath.GetDefaultValue ();
                    if (defaultValue != null) {
                        writer.Write (" = {0}", defaultValue);
                    }
                }
                if (arg != lastArg) {
                    writer.Write (", ");
                }
            }
        }

        public static bool IsOpaque (this string fixupPath)
        {
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("opaque"));
        }

        public static bool IsStaticConstructor (this string fixupPath)
        {
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("static constructor"));
        }

        static readonly string[] opaqueVirtualMethods = {
            "Ref",
            "Unref",
            "Copy",
            "Free"
        };

        public static void WritePInvoke (this TextWriter writer, FunctionInfo function)
        {
            writer.WriteLine ("\t\t[DllImport ({0}.{1}.Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]", MainClass.parentNamespace, function.Namespace);
            writer.Write ("\t\tstatic extern ");
            writer.WriteType (function.ReturnTypeInfo, true);
            writer.Write (" {0} (", function.Symbol);
            if (function.IsMethod) {
                writer.Write ("IntPtr instance");
                if (function.Args.Any ()) {
                    writer.Write (", ");
                }
            }
            writer.WriteArgs (function.Args.ToList (), true);
            writer.WriteLine (");");
            writer.WriteLine ();
        }

        public static bool IsPInvokeOnly (this string fixupPath)
        {
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("pinvoke only"));
        }

        public static string WriteMarshalTypeFromManaged (this TextWriter writer,
            TypeInfo type, string managedVarName, out Action writeFree)
        {
            string unmanagedVarName = managedVarName;
            writeFree = null;

            // basic types and interfaces do not need to be marshalled.
            switch (type.Tag) {
            case TypeTag.GType:
                throw new NotImplementedException ();
            case TypeTag.UTF8:
                unmanagedVarName += "Ptr";
                writer.WriteLine ("\t\t\tvar {0} = GISharp.Core.MarshalG.StringToUtf8Ptr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => writer.WriteLine ("\t\t\tGISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.Filename:
                unmanagedVarName += "Ptr";
                writer.WriteLine ("\t\t\tvar {0} = GISharp.Core.MarshalG.StringToFilenamePtr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => writer.WriteLine ("\t\t\tGISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.Array:
                if (type.ArrayType == ArrayType.C) {
                    break;
                }
                throw new NotImplementedException ();
            case TypeTag.GList:
                throw new NotImplementedException ();
            case TypeTag.GSList:
                throw new NotImplementedException ();
            case TypeTag.GHash:
                throw new NotImplementedException ();
            case TypeTag.Error:
                throw new NotImplementedException ();
            }
            return unmanagedVarName;
        }

        public static void WriteMarshalTypeToManaged (this TextWriter writer,
            TypeInfo type, string unmanagedVarName, string managedVarName,
            Transfer transfer)
        {
            // basic types do not need to be marshalled.
            switch (type.Tag) {
            case TypeTag.GType:
                throw new NotImplementedException ();
            case TypeTag.UTF8:
                writer.WriteLine ("\t\t\tvar {0} = GISharp.Core.MarshalG.Utf8PtrToString ({1});",
                    managedVarName, unmanagedVarName);
                if (transfer != Transfer.Nothing) {
                    writer.WriteLine ("\t\t\tGISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                }
                break;
            case TypeTag.Filename:
                writer.WriteLine ("\t\t\tvar {0} = GISharp.Core.MarshalG.FilenamePtrToString ({1});",
                    managedVarName, unmanagedVarName);
                if (transfer != Transfer.Nothing) {
                    writer.WriteLine ("\t\t\tGISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                }
                break;
            case TypeTag.Array:
                if (type.ArrayType == ArrayType.C) {
                    break;
                }
                throw new NotImplementedException ();
            case TypeTag.Interface:
                var @struct = type.Interface as StructInfo;
                if (@struct != null && @struct.IsOpaque ()) {
                    var isReferenceCounted = @struct.IsReferenceCountedOpaque ();
                    writer.Write ("\t\t\tvar {0} = GISharp.Core.MarshalG.PtrTo{1}Opaque<",
                        managedVarName, isReferenceCounted ? "ReferenceCounted" : "");
                    writer.WriteType (type);
                    writer.WriteLine ("> ({0}, {1});",unmanagedVarName,
                        transfer == Transfer.Nothing ? "false" : "true");
                }
                break;
            case TypeTag.GList:
                throw new NotImplementedException ();
            case TypeTag.GSList:
                throw new NotImplementedException ();
            case TypeTag.GHash:
                throw new NotImplementedException ();
            case TypeTag.Error:
                throw new NotImplementedException ();
            }
        }

        public static void WriteNullCheck (this TextWriter writer, ArgInfo arg)
        {
            if (arg.MayBeNull || !arg.TypeInfo.NeedsMarshal ()) {
                return;
            }
            var argName = arg.Name.ToCamelCase ();
            writer.WriteLine ("\t\t\tif ({0} == null) {{", argName);
            writer.WriteLine ("\t\t\t\tthrow new ArgumentNullException (\"{0}\");", argName);
            writer.WriteLine ("\t\t\t}");
        }


        public static bool GetSkipProperty (this string fixupPath)
        {
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("no property");
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Writes the function.
        /// </summary>
        /// <returns>An Tuple with action to write a property getter/setter and
        /// a bool where <c>true</c> indicates that this is a getter (and
        /// <c>false</c> is a setter) or <c>null</c> if this is not a getter or
        /// setter.</returns>
        /// <param name="writer">Writer.</param>
        /// <param name="function">Function.</param>
        /// <param name="stripPrefix">Strip prefix.</param>
        public static Tuple<string, bool, Action, Action>  WriteFunction (this TextWriter writer,
            FunctionInfo function, string stripPrefix = null)
        {
            var fixupPath = function.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return null;
            }
            var functionName = function.Name.ToPascalCase ();
            if (stripPrefix != null && functionName.StartsWith (stripPrefix, StringComparison.Ordinal)) {
                functionName = functionName.Remove (0, stripPrefix.Length);
            }
            functionName = fixupPath.GetManagedName (functionName);

            writer.WritePInvoke (function);
            if (fixupPath.IsPInvokeOnly ()) {
                return null;
            }

            // some constructors may be handled as static methods to avoid name conflicts
            // i.e. we cant have 2 constructors with the same number of arguments
            var isConstructor = function.IsConstructor && !fixupPath.IsStaticConstructor ();

            // anything that starts with Get, Is or Set is considered a property.
            // unless the fixup file says to skip it.
            var isGetter = false;
            var isSetter = false;
            if (!fixupPath.GetSkipProperty ()) {
                isGetter = function.IsGetter
                    || (functionName.StartsWith ("Get", StringComparison.Ordinal) && function.Args.Count == 0)
                    || (functionName.StartsWith ("Is", StringComparison.Ordinal) && function.Args.Count == 0);
                isSetter = function.IsSetter
                    || (functionName.StartsWith ("Set", StringComparison.Ordinal) && function.Args.Count == 1);

                // Add "Get" prefix to "Is" getters to avoid naming conflict.
                // The resulting property will still start with "Is".
                if (isGetter && functionName.StartsWith ("Is", StringComparison.Ordinal)) {
                    functionName = "Get" + functionName;
                }
            }

            // Write the function declration

            if (function.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }

            if (function.InstanceOwnershipTransfer != Transfer.Nothing) {
                throw new NotImplementedException ();
            }
            if (opaqueVirtualMethods.Contains (functionName)) {
                writer.Write ("\t\tpublic override ");
            } else if (isGetter || isSetter) {
                writer.Write ("\t\t");
            } else {
                writer.Write ("\t\t{0}", fixupPath.GetAccessModifier ());
            }
            if (!function.IsMethod && !isConstructor) {
                writer.Write ("static ");
            }

            var returnType = function.ReturnTypeInfo;

            var returnsValue = true;
            if (isConstructor) {
                // constructors don't return a value
                returnsValue = false;
            }
            if (returnType.Tag == TypeTag.Void && !returnType.IsPointer) {
                //void functions don't return a value
                returnsValue = false;
            }
            if (function.SkipReturn) {
                // GI tells us to ignore the return value
                returnsValue = false;
            }
            if (function.Name == "ref") {
                // suppress the return value on reference functions
                returnsValue = false;
            }

            if (isConstructor) {
                writer.Write (returnType.Name);
            } else if (returnsValue) {
                writer.WriteType (returnType);
            } else {
                writer.Write ("void");
            }
            if (!isConstructor) {
                writer.Write (" {0}", functionName);
            }
            writer.Write (" (");
            writer.WriteArgs (function.Args.ToList ());
            writer.Write (")");
            if (isConstructor) {
                writer.Write (" : base (IntPtr.Zero)");
            }
            writer.WriteLine(" // {0}", function.Name);
            writer.WriteLine ("\t\t{");

            var managedArgs = function.Args.ToList ();
            managedArgs.FilterForManaged ();

            // Do null argument checks
            foreach (var arg in managedArgs) {
                writer.WriteNullCheck (arg);
            }

            // Then marshal input args to unmanaged structures as needed

            var marshalledArgNames = new Dictionary<string, string> ();
            var marshalledArgWriteFree = new List<Action> ();
            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.In || a.Direction == Direction.Inout)) {
                if (arg.OwnershipTransfer != Transfer.Nothing) {
                    throw new NotImplementedException ();
                }
                Action writeFree;
                marshalledArgNames [arg.Name] = writer.WriteMarshalTypeFromManaged (arg.TypeInfo, arg.Name.ToCamelCase (), out writeFree);
                if (writeFree != null) {
                    // have to postpone writing the free statement until after calling the pinvoke function
                    marshalledArgWriteFree.Add (writeFree);
                }
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = function.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase ();
                    writer.WriteLine ("\t\t\tvar {0} = {1}.Length;",
                        marshalledArgNames [lengthArg.Name],
                        marshalledArgNames [arg.Name]);
                }
            }

            // Declare any out args that need to be marshalled

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out)) {
                marshalledArgNames [arg.Name] = arg.Name.ToCamelCase ();
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = function.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase ();
                    writer.Write ("\t\t\t");
                    writer.WriteType (lengthArg.TypeInfo);
                    writer.WriteLine (" {0};", marshalledArgNames [lengthArg.Name]);
                }
            }

            // Marshal callbacks to native delegates

            var callbackArgs = managedArgs.Where (a => a.TypeInfo.Tag == TypeTag.Interface && a.TypeInfo.Interface.InfoType == InfoType.Callback);
            foreach (var arg in callbackArgs) {
                marshalledArgNames [arg.Name] += "Ptr";
                writer.WriteLine ("\t\t\tIntPtr {0} = IntPtr.Zero;", marshalledArgNames [arg.Name]);
//                writer.Write ("\t\t\tNative");
//                writer.WriteType (arg.TypeInfo);
//                writer.WriteLine (" {0} = null;", marshalledArgNames[arg.Name]);
            }

            // Assign user_data for closures

            // TODO: figure out how to handle closures
            var closureArgs = function.Args.Where (a => a.Closure >= 0).Select (a => function.Args [a.Closure]);
            foreach (var arg in closureArgs) {
                marshalledArgNames [arg.Name] = arg.Name.ToCamelCase ();
                writer.Write ("\t\t\tvar {0} = default(", marshalledArgNames [arg.Name]);
                writer.WriteType (arg.TypeInfo);
                writer.WriteLine (");");
            }

            // Assign destroy function

            // TODO: figure out how to handle destroy notify
            var destroyArgs = function.Args.Where (a => a.Destroy >= 0).Select (a => function.Args [a.Destroy]);
            foreach (var arg in destroyArgs) {
                marshalledArgNames [arg.Name] = arg.Name.ToCamelCase ();
                writer.WriteLine ("\t\t\tIntPtr {0} = IntPtr.Zero;", marshalledArgNames [arg.Name]);
                //writer.WriteLine ("\t\t\tGISharp.Core.DestroyNotify {0} = null;", marshalledArgNames[arg.Name]);
            }

            // Call the PInvoke function

            writer.Write ("\t\t\t");
            if (returnsValue) {
                writer.Write ("var ret{0} = ", returnType.NeedsMarshal () ? "Ptr" : "");
            } else if (isConstructor) {
                writer.Write ("Handle = ");
            }
            writer.Write ("{0} (", function.Symbol);
            var lastArg = function.Args.LastOrDefault ();
            if (function.IsMethod) {
                writer.Write ("Handle");
                if (lastArg != null) {
                    writer.Write (", ");
                }
            }
            if (lastArg != null) {
                foreach (var arg in function.Args) {
                    if (arg.Direction == Direction.Inout) {
                        writer.Write ("ref ");
                    }
                    if (arg.Direction == Direction.Out) {
                        writer.Write ("out ");
                    }
                    writer.Write (marshalledArgNames [arg.Name]);
                    var @struct = arg.TypeInfo.Interface as StructInfo;
                    if (@struct != null && @struct.IsOpaque ()) {
                        writer.Write (" == null ? IntPtr.Zero : {0}.Handle", marshalledArgNames [arg.Name]);
                    }
                    if (arg != lastArg) {
                        writer.Write (", ");
                    }
                }
            }
            writer.WriteLine (");");

            // handle ownership in constructor

            if (isConstructor) {
                if (function.CallerOwns != Transfer.Everything) {
                    throw new NotImplementedException ();
                }
            }

            // Free any unmanged input args

            foreach (var writeFree in marshalledArgWriteFree) {
                writeFree ();
            }

            // Marshal output parameters as needed.

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out || a.Direction == Direction.Inout)) {
                writer.WriteMarshalTypeToManaged (arg.TypeInfo, marshalledArgNames[arg.Name], arg.Name.ToCamelCase (), arg.OwnershipTransfer);
//                if (arg.TypeInfo.ArrayLength >= 0) {
//                    var lengthArg = function.Args [arg.TypeInfo.ArrayLength];
//                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase ();
//                    writer.WriteLine ("\t\t\t{0} = {1}.Length;",
//                        marshalledArgNames [arg.Name],
//                        marshalledArgNames [lengthArg.Name]);
//                }
            }

            // return result if needed;

            if (returnsValue) {
                writer.WriteMarshalTypeToManaged (returnType, "retPtr", "ret", function.CallerOwns);
                writer.WriteLine ("\t\t\treturn ret;");
            }

            writer.WriteLine ("\t\t}");
            writer.WriteLine ();

            // generate property accessor for use later

            Tuple<string, bool, Action, Action> writeProperty = null;
            var propertyName = functionName.Remove (0, 3);
            if (isGetter) {
                writeProperty = new Tuple<string, bool, Action, Action> (
                    propertyName,
                    true,
                    () => {
                        writer.Write ("\t\t{0}", fixupPath.GetAccessModifier ());
                        if (!function.IsMethod) {
                            writer.Write ("static ");
                        }
                        writer.WriteType (function.ReturnTypeInfo);
                        writer.WriteLine (" {0} {{", propertyName);
                    },
                    () => {
                        writer.WriteLine ("\t\t\tget {");
                        writer.WriteLine ("\t\t\t\treturn {0} ();", functionName);
                        writer.WriteLine ("\t\t\t}");
                    });
            }
            if (isSetter) {
                writeProperty = new Tuple<string, bool, Action, Action> (
                    propertyName,
                    false,
                    () => {
                        writer.Write ("\t\t{0}", fixupPath.GetAccessModifier ());
                        if (!function.IsMethod) {
                            writer.Write ("static ");
                        }
                        writer.WriteType (function.Args[0].TypeInfo);
                        writer.WriteLine (" {0} {{", propertyName);
                    },
                    () => {
                        writer.WriteLine ("\t\t\tset {");
                        writer.WriteLine ("\t\t\t\t{0} (value);", functionName);
                        writer.WriteLine ("\t\t\t}");
                    });
            }

            return writeProperty;
        }

        public static void WriteOpaque (this TextWriter writer, StructInfo @struct,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @struct.GetFixupPath ();
            var isReferenceCounted = @struct.IsReferenceCountedOpaque ();

            writer.WriteHeader (@struct.Namespace);
            writer.Write ("\t{0}", fixupPath.GetAccessModifier ());
            writer.WriteLine ("partial class {0} : GISharp.Core.{1}Opaque",
               @struct.Name, isReferenceCounted ? "ReferenceCounted" : "");
            writer.WriteLine ("\t{");

            foreach (var constant in constants) {
                writer.WriteConstant (constant, @struct.Name);
            }

            writer.WriteLine ("\t\tpublic {0} (IntPtr handle) : base (handle)", @struct.Name);
            writer.WriteLine ("\t\t{");
            writer.WriteLine ("\t\t}");
            writer.WriteLine ();

            writer.WriteFunctions (@struct.Methods);
            writer.WriteFunctions (extraFunctions, @struct.Name);

            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WritePseudoProperties (this TextWriter writer,
            Dictionary<string, Action> declarations,
            Dictionary<string, Action> getters,
            Dictionary<string, Action> setters)
        {
            foreach (var property in declarations) {
                property.Value.Invoke ();
                if (getters.ContainsKey (property.Key)) {
                    getters [property.Key].Invoke ();
                }
                if (setters.ContainsKey (property.Key)) {
                    setters [property.Key].Invoke ();
                }
                writer.WriteLine ("\t\t}");
                writer.WriteLine ();
            }
        }

        public static void WriteFunctions (this TextWriter writer, IEnumerable<FunctionInfo> functions,
            string stripPrefix = null)
        {
            var propertyTypes = new Dictionary <string, Action> ();
            var propertyGetters = new Dictionary <string, Action> ();
            var propertySetters = new Dictionary <string, Action> ();

            foreach (var function in functions) {
                var propertyAccessor = writer.WriteFunction (function, stripPrefix);
                if (propertyAccessor != null) {
                    propertyTypes [propertyAccessor.Item1] = propertyAccessor.Item3;
                    if (propertyAccessor.Item2) {
                        propertyGetters [propertyAccessor.Item1] = propertyAccessor.Item4;
                    } else {
                        propertySetters [propertyAccessor.Item1] = propertyAccessor.Item4;
                    }
                }
            }
            writer.WritePseudoProperties (propertyTypes, propertyGetters, propertySetters);
        }

        public static void WriteStruct (this TextWriter writer, StructInfo @struct,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @struct.GetFixupPath ();

            writer.WriteHeader (@struct.Namespace);
            writer.WriteLine ("\t[StructLayout (LayoutKind.Explicit)]");
            writer.Write ("\t{0}", fixupPath.GetAccessModifier ());
            writer.WriteLine ("struct {0}", @struct.Name);
            writer.WriteLine ("\t{");
            foreach (var constant in constants) {
                writer.WriteConstant (constant, @struct.Name);
            }
            foreach (var field in @struct.Fields) {
                writer.WriteField (field);
            }
            writer.WriteFunctions (@struct.Methods);
            writer.WriteFunctions (extraFunctions, @struct.Name);
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteUnion (this TextWriter writer, UnionInfo union,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = union.GetFixupPath ();
            writer.WriteHeader (union.Namespace);
            writer.WriteLine ("\t[StructLayout (LayoutKind.Explicit)] // union");
            writer.Write ("\t{0}", fixupPath.GetAccessModifier ());
            writer.WriteLine ("struct {0}", union.Name);
            writer.WriteLine ("\t{");
            foreach (var constant in constants) {
                writer.WriteConstant (constant, union.Name);
            }
            foreach (var field in union.Fields) {
                writer.WriteField (field);
            }
            writer.WriteFunctions (union.Methods);
            writer.WriteFunctions (extraFunctions, union.Name);
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        static readonly string[] keywords = {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
            "char", "checked", "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum", "event", "explicit",
            "extern", "false", "finally", "fixed", "float", "for", "foreach",
            "goto", "if", "implicit", "in", "int", "interface", "internal", "is",
            "lock", "long", "namespace", "new", "null", "object", "operator", "out",
            "override", "params", "private", "protected", "public", "readonly",
            "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc",
            "static", "string", "struct", "switch", "this", "throw", "true", "try",
            "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
            "virtual", "void", "volatile", "while"
        };

        public static bool IsKeyword (this string str)
        {
            return keywords.Contains (str);
        }

        public static string ToCamelCase (this string str)
        {
            str = str.ToLower ();
            int index;
            while ((index = str.IndexOf ("_", StringComparison.Ordinal)) >= 0) {
                if (index == str.Length - 1) {
                    str = str.Replace ("_", "");
                    break;
                }
                var oldChar = str [index + 1];
                str = str.Remove (index, 2);
                str = str.Insert (index, oldChar.ToString ().ToUpper ());
            }
            if (str.IsKeyword ()) {
                str = "@" + str;
            }
            return str;
        }

        public static string ToPascalCase (this string str)
        {
            if (string.IsNullOrWhiteSpace (str)) {
                throw new ArgumentException ("Can't have empty string", "str");
            }
            if (str == "_") {
                return str;
            }
            str = "_" + str;
            return str.ToCamelCase ();
        }
    }
}
