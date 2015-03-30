using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using GISharp.GI;
using TypeInfo = GISharp.GI.TypeInfo;

using Mono.Options;

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

        static void PrintHelpAndExit (OptionSet options, int exitCode = 0)
        {
            var writer = exitCode == 0 ? Console.Out : Console.Error;
            writer.WriteLine ("Usage: mono GICodeGen.exe [-n <namespace> | -h | -v]");
            writer.WriteLine ();
            options.WriteOptionDescriptions (writer);
            Environment.Exit (exitCode);
        }

        static void PrintVersionAndExit ()
        {
            var assembly = Assembly.GetExecutingAssembly ();
            var assemblyName = assembly.GetName ();
            Console.WriteLine ("{0} v{1}", assemblyName.Name, assemblyName.Version);
            Environment.Exit (0);
        }

        public static void Main (string[] args)
        {
            string namespaceName = null;
            string fixupFile = null;
            string outputDirectory = null;

            OptionSet options = null;
            options = new OptionSet () {
                {
                    "h|help",
                    "Print this message.",
                    v => PrintHelpAndExit (options)
                },
                {
                    "v|version",
                    "Print the program version infomation.",
                    v => PrintVersionAndExit ()
                },
                {
                    "n=|namespace=",
                    "The namespace to generate.",
                    v => namespaceName = v
                },
                {
                    "f=|fixup=",
                    "The name of the fixup.yaml file. By default '<namespace>.fixup.yaml' will be used.",
                    v => fixupFile = v
                },
                {
                    "o=|output=",
                    "The name of the output directory. By default './<namespace>/Generated' will be used.",
                    v => outputDirectory = v
                },
            };
            var extraArgs = options.Parse (args);
            if (namespaceName == null || extraArgs.Any ()) {
                Console.Error.WriteLine ("Bad arguments.");
                Console.Error.WriteLine ();
                PrintHelpAndExit (options, 1);
            }

            fixupFile = fixupFile ?? namespaceName + ".fixup.yaml";
            outputDirectory = outputDirectory ?? Path.Combine (namespaceName, "Generated");

            Console.WriteLine ("Generating files for namespace '{0}'.", namespaceName);
            Console.WriteLine ("Using fixup file '{0}'.", Path.GetFullPath (fixupFile));
            Console.WriteLine ("Placing generated files in '{0}'.", Path.GetFullPath (outputDirectory));

            using (var fs = File.OpenRead (fixupFile)) {
                using (var sr = new StreamReader (fs)) {
                    var deserializer = new Deserializer (namingConvention: new CamelCaseNamingConvention ());
                    fixup = deserializer.Deserialize<FixupDictionary> (sr);
                }
            }
            // if the file is empty, fixup will be null
            fixup = fixup ?? new FixupDictionary ();

            Directory.CreateDirectory (outputDirectory);
            Environment.CurrentDirectory = string.Format (outputDirectory);
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
                using (var fs = File.OpenWrite (info.Name + ".cs"))
                using (var cw = new CodeWriter (fs)) {
                    cw.WriteClass (info, constants, extraFunctions);
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

                using (var fs = File.OpenWrite (staticClassName + ".cs"))
                using (var cw = new CodeWriter (fs)) {
                    cw.WriteStaticClass (@namespace.Name, staticClassName, constants, functions);
                }
                infoPool.RemoveAll (i => constants.Contains (i as ConstantInfo));
                infoPool.RemoveAll (i => functions.Contains (i as FunctionInfo));
            }

            var generalConstants = infoPool.Where (i => i.InfoType == InfoType.Constant).Cast<ConstantInfo> ().ToList ();
            if (generalConstants.Any ()) {
                using (var fs = File.OpenWrite ("Constants.cs"))
                using (var cw = new CodeWriter (fs)) {
                    cw.WriteConstants (@namespace.SharedLibraries [0], generalConstants);
                }
            }
            infoPool.RemoveAll (i => generalConstants.Contains (i));

            var generalCallbacks = infoPool.Where (i => i.InfoType == InfoType.Callback).Cast<CallbackInfo> ().ToList ();
            if (generalCallbacks.Any ()) {
                using (var fs = File.OpenWrite ("Delegates.cs"))
                using (var sw = new CodeWriter (fs)) {
                    sw.WriteCallbacks (generalCallbacks);
                }
            }
            infoPool.RemoveAll (i => generalCallbacks.Contains (i));

            //var generalFunctions = infoPool.Where (i => i.InfoType == InfoType.Function).Cast<FunctionInfo> ().ToList ();

            Console.WriteLine ("Done!");

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

        public static void WriteHeader (this CodeWriter cw, string @namespace)
        {
            cw.WriteLine ("using System;");
            cw.WriteLine ("using System.Runtime.InteropServices;");
            cw.WriteLine ();
            cw.WriteLine ("namespace {0}.{1}", MainClass.parentNamespace, @namespace);
            cw.WriteLine ("{");
            cw.IncIndent ();
        }

        public static string GetAccessModifier (this string fixupPath)
        {
            var modifier = "public";
            try {
                modifier = MainClass.fixup[fixupPath]["access modifier"];
            } catch {
            }
            modifier = modifier.Replace ("private", "");
            if (modifier.Length > 0) {
                modifier += " ";
            }
            return modifier;
        }

        public static void WriteStaticClass (this CodeWriter cw, string @namespace,
            string name, List<ConstantInfo> constants, List<FunctionInfo> functions)
        {
            var fixupPath = string.Join (".", @namespace, "StaticClass", name);
            cw.WriteHeader (@namespace);
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.WriteLine ("static partial class {0}", name);
            cw.WriteLine ("{");
            cw.IncIndent ();
            foreach (var constant in constants) {
                cw.WriteConstant (constant, name);
            }
            cw.WriteFunctions (functions, name);
            cw.DecIndent ();
            cw.WriteLine ("}");

            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static void WriteObject (this CodeWriter cw, BaseInfo info,
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

        public static void WriteClass (this CodeWriter cw, BaseInfo info,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var @enum = info as EnumInfo;
            if (@enum != null) {
                if (constants.Count > 0) {
                    throw new Exception ("Enums can't have extra constants");
                }
                cw.WriteEnum (@enum, extraFunctions);
                return;
            }
            var @object = info as ObjectInfo;
            if (@object != null) {
                cw.WriteObject (@object, constants, extraFunctions);
                return;
            }
            var @struct = info as StructInfo;
            if (@struct != null) {
                if (@struct.IsOpaque ()) {
                    cw.WriteOpaque (@struct, constants, extraFunctions);
                } else {
                    cw.WriteStruct (@struct, constants, extraFunctions);
                }
                return;
            }
            var union = info as UnionInfo;
            if (union != null) {
                cw.WriteUnion (union, constants, extraFunctions);
                return;
            }
        }

        public static bool IsHidden (this string fixupPath)
        {
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("hidden");
            } catch {
                return false;
            }
        }

        public static List<string> GetExtras (this string fixupPath, string @namespace, string infoType)
        {
            var prefix = string.Join (".", @namespace, infoType, string.Empty);
            var items = MainClass.fixup
                .Where (i => i.Key.StartsWith (prefix, StringComparison.Ordinal) && i.Value.ContainsKey ("class") && i.Value ["class"] == fixupPath)
                .Select (i => i.Key.Remove (0, prefix.Length));
            return items.ToList ();
        }

        public static void WriteCallback (this CodeWriter cw, CallbackInfo callback, bool native = false)
        {
            var fixupPath = callback.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            if (callback.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.Write ("{0}", native ? "" : fixupPath.GetAccessModifier ());
            cw.Write ("delegate ");
            cw.WriteType (callback.ReturnTypeInfo);
            cw.Write (" {0}{1} (", callback.Name, native ? "Native" : "");
            cw.WriteArgs (callback.Args.ToList (), native);
            cw.WriteLine (");");
            cw.WriteLine ();
        }

        public static void WriteCallbacks (this CodeWriter cw, List<CallbackInfo> callbacks)
        {
            cw.WriteHeader (callbacks[0].Namespace);
            foreach (var callback in callbacks) {
                cw.WriteCallback (callback);
                cw.WriteCallback (callback, true);
            }
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static void WriteValue (this CodeWriter cw, ValueInfo value)
        {
            var fixupPath = value.GetFixupPath ();
            if (fixupPath.IsHidden ()) {
                return;
            }
            if (value.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.WriteLine ("{0} = {1},", value.Name.ToPascalCase (), value.Value);
        }

        public static string GetManagedName (this string fixupPath, string defaultValue)
        {
            if (MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("name"))) {
                return MainClass.fixup [fixupPath] ["name"];
            }
            return defaultValue;
        }

        public static void WriteConstant (this CodeWriter cw, ConstantInfo constant, string stripPrefix = null)
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
                cw.WriteLine ("[Obsolete]");
            }
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.Write ("const {0} {1} = ",
                constant.TypeInfo.ToManagedType (),
                constantName);

            Argument arg;
            constant.GetValue (out arg);
            switch (constant.TypeInfo.Tag) {
            case TypeTag.Boolean:
                cw.Write ("{0}", arg.Boolean ? "true" : "false");
                break;
            case TypeTag.Int8:
                cw.Write ("{0}", arg.Int8);
                break;
            case TypeTag.UInt8:
                cw.Write ("{0}", arg.UInt8);
                break;
            case TypeTag.Int16:
                cw.Write ("{0}", arg.Int16);
                break;
            case TypeTag.UInt16:
                cw.Write ("{0}", arg.UInt16);
                break;
            case TypeTag.Int32:
                cw.Write ("{0}", arg.Int32);
                break;
            case TypeTag.UInt32:
                cw.Write ("{0}", arg.UInt32);
                break;
            case TypeTag.Int64:
                cw.Write ("{0}", arg.Int64);
                break;
            case TypeTag.UInt64:
                cw.Write ("{0}", arg.UInt64);
                break;
            case TypeTag.Float:
                cw.Write ("{0}", arg.Float);
                break;
            case TypeTag.Double:
                cw.Write ("{0}", arg.Double);
                break;
            case TypeTag.UTF8:
                cw.Write ("\"{0}\"", arg.String.Escape ());
                break;
            }
            constant.FreeValue (ref arg);
            cw.WriteLine ("; // {0}", constant.Name);
            cw.WriteLine ();
        }

        public static string Escape (this string str)
        {
            str = str.Replace ("\\", @"\\");
            str = str.Replace ("\"", @"\""");
            str = str.Replace ("\n", @"\n");
            str = str.Replace ("\t", @"\t");
            return str;
        }

        public static void WriteConstants (this CodeWriter cw, string dllName, List<ConstantInfo> constants)
        {
            cw.WriteHeader (constants[0].Namespace);
            cw.WriteLine ("public static class Constants");
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("public const string ExternDllName = \"{0}\";", dllName);
            cw.WriteLine ();
            foreach (var constant in constants) {
                cw.WriteConstant (constant);
            }
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static void WriteEnum (this CodeWriter cw, EnumInfo @enum, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @enum.GetFixupPath ();
            cw.WriteHeader (@enum.Namespace);
            if (@enum.InfoType == InfoType.Flags) {
                cw.WriteLine ("[Flags]");
            }
            if (@enum.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.WriteLine ("{0}", fixupPath.GetAccessModifier ());
            cw.WriteLine ("enum {0} : {1}", @enum.Name, @enum.StorageType.ToBuiltInManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();
            foreach (var value in @enum.Values) {
                cw.WriteValue (value);
            }
            cw.DecIndent ();
            cw.WriteLine ("}");

            if (@enum.Methods.Count > 0 || extraFunctions.Count > 0) {
                cw.WriteLine ();
                cw.Write ("{0}", fixupPath.GetAccessModifier ());
                cw.WriteLine ("static class {0}Extensions", @enum.Name);
                cw.WriteLine ("{");
                cw.IncIndent ();
                cw.WriteFunctions (@enum.Methods);
                cw.WriteFunctions (extraFunctions, @enum.Name);
                cw.DecIndent ();
                cw.WriteLine ("}");
            }
            cw.DecIndent ();
            cw.WriteLine ("}");
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
                // special case for internal callback
                if (type.Interface.Namespace == "GLib" && type.Interface.Name == "DestroyNotify") {
                    return  MainClass.parentNamespace + ".Core.DestroyNotify";
                }
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
                case InfoType.Callback:
                    // Some structs have function pointers that are not defined at the top level Repository.GetInfos
                    // would be better to have actual delegates, but just using IntPtr for now.
                    return char.IsLower (type.Name, 0);
                case InfoType.Struct:
                    return (type.Interface as StructInfo).IsOpaque ();
                }
            } else if (type.Tag == TypeTag.Array) {
                return type.ArrayType != ArrayType.C;
            }
            return true;
        }

        public static void WriteType (this CodeWriter cw, TypeInfo type, bool forPinvoke = false)
        {
            if (forPinvoke && type.NeedsMarshal ()) {
                cw.Write ("IntPtr");
                return;
            }
            cw.Write ("{0}", type.ToManagedType ());
            if (forPinvoke && type.Tag == TypeTag.Interface && type.Interface.InfoType == InfoType.Callback) {
                cw.Write ("Native");
            }
        }

        public static void WriteField (this CodeWriter cw, GISharp.GI.FieldInfo field)
        {
            var fixupPath = field.GetFixupPath ();
            cw.WriteLine ("[FieldOffset({0})]", field.Offset);
            if (field.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            var marshalNeeded = !field.TypeInfo.NeedsMarshal ();

            cw.Write ("{0}", marshalNeeded ? "" : fixupPath.GetAccessModifier ());
            cw.WriteType (field.TypeInfo, true);
            cw.WriteLine (" {0};", marshalNeeded ? field.Name.ToCamelCase () : field.Name.ToPascalCase ());
            cw.WriteLine ();
            if (marshalNeeded) {
//        cw.WriteLine ("\tpublic ");
//        cw.WriteLine (field_type);
//        cw.WriteLine (" %s {\n", field.get_name ());
//        cw.WriteLine ("\t\tget {\n");
//        print_marshal_type_to_managed (field_type, field_name);
//        cw.WriteLine ("\t\t}\n");
//        cw.WriteLine ("\t\tset {\n");
//        print_marshal_type_from_managed (field_type, field_name, "value");
//        cw.WriteLine ("\t\t}\n");
//        cw.WriteLine ("\t}\n");
//        cw.WriteLine ("\n");
            }
        }

        public static void WriteArg (this CodeWriter cw, ArgInfo arg, bool forPinvoke = false)
        {
            if (arg.IsCallerAllocates) {
                throw new NotImplementedException ();
            }
            if (arg.IsReturnValue) {
                throw new NotImplementedException ();
            }
            if (arg.Direction == Direction.Inout) {
                cw.Write ("ref ");
            } else if (arg.Direction == Direction.Out) {
                cw.Write ("out ");
            }
            cw.WriteType (arg.TypeInfo, forPinvoke);
            cw.Write (" {0}", arg.Name.ToCamelCase ());
        }

        public static void FilterForManaged (this List<ArgInfo> args)
        {
            var closureArgs = args.Where (a => a.Closure >= 0).Select (a => args[a.Closure]);
            var destryoArgs = args.Where (a => a.Destroy >= 0).Select (a => args[a.Destroy]);
            var arrayLengthArgs = args.Where (a => a.TypeInfo.ArrayLength >= 0).Select (a => args[a.TypeInfo.ArrayLength]);
            foreach (var arg in closureArgs.Union (destryoArgs).Union (arrayLengthArgs).ToList ()) {
                args.Remove (arg);
            }
            // move args with default parameters to the end of the list
            foreach (var arg in args.ToList ()) {
                var fixupPath = arg.GetFixupPath ();
                if (fixupPath.GetDefaultValue () != null) {
                    args.Remove (arg);
                    args.Add (arg);
                }
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

        public static void WriteArgs (this CodeWriter cw, List<ArgInfo> args,
            bool forPinvoke = false, string suffix = null)
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
                cw.WriteArg (arg, forPinvoke);
                if (suffix != null) {
                    cw.Write (suffix);
                }
                if (!forPinvoke) {
                    var defaultValue = fixupPath.GetDefaultValue ();
                    if (defaultValue != null) {
                        cw.Write (" = {0}", defaultValue);
                    }
                }
                if (arg != lastArg) {
                    cw.Write (", ");
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

        public static void WritePInvoke (this CodeWriter cw, FunctionInfo function)
        {
            cw.WriteLine ("[DllImport ({0}.{1}.Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]", MainClass.parentNamespace, function.Namespace);
            cw.Write ("static extern ");
            cw.WriteType (function.ReturnTypeInfo, true);
            cw.Write (" {0} (", function.Symbol);
            if (function.IsMethod) {
                cw.Write ("IntPtr instance");
                if (function.Args.Any ()) {
                    cw.Write (", ");
                }
            }
            cw.WriteArgs (function.Args.ToList (), true);
            cw.WriteLine (");");
            cw.WriteLine ();
        }

        public static bool IsPInvokeOnly (this string fixupPath)
        {
            return MainClass.fixup.Any (f => f.Key == fixupPath && f.Value.ContainsKey ("pinvoke only"));
        }

        public static string WriteMarshalTypeFromManaged (this CodeWriter cw,
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
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.StringToUtf8Ptr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.Filename:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.StringToFilenamePtr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
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

        public static void WriteMarshalTypeToManaged (this CodeWriter cw,
            TypeInfo type, string unmanagedVarName, string managedVarName,
            Transfer transfer)
        {
            // basic types do not need to be marshalled.
            switch (type.Tag) {
            case TypeTag.GType:
                throw new NotImplementedException ();
            case TypeTag.UTF8:
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.Utf8PtrToString ({1});",
                    managedVarName, unmanagedVarName);
                if (transfer != Transfer.Nothing) {
                    cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                }
                break;
            case TypeTag.Filename:
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.FilenamePtrToString ({1});",
                    managedVarName, unmanagedVarName);
                if (transfer != Transfer.Nothing) {
                    cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
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
                    cw.Write ("var {0} = GISharp.Core.MarshalG.PtrTo{1}Opaque<",
                        managedVarName, isReferenceCounted ? "ReferenceCounted" : "");
                    cw.WriteType (type);
                    cw.WriteLine ("> ({0}, {1});",unmanagedVarName,
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

        public static void WriteNullCheck (this CodeWriter cw, ArgInfo arg)
        {
            if (arg.MayBeNull || !arg.TypeInfo.NeedsMarshal ()) {
                return;
            }
            var argName = arg.Name.ToCamelCase ();
            cw.WriteLine ("if ({0} == null) {{", argName);
            cw.IncIndent ();
            cw.WriteLine ("throw new ArgumentNullException (\"{0}\");", argName);
            cw.DecIndent ();
            cw.WriteLine ("}");
        }


        public static bool GetSkipProperty (this string fixupPath)
        {
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("no property");
            } catch (Exception) {
                return false;
            }
        }

        public static bool GetReturnsValue (this CallableInfo callable)
        {
            if (callable.ReturnTypeInfo.Tag == TypeTag.Void && !callable.ReturnTypeInfo.IsPointer) {
                //void functions don't return a value
                return false;
            }
            if (callable.SkipReturn) {
                // GI tells us to ignore the return value
                return false;
            }
            if (callable.Name == "ref") {
                // suppress the return value on reference functions
                return false;
            }
            return true;
        }

        public static void WriteMarshalInArg (this CodeWriter cw, ArgInfo arg,
            Dictionary<string, string> marshalledArgNames, List<Action> marshalledArgWriteFree)
        {
            if (arg.OwnershipTransfer != Transfer.Nothing) {
                throw new NotImplementedException ();
            }
            Action writeFree;
            marshalledArgNames [arg.Name] = cw.WriteMarshalTypeFromManaged (arg.TypeInfo, arg.Name.ToCamelCase (), out writeFree);
            if (writeFree != null) {
                // have to postpone writing the free statement until after calling the pinvoke function
                marshalledArgWriteFree.Add (writeFree);
            }
            if (arg.TypeInfo.ArrayLength >= 0) {
                var callable = arg.Container as CallableInfo;
                var lengthArg = callable.Args [arg.TypeInfo.ArrayLength];
                marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase ();
                cw.WriteLine ("var {0} = {1}.Length;",
                    marshalledArgNames [lengthArg.Name],
                    marshalledArgNames [arg.Name]);
            }
        }

        /// <summary>
        /// Writes the function.
        /// </summary>
        /// <returns>An Tuple with action to write a property getter/setter and
        /// a bool where <c>true</c> indicates that this is a getter (and
        /// <c>false</c> is a setter) or <c>null</c> if this is not a getter or
        /// setter.</returns>
        /// <param name="cw">cw.</param>
        /// <param name="function">Function.</param>
        /// <param name="stripPrefix">Strip prefix.</param>
        public static Tuple<string, bool, Action, Action> WriteFunction (this CodeWriter cw,
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

            cw.WritePInvoke (function);
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
                cw.WriteLine ("[Obsolete]");
            }

            if (function.InstanceOwnershipTransfer != Transfer.Nothing) {
                throw new NotImplementedException ();
            }
            if (opaqueVirtualMethods.Contains (functionName)) {
                cw.Write ("public override ");
            } else if (isGetter || isSetter) {
                cw.Write (""); // private
            } else {
                cw.Write ("{0}", fixupPath.GetAccessModifier ());
            }
            if (!function.IsMethod && !isConstructor) {
                cw.Write ("static ");
            }

            var returnType = function.ReturnTypeInfo;
            var returnsValue = !isConstructor && function.GetReturnsValue ();

            if (isConstructor) {
                cw.Write (returnType.Name);
            } else if (returnsValue) {
                cw.WriteType (returnType);
            } else {
                cw.Write ("void");
            }
            if (!isConstructor) {
                cw.Write (" {0}", functionName);
            }
            cw.Write (" (");
            cw.WriteArgs (function.Args.ToList ());
            cw.Write (")");
            if (isConstructor) {
                cw.Write (" : base (IntPtr.Zero)");
            }
            cw.WriteLine (" // {0}", function.Name);
            cw.WriteLine ("{");
            cw.IncIndent ();

            // write the function body

            Action<Dictionary<string, string>, string> writeInvoke = (marshalledArgNames, argSuffix) => {
                // Call the PInvoke function

                if (returnsValue) {
                    cw.Write ("var ret{0}{1} = ", returnType.NeedsMarshal () ? "Ptr" : "", argSuffix);
                } else if (isConstructor) {
                    cw.Write ("Handle = ");
                }
                cw.Write ("{0} (", function.Symbol);
                var lastArg = function.Args.LastOrDefault ();
                if (function.IsMethod) {
                    cw.Write ("Handle");
                    if (lastArg != null) {
                        cw.Write (", ");
                    }
                }
                if (lastArg != null) {
                    foreach (var arg in function.Args) {
                        if (arg.Direction == Direction.Inout) {
                            cw.Write ("ref ");
                        }
                        if (arg.Direction == Direction.Out) {
                            cw.Write ("out ");
                        }
                        cw.Write (marshalledArgNames [arg.Name]);
                        var @struct = arg.TypeInfo.Interface as StructInfo;
                        if (@struct != null && @struct.IsOpaque ()) {
                            cw.Write (" == null ? IntPtr.Zero : {0}.Handle", marshalledArgNames [arg.Name]);
                        }
                        if (arg != lastArg) {
                            cw.Write (", ");
                        }
                    }
                }
                cw.WriteLine (");");
            };

            cw.WriteCallableBody (function, writeInvoke, isConstructor, returnsValue);
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // generate property accessor for use later

            Tuple<string, bool, Action, Action> writeProperty = null;
            var propertyName = functionName.Remove (0, 3);
            if (isGetter) {
                writeProperty = new Tuple<string, bool, Action, Action> (
                    propertyName,
                    true,
                    () => {
                        cw.Write ("{0}", fixupPath.GetAccessModifier ());
                        if (!function.IsMethod) {
                            cw.Write ("static ");
                        }
                        cw.WriteType (function.ReturnTypeInfo);
                        cw.WriteLine (" {0} {{", propertyName);
                        cw.IncIndent ();
                    },
                    () => {
                        cw.WriteLine ("get {");
                        cw.IncIndent ();
                        cw.WriteLine ("return {0} ();", functionName);
                        cw.DecIndent ();
                        cw.WriteLine ("}");
                    });
            }
            if (isSetter) {
                writeProperty = new Tuple<string, bool, Action, Action> (
                    propertyName,
                    false,
                    () => {
                        cw.Write ("{0}", fixupPath.GetAccessModifier ());
                        if (!function.IsMethod) {
                            cw.Write ("static ");
                        }
                        cw.WriteType (function.Args[0].TypeInfo);
                        cw.WriteLine (" {0} {{", propertyName);
                        cw.IncIndent ();
                    },
                    () => {
                        cw.WriteLine ("set {");
                        cw.IncIndent ();
                        cw.WriteLine ("{0} (value);", functionName);
                        cw.DecIndent ();
                        cw.WriteLine ("}");
                    });
            }

            return writeProperty;
        }

        public static void WriteCallableBody (this CodeWriter cw, CallableInfo callable,
            Action<Dictionary<string, string>, string> writeInvoke,
            bool isConstructor, bool returnsValue, string argSuffix = "")
        {
            var managedArgs = callable.Args.ToList ();
            managedArgs.FilterForManaged ();

            // Do null argument checks
            foreach (var arg in managedArgs) {
                cw.WriteNullCheck (arg);
            }

            // Then marshal input args to unmanaged structures as needed

            var marshalledArgNames = new Dictionary<string, string> ();
            var marshalledArgWriteFree = new List<Action> ();

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.In || a.Direction == Direction.Inout)) {
                if (arg.OwnershipTransfer != Transfer.Nothing) {
                    throw new NotImplementedException ();
                }
                Action writeFree;
                marshalledArgNames [arg.Name] = cw.WriteMarshalTypeFromManaged (arg.TypeInfo, arg.Name.ToCamelCase () + argSuffix, out writeFree);
                if (writeFree != null) {
                    // have to postpone writing the free statement until after calling the pinvoke function
                    marshalledArgWriteFree.Add (writeFree);
                }
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = callable.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase () + argSuffix;
                    cw.WriteLine ("var {0} = {1}.Length;",
                        marshalledArgNames [lengthArg.Name],
                        marshalledArgNames [arg.Name]);
                }
            }

            // Declare any out args that need to be marshalled

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out)) {
                marshalledArgNames [arg.Name] = arg.Name.ToCamelCase () + argSuffix;
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = callable.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase () + argSuffix;
                    cw.WriteType (lengthArg.TypeInfo);
                    cw.WriteLine (" {0};", marshalledArgNames [lengthArg.Name]);
                }
            }

            // Implement callback function for closures

            var closureArgs = callable.Args.Where (a => a.Closure >= 0).Select (a => new Tuple<ArgInfo, ArgInfo> (a, callable.Args [a.Closure]));
            foreach (var args in closureArgs) {
                var arg = args.Item1;
                marshalledArgNames [arg.Name] = arg.Name.ToCamelCase () + argSuffix;
                var userDataArg = args.Item2;
                marshalledArgNames [userDataArg.Name] = userDataArg.Name.ToCamelCase () + argSuffix;

                // if we are implementing a callback, there is nothing to do here
                if (callable.InfoType == InfoType.Callback) {
                    continue;
                }

                // write the callback implementation

                marshalledArgNames [arg.Name] += "Wrapper";
                var callback = arg.TypeInfo.Interface as CallbackInfo;
                var managedCallbackArgName = arg.Name.ToCamelCase () + argSuffix;

                cw.WriteType (arg.TypeInfo, true);
                cw.Write (" {0} = (", marshalledArgNames[arg.Name]);
                // have to use a suffix to avoid naming conflicts with the outer function.
                cw.WriteArgs (callback.Args.ToList (), true, "_");
                cw.WriteLine (") => {");
                cw.IncIndent ();

                Action<Dictionary<string, string>, string> writeInvoke_ = (marshalledArgNames_, argSuffix_) => {
                    if (callback.GetReturnsValue ()) {
                        cw.Write ("var ret{0}{1} = ", "", argSuffix_);
                    }
                    cw.Write ("{0} (", managedCallbackArgName);
                    var invokeArgs = callback.Args.ToList ();
                    invokeArgs.FilterForManaged ();
                    var lastInvokeArg = invokeArgs.LastOrDefault ();
                    foreach (var invokeArg in invokeArgs) {
                        cw.Write (marshalledArgNames_[invokeArg.Name]);
                        if (invokeArg != lastInvokeArg) {
                            cw.Write (", ");
                        }
                    }
                    cw.WriteLine (");");
                };
                cw.WriteCallableBody (callback, writeInvoke_, false, callback.GetReturnsValue (), argSuffix + "_");
                cw.DecIndent ();
                cw.WriteLine ("};");
                cw.WriteLine ();

                // assign the GC handle of the callback to user_data

                if (userDataArg.TypeInfo.Tag != TypeTag.Void || !userDataArg.TypeInfo.IsPointer) {
                    // assuming that user_data is always void*
                    throw new NotImplementedException ();
                }
                cw.WriteLine ("var {0} = (IntPtr)GCHandle.Alloc ({1});",
                    marshalledArgNames [userDataArg.Name], managedCallbackArgName);

                // for now, just using the GISharp.Core.Default.DestroyNotify
                // instead of an individual imlementation for each function

                var destroyArg = callable.Args [arg.Destroy];
                marshalledArgNames [destroyArg.Name] = "GISharp.Core.Default.DestroyNotify";
            }

            // Write the native or callback invoker

            writeInvoke (marshalledArgNames, argSuffix);

            // handle ownership in constructor

            if (isConstructor) {
                if (callable.CallerOwns != Transfer.Everything) {
                    throw new NotImplementedException ();
                }
            }

            // Free any unmanged input args

            foreach (var writeFree in marshalledArgWriteFree) {
                writeFree ();
            }

            // Marshal output parameters as needed.

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out || a.Direction == Direction.Inout)) {
                cw.WriteMarshalTypeToManaged (arg.TypeInfo, marshalledArgNames[arg.Name], arg.Name.ToCamelCase () + argSuffix, arg.OwnershipTransfer);
//                if (arg.TypeInfo.ArrayLength >= 0) {
//                    var lengthArg = function.Args [arg.TypeInfo.ArrayLength];
//                    marshalledArgNames [lengthArg.Name] = lengthArg.Name.ToCamelCase ();
//                    cw.WriteLine ("{0} = {1}.Length;",
//                        marshalledArgNames [arg.Name],
//                        marshalledArgNames [lengthArg.Name]);
//                }
            }

            // return result if needed;

            if (returnsValue) {
                cw.WriteMarshalTypeToManaged (callable.ReturnTypeInfo, "retPtr" + argSuffix, "ret" + argSuffix, callable.CallerOwns);
                cw.WriteLine ("return ret{0};", argSuffix);
            }
        }

        public static void WriteOpaque (this CodeWriter cw, StructInfo @struct,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @struct.GetFixupPath ();
            var isReferenceCounted = @struct.IsReferenceCountedOpaque ();

            cw.WriteHeader (@struct.Namespace);
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.WriteLine ("partial class {0} : GISharp.Core.{1}Opaque",
               @struct.Name, isReferenceCounted ? "ReferenceCounted" : "");
            cw.WriteLine ("{");
            cw.IncIndent ();

            foreach (var constant in constants) {
                cw.WriteConstant (constant, @struct.Name);
            }

            // this constructor is called when marshalling
            cw.WriteLine ("public {0} (IntPtr handle) : base (handle)", @struct.Name);
            cw.WriteLine ("{");
            cw.WriteLine ("}");
            cw.WriteLine ();

            cw.WriteFunctions (@struct.Methods);
            cw.WriteFunctions (extraFunctions, @struct.Name);

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static void WritePseudoProperties (this CodeWriter cw,
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
                cw.DecIndent ();
                cw.WriteLine ("}");
                cw.WriteLine ();
            }
        }

        public static void WriteFunctions (this CodeWriter cw, IEnumerable<FunctionInfo> functions,
            string stripPrefix = null)
        {
            var propertyTypes = new Dictionary <string, Action> ();
            var propertyGetters = new Dictionary <string, Action> ();
            var propertySetters = new Dictionary <string, Action> ();

            foreach (var function in functions) {
                var propertyAccessor = cw.WriteFunction (function, stripPrefix);
                if (propertyAccessor != null) {
                    propertyTypes [propertyAccessor.Item1] = propertyAccessor.Item3;
                    if (propertyAccessor.Item2) {
                        propertyGetters [propertyAccessor.Item1] = propertyAccessor.Item4;
                    } else {
                        propertySetters [propertyAccessor.Item1] = propertyAccessor.Item4;
                    }
                }
            }
            cw.WritePseudoProperties (propertyTypes, propertyGetters, propertySetters);
        }

        public static void WriteStruct (this CodeWriter cw, StructInfo @struct,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @struct.GetFixupPath ();

            cw.WriteHeader (@struct.Namespace);
            cw.WriteLine ("[StructLayout (LayoutKind.Explicit)]");
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.WriteLine ("struct {0}", @struct.Name);
            cw.WriteLine ("{");
            cw.IncIndent ();
            foreach (var constant in constants) {
                cw.WriteConstant (constant, @struct.Name);
            }
            foreach (var field in @struct.Fields) {
                cw.WriteField (field);
            }
            cw.WriteFunctions (@struct.Methods);
            cw.WriteFunctions (extraFunctions, @struct.Name);
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static void WriteUnion (this CodeWriter cw, UnionInfo union,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = union.GetFixupPath ();
            cw.WriteHeader (union.Namespace);
            cw.WriteLine ("[StructLayout (LayoutKind.Explicit)] // union");
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.WriteLine ("struct {0}", union.Name);
            cw.WriteLine ("{");
            cw.IncIndent ();
            foreach (var constant in constants) {
                cw.WriteConstant (constant, union.Name);
            }
            foreach (var field in union.Fields) {
                cw.WriteField (field);
            }
            cw.WriteFunctions (union.Methods);
            cw.WriteFunctions (extraFunctions, union.Name);
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
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
