// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using Buildalyzer;
using GISharp.CodeGen.Gir;
using GISharp.CodeGen.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.Extensions.Logging;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Microsoft.CodeAnalysis.CSharp.SyntaxKind;

using Generic = System.Collections.Generic;

namespace GISharp.CodeGen
{
    class Program
    {
        private const string createFixupCommandName = "create-fixup";
        private const string generateCommandName = "generate";

        public static int Main(string[] args)
        {
            var projectOption = new Option<string>(
                new[] { "-p", "--project" },
                "The name of the project, e.g. GLib-2.0") {
                IsRequired = true
            };

            var girDirOption = new Option<DirectoryInfo>(
                new[] { "-g", "--gir-dir" },
                "The directory where the .gir file is located");

            var forceOption = new Option<bool>(
                new[] { "-f", "--force" },
                "Replace the existing fixup file");

            var debugOption = new Option<bool>(
                "--debug", "Enable debug logging");

            var createFixupCommand = new Command(
                createFixupCommandName,
                "Create a new gir-fixup/_default.yml file for a project"
            ) {
                projectOption,
                girDirOption,
                forceOption,
            };
            createFixupCommand.Handler =
                CommandHandler.Create<InvocationContext, string, DirectoryInfo, bool, bool>(CreateFixup);

            var generateCommand = new Command(
                generateCommandName,
                "Generate .cs and .xmldoc files for a project"
            ) {
                projectOption,
                girDirOption,
            };
            generateCommand.Handler =
                CommandHandler.Create<InvocationContext, string, DirectoryInfo, bool>(Generate);

            var rootCommand = new RootCommand(
                "GISharp code generator"
            ) {
                createFixupCommand,
                generateCommand,
            };
            rootCommand.AddOption(debugOption);

            var code = rootCommand.Invoke(args);
            // flush logs
            Globals.LoggerFactory.Dispose();
            Console.Out.Flush();
            Console.Error.Flush();
            return code;
        }

        private static void CreateFixup(InvocationContext context, string project, DirectoryInfo girDir, bool force, bool debug)
        {
            Run(createFixupCommandName, context, project, girDir, force, debug);
        }

        private static void Generate(InvocationContext context, string project, DirectoryInfo girDir, bool debug)
        {
            Run(generateCommandName, context, project, girDir, default, debug);
        }

        private static void Run(string command, InvocationContext context, string project, DirectoryInfo girDir, bool force, bool debug)
        {
            Globals.EnableDebugLogging = debug;
            var logger = Globals.LoggerFactory.CreateLogger("Main");

            // load the project given by the --project option

            var analyzerOptions = new AnalyzerManagerOptions() {
                LoggerFactory = Globals.LoggerFactory,
            };
            var manager = new AnalyzerManager(analyzerOptions);
            ProjectAnalyzer projectAnalyzer;

            try {
                // If the --project argument is a directory, find the .csproj inside
                if (Directory.Exists(project)) {
                    project = Directory.EnumerateFiles(project, "*.csproj").FirstOrDefault() ?? project;
                }

                projectAnalyzer = manager.GetProject(project);

            }
            catch (Exception ex) {
                logger.LogError("Failed to load project: {ExceptionMessage}", ex.Message);
                context.ExitCode = 1;
                return;
            }

            var repositoryName = Path.GetFileNameWithoutExtension(projectAnalyzer.ProjectFile.Path);
            var girFilePath = Path.Combine(girDir?.FullName ?? "gir-1.0", repositoryName + ".gir");
            if (!Path.IsPathRooted(girFilePath)) {
                girFilePath = Freedesktop.Xdg.BaseDirectory.FindDataFile(girFilePath) ?? girFilePath;
            }

            // load the GIR XML file

            logger.LogInformation("Loading GIR XML file '{Path}'...", girFilePath);
            XDocument girXml;

            try {
                girXml = XDocument.Load(girFilePath);
            }
            catch (Exception ex) {
                logger.LogError("Failed to load GIR XML: {ExceptionMessage}", ex.Message);
                context.ExitCode = 1;
                return;
            }

            // load the gir-fixup/*.yml files

            var projectDirPath = Path.GetDirectoryName(projectAnalyzer.ProjectFile.Path);
            var fixupDirPath = Path.Combine(projectDirPath, "gir-fixup");
            var defaultFixupFilePath = Path.Combine(fixupDirPath, "_default.yml");
            var defaultFixupFileExists = File.Exists(defaultFixupFilePath);

            // for most commands, we need an existing fixup file
            if (command != createFixupCommandName && !defaultFixupFileExists) {
                logger.LogError("gir-fixup/_default.yml does not exist. Create it using create-fixup command.");
                context.ExitCode = 1;
                return;
            }
            // for the create-fixup command, we want to make sure we aren't overwriting an existing file
            else if (command == createFixupCommandName == !force && defaultFixupFileExists) {
                logger.LogError("gir-fixup/_default.yml already exists in project. Use --force to overwrite.");
                context.ExitCode = 1;
                return;
            }

            // Handle the create-fixup command

            if (command == createFixupCommandName) {
                logger.LogInformation("Generating '{Path}'", defaultFixupFilePath);
                try {
                    Directory.CreateDirectory(fixupDirPath);
                    using var writer = new StreamWriter(defaultFixupFilePath);
                    girXml.Generate(writer);
                }
                catch (Exception ex) {
                    logger.LogError("Failed to create fixup file: {ExceptionMessage}", ex.Message);
                    context.ExitCode = 1;
                }
                return;
            }

            // Parse the fixup file

            logger.LogInformation($"Loading fixup file(s)...");
            var commands = new Generic.List<Fixup.Command>();

            foreach (var file in Directory.EnumerateFiles(fixupDirPath, "*.yml")) {
                try {
                    using var reader = new StreamReader(file);
                    commands.AddRange(Fixup.Parse(reader));
                }
                catch (Exception ex) {
                    logger.LogError("Fixup file error: {ExceptionMessage} in '{Path}'", ex.Message, file);
                }
            }

            // Apply the fixups to the GIR XML

            logger.LogInformation("Applying fixup data...");

            girXml.ApplyFixup(commands);
            girXml.ApplyBuiltinFixup();
            girXml.Validate();

            logger.LogInformation("Writing fixed up GIR XML...");

            girXml.Save(Path.Join(projectDirPath, "gir.xml"));

            logger.LogInformation("Resolving references...");

            // load the .gir files from the dependencies

            void resolveReferences(XDocument doc)
            {
                foreach (var include in doc.GetIncludes()) {
                    var includePath = Path.Combine(projectDirPath, "..", include, "gir.xml");
                    var includeRepository = XDocument.Load(includePath);
                    TypeResolver.AddRepository(new Repository(includeRepository));
                    resolveReferences(includeRepository);
                }
            }

            resolveReferences(girXml);

            // write the generate code file

            logger.LogInformation("Generating code...");

            var gir = new Repository(girXml);
            TypeResolver.AddRepository(gir);
            var codeCompileUnits = gir.GetCompilationUnits().ToArray();
            var workspace = new AdhocWorkspace();

            var slashReplacer = new Regex("^/// ", RegexOptions.Multiline);

            // temporary file where output will be written
            var tempFile = Path.GetTempFileName();

            // there may be existing generated files that need to be deleted
            var filesToDelete = Directory.GetFiles(projectDirPath, "*.Generated.*").ToList();
            filesToDelete.Add(tempFile);

            logger.LogInformation($"Writing '*.Generated.*'...");
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
                    newNode = newNode.WithLeadingTrivia(otherTrivia.Concat(ParseLeadingTrivia(
                        $@"/// <include file=""{docFileName}"" path=""declaration/member[@name='{memberName}']/*"" />
                        ")));

                    return newNode;
                }

                var modifiedUnit = unit.ReplaceNodes(unit.ChildNodes(), replaceLeadingTrivia);
                collectedDocs.AppendLine("</declaration>");

                static string Hash(string path)
                {
                    try {
                        using var md5 = MD5.Create();
                        using var stream = File.OpenRead(path);
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash);
                    }
                    catch (FileNotFoundException) {
                        return null;
                    }
                }

                using (var generatedFile = new StreamWriter(tempFile)) {
                    Formatter.Format(modifiedUnit, workspace).WriteTo(generatedFile);
                }
                var generatedFilePath = Path.Combine(projectDirPath, $"{name}.Generated.cs");
                if (Hash(tempFile) != Hash(generatedFilePath)) {
                    File.Copy(tempFile, generatedFilePath, overwrite: true);
                }
                filesToDelete.Remove(generatedFilePath);

                using (var generatedFile = new StreamWriter(tempFile)) {
                    generatedFile.Write(collectedDocs.ToString());
                }
                var generateDocPath = Path.Combine(projectDirPath, $"{name}.Generated.xmldoc");
                if (Hash(tempFile) != Hash(generateDocPath)) {
                    File.Copy(tempFile, generateDocPath, overwrite: true);
                }
                filesToDelete.Remove(generateDocPath);

                // create the hand-maintained file only if it doesn't already exist
                var docPath = Path.Combine(projectDirPath, docFileName);
                if (!File.Exists(docPath)) {
                    File.Copy(generateDocPath, docPath);
                }
            }

            foreach (var f in filesToDelete) {
                File.Delete(f);
            }

            logger.LogInformation("Done.");
        }
    }

    static class ExtensionMethods
    {
#pragma warning disable CS0414, IDE0052 // ignore private field not used
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;
#pragma warning restore CS0414, IDE0052

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
            if (element.Attribute("closure") is null) {
                return -1;
            }

            var index = int.Parse(element.Attribute("closure").Value);
            if (countInstanceParameter && element.Parent.Element(gi + "instance-parameter") is not null) {
                index++;
            }

            return index;
        }

        public static int GetDestroyIndex(this XElement element, bool countInstanceParameter = false)
        {
            if (element.Attribute("destroy") is null) {
                return -1;
            }

            var index = int.Parse(element.Attribute("destroy").Value);
            if (countInstanceParameter && element.Parent.Element(gi + "instance-parameter") is not null) {
                index++;
            }

            return index;
        }

        public static int GetLengthIndex(this XElement element, bool countInstanceParameter = false)
        {
            var arrayElement = element.Element(gi + "array");
            if (arrayElement is null || arrayElement.Attribute("length") is null) {
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
            if (arrayElement is null || arrayElement.Attribute("fixed-size") is null) {
                return -1;
            }

            return int.Parse(arrayElement.Attribute("fixed-size").Value);
        }

        public static bool GetZeroTerminated(this XElement element)
        {
            var arrayElement = element.Element(gi + "array");
            if (arrayElement is null) {
                return false;
            }

            return arrayElement.Attribute("zero-terminated").AsBool();
        }
    }
}
