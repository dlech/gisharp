using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using GI;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using FixupDictionary = System.Collections.Generic.Dictionary<string,
System.Collections.Generic.Dictionary<string, string>>;

namespace GICodeGen
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
            var repo = Repository.Default;
            repo.Require (namespaceName, null, (RepositoryLoadFlags)0);
            var @namespace = repo.Namespaces [namespaceName];

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
                .Where (x => x.Key.StartsWith (@namespace.Name + ".") && x.Value.Keys.Contains ("class") && x.Value["class"].StartsWith (fixupPrefix))
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
                Console.Error.Write ("Unhandled top level '{0}.{1}.{2}", info.Namespace, info.InfoType, info.Name);
                var functionInfo = info as FunctionInfo;
                if (functionInfo != null) {
                    Console.Error.Write (" ({0})", functionInfo.Symbol);
                }
                Console.Error.WriteLine ();
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

        public static void WriteStaticClass (this TextWriter writer, string @namespace,
            string name, List<ConstantInfo> constants, List<FunctionInfo> functions)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @namespace);
            writer.WriteLine ("{");
            writer.WriteLine ("\tpublic static class {0}", name);
            writer.WriteLine ("\t{");
            foreach (var constant in constants) {
                writer.WriteConstant (constant, name);
            }
            foreach (var function in functions) {
                writer.WriteFunction (function, name);
            }
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteObject (this TextWriter writer, BaseInfo info, List<FunctionInfo> extraFunctions)
        {
            throw new NotImplementedException ();
        }

        public static void WriteClass (this TextWriter writer, BaseInfo info,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = info.GetFixupPath ();
            var @enum = info as EnumInfo;
            if (@enum != null) {
                writer.WriteEnum (@enum, extraFunctions);
                return;
            }
            var @object = info as ObjectInfo;
            if (@object != null) {
                writer.WriteObject (@object, extraFunctions);
                return;
            }
            var @struct = info as StructInfo;
            if (@struct != null) {
                if (@struct.Fields.Any () && !fixupPath.IsOpaque ()) {
                    writer.WriteStruct (@struct, extraFunctions);
                } else {
                    writer.WriteOpaque (@struct, extraFunctions);
                }
                return;
            }
            var union = info as UnionInfo;
            if (union != null) {
                writer.WriteUnion (union, extraFunctions);
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
                where i.Key.StartsWith (prefix) && i.Value.ContainsKey ("class") && i.Value ["class"] == fixupPath
                select i.Key.Remove (0, prefix.Length);
            return items.ToList ();
        }

        public static void WriteCallback (this TextWriter writer, CallbackInfo callback)
        {
            var fixupPath = callback.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            if (callback.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            writer.Write ("\tpublic delegate ");
            writer.WriteType (callback.ReturnTypeInfo);
            writer.Write (" {0} (", callback.Name);
            writer.WriteArgs (callback.Args.ToList ());
            writer.WriteLine (");");
            writer.WriteLine ();
        }

        public static void WriteCallbacks (this TextWriter writer, List<CallbackInfo> callbacks)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, callbacks.First ().Namespace);
            writer.WriteLine ("{");
            foreach (var callback in callbacks) {
                writer.WriteCallback (callback);
            }
            writer.WriteLine ("}");
        }

        public static void WriteValue (this TextWriter writer, ValueInfo value)
        {
            var container = value.Container;
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
            if (stripPrefix != null && constantName.StartsWith (stripPrefix)) {
                constantName = constantName.Remove (0, stripPrefix.Length);
            }
            constantName = fixupPath.GetManagedName (constantName);

            if (constant.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            writer.Write ("\t\tpublic const {0} {1} = ",
                constant.TypeInfo.Tag.ToManagedType (constant.TypeInfo.IsPointer), constantName);
            var arg = new Argument ();
            constant.GetValue (ref arg);
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
            writer.WriteLine ("using System;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, constants.First ().Namespace);
            writer.WriteLine ("{");
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
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @enum.Namespace);
            writer.WriteLine ("{");
            if (@enum.InfoType == InfoType.Flags) {
                writer.WriteLine ("\t[Flags]");
            }
            if (@enum.IsDeprecated) {
                writer.WriteLine ("\t[Obsolete]");
            }
            writer.WriteLine ("\tpublic enum {0} : {1}", @enum.Name, @enum.StorageType.ToManagedType ());
            writer.WriteLine ("\t{");
            foreach (var value in @enum.Values) {
                writer.WriteValue (value);
            }
            writer.WriteLine ("\t}");

            if (@enum.Methods.Count > 0 || extraFunctions.Count > 0) {
                writer.WriteLine ();
                writer.WriteLine ("\tpublic static class {0}Extensions", @enum.Name);
                writer.WriteLine ("\t{");
                foreach (var method in @enum.Methods) {
                    writer.WriteFunction (method);
                }
                foreach (var function in extraFunctions) {
                    writer.WriteFunction (function, @enum.Name);
                }
                writer.WriteLine ("\t}");
            }

            writer.WriteLine ("}");
        }

        public static string ToManagedType (this TypeTag tag, bool isPointer = false)
        {
            switch (tag) {
            case TypeTag.Void:
                if (isPointer) {
                    return "IntPtr";
                }
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
            case TypeTag.GType:
                return MainClass.parentNamespace + ".Runtime.GType";
            case TypeTag.UTF8:
            case TypeTag.Unichar:
                if (isPointer) {
                    return "string";
                }
                return "char";
            case TypeTag.Filename:
                return "System.IO.FileInfo";
            case TypeTag.Interface:
                return "object";
            case TypeTag.Array:
                return "System.Array";
            case TypeTag.GList:
            case TypeTag.GSList:
                return "System.Collections.List";
            case TypeTag.GHash:
                return "GLib.HashTable";
            default:
                return string.Format ("{0}", tag);
            }
        }

        public static void WriteType (this TextWriter writer, GI.TypeInfo type, bool forPinvoke = false)
        {
            if (type.IsPointer && type.Tag.IsBasicValueType () && type.Tag != TypeTag.Void) {
                var x = 0;
            }
            if (forPinvoke && (type.IsPointer || !type.Tag.IsBasicValueType ())) {
                writer.Write ("IntPtr");
                return;
            }
            if (type.Tag == TypeTag.Interface) {
                writer.Write ("{0}.{1}", type.Interface.Namespace, type.Interface.Name);
            } else {
                writer.Write ("{0}", type.Tag.ToManagedType (type.IsPointer));
            }
        }

        public static void WriteField (this TextWriter writer, GI.FieldInfo field)
        {
            writer.WriteLine ("\t\t[FieldOffset({0})]", field.Offset);
            if (field.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            var marshalNeeded = !field.TypeInfo.Tag.IsBasicValueType ();

            writer.Write ("\t\t{0} ", marshalNeeded ? "private" : "public");
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
            if (arg.Direction == Direction.Inout) {
                writer.Write ("ref ");
            } else if (arg.Direction == Direction.Out || arg.IsReturnValue) {
                writer.Write ("out ");
            }
            writer.WriteType (arg.TypeInfo, forPinvoke);
            writer.Write (" {0}", arg.Name.ToCamelCase ());
        }

        public static void WriteArgs (this TextWriter writer, List<ArgInfo> args, bool forPinvoke = false)
        {
            if (args.Count == 0) {
                return;
            }
            var lastArg = args [args.Count - 1];
            foreach (var arg in args) {
                writer.WriteArg (arg, forPinvoke);
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
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("static_constructor"));
        }

        static readonly string[] opaqueVirtualMethods = {
            "Ref",
            "Unref",
            "Copy",
            "Free"
        };

        public static void WritePInvoke (this TextWriter writer, FunctionInfo function)
        {
            writer.WriteLine ("\t\t[DllImport ({0}.{1}.Constants.ExternDllName)]", MainClass.parentNamespace, function.Namespace);
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
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("pinvoke_only"));
        }

        public static void WriteFunction (this TextWriter writer, FunctionInfo function, string stripPrefix = null)
        {
            var container = function.Container;
            var fixupPath = function.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            var functionName = function.Name.ToPascalCase ();
            if (stripPrefix != null && functionName.StartsWith (stripPrefix)) {
                functionName = functionName.Remove (0, stripPrefix.Length);
            }
            functionName = fixupPath.GetManagedName (functionName);

            writer.WritePInvoke (function);
            if (fixupPath.IsPInvokeOnly ()) {
                return;
            }

            var isConstructor = function.IsConstructor && !fixupPath.IsStaticConstructor ();

            if (function.IsDeprecated) {
                writer.WriteLine ("\t\t[Obsolete]");
            }
            if (function.IsMethod) {
                if (opaqueVirtualMethods.Contains (functionName)) {
                    writer.Write ("\t\tprotected override ");
                } else if (function.IsGetter || function.IsSetter) {
                    writer.Write ("\t\tprotected ");
                } else {
                    writer.Write ("\t\tpublic ");
                }
            } else {
                if (isConstructor) {
                    writer.Write ("\t\tpublic ");
                } else {
                    writer.Write ("\t\tpublic static ");
                }
            }

            var returnType = function.ReturnTypeInfo;

            if (isConstructor) {
                writer.Write (returnType.Name);
            } else {
                writer.WriteType (returnType);
                writer.Write (" {0}", functionName);
            }
            writer.Write (" (");
            writer.WriteArgs (function.Args.ToList ());
            writer.WriteLine (") // {0}", function.Name);
            writer.WriteLine ("\t\t{");

            // TODO: check IsCallerAllocates and handle accordingly
            foreach (var arg in function.Args) {
                if (arg.Direction == Direction.Out || arg.IsReturnValue) {
                    writer.Write ("\t\t\t{0} = default(", arg.Name.ToCamelCase ());
                    writer.WriteType (arg.TypeInfo);
                    writer.WriteLine (");");
                }
            }

            // TODO: marshall args as needed
            foreach (var arg in function.Args) {
                if (!arg.TypeInfo.Tag.IsBasicValueType ()) {
                    writer.WriteLine ("\t\t\tIntPtr {0}Ptr = IntPtr.Zero;", arg.Name.ToCamelCase ());
                }
            }

            if (isConstructor || (returnType.Tag == TypeTag.Void && !returnType.IsPointer)) {
                // don't do anything
            } else if (!returnType.IsPointer && returnType.Tag.IsBasicValueType ()) {
                // we can return directly
                writer.Write ("\t\t\treturn {0} (", function.Symbol);
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
                        if (arg.Direction == Direction.Out || arg.IsReturnValue) {
                            writer.Write ("out ");
                        }
                        writer.Write (arg.Name.ToCamelCase ());
                        if (!arg.TypeInfo.Tag.IsBasicValueType ()) {
                            writer.Write ("Ptr");
                        }
                        if (arg != lastArg) {
                            writer.Write (", ");
                        }
                    }
                }
                writer.WriteLine (");");
            } else if (returnType.IsPointer || returnType.Tag != TypeTag.Void) {
                // TODO: marshal return value
                writer.Write ("\t\t\treturn default(");
                writer.WriteType (returnType);
                writer.WriteLine (");");
            }
            writer.WriteLine ("\t\t}");
            writer.WriteLine ();
        }

        public static void WriteOpaque (this TextWriter writer, StructInfo @struct, List<FunctionInfo> extraFunctions)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @struct.Namespace);
            writer.WriteLine ("{");
            if (@struct.Fields.Any ()) {
                writer.WriteLine ("\t[StructLayout (LayoutKind.Explicit)]");
            }
            writer.WriteLine ("\tpublic class {2} : {0}.Runtime.Opaque<{1}.{2}>", MainClass.parentNamespace, @struct.Namespace, @struct.Name);
            writer.WriteLine ("\t{");
            writer.WriteLine ("\t\tprotected {0} (IntPtr handle, bool ownsHandle) : base (handle, ownsHandle)", @struct.Name);
            writer.WriteLine ("\t\t{");
            writer.WriteLine ("\t\t}");
            writer.WriteLine ();
            writer.WriteLine ();
            foreach (var field in @struct.Fields) {
                writer.WriteField (field);
            }
            foreach (var method in @struct.Methods) {
                writer.WriteFunction (method);
            }
            foreach (var function in extraFunctions) {
                writer.WriteFunction (function, @struct.Name);
            }
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteStruct (this TextWriter writer, StructInfo @struct, List<FunctionInfo> extraFunctions)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @struct.Namespace);
            writer.WriteLine ("{");
            writer.WriteLine ("\t[StructLayout (LayoutKind.Explicit)]");
            writer.WriteLine ("\tpublic struct {0}", @struct.Name);
            writer.WriteLine ("\t{");
            foreach (var field in @struct.Fields) {
                writer.WriteField (field);
            }
            writer.WriteLine ();
            foreach (var method in @struct.Methods) {
                writer.WriteFunction (method);
            }
            foreach (var function in extraFunctions) {
                writer.WriteFunction (function, @struct.Name);
            }
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }

        public static void WriteUnion (this TextWriter writer, UnionInfo union, List<FunctionInfo> extraFunctions)
        {
            writer.WriteLine ("using System;");
            writer.WriteLine ("using System.Runtime.InteropServices;");
            writer.WriteLine ();
            writer.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, union.Namespace);
            writer.WriteLine ("{");
            writer.WriteLine ("\t[StructLayout (LayoutKind.Explicit)] // union");
            // TODO: Figure out when to use Opaque and when to use struct
            writer.WriteLine ("\tpublic struct {0}", union.Name);
            writer.WriteLine ("\t{");
            writer.WriteLine ();
            foreach (var field in union.Fields) {
                writer.WriteField (field);
            }
            writer.WriteLine ();
            foreach (var method in union.Methods) {
                writer.WriteFunction (method);
            }
            foreach (var function in extraFunctions) {
                writer.WriteFunction (function, union.Name);
            }
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
            while ((index = str.IndexOf ("_")) >= 0) {
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
                //throw new ArgumentException ("Can't have empty string", "str");
            }
            if (str == "_") {
                return str;
            }
            str = "_" + str;
            return str.ToCamelCase ();
        }
    }
}
