using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

using GISharp.Runtime;
using GISharp.CodeGen.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.MSBuild;
using Mono.Options;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace GISharp.CodeGen
{
    class MainClass
    {
        internal const string parentNamespace = "GISharp";

        static void PrintHelpAndExit (OptionSet options, int exitCode = 0)
        {
            var writer = exitCode == 0 ? Console.Out : Console.Error;
            writer.WriteLine ("Usage: mono GICodeGen.exe -r <repository-name> [-g <gir-directory>] [-f <fixup-file>] [-o <output-file>] [-a <path1[:path2[...]] | -h | -v]");
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
            string repositoryName = null;
            string girDirectory = null;
            string fixupFile = null;
            string outputFile = null;
            string paths = null;

            OptionSet options = null;
            options = new OptionSet () { {
                    "h|help",
                    "Print this message.",
                    v => PrintHelpAndExit (options)
                }, {
                    "v|version",
                    "Print the program version infomation.",
                    v => PrintVersionAndExit ()
                }, {
                    "r=|repository=",
                    "The repository to generate. Essentially this is the name of the .gir file without the .gir extension.",
                    v => repositoryName = v
                }, {
                    "g=|gir-dir=",
                    "The directory where the .gir file is located. By default /usr/share/gir-1.0/ will be used.",
                    v => girDirectory = v
                }, {
                    "f=|fixup=",
                    "The name of the .girfixup file. By default '<namespace>.girfixup' will be used.",
                    v => fixupFile = v
                }, {
                    "a=|assemblies=",
                    "A colon separated list of dependant assembly paths.",
                    v => paths = v
                }, {
                    "o=|output=",
                    "The name of the output file. By default './<namespace>/Generated.cs' will be used.",
                    v => outputFile = v
                },
            };
            var extraArgs = options.Parse (args);
            if (repositoryName == null || extraArgs.Any ()) {
                Console.Error.WriteLine ("Bad arguments.");
                Console.Error.WriteLine ();
                PrintHelpAndExit (options, 1);
            }

            // Analysis disable ConstantNullCoalescingCondition
            var girFile = Path.Combine (girDirectory ?? "gir-1.0", repositoryName + ".gir");
            if (!Path.IsPathRooted (girFile)) {
                girFile = Freedesktop.Xdg.BaseDirectory.FindDataFile (girFile) ?? girFile;
            }

            fixupFile = fixupFile ?? repositoryName + ".girfixup";
            outputFile = outputFile ?? Path.Combine (repositoryName, "Generated");

            var pathList = (paths?.Split (':') ?? new string[0] )
                .Select (x => Path.GetFullPath(x)).ToList ();
            // Analysis restore ConstantNullCoalescingCondition

            Console.WriteLine ("Generating code for '{0}'.", Path.GetFullPath (girFile));
            Console.WriteLine ("Using fixup file '{0}'.", Path.GetFullPath (fixupFile));
            Console.WriteLine ("Creating output file '{0}'.", Path.GetFullPath (outputFile));
            Console.WriteLine ("With assemblies: {0}.",
                string.Join (", ", pathList.Select (x => string.Format ("'{0}'", x))));

            // Preload the specified assemblies for lookup later
            foreach (var path in pathList) {
                TypeResolver.LoadAssembly (path);
            }
            AppDomain.CurrentDomain.TypeResolve += TypeResolver.Resolve;

            var xmlDoc = XDocument.Load (girFile);
            xmlDoc.ApplyFixupFile (fixupFile);
            xmlDoc.ApplyBuiltinFixup ();

            var namespaceInfo = new NamespaceInfo (xmlDoc);
            var codeCompileUnit = CompilationUnit ()
                .AddMembers (namespaceInfo.Syntax);
            using (var outFileStream = File.Open (outputFile, FileMode.Create))
            using (var writer = new StreamWriter (outFileStream)) {
                var workspace = MSBuildWorkspace.Create ();
                Formatter.Format (codeCompileUnit, workspace).GetText ().Write (writer);
            }
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
        /// Converts an object to an approprate ExpressionSyntax
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
