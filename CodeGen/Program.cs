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
                if (info.IsHidden ()) {
                    infoPool.Remove (info);
                    continue;
                }
                // this means we are just handling Enum, Object, Struct and Union
                var methodContainer = info as IMethodContainer;
                if (methodContainer == null) {
                    continue;
                }
                var fixupPath = info.GetFixupPath ();
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
                .Where (x => x.Key.StartsWith (@namespace.Name + ".", StringComparison.Ordinal)
                    && x.Value != null && x.Value.Keys.Contains ("class") && x.Value["class"].StartsWith (fixupPrefix))
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

        public static void WriteObject (this CodeWriter cw, ObjectInfo @object,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            cw.WriteHeader (@object.Namespace);
            if (@object.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.WriteLine ("public class {0} : GISharp.Core.GObject", @object.Name);
            cw.WriteLine ("{");
            cw.IncIndent ();

            cw.WriteLine ("public {0} (IntPtr handle) : base (handle)", @object.Name);
            cw.WriteLine ("{");
            cw.WriteLine ("}");
            cw.WriteLine ();

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static bool IsFunctionNamed (this FunctionInfo function, string name)
        {
            string functionName;
            try {
                var fixupPath = function.GetFixupPath ();
                functionName = MainClass.fixup[fixupPath]["name"].ToLower ();
            } catch {
                functionName = function.Name;
            }
            return functionName == name;
        }

        public static bool IsRefFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("ref")
                && function.IsMethod
                && function.Args.Count == 0;
        }

        public static bool IsUnrefFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("unref")
                && function.IsMethod
                && function.Args.Count == 0;
        }

        public static bool IsReferenceCountedOpaque (this StructInfo @struct)
        {
            return @struct.Methods.Any (m => m.IsRefFunction ())
                && @struct.Methods.Any (m => m.IsUnrefFunction ());
        }

        public static bool IsCopyFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("copy")
                && function.IsMethod
                && function.Args.Count == 0;
        }

        public static bool IsFreeFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("free")
                && function.IsMethod
                && function.Args.Count == 0;
        }

        public static bool IsOwnedOpaque (this StructInfo @struct)
        {
            var fixupPath = @struct.GetFixupPath ();
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("owned");
            } catch {
                return @struct.Methods.Any (m => m.IsCopyFunction ())
                   && @struct.Methods.Any (m => m.IsFreeFunction ());
            }
        }

        public static bool IsStaticOpaque (this StructInfo @struct)
        {
            try {
                var newMethod = @struct.Methods.Single (m => m.Name == "new");
                return  newMethod.CallerOwns == Transfer.Nothing;
            } catch {
                return false;
            }
        }

        public static bool IsOpaque (this StructInfo @struct)
        {
            return !@struct.Fields.Any ()
                || @struct.IsReferenceCountedOpaque ()
                || @struct.IsStaticOpaque ()
                || @struct.IsOwnedOpaque ();
        }

        public static bool IsEqualFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("equal")
                && function.IsMethod
                && function.Args.Count == 1;
        }

        public static bool IsCompareFunction (this FunctionInfo function)
        {
            return function.IsFunctionNamed ("compare")
                && function.IsMethod
                && function.Args.Count == 1;
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
            var @interface = info as InterfaceInfo;
            if (@interface != null) {
                cw.WriteInterface (@interface);
            }
        }

        public static void WriteInterface (this CodeWriter cw, InterfaceInfo @interface)
        {
            cw.WriteHeader (@interface.Namespace);
            if (@interface.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.WriteLine ("public interface {0}", @interface.Name);
            cw.WriteLine ("{");
            cw.IncIndent ();

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.DecIndent ();
            cw.WriteLine ("}");
        }

        public static bool IsHidden (this BaseInfo info)
        {
            var fixupPath = info.GetFixupPath ();
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
            if (callback.IsHidden ()) {
                return;
            }
            if (callback.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
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
            if (value.IsHidden ()) {
                return;
            }
            if (value.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.WriteLine ("{0} = {1},", value.GetFixedUpName (ToPascalCase), value.Value);
        }

        public static string GetManagedName (this string fixupPath, string defaultValue)
        {
            try {
                return MainClass.fixup [fixupPath] ["name"];
            } catch {
                return defaultValue;
            }
        }

        public static void WriteConstant (this CodeWriter cw, ConstantInfo constant, string stripPrefix = null)
        {
            if (constant.IsHidden ()) {
                return;
            }

            var constantName = constant.GetFixedUpName (ToPascalCase);
            if (stripPrefix != null && constantName.StartsWith (stripPrefix, StringComparison.Ordinal)) {
                constantName = constantName.Remove (0, stripPrefix.Length);
            }
            var fixupPath = constant.GetFixupPath ();
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
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
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

        public static string ToBuiltInManagedType (this TypeTag tag, bool isPointer = false)
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
            case TypeTag.Unichar:
                if (isPointer) {
                    return "string";
                }
                return "char";
            }
            throw new ArgumentException ("Must be a basic type.", "tag");
        }

        public static string ToManagedType (this TypeInfo type)
        {
            if (type.Tag.IsBasicValueType ()) {
                return type.Tag.ToBuiltInManagedType (type.IsPointer);
            }
            switch (type.Tag) {
            case TypeTag.GType:
                return "GISharp.Core.GType";
            case TypeTag.UTF8:
            case TypeTag.Filename:
                if (type.IsPointer) {
                    return "string";
                }
                return "char";
            case TypeTag.Interface:
                // special case for internal callback
                if (type.Interface.Namespace == "GLib" && type.Interface.Name == "DestroyNotify") {
                    return  MainClass.parentNamespace + ".Core.DestroyNotify";
                }
                // special case for GObject
                if (type.Interface.Namespace == "GObject" && type.Interface.Name == "Object") {
                    return MainClass.parentNamespace + ".Core.GObject";
                }
                // special case for GType
                if (type.Interface.Namespace == "GObject" && type.Interface.Name == "GType") {
                    return MainClass.parentNamespace + ".Core.GType";
                }
                return string.Join (".", MainClass.parentNamespace, type.Interface.Namespace, type.Interface.Name);
            case TypeTag.Array:
                return type.GetParamType (0).ToManagedType () + "[]";
            case TypeTag.GList:
            case TypeTag.GSList:
                return "System.Collections.IList";
            case TypeTag.GHash:
                return "System.Collections.IDictionary";
            case TypeTag.Error:
                return "GISharp.Core.GErrorException";
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
                return !type.IsLPArray ();
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
            cw.WriteLine (" {0};", marshalNeeded ? field.GetFixedUpName (ToCamelCase) : field.GetFixedUpName (ToPascalCase));
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

        /// <summary>
        /// Writes the parameter modifier ("ref" or "out") for an argument if needed.
        /// </summary>
        /// <param name="cw">Code writer</param>
        /// <param name="arg">Argument info.</param>
        public static void WriteParameterModifier (this CodeWriter cw, ArgInfo arg)
        {
            if (arg.Direction == Direction.Inout
                || (arg.TypeInfo.Tag.IsBasicValueType () && arg.TypeInfo.Tag != TypeTag.Void && arg.TypeInfo.IsPointer))
            {
                cw.Write ("ref ");
            } else if (arg.Direction == Direction.Out) {
                cw.Write ("out ");
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
            if (forPinvoke && arg.TypeInfo.IsLPArray ()) {
                cw.Write ("[MarshalAs (UnmanagedType.LPArray)]");
            }
            cw.WriteParameterModifier (arg);
            cw.WriteType (arg.TypeInfo, forPinvoke);
            cw.Write (" {0}", arg.GetFixedUpName (ToCamelCase));
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
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("static constructor");
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Determines if type can be marshaled using UnamagedType.LPArray.
        /// </summary>
        /// <returns><c>true</c> if is LP array the specified type; otherwise, <c>false</c>.</returns>
        /// <param name="type">Type.</param>
        public static bool IsLPArray (this TypeInfo type)
        {
            if (type.Tag != TypeTag.Array) {
                return false;
            }
            if (type.ArrayType != ArrayType.C) {
                return false;
            }
            if (type.IsZeroTerminated) {
                return false;
            }
            if (type.GetParamType (0).NeedsMarshal ()) {
                return false;
            }
            return true;
        }

        public static void WritePInvoke (this CodeWriter cw, FunctionInfo function)
        {
            var returnType = function.ReturnTypeInfo;
            cw.WriteLine ("[DllImport ({0}.{1}.Constants.ExternDllName, CallingConvention = CallingConvention.Cdecl)]", MainClass.parentNamespace, function.Namespace);
            if (returnType.IsLPArray ()) {
                cw.Write ("[return: MarshalAs (UnmanagedType.LPArray");
                if (returnType.ArrayFixedSize >= 0) {
                    cw.Write (", SizeConst = {0}", returnType.ArrayFixedSize);
                }
                if (returnType.ArrayLength >= 0) {
                    cw.Write (", SizeParamIndex = {0}", returnType.ArrayLength);
                }
                cw.WriteLine (")]");
            }
            cw.Write ("static extern ");
            cw.WriteType (returnType, true);
            cw.Write (" {0} (", function.Symbol);
            if (function.IsMethod) {
                cw.Write ("IntPtr self");
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
            try {
                return MainClass.fixup[fixupPath].ContainsKey ("pinvoke only");
            } catch {
                return false;
            }
        }

        public static string WriteMarshalTypeFromManaged (this CodeWriter cw,
            TypeInfo type, string managedVarName, Transfer transfer, out Action writeFree)
        {
            string unmanagedVarName = managedVarName;
            writeFree = null;

            // basic types and interfaces do not need to be marshalled.
            switch (type.Tag) {
            case TypeTag.GType:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = {1}.Handle;", unmanagedVarName, managedVarName);
                break;
            case TypeTag.UTF8:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.StringToUtf8Ptr ({1});", unmanagedVarName, managedVarName);
                if (transfer == Transfer.Nothing) {
                    writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                }
                break;
            case TypeTag.Filename:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.StringToFilenamePtr ({1});", unmanagedVarName, managedVarName);
                if (transfer == Transfer.Nothing) {
                    writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                }
                break;
            case TypeTag.Array:
                if (type.IsLPArray ()) {
                    // array does not need to be manually marshaled
                    break;
                }
                if (type.ArrayType == ArrayType.C) {
                    if (type.GetParamType (0).Tag == TypeTag.UInt8 && type.IsZeroTerminated) {
                        // this is a CString with unspecified encoding
                        unmanagedVarName += "Ptr";
                        cw.WriteLine ("var {0} = GISharp.Core.MarshalG.ByteStringToPtr ({1});", unmanagedVarName, managedVarName);
                        if (transfer == Transfer.Nothing) {
                            writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                        }
                        break;
                    }
                    if (type.GetParamType (0).Tag == TypeTag.UTF8 && type.IsZeroTerminated) {
                        // This is a GStrv (null terminated UTF8 string array)
                        unmanagedVarName += "Ptr";
                        cw.WriteLine ("var {0} = GISharp.Core.MarshalG.StringArrayToGStrvPtr ({1});", unmanagedVarName, managedVarName);
                        if (transfer == Transfer.Nothing) {
                            writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.FreeGStrv ({0});", unmanagedVarName);
                        } else if (transfer == Transfer.Container) {
                            throw new NotImplementedException ();
                        }
                        break;
                    }
                    if (type.GetParamType (0).NeedsMarshal ()) {
                        // for arrays with elements that need to be marshaled, iterate the array
                        // and marshal each element individually.
                        unmanagedVarName += "Ptr";
                        cw.WriteLine ("var {0} = IntPtr.Zero;", unmanagedVarName);
                        var elementPtrsName = managedVarName + "ElementPtrs";
                        if (transfer == Transfer.Nothing) {
                            cw.WriteLine ("var {0} = new System.Collections.Generic.List<IntPtr> ();", elementPtrsName);
                        }
                        cw.WriteLine ("if ({0} != null) {{", managedVarName);
                        cw.IncIndent ();
                        if (type.ArrayFixedSize >= 0) {
                            cw.WriteLine ("if ({0}.Length != {1}) {{", managedVarName, type.ArrayFixedSize);
                            cw.IncIndent ();
                            cw.WriteLine ("var message = string.Format (\"Expected array with Length {0} but was {{0}}.\", {1}.Length);",
                                type.ArrayFixedSize, managedVarName);
                            cw.WriteLine ("throw new ArgumentException (message, \"{0}\");", managedVarName);
                            cw.DecIndent ();
                            cw.WriteLine ("}");
                        }
                        cw.WriteLine ("{0} = GISharp.Core.MarshalG.Alloc ({1}.Length * IntPtr.Size);",
                            unmanagedVarName, managedVarName);
                        cw.WriteLine ("var offset = 0;");
                        var managedElementName = managedVarName + "Element";
                        cw.WriteLine ("foreach (var {0} in {1}) {{", managedElementName, managedVarName);
                        cw.IncIndent ();
                        Action writeElementFree;
                        cw.WriteMarshalTypeFromManaged (type.GetParamType (0), managedElementName,
                            transfer == Transfer.Container ? Transfer.Nothing : transfer, out writeElementFree);
                        cw.WriteLine ("Marshal.WriteIntPtr ({0}, offset, {1});",
                            unmanagedVarName, managedElementName + "Ptr");
                        if (transfer == Transfer.Nothing) {
                            cw.WriteLine ("{0}.Add ({1});", elementPtrsName, managedElementName + "Ptr");
                        }
                        cw.WriteLine ("offset += IntPtr.Size;");
                        cw.DecIndent ();
                        cw.WriteLine ("}");
                        cw.DecIndent ();
                        cw.WriteLine ("}");
                        if (transfer != Transfer.Everything) {
                            writeFree = () => {
                                cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                                if (transfer != Transfer.Container && writeElementFree != null) {
                                    cw.WriteLine ("foreach (var {0} in {1}) {{", managedElementName + "Ptr", elementPtrsName);
                                    cw.IncIndent ();
                                    writeElementFree ();
                                    cw.DecIndent ();
                                    cw.WriteLine ("}");
                                }
                            };
                        }
                        break;
                    }
                }
                throw new NotImplementedException ();
            case TypeTag.Interface:
                var @enum = type.Interface as EnumInfo;
                if (@enum != null) {
                    // enums/flags are passed directly
                    break;
                }
                var callback = type.Interface as CallableInfo;
                if (callback != null) {
                    // callabacks are handled seperately
                    break;
                }
                var @struct = type.Interface as StructInfo;
                if (@struct != null) {
                    if (@struct.IsOpaque ()) {
                        unmanagedVarName += "Ptr";
                        cw.WriteLine ("var {0} = {1} == null ? IntPtr.Zero : {1}.Handle;", unmanagedVarName, managedVarName);
                    }
                    // managed struct types are passed directly
                    break;
                }
                var @object = type.Interface as ObjectInfo;
                if (@object != null) {
                    unmanagedVarName += "Ptr";
                    cw.WriteLine ("var {0} = {1} == null ? IntPtr.Zero : {1}.Handle;", unmanagedVarName, managedVarName);
                    break;
                }
                var @interface = type.Interface as InterfaceInfo;
                if (@interface != null) {
                    unmanagedVarName += "Ptr";
                    cw.WriteLine ("var {0} = {1} == null ? IntPtr.Zero : {1}.Handle;", unmanagedVarName, managedVarName);
                    break;
                }
                throw new NotImplementedException ();
            case TypeTag.GList:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.GListToPtr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.GSList:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.GSListToPtr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.GHash:
                unmanagedVarName += "Ptr";
                cw.WriteLine ("var {0} = GISharp.Core.MarshalG.GHashToPtr ({1});", unmanagedVarName, managedVarName);
                writeFree = () => cw.WriteLine ("GISharp.Core.MarshalG.Free ({0});", unmanagedVarName);
                break;
            case TypeTag.Error:
                unmanagedVarName += ".Handle";
                break;
            }
            return unmanagedVarName;
        }

        public static void WriteMarshalTypeToManaged (this CodeWriter cw,
            TypeInfo type, string unmanagedVarName, string managedVarName,
            bool managedVarExists, Transfer transfer)
        {
            string marshalExpression = null;

            // basic types do not need to be marshalled.
            switch (type.Tag) {
            case TypeTag.GType:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGType ({0})", unmanagedVarName);
                break;
            case TypeTag.UTF8:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.Utf8PtrToString ({0}, freePtr: {1})",
                    unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true");
                break;
            case TypeTag.Filename:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.FilenamePtrToString ({0}, freePtr: {1})",
                    unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true");
                break;
            case TypeTag.Array:
                if (type.IsLPArray ()) {
                    // array can be passed directly
                    return;
                }
                if (type.ArrayType == ArrayType.C) {
                    if (type.GetParamType (0).Tag == TypeTag.UInt8 && type.IsZeroTerminated) {
                        // This is a C string with unspecified encoding
                        marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToByteString ({0}, freePtr: {1})",
                            unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true");
                        break;
                    }
                    if (type.IsZeroTerminated) {
                        if (type.GetParamType (0).Tag == TypeTag.UTF8) {
                            marshalExpression = string.Format ("GISharp.Core.MarshalG.GStrvPtrToStringArray ({0}, freePtr: {1}, freeElements: {2})",
                                unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true",
                                transfer == Transfer.Everything ? "true" : "false");
                            break;
                        }
                    } else {
                        // TODO: implement this properly
                        marshalExpression = string.Format ("new {0}[0]", type.GetParamType(0).ToManagedType ());
                        break;
                    }
                }
                throw new NotImplementedException ();
            case TypeTag.Interface:
                var @enum = type.Interface as EnumInfo;
                if (@enum != null) {
                    // enums/flags are passed directly
                    return;
                }
                var @struct = type.Interface as StructInfo;
                if (@struct != null) {
                    if (@struct.IsOpaque ()) {
                        var isReferenceCounted = @struct.IsReferenceCountedOpaque ();
                        var isStaticOpaque = @struct.IsStaticOpaque ();
                        var isOwnedOpaque = @struct.IsOwnedOpaque ();
                        marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrTo{0}{1}{2}Opaque<{3}> ({4}, {5})",
                            isReferenceCounted ? "ReferenceCounted" : "",
                            isOwnedOpaque ? "Owned" : "",
                            isStaticOpaque ? "Static" : "",
                            type.ToManagedType (),
                            unmanagedVarName,
                            transfer == Transfer.Nothing ? "false" : "true");
                        break;
                    }
                    // managed struct types are passed directly
                    return;
                }
                var @object = type.Interface as ObjectInfo;
                if (@object != null) {
                    marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGObject<{0}> ({1}, {2})",
                        type.ToManagedType (), unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true");
                    break;
                }
                var @interface = type.Interface as InterfaceInfo;
                if (@interface != null) {
                    marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGObjectInterface<{0}> ({1}, {2})",
                        type.ToManagedType (), unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true");
                    break;
                }
                var type_ = type.Interface as TypeInfo;
                if (type_ != null) {
                    marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGType<{0}> ({1})",
                        type.ToManagedType (), unmanagedVarName);
                    break;
                }
                throw new NotImplementedException ();
            case TypeTag.GList:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGList<{0}> ({1}, {2}, {3})",
                    type.ToManagedType (), unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true",
                    transfer == Transfer.Everything ? "true" : "false");
                break;
            case TypeTag.GSList:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGSList<{0}> ({1}, {2}, {3})",
                    type.ToManagedType (), unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true",
                    transfer == Transfer.Everything ? "true" : "false");
                break;
            case TypeTag.GHash:
                marshalExpression = string.Format ("GISharp.Core.MarshalG.PtrToGHash<{0}> ({1}, {2}, {3})",
                    type.ToManagedType (), unmanagedVarName, transfer == Transfer.Nothing ? "false" : "true",
                    transfer == Transfer.Everything ? "true" : "false");
                break;
            case TypeTag.Error:
                throw new NotImplementedException ();
            default:
                // basic types are passed directly
                return;
            }
            if (marshalExpression == null) {
                throw new NotImplementedException ();
            }
            cw.WriteLine ("{0}{1} = {2};", managedVarExists ? "" : "var ", managedVarName, marshalExpression);
        }

        public static void WriteNullCheck (this CodeWriter cw, ArgInfo arg)
        {
            if (arg.MayBeNull || arg.Direction == Direction.Out || !arg.TypeInfo.NeedsMarshal ()) {
                return;
            }
            var argName = arg.GetFixedUpName (ToCamelCase);
            cw.WriteLine ("if ({0} == null) {{", argName);
            cw.IncIndent ();
            var function = arg.Container as FunctionInfo;
            if (function != null && function.IsEqualFunction ()) {
                cw.WriteLine ("return false;");
            } else {
                cw.WriteLine ("throw new ArgumentNullException (\"{0}\");", argName);
            }
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

        public static string GetFixedUpName (this BaseInfo info, Func<string, string> convertFunc = null)
        {
            var fixupPath = info.GetFixupPath ();
            if (convertFunc == null) {
                convertFunc = (s) => s;
            }
            var function = info as FunctionInfo;
            if (function != null) {
                if (function.IsEqualFunction ()) {
                    return "Equals"; // to implement IEquatable<T>
                }
                if (function.IsCompareFunction ()) {
                    return "CompareTo"; // to implement IComparable<T>
                }
            }
            try {
                return MainClass.fixup[fixupPath]["name"];
            } catch {
                return convertFunc (info.Name);
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
            return true;
        }

        public static void WriteEqualOperatorImplementation (this CodeWriter cw, FunctionInfo function)
        {
            // == implementation

            cw.WriteLine ("public static bool operator == ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();

            cw.WriteLine ("if ((object)one == null) {");
            cw.IncIndent ();
            cw.WriteLine ("return (object)two == null;");
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ("return one.Equals (two);");

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // != implementation

            cw.WriteLine ("public static bool operator != ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();

            cw.WriteLine ("return !(one == two);");

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();
        }

        public static void WriteCompareOperatorImplementation (this CodeWriter cw, FunctionInfo function)
        {
            // < implementation

            cw.WriteLine ("public static bool operator < ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("return one.CompareTo (two) < 0;");
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // <= implementation

            cw.WriteLine ("public static bool operator <= ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("return one.CompareTo (two) <= 0;");
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // > implementation

            cw.WriteLine ("public static bool operator > ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("return one.CompareTo (two) > 0;");
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // >= implementation

            cw.WriteLine ("public static bool operator >= ({0} one, {0} two)", function.Args[0].TypeInfo.ToManagedType ());
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("return one.CompareTo (two) >= 0;");
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();
        }

        public static FunctionInfo GetHashFunction (this FunctionInfo function)
        {
            var fixupPath = function.GetFixupPath ();
            try {
                var hashFunctionName = MainClass.fixup[fixupPath]["hash"];
                var container = function.Container as IMethodContainer;
                return container.Methods.Single (m => !m.IsHidden () && m.Name == hashFunctionName);
            } catch {
                return null;
            }
        }

        public static void WriteEqualsOverride (this CodeWriter cw, FunctionInfo function)
        {
            // override System.Object.Equals

            cw.WriteLine ("public override bool Equals (object other)");
            cw.WriteLine ("{");
            cw.IncIndent ();
            cw.WriteLine ("return Equals (other as {0});", function.Args[0].TypeInfo.ToManagedType ());

            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();

            // override System.Object.GetHashCode

            cw.WriteLine ("public override int GetHashCode ()");
            cw.WriteLine ("{");
            cw.IncIndent ();
            var hashFunction = function.GetHashFunction ();
            if (hashFunction == null) {
                cw.WriteLine ("return Handle.GetHashCode ();");
            } else {
                cw.WriteLine ("return (int){0} (Handle);", hashFunction.Symbol);
            }
            cw.DecIndent ();
            cw.WriteLine ("}");
            cw.WriteLine ();
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
            if (function.IsHidden ()) {
                return null;
            }
            var functionName = function.GetFixedUpName (ToPascalCase);
            if (stripPrefix != null && functionName.StartsWith (stripPrefix, StringComparison.Ordinal)) {
                functionName = functionName.Remove (0, stripPrefix.Length);
            }
            var fixupPath = function.GetFixupPath ();
            functionName = fixupPath.GetManagedName (functionName);

            cw.WritePInvoke (function);
            if (fixupPath.IsPInvokeOnly ()) {
                return null;
            }

            // some constructors may be handled as static methods to avoid name conflicts
            // i.e. we cant have 2 constructors with the same number of arguments
            var isConstructor = (function.IsConstructor  || function.Name == "new") && !fixupPath.IsStaticConstructor ();

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
                // TODO: not sure how this needs to be handled. Ignoring "unref" is a hack for now.
                if (function.Name != "unref") {
                    throw new NotImplementedException ();
                }
            }

            var @override = false;
            var @struct = function.Container as StructInfo;
            if (@struct != null) {
                if (@struct.IsReferenceCountedOpaque ()) {
                    @override = function.IsRefFunction () || function.IsUnrefFunction ();
                }
                if (@struct.IsOwnedOpaque ()) {
                    @override = function.IsCopyFunction () || function.IsFreeFunction ();
                }
            }

            if (@override) {
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
                        cw.WriteParameterModifier (arg);
                        cw.Write (marshalledArgNames [arg.Name]);
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

            if (function.IsEqualFunction ()) {
                cw.WriteEqualsOverride (function);
                cw.WriteEqualOperatorImplementation (function);
            }

            if (function.IsCompareFunction ()) {
                cw.WriteCompareOperatorImplementation (function);
            }

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
                marshalledArgNames [arg.Name] = cw.WriteMarshalTypeFromManaged (arg.TypeInfo,
                    arg.GetFixedUpName (ToCamelCase) + argSuffix, arg.OwnershipTransfer, out writeFree);
                if (writeFree != null) {
                    // have to postpone writing the free statement until after calling the pinvoke function
                    marshalledArgWriteFree.Add (writeFree);
                }
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = callable.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.GetFixedUpName (ToCamelCase) + argSuffix;
                    var lengthArgManagedType = lengthArg.TypeInfo.ToManagedType ();
                    cw.Write ("var {0} = ", marshalledArgNames [lengthArg.Name]);
                    if (lengthArgManagedType != "int" && lengthArgManagedType != "long") {
                        cw.Write ("({0})", lengthArgManagedType);
                    }
                    cw.Write ("{0}.", arg.GetFixedUpName (ToCamelCase));
                    if (lengthArgManagedType == "long" || lengthArgManagedType == "ulong") {
                        cw.Write ("Long");
                    }
                    cw.WriteLine ("Length;");
                }
            }

            // Declare any out args that need to be marshalled

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out)) {
                marshalledArgNames [arg.Name] = arg.GetFixedUpName (ToCamelCase) + argSuffix;
                if (arg.TypeInfo.NeedsMarshal ()) {
                    marshalledArgNames [arg.Name] += "Ptr";
                    cw.WriteType (arg.TypeInfo, true);
                    cw.WriteLine (" {0};", marshalledArgNames [arg.Name]);
                }
                if (arg.TypeInfo.ArrayLength >= 0) {
                    var lengthArg = callable.Args [arg.TypeInfo.ArrayLength];
                    marshalledArgNames [lengthArg.Name] = lengthArg.GetFixedUpName (ToCamelCase) + argSuffix;
                    cw.WriteType (lengthArg.TypeInfo);
                    cw.WriteLine (" {0};", marshalledArgNames [lengthArg.Name]);
                }
            }

            // Implement callback function for closures

            var closureArgs = callable.Args.Where (a => a.Closure >= 0).Select (a => new Tuple<ArgInfo, ArgInfo> (a, callable.Args [a.Closure]));
            foreach (var args in closureArgs) {
                var arg = args.Item1;
                marshalledArgNames [arg.Name] = arg.GetFixedUpName (ToCamelCase) + argSuffix;
                var userDataArg = args.Item2;
                marshalledArgNames [userDataArg.Name] = userDataArg.GetFixedUpName (ToCamelCase) + argSuffix;

                // if we are implementing a callback, there is nothing to do here
                if (callable.InfoType == InfoType.Callback) {
                    continue;
                }

                // for now, just using the GISharp.Core.Default.DestroyNotify
                // instead of an individual imlementation for each function

                var hasDestroy = arg.Destroy >= 0;
                if (hasDestroy) {
                    var destroyArg = callable.Args [arg.Destroy];
                    marshalledArgNames [destroyArg.Name] = "GISharp.Core.Default.DestroyNotify";
                }

                // write the callback implementation

                marshalledArgNames [arg.Name] += "Wrapper";
                var callback = arg.TypeInfo.Interface as CallbackInfo;
                var managedCallbackArgName = arg.GetFixedUpName (ToCamelCase) + argSuffix;

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

                // assign the GC handle of the callback to user_data for use by the destroy callback

                if (hasDestroy) {
                    if (userDataArg.TypeInfo.Tag != TypeTag.Void || !userDataArg.TypeInfo.IsPointer) {
                        // assuming that user_data is always void*
                        throw new NotImplementedException ();
                    }
                    cw.WriteLine ("var {0} = (IntPtr)GCHandle.Alloc ({1});",
                        marshalledArgNames [userDataArg.Name], managedCallbackArgName);
                } else {
                    cw.WriteLine ("var {0} = IntPtr.Zero;", marshalledArgNames [userDataArg.Name]);
                }
            }

            // Write the native or callback invoker

            writeInvoke (marshalledArgNames, argSuffix);

            // handle ownership in constructor

            if (isConstructor) {
                do {
                    if (callable.CallerOwns != Transfer.Everything) {
                        var @struct = callable.Container as StructInfo;
                        if (@struct != null) {
                            if (@struct.IsStaticOpaque ()) {
                                // there is no ownership in StaticOpaque
                                break;
                            }
                            if (@struct.IsReferenceCountedOpaque ()) {
                                var refFunction = @struct.Methods.Single (m => !m.IsHidden () && m.IsRefFunction ());
                                cw.WriteLine ("{0} (Handle);", refFunction.Symbol);
                                break;
                            }
                        }
                        throw new NotImplementedException ();
                    }
                } while (false);
            }

            // Free any unmanged input args

            foreach (var writeFree in marshalledArgWriteFree) {
                writeFree ();
            }

            // Marshal output parameters as needed.

            foreach (var arg in managedArgs.Where (a => a.Direction == Direction.Out || a.Direction == Direction.Inout)) {
                cw.WriteMarshalTypeToManaged (arg.TypeInfo, marshalledArgNames[arg.Name], arg.GetFixedUpName (ToCamelCase) + argSuffix, true, arg.OwnershipTransfer);
//                if (arg.TypeInfo.ArrayLength >= 0) {
//                    var lengthArg = function.Args [arg.TypeInfo.ArrayLength];
//                    marshalledArgNames [lengthArg.Name] = lengthArg.GetFixedUpName (ToCamelCase);
//                    cw.WriteLine ("{0} = {1}.Length;",
//                        marshalledArgNames [arg.Name],
//                        marshalledArgNames [lengthArg.Name]);
//                }
            }

            // return result if needed;

            if (returnsValue) {
                cw.WriteMarshalTypeToManaged (callable.ReturnTypeInfo, "retPtr" + argSuffix, "ret" + argSuffix, false, callable.CallerOwns);
                cw.WriteLine ("return ret{0};", argSuffix);
            }
        }

        public static  void WriteImplementedInterfaces (this CodeWriter cw, IMethodContainer container)
        {
            var info = container as BaseInfo;
            foreach (var method in container.Methods) {
                if (method.IsEqualFunction ()) {
                    cw.Write (", IEquatable<{0}.{1}.{2}>", MainClass.parentNamespace, info.Namespace, info.Name);
                }
                if (method.IsCompareFunction ()) {
                    cw.Write (", IComparable<{0}.{1}.{2}>", MainClass.parentNamespace, info.Namespace, info.Name);
                }
            }
        }

        public static void WriteOpaque (this CodeWriter cw, StructInfo @struct,
            List<ConstantInfo> constants, List<FunctionInfo> extraFunctions)
        {
            var fixupPath = @struct.GetFixupPath ();
            var isReferenceCounted = @struct.IsReferenceCountedOpaque ();
            var isStaticOpaque = @struct.IsStaticOpaque ();
            var isOwnedOpaque = @struct.IsOwnedOpaque ();

            cw.WriteHeader (@struct.Namespace);
            if (@struct.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
            cw.Write ("{0}", fixupPath.GetAccessModifier ());
            cw.Write ("partial class {0} : GISharp.Core.{1}{2}{3}Opaque<{0}>",
                @struct.Name, isReferenceCounted ? "ReferenceCounted" : "",
                isStaticOpaque ? "Static" : "", isOwnedOpaque ? "Owned" : "");
            cw.WriteImplementedInterfaces (@struct);
            cw.WriteLine ();
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
            if (@struct.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
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
            if (union.IsDeprecated) {
                cw.WriteLine ("[Obsolete]");
            }
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
            // Make sure 'T' in GType is capitalized
            str = str.Replace ("_gtype", "_g_type");
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
