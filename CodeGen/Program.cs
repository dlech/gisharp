using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

using Buildalyzer;
using Buildalyzer.Workspaces;
using GISharp.Runtime;
using GISharp.CodeGen.Model;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Workspaces;
using Mono.Options;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen
{
    class MainClass
    {
        internal const string parentNamespace = "GISharp";

        enum Command
        {
            // create a new gir-fixup.yml file
            NewFixup,
            // generate source code files
            Generate,
        }

        static void PrintHelpAndExit (OptionSet options, int exitCode = 0)
        {
            var writer = exitCode == 0 ? Console.Out : Console.Error;
            writer.WriteLine("Usage: mono GICodeGen.exe { -c <command> -p <project> [ -g <gir-path> ] [ -f ] | -h | -v }");
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
            string commandArg = null;
            string projectArg = null;
            string girDirectoryArg = null;
            bool forceArg = false;

            OptionSet options = null;
            options = new OptionSet {
                {
                    "h|help",
                    "Print this message.",
                    v => PrintHelpAndExit (options)
                }, {
                    "v|version",
                    "Print the program version infomation.",
                    v => PrintVersionAndExit ()
                }, {
                    "c|command=",
                    "The command to run.",
                    v => commandArg = v
                }, {
                    "p|project=",
                    "The .NET project to use.",
                    v => projectArg = v
                }, {
                    "g|gir-dir=",
                    "The directory where the .gir file is located. By default /usr/share/gir-1.0/ will be used.",
                    v => girDirectoryArg = v
                }, {
                    "f|force",
                    "Overwrite existing files.",
                    v => forceArg = true
                },
            };
            var extraArgs = options.Parse(args);
            if (extraArgs.Any()) {
                var argList = string.Join(", ", extraArgs.ToArray());
                Console.Error.WriteLine($"Unknown arguments: {argList}");
                Console.Error.WriteLine ();
                PrintHelpAndExit(options, 1);
                return;
            }

            if (commandArg == null) {
                Console.Error.WriteLine("Command option is required");
                Console.Error.WriteLine();
                PrintHelpAndExit(options, 1);
                return;
            }

            if (projectArg == null) {
                Console.Error.WriteLine("Project option is required");
                Console.Error.WriteLine();
                PrintHelpAndExit(options, 1);
                return;
            }

            Command command;
            switch (commandArg.ToLower()) {
            case "new-fixup":
                command = Command.NewFixup;
                break;
            case "generate":
                command = Command.Generate;
                break;
            default:
                Console.Error.WriteLine($"Unknown command: {commandArg}");
                Console.Error.WriteLine();
                PrintHelpAndExit(options, 1);
                return;
            }

            // load the project given by the --project option

            ProjectAnalyzer projectAnalyzer;

            try {
                // If the --project argument is a directory, find the .csproj inside
                if (Directory.Exists(projectArg)) {
                    projectArg = Directory.EnumerateFiles(projectArg, "*.csproj").FirstOrDefault() ?? projectArg;
                }

                var manager = new AnalyzerManager(Console.Error, LoggerVerbosity.Quiet);
                projectAnalyzer = manager.GetProject(projectArg);

            }
            catch (Exception ex) {
                Console.Error.WriteLine($"Failed to load project: {ex.Message}");
                Environment.Exit(1);
                return;
            }

            var repositoryName = Path.GetFileNameWithoutExtension(projectAnalyzer.ProjectFilePath);
            var girFilePath = Path.Combine(girDirectoryArg ?? "gir-1.0", repositoryName + ".gir");
            if (!Path.IsPathRooted(girFilePath)) {
                girFilePath = Freedesktop.Xdg.BaseDirectory.FindDataFile(girFilePath) ?? girFilePath;
            }

            // load the GIR XML file

            Console.WriteLine($"Loading GIR XML file '{girFilePath}'...");
            XDocument girXml;

            try {
                girXml = XDocument.Load(girFilePath);
            }
            catch (Exception ex) {
                Console.Error.WriteLine($"Failed to load GIR XML: {ex.Message}");
                Environment.Exit(1);
                return;
            }

            // load the gir-fixup.yml file

            const string fixupFileName = "gir-fixup.yml";

            var fixupFilePath = Path.Combine(Path.GetDirectoryName(projectAnalyzer.ProjectFilePath), fixupFileName);
            var fixupFileExists = File.Exists(fixupFilePath);

            // for most commands, we need an existing fixup file
            if (command != Command.NewFixup && !fixupFileExists) {
                Console.Error.WriteLine("gir-fixup.yml does not exist. Create it using --command=new-fixup.");
                Environment.Exit(1);
                return;
            }
            // for the new-fixup command, we want to make sure we aren't overwriting an existing file
            else if (command == Command.NewFixup == !forceArg && fixupFileExists) {
                Console.Error.WriteLine("gir-fixup.yml already exists in project. Use --force to overwrite.");
                Environment.Exit(1);
                return;
            }

            // Handle the new-fixup command

            if (command == Command.NewFixup) {
                Console.WriteLine ($"Generating '{fixupFilePath}'");
                try {
                    using (var writer = new StreamWriter(fixupFilePath)) {
                        girXml.Generate(writer);
                    }
                }
                catch (Exception ex) {
                    var msg = $"Failed to create fixup file: {ex.Message}";
                    Console.Error.WriteLine(msg);
                    Environment.Exit(1);
                }
                return;
            }

            // Parse the fixup file

            Console.WriteLine($"Loading fixup file '{fixupFilePath}'...");
            Fixup.Command[] commands;
            try {
                using (var reader = new StreamReader(fixupFilePath)) {
                    commands = Fixup.Parse(reader);
                }
            }
            catch (Exception ex) {
                var msg = $"Fixup file error: {ex.Message}";
                Console.Error.WriteLine(msg);
                Environment.Exit(1);
                return;
            }

            // Apply the fixups to the GIR XML

            Console.WriteLine("Applying fixup data...");

            girXml.ApplyFixup(commands);
            girXml.ApplyBuiltinFixup();
            girXml.Validate();

            Console.WriteLine("Generating code...");

            // FIXME: need to load assemblies of dependencies

            TypeResolver.LoadAssembly(Assembly.GetAssembly(typeof(GISharp.Runtime.Opaque)));
            AppDomain.CurrentDomain.TypeResolve += TypeResolver.Resolve;

            var moduleInfo = new ModuleInfo(girXml.Root);
            var codeCompileUnit = CompilationUnit().WithMembers(moduleInfo.AllDeclarations);
            var workspace = new AdhocWorkspace();

            // write the generate code file

            var generatedFilePath = Path.Combine(Path.GetDirectoryName(projectAnalyzer.ProjectFilePath), "Generated.cs");
            Console.WriteLine($"Writing '{generatedFilePath}'...");
            using (var generatedFile = new StreamWriter(generatedFilePath)) {
                Formatter.Format(codeCompileUnit, workspace).WriteTo(generatedFile);
            }

            Console.WriteLine("Done.");
        }
    }

    static class ExtensionMethods
    {
        #pragma warning disable 0414 // ignore private field not used
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;
        #pragma warning restore 0414

        /// <summary>
        /// Converts an object to an appropriate ExpressionSyntax
        /// </summary>
        /// <returns>The expression.</returns>
        /// <param name="obj">Object.</param>
        public static ExpressionSyntax ToExpression (this object obj)
        {
            var @bool = obj as bool?;
            if (@bool.HasValue) {
                if (@bool.Value) {
                    return LiteralExpression (
                        SyntaxKind.TrueLiteralExpression,
                        Token (SyntaxKind.TrueKeyword));
                }
                return LiteralExpression (
                    SyntaxKind.FalseLiteralExpression,
                    Token (SyntaxKind.FalseKeyword));
            }
            var @byte = obj as byte?;
            if (@byte.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@byte.Value));
            }
            var @sbyte = obj as sbyte?;
            if (@sbyte.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@sbyte.Value));
            }
            var @short = obj as short?;
            if (@short.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@short.Value));
            }
            var @ushort = obj as ushort?;
            if (@ushort.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@ushort.Value));
            }
            var @int = obj as int?;
            if (@int.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@int.Value));
            }
            var @uint = obj as uint?;
            if (@uint.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@uint.Value));
            }
            var @long = obj as long?;
            if (@long.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@long.Value));
            }
            var @ulong = obj as ulong?;
            if (@ulong.HasValue) {
                return LiteralExpression (
                    SyntaxKind.NumericLiteralExpression,
                    Literal (@ulong.Value));
            }
            var str = obj as string;
            if (str != null) {
                return LiteralExpression (
                    SyntaxKind.StringLiteralExpression,
                    Literal (str));
            }
            var @enum = obj as Enum;
            if (@enum != null) {
                return MemberAccessExpression (
                    SyntaxKind.SimpleMemberAccessExpression,
                    ParseExpression (@enum.GetType ().FullName),
                    IdentifierName (@enum.ToString ()));
            }
            var message = string.Format ("Unexpected type '{0}", obj.GetType ().FullName);
            throw new ArgumentException (message, nameof(obj));
        }

        public static int GetClosureIndex (this XElement element, bool countInstanceParameter = false)
        {
            if (element.Attribute ("closure") == null) {
                return -1;
            }

            var index = int.Parse (element.Attribute ("closure").Value);
            if (countInstanceParameter && element.Parent.Element (gi + "instance-parameter") != null) {
                index++;
            }

            return index;
        }

        public static int GetDestroyIndex (this XElement element, bool countInstanceParameter = false)
        {
            if (element.Attribute ("destroy") == null) {
                return -1;
            }

            var index = int.Parse (element.Attribute ("destroy").Value);
            if (countInstanceParameter && element.Parent.Element (gi + "instance-parameter") != null) {
                index++;
            }

            return index;
        }

        public static int GetLengthIndex (this XElement element, bool countInstanceParameter = false)
        {
            var arrayElement = element.Element (gi + "array");
            if (arrayElement == null || arrayElement.Attribute ("length") == null) {
                return -1;
            }

            var index = int.Parse (arrayElement.Attribute ("length").Value);
            if (countInstanceParameter && element.Ancestors (gi + "method").Any ()) {
                index++;
            }

            return index;
        }

        public static int GetFixedSize (this XElement element)
        {
            var arrayElement = element.Element (gi + "array");
            if (arrayElement == null || arrayElement.Attribute ("fixed-size") == null) {
                return -1;
            }

            return int.Parse (arrayElement.Attribute ("fixed-size").Value);
        }

        public static bool GetZeroTerminated (this XElement element)
        {
            var arrayElement = element.Element (gi + "array");
            if (arrayElement == null) {
                return false;
            }

            return arrayElement.Attribute ("zero-terminated").AsBool ();
        }
    }
}
