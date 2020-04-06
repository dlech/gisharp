﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using Buildalyzer;
using Buildalyzer.Workspaces;
using GISharp.CodeGen.Gir;
using GISharp.CodeGen.Syntax;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Workspaces;
using Mono.Options;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

using Generic = System.Collections.Generic;

namespace GISharp.CodeGen
{
    class MainClass
    {
        internal const string parentNamespace = "GISharp.Lib";

        enum Command
        {
            // create a new gir-fixup.yml file
            NewFixup,
            // generate source code files
            Generate,
        }

        static void PrintHelpAndExit(OptionSet options, int exitCode = 0)
        {
            var writer = exitCode == 0 ? Console.Out : Console.Error;
            writer.WriteLine("Usage: mono GICodeGen.exe { -c <command> -p <project> [ -g <gir-path> ] [ -f ] | -h | -v }");
            writer.WriteLine();
            options.WriteOptionDescriptions(writer);
            Environment.Exit(exitCode);
        }

        static void PrintVersionAndExit()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();
            Log.Message("{0} v{1}", assemblyName.Name, assemblyName.Version);
            Environment.Exit(0);
        }

        public static void Main(string[] args)
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
                Console.Error.WriteLine();
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

            var analyzerOptions = new AnalyzerManagerOptions() {
                // LogWriter = Console.Error,
            };
            var manager = new AnalyzerManager(analyzerOptions);
            ProjectAnalyzer projectAnalyzer;

            try {
                // If the --project argument is a directory, find the .csproj inside
                if (Directory.Exists(projectArg)) {
                    projectArg = Directory.EnumerateFiles(projectArg, "*.csproj").FirstOrDefault() ?? projectArg;
                }

                projectAnalyzer = manager.GetProject(projectArg);

            }
            catch (Exception ex) {
                Console.Error.WriteLine($"Failed to load project: {ex.Message}");
                Environment.Exit(1);
            }

            var repositoryName = Path.GetFileNameWithoutExtension(projectAnalyzer.ProjectFile.Path);
            var girFilePath = Path.Combine(girDirectoryArg ?? "gir-1.0", repositoryName + ".gir");
            if (!Path.IsPathRooted(girFilePath)) {
                girFilePath = Freedesktop.Xdg.BaseDirectory.FindDataFile(girFilePath) ?? girFilePath;
            }

            // load the GIR XML file

            Log.Message($"Loading GIR XML file '{girFilePath}'...");
            XDocument girXml;

            try {
                girXml = XDocument.Load(girFilePath);
            }
            catch (Exception ex) {
                Console.Error.WriteLine($"Failed to load GIR XML: {ex.Message}");
                Environment.Exit(1);
            }

            // load the gir-fixup.yml file

            const string fixupFileName = "gir-fixup.yml";
            const string fixupDirName = fixupFileName + ".d";

            var projectDirPath = Path.GetDirectoryName(projectAnalyzer.ProjectFile.Path);

            var fixupFilePath = Path.Combine(projectDirPath, fixupFileName);
            var fixupFileExists = File.Exists(fixupFilePath);
            var fixupDirPath = Path.Combine(projectDirPath, fixupDirName);
            var fixupDirExists = Directory.Exists(fixupDirPath);

            // for most commands, we need an existing fixup file
            if (command != Command.NewFixup && !fixupFileExists && !fixupDirExists) {
                Console.Error.WriteLine("gir-fixup.yml does not exist. Create it using --command=new-fixup.");
                Environment.Exit(1);
            }
            // for the new-fixup command, we want to make sure we aren't overwriting an existing file
            else if (command == Command.NewFixup == !forceArg && fixupFileExists) {
                Console.Error.WriteLine("gir-fixup.yml already exists in project. Use --force to overwrite.");
                Environment.Exit(1);
            }

            // Handle the new-fixup command

            if (command == Command.NewFixup) {
                Log.Message($"Generating '{fixupFilePath}'");
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

            Log.Message($"Loading fixup file(s)...");
            var commands = new Generic.List<Fixup.Command>();
            var fixupFiles = new Generic.List<string>();
            if (fixupFileExists) {
                fixupFiles.Add(fixupFilePath);
            }
            if (fixupDirExists) {
                fixupFiles.AddRange(Directory.EnumerateFiles(fixupDirPath, "*.yml"));
            }
            try {
                foreach (var file in fixupFiles) {
                    using (var reader = new StreamReader(file)) {
                        commands.AddRange(Fixup.Parse(reader));
                    }
                }
            }
            catch (Exception ex) {
                var msg = $"Fixup file error: {ex.Message}";
                Console.Error.WriteLine(msg);
                Environment.Exit(1);
            }

            // Apply the fixups to the GIR XML

            Log.Message("Applying fixup data...");

            girXml.ApplyFixup(commands);
            girXml.ApplyBuiltinFixup();
            girXml.Validate();

            Log.Message("Resolving references...");

            // load all references assemblies into type resolver

            TypeResolver.LoadAssembly(typeof(GISharp.Runtime.Opaque).Assembly);
            TypeResolver.LoadAssembly(typeof(System.ReadOnlySpan<>).Assembly);

            foreach (var projRef in projectAnalyzer.Build().SelectMany(x => x.ProjectReferences).Distinct()) {
                var proj = manager.GetProject(projRef);
                var targetPath = proj.Build().Single().GetProperty("TargetPath");

                // build the project references to ensure they are not out of date.
                // theoretically, we could use MSBUild programmatically
                // but it is really quirky and doesn't "just work"
                var dotnet = Process.Start("dotnet", $"build -v q --nologo {projRef}");
                dotnet.WaitForExit();
                if (dotnet.ExitCode != 0) {
                    Environment.Exit(dotnet.ExitCode);
                }

                TypeResolver.LoadAssembly(Assembly.LoadFile(targetPath));
            }

            AppDomain.CurrentDomain.TypeResolve += TypeResolver.Resolve;

            // write the generate code file

            Log.Message("Generating code...");

            var gir = new Repository(girXml);
            var codeCompileUnits = gir.GetCompilationUnits().ToArray();
            var workspace = new AdhocWorkspace();

            var slashReplacer = new Regex("^/// ", RegexOptions.Multiline);

            foreach (var f in Directory.GetFiles(projectDirPath, "*.Generated.*")) {
                File.Delete(f);
            }

            Log.Message($"Writing '*.Generated.*'...");
            foreach (var (name, unit) in codeCompileUnits) {
                var docFileName = name + ".xmldoc";
                var collectedDocs = new StringBuilder();
                collectedDocs.AppendLine("<declaration>");
                collectedDocs.AppendLine();

                // Replace all of the public doc comments with an <include>
                // and dump the XML to a separate file so that it can be fixed
                // up by hand.
                SyntaxNode replaceLeadingTrivia(SyntaxNode node, SyntaxNode _)
                {
                    var newNode = node.ReplaceNodes(node.ChildNodes(), replaceLeadingTrivia);

                    if (!node.HasAnnotations("extern doc")) {
                        return newNode;
                    }

                    var memberName = SecurityElement.Escape(node.GetMemberDeclarationName());
                    collectedDocs.AppendFormat("<member name='{0}'>", memberName);
                    collectedDocs.AppendLine();
                    collectedDocs.Append(slashReplacer.Replace(node.GetLeadingTrivia()
                        .Where(x => x.IsKind(SingleLineDocumentationCommentTrivia))
                        .ToSyntaxTriviaList().ToFullString(), ""));
                    collectedDocs.AppendLine("</member>");
                    collectedDocs.AppendLine();

                    // make sure we don't lose other trivia like #pragma
                    var otherTrivia = node.GetLeadingTrivia().Where(x => x.Kind() != SingleLineDocumentationCommentTrivia);
                    newNode = newNode.WithLeadingTrivia(otherTrivia.Concat(ParseLeadingTrivia(string.Format(
                        "/// <include file=\"{0}\" path=\"declaration/member[@name='{1}']/*\" />\r\n",
                        docFileName,
                        memberName
                    ))));

                    return newNode;
                }

                var modifiedUnit = unit.ReplaceNodes(unit.ChildNodes(), replaceLeadingTrivia);
                collectedDocs.AppendLine("</declaration>");

                var generatedFilePath = Path.Combine(projectDirPath, name + ".Generated.cs");
                using (var generatedFile = new StreamWriter(generatedFilePath)) {
                    Formatter.Format(modifiedUnit, workspace).WriteTo(generatedFile);
                }

                var generateDocPath = Path.Combine(projectDirPath, name + ".Generated.xmldoc");
                using (var generatedFile = new StreamWriter(generateDocPath)) {
                    generatedFile.Write(collectedDocs.ToString());
                }

                // create the hand-maintained file only if it doesn't already exist
                var docPath = Path.Combine(projectDirPath, docFileName);
                if (!File.Exists(docPath)) {
                    File.Copy(generateDocPath, docPath);
                }
            }

            Log.Message("Done.");
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
        public static ExpressionSyntax ToExpression(this object obj)
        {
            var @bool = obj as bool?;
            if (@bool.HasValue) {
                if (@bool.Value) {
                    return LiteralExpression(
                        TrueLiteralExpression,
                        Token(TrueKeyword));
                }
                return LiteralExpression(
                    FalseLiteralExpression,
                    Token(FalseKeyword));
            }
            var @byte = obj as byte?;
            if (@byte.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@byte.Value));
            }
            var @sbyte = obj as sbyte?;
            if (@sbyte.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@sbyte.Value));
            }
            var @short = obj as short?;
            if (@short.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@short.Value));
            }
            var @ushort = obj as ushort?;
            if (@ushort.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@ushort.Value));
            }
            var @int = obj as int?;
            if (@int.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@int.Value));
            }
            var @uint = obj as uint?;
            if (@uint.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@uint.Value));
            }
            var @long = obj as long?;
            if (@long.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@long.Value));
            }
            var @ulong = obj as ulong?;
            if (@ulong.HasValue) {
                return LiteralExpression(
                    NumericLiteralExpression,
                    Literal(@ulong.Value));
            }
            if (obj is string str) {
                return LiteralExpression(
                    StringLiteralExpression,
                    Literal(str));
            }
            if (obj is Enum @enum) {
                return MemberAccessExpression(
                    SimpleMemberAccessExpression,
                    ParseExpression(@enum.GetType().FullName),
                    IdentifierName(@enum.ToString()));
            }
            var message = string.Format("Unexpected type '{0}", obj.GetType().FullName);
            throw new ArgumentException(message, nameof(obj));
        }

        public static int GetClosureIndex(this XElement element, bool countInstanceParameter = false)
        {
            if (element.Attribute("closure") == null) {
                return -1;
            }

            var index = int.Parse(element.Attribute("closure").Value);
            if (countInstanceParameter && element.Parent.Element(gi + "instance-parameter") != null) {
                index++;
            }

            return index;
        }

        public static int GetDestroyIndex(this XElement element, bool countInstanceParameter = false)
        {
            if (element.Attribute("destroy") == null) {
                return -1;
            }

            var index = int.Parse(element.Attribute("destroy").Value);
            if (countInstanceParameter && element.Parent.Element(gi + "instance-parameter") != null) {
                index++;
            }

            return index;
        }

        public static int GetLengthIndex(this XElement element, bool countInstanceParameter = false)
        {
            var arrayElement = element.Element(gi + "array");
            if (arrayElement == null || arrayElement.Attribute("length") == null) {
                return -1;
            }

            var index = int.Parse(arrayElement.Attribute("length").Value);
            if (countInstanceParameter && element.Ancestors(gi + "method").Any()) {
                index++;
            }

            return index;
        }

        public static int GetFixedSize(this XElement element)
        {
            var arrayElement = element.Element(gi + "array");
            if (arrayElement == null || arrayElement.Attribute("fixed-size") == null) {
                return -1;
            }

            return int.Parse(arrayElement.Attribute("fixed-size").Value);
        }

        public static bool GetZeroTerminated(this XElement element)
        {
            var arrayElement = element.Element(gi + "array");
            if (arrayElement == null) {
                return false;
            }

            return arrayElement.Attribute("zero-terminated").AsBool();
        }
    }
}
