// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Logging;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using GISharp.Runtime;

namespace GISharp.CodeGen
{
    public static class Fixup
    {
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;

        static XmlNamespaceManager _Manager;
        static XmlNamespaceManager Manager {
            get {
                if (_Manager is null) {
                    _Manager = new(new NameTable());
                    _Manager.AddNamespace(string.Empty, gi.NamespaceName);
                    // default namespace does not seem to work in XPathGetElement(s) extension methods
                    // so we add a named namespace for it too.
                    _Manager.AddNamespace("gi", gi.NamespaceName);
                    _Manager.AddNamespace("c", c.NamespaceName);
                    _Manager.AddNamespace("glib", glib.NamespaceName);
                    _Manager.AddNamespace("gs", gs.NamespaceName);
                }
                return _Manager;
            }
        }

        private readonly static ILogger logger = Globals.LoggerFactory.CreateLogger("Fixup");

        /// <summary>
        /// Creates a new gir-fixup.yml file that skips everything in the GIR
        /// XML file.
        /// </summary>
        /// <param name="gir">The GIR XML document</param>
        /// <param name="writer">TextWriter where the YAML will be written</param>
        public static void Generate(this XDocument gir, TextWriter writer)
        {
            if (gir is null) {
                throw new ArgumentNullException(nameof(gir));
            }
            if (writer is null) {
                throw new ArgumentNullException(nameof(writer));
            }

            // we want everything lower-case and hyphenated
            var hyphenator = HyphenatedNamingConvention.Instance;

            var builder = new SerializerBuilder().WithNamingConvention(hyphenator);

            // Since each command has a unique type, we need to add a
            // type discriminator. This is done by adding a tag mapping
            // for each type that inherits from Command.
            var commandTypes = typeof(Fixup).GetNestedTypes()
                .Where(t => t.BaseType == typeof(Command));
            foreach (var type in commandTypes) {
                var name = hyphenator.Apply(type.Name);
                builder.WithTagMapping("!" + name, type);
            }

            var serializer = builder.Build();

            static string resolveElementNamespace(XElement element)
            {
                var @namespace = element.Name.Namespace;

                if (@namespace == gi) {
                    return "gi";
                }
                if (@namespace == glib) {
                    return "glib";
                }
                throw new Exception($"Unexpected namespace: {@namespace}");
            }

            static string resolveNameAttribute(XElement element)
            {
                var isGI = element.Name.Namespace == gi;
                var xpath = isGI ? "name" : element.Name.Namespace.GetName("name");

                var value = element.Attribute(xpath).Value;

                return isGI ? $"@name='{value}'" : $"@{resolveElementNamespace(element)}:name='{value}'";
            }

            var commands = gir.Element(gi + "repository").Element(gi + "namespace").Elements()
                .Where(e => !e.IsSkipped()) // these will be handled by ApplyBuiltinFixup()
                .Select(e => new SetAttribute {
                    Name = "introspectable",
                    Value = "0",
                    Xpath = $"gi:repository/gi:namespace/{resolveElementNamespace(e)}:{e.Name.LocalName}[{resolveNameAttribute(e)}]"
                }).ToList<Command>();

            serializer.Serialize(writer, commands);
        }

        /// <summary>
        /// Parses data from a gir-fixup.yml file
        /// </summary>
        /// <param name="yaml"/>YAML text data</param>
        public static Command[] Parse(TextReader reader)
        {
            if (reader is null) {
                throw new ArgumentNullException(nameof(reader));
            }

            // we expect everything lower-case and hyphenated
            var hyphenator = HyphenatedNamingConvention.Instance;

            var builder = new DeserializerBuilder().WithNamingConvention(hyphenator);

            // Since each command has a unique type, we need to add a
            // type discriminator. This is done by adding a tag mapping
            // for each type that inherits from Command.
            var commandTypes = typeof(Fixup).GetNestedTypes()
                .Where(t => t.BaseType == typeof(Command));
            foreach (var type in commandTypes) {
                var name = hyphenator.Apply(type.Name);
                builder.WithTagMapping("!" + name, type);
            }

            var deserializer = builder.Build();

            var commands = deserializer.Deserialize<Command[]>(reader);

            return commands;
        }

        public static void ApplyFixup(this XDocument document, IEnumerable<Command> commands)
        {
            if (document is null) {
                throw new ArgumentNullException(nameof(document));
            }
            if (commands is null) {
                throw new ArgumentNullException(nameof(commands));
            }

            foreach (var command in commands) {
                switch (command) {
                case AddElement addElement:
                    var newElement = ParseElement(addElement.Xml);
                    var addParent = document.XPathSelectElement(addElement.Xpath, Manager);
                    if (addParent is null) {
                        logger.LogWarning($"Could not find element at '{addElement.Xpath}'");
                        break;
                    }
                    addParent.Add(newElement);
                    break;
                case SetAttribute setAttr:
                    var setAttrNameParts = setAttr.Name.Split(':');
                    var setAttrLocalName = setAttrNameParts[0];
                    var setAttrNamespace = XNamespace.None;
                    if (setAttrNameParts.Length > 1) {
                        setAttrLocalName = setAttrNameParts[1];
                        setAttrNamespace = Manager.LookupNamespace(setAttrNameParts[0]);
                    }
                    var setAttrElements = document.XPathSelectElements(setAttr.Xpath, Manager).ToList();
                    if (setAttrElements.Count == 0) {
                        logger.LogWarning($"Could not find any elements matching '{setAttr.Xpath}'");
                        break;
                    }
                    foreach (var element in setAttrElements) {
                        var attribute = element.Attribute(setAttrNamespace + setAttrLocalName);
                        element.SetAttributeValue(setAttrNamespace + setAttrLocalName, setAttr.Value);
                    }
                    break;
                case ChangeAttribute changeAttr:
                    var changeAttrNameParts = changeAttr.Name.Split(':');
                    var changeAttrLocalName = changeAttrNameParts[0];
                    var changeAttrNamespace = XNamespace.None;
                    if (changeAttrNameParts.Length > 1) {
                        setAttrLocalName = changeAttrNameParts[1];
                        setAttrNamespace = (XNamespace)Manager.LookupNamespace(changeAttrNameParts[0]);
                    }
                    var changeAttrElements = document.XPathSelectElements(changeAttr.Xpath, Manager).ToList();
                    if (changeAttrElements.Count == 0) {
                        logger.LogWarning($"Could not find any elements matching '{changeAttr.Xpath}'");
                        break;
                    }
                    foreach (var element in changeAttrElements) {
                        var attribute = element.Attribute(changeAttrNamespace + changeAttrLocalName);
                        var oldValue = attribute is null ? string.Empty : attribute.Value;
                        var newValue = string.IsNullOrEmpty(changeAttr.Regex) ? changeAttr.Replace
                            : Regex.Replace(oldValue, changeAttr.Regex, changeAttr.Replace);
                        element.SetAttributeValue(changeAttrNamespace + changeAttrLocalName, newValue);
                    }
                    break;
                case ChangeElement changeElement:
                    var elementParts = changeElement.NewName.Split(':');
                    var elementLocalName = elementParts[0];
                    var elementNamespace = XNamespace.None;
                    if (elementParts.Length > 1) {
                        elementLocalName = elementParts[1];
                        elementNamespace = (XNamespace)Manager.LookupNamespace(elementParts[0]);
                    }
                    var elementsToChange = document.XPathSelectElements(changeElement.Xpath, Manager);
                    if (elementsToChange is null) {
                        logger.LogWarning($"Could not find elements matching '{changeElement.Xpath}'");
                        break;
                    }
                    foreach (var element in elementsToChange) {
                        element.Name = elementNamespace + elementLocalName;
                    }
                    break;
                case MoveElement moveElement:
                    var moveElements = document.XPathSelectElements(moveElement.Xpath, Manager).ToList();
                    if (moveElements.Count == 0) {
                        logger.LogWarning($"Could not find any elements matching '{moveElement.Xpath}'");
                    }
                    var moveParent = document.XPathSelectElement(moveElement.NewParentXpath, Manager);
                    if (moveParent is null) {
                        logger.LogWarning($"Could not find element at '{moveElement.NewParentXpath}'");
                        break;
                    }
                    foreach (var element in moveElements) {
                        element.Remove();
                        moveParent.Add(element);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Tests if an element should be ignored/removed.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the element is marked as "introspectable='0'",
        /// "moved-to" or "shadowed-by or if the element is a function/method
        /// with varargs or if the element is an alias that ends with _autoptr.
        /// </returns>
        static bool IsSkipped(this XElement element)
        {
            return !element.Attribute("introspectable").AsBool(true)
                || element.Attribute("moved-to") is not null
                || element.Attribute("shadowed-by") is not null
                || IsCallableWithVarArgs()
                || IsAutoptrAlias();

            bool IsCallableWithVarArgs()
            {
                var parameters = element.Element(gi + "parameters");
                if (parameters is null) {
                    return false;
                }
                foreach (var child in parameters.Elements(gi + "parameter")) {
                    if (child.Element(gi + "type")?.Attribute("name").AsString() == "va_list") {
                        return true;
                    }
                    if (child.Element(gi + "varargs") is not null) {
                        return true;
                    }
                }
                return false;
            }

            bool IsAutoptrAlias()
            {
                if (element.Name != gi + "alias") {
                    return false;
                }

                return element.Attribute("name").AsString("").EndsWith("_autoptr", StringComparison.Ordinal);
            }
        }

        public static void ApplyBuiltinFixup(this XDocument document)
        {
            // scrape the dll name from the shared-library attribute
            var sharedLibrary = document.Element(gi + "repository").Element(gi + "namespace").Attribute("shared-library").AsString();
            // strip the file extension
            var dllName = Path.GetFileNameWithoutExtension(sharedLibrary);
            // strip the ABI version, if any
            if (Regex.Match(dllName, @"\d+\.\d+\.\d+$").Success) {
                dllName = dllName.Substring(0, dllName.LastIndexOf("."));
            }
            // strip the lib prefix
            if (dllName.StartsWith("lib")) {
                dllName = dllName[3..];
            }

            // add the gs namespace prefix

            document.Root.SetAttributeValue(XNamespace.Xmlns + "gs", gs.NamespaceName);

            // ensure that functions without parameters have an empty <parameters> element

            foreach (var element in document.Descendants(gi + "function")
                .Concat(document.Descendants(gi + "constructor"))
                .Concat(document.Descendants(gi + "method"))
                .Concat(document.Descendants(gi + "callback"))
                .Concat(document.Descendants(glib + "signal"))
                .Where(x => x.Element(gi + "parameters") is null)) {
                element.Add(new XElement(gi + "parameters"));
            }

            // all fields must be included for proper struct sizes

            foreach (var element in document.Descendants(gi + "field")
                .Where(x => !x.Attribute("introspectable").AsBool(true))) {
                element.SetAttributeValue("introspectable", "1");

                // if it is a callback, change it to an IntPtr
                var callbackElement = element.Element(gi + "callback");
                if (callbackElement is not null) {
                    callbackElement.Name = gi + "type";
                    callbackElement.SetAttributeValue("name", "gpointer");
                    // sometimes, the callback node also has introspectable="0"
                    callbackElement.SetAttributeValue("introspectable", "1");
                }
            }

            // flag records ending in "Private" as not introspectable

            foreach (var element in document.Descendants(gi + "record")
                .Where(x => x.Attribute("name").Value.EndsWith("Private"))) {
                if (element.Attribute("introspectable") is not null) {
                    continue;
                }
                element.SetAttributeValue("introspectable", "0");
            }

            // remove non-introspectable nodes

            var elementsToRemove = document.Descendants()
                .Where(d => d.Name != gi + "return-value" && d.Name != gi + "parameter")
                .Where(d => d.IsSkipped())
                .ToList();
            foreach (var element in elementsToRemove) {
                element.Remove();
            }

            // scrape version attribute from member doc

            foreach (var element in document.Descendants(gi + "member")) {
                if (element.Attribute("since") is not null) {
                    continue;
                }

                var docElement = element.Element(gi + "doc");
                if (docElement is null) {
                    continue;
                }

                var match = Regex.Match(docElement.Value, @"\n?\s*Since:?\s+(\d+\.\d+)\.?",
                    RegexOptions.Multiline);
                if (!match.Success) {
                    continue;
                }

                element.SetAttributeValue("version", match.Groups[1]);
                docElement.Value = docElement.Value.Replace(match.Value, "");
            }

            // scrape deprecated-version attribute from member doc

            foreach (var element in document.Descendants(gi + "member")) {
                if (element.Attribute("since") is not null) {
                    continue;
                }

                var docElement = element.Element(gi + "doc");
                if (docElement is null) {
                    continue;
                }

                var match = Regex.Match(docElement.Value, @"\n?\s*Deprecated since:?\s+(\d+\.\d+)[\.:]?",
                    RegexOptions.Multiline);
                if (!match.Success) {
                    continue;
                }

                element.SetAttributeValue("deprecated", "1");
                element.SetAttributeValue("deprecated-version", match.Groups[1]);
                docElement.Value = docElement.Value.Replace(match.Value, "");
            }

            // Fix up error quark functions

            // Some types have an "error_quark" function that needs to be moved
            // to the *Error enum.
            var errorQuarkFunctions = document.Descendants(gi + "function")
                .Where(x => x.Attribute("name").AsString() == "error_quark");
            foreach (var element in errorQuarkFunctions) {
                var errorDomain = element.Parent.Attribute("name").AsString() + "Error";
                var errorDomainElement = document.Descendants(gi + "enumeration")
                    .SingleOrDefault(x => x.Attribute("name").AsString() == errorDomain);
                if (errorDomainElement is null) {
                    continue;
                }
                element.Remove();
                element.SetAttributeValue("name", "get_quark");
                errorDomainElement.Add(element);
            }

            // Other *Error types just have a quark function that need to have
            // the get_ prefix added.
            var quarkFunctions = document.Descendants(gi + "function")
                .Where(x => x.Attribute("name").AsString() == "quark");
            foreach (var element in quarkFunctions) {
                element.SetAttributeValue("name", "get_quark");
            }

            // add functions for GType getters

            var elementsWithGTypeGetter = document.Descendants()
                .Where(d => d.Attribute(glib + "get-type").AsString("intern") != "intern");
            foreach (var element in elementsWithGTypeGetter) {
                var functionElement = new XElement(
                    gi + "function",
                    new XAttribute("name", "get_g_type"),
                    new XAttribute(gs + "pinvoke-only", "1"),
                    new XAttribute(c + "identifier", element.Attribute(glib + "get-type").Value),
                    new XAttribute(gs + "access-modifiers", "private"),
                    new XElement(
                        gi + "return-value",
                        new XElement(
                            gi + "type",
                            new XAttribute("name", "GType"),
                            new XAttribute(c + "type", "GType"))),
                    new XElement(gi + "parameters"));
                // GLib get_type functions are defined in GObject library
                if (dllName == "glib-2.0") {
                    functionElement.SetAttributeValue(gs + "dll-name", "gobject-2.0");
                }
                element.Add(functionElement);
            }

            // if arrays don't have a length or fixed-size, assume zero-terminated

            foreach (var element in document.Descendants(gi + "array")) {
                if (element.Attribute("length") is null && element.Attribute("fixed-size") is null) {
                    element.SetAttributeValue("zero-terminated", "1");
                }
            }

            // add error parameters for anything that throws

            var elementsThatThrow = document.Descendants()
                .Where(d => d.Attribute("throws") is not null);
            foreach (var element in elementsThatThrow) {
                var errorElement = new XElement(gs + "error-parameter",
                    new XAttribute("name", "error"),
                    new XAttribute("direction", "inout"),
                    new XAttribute("transfer-ownership", "full"),
                    new XElement(gi + "doc", "return location for a #GError"),
                    new XElement(gi + "type",
                        new XAttribute("name", "GLib.Error"),
                        new XAttribute(c + "type", "GError**")));
                if (element.Element(gi + "parameters") is null) {
                    element.Add(new XElement(gi + "parameters"));
                }
                element.Element(gi + "parameters").Add(errorElement);
            }

            // add instance parameter and user data parameter for signals

            foreach (var element in document.Descendants(glib + "signal")) {
                var parametersElement = element.Element(gi + "parameters");
                var declaringType = element.Parent.Attribute("name").AsString();
                parametersElement.AddFirst(new XElement(gi + "instance-parameter",
                    new XAttribute("name", declaringType.ToSnakeCase()),
                    new XAttribute("transfer-ownership", "none"),
                    new XElement(gi + "doc", "the instance on which the signal was invoked"),
                    new XElement(gi + "type",
                        new XAttribute("name", declaringType),
                        new XAttribute(c + "name", "gpointer"),
                        new XAttribute(gs + "is-pointer", "1")
                    )
                ));
                parametersElement.Add(new XElement(gi + "parameter",
                    new XAttribute("name", "user_data"),
                    new XAttribute("transfer-ownership", "none"),
                    new XAttribute("closure", parametersElement.Elements(gi + "parameter").Count()),
                    new XElement(gi + "type",
                        new XAttribute("name", "gpointer"),
                        new XAttribute(c + "name", "gpointer"),
                        new XAttribute(gs + "is-pointer", "1")
                    )
                ));
            }

            // set a value for parameters without transfer-ownership attribute

            foreach (var element in document.Descendants(gi + "return-value")
                .Where(x => x.Attribute("transfer-ownership") is null)) {
                element.SetAttributeValue("transfer-ownership", "full");
            }

            foreach (var element in document.Descendants(gi + "parameter")
                .Concat(document.Descendants(gi + "instance-parameter"))
                .Where(x => x.Attribute("transfer-ownership") is null)) {
                element.SetAttributeValue("transfer-ownership", "none");
            }

            // create dll-name attributes

            foreach (var element in document.Descendants().Where(x => x.Element(gi + "parameters") is not null || x.Element(gi + "return-value") is not null)) {
                if (element.Attribute(gs + "dll-name") is not null) {
                    // don't overwrite value from fixup.yml
                    continue;
                }
                element.SetAttributeValue(gs + "dll-name", dllName);
            }

            // create managed-name attributes

            foreach (var element in document.Descendants()) {
                if (element.Attribute(gs + "managed-name") is not null) {
                    continue;
                }

                if (element.Name == gi + "return-value") {
                    element.SetAttributeValue(gs + "managed-name", "ret");
                    continue;
                }

                // C arrays don't have a name attribute

                if (element.Name == gi + "array" && element.Attribute("name") is null) {
                    // special case for null-terminated arrays of strings
                    if (element.Attribute("zero-terminated").AsBool()) {
                        var elementType = element.Element(gi + "type").Attribute("name").AsString();
                        if (elementType == "utf8") {
                            element.SetAttributeValue("name", "GLib.Strv");
                            element.SetAttributeValue(gs + "managed-name", "GISharp.Lib.GLib.Strv");
                            continue;
                        }
                        if (elementType == "filename") {
                            element.SetAttributeValue(gs + "managed-name", typeof(FilenameArray));
                            continue;
                        }
                    }
                    element.SetAttributeValue(gs + "managed-name", typeof(CArray));
                    continue;
                }

                var attr = element.Attribute("name");
                if (attr is null) {
                    continue;
                }
                var name = attr.Value;

                // interfaces get an "I" prefix
                if (element.Name == gi + "interface") {
                    name = "I" + name;
                }

                // fix up type names

                if (element.Name == gi + "type" || element.Name == gi + "array") {
                    name = GetManagedTypeName(name);
                }

                // replace name by shadows if it exists (i.e. drop _full suffix)
                var shadows = element.Attribute("shadows");
                if (shadows is not null) {
                    name = shadows.Value;
                }

                // if method returns bool and does not throw and contains out parameters, add try_ prefix
                if (element.Name == gi + "function" || element.Name == gi + "method" || element.Name == gi + "virtual-method" || element.Name == gi + "callback") {
                    var returnTypeElement = element.Element(gi + "return-value")?.Element(gi + "type");
                    if (returnTypeElement?.Attribute("name")?.Value == "gboolean" && !element.Attribute("throws").AsBool()) {
                        var paramElements = element.Element(gi + "parameters").Elements(gi + "parameter");
                        if (paramElements.Any(x => x.Attribute("direction").AsString("in") == "out")) {
                            name = "try_" + name;
                        }
                    }
                }

                // virtual method names get an "Do" prefix because they usually
                // have the same name as the invoker method
                if (element.Name == gi + "virtual-method") {
                    name = "do_" + name;
                }

                // add "Signal" suffix to signals since signal names often
                // conflict with method names
                if (element.Name == glib + "signal") {
                    name += "_signal";
                }

                // check various conditions where we might want camelCase
                var camelCase = false;
                var accessModifier = element.Attribute(gs + "access-modifiers");
                if (accessModifier is not null && (element.Name == gi + "field" || element.Name == gi + "constant")) {
                    camelCase = accessModifier.Value.Contains("private");
                }
                if (element.Name == gi + "parameter" || element.Name == gi + "instance-parameter" || element.Name == gs + "error-parameter") {
                    camelCase = true;
                }

                name = camelCase ? name.ToCamelCase() : name.ToPascalCase();

                element.SetAttributeValue(gs + "managed-name", name);
            }

            // flag async methods

            foreach (var element in document.Descendants(gi + "method")
                .Concat(document.Descendants(gi + "function"))
                .Where(x => x.Attribute("name").AsString("").EndsWith("_async"))) {
                if (!element.Attribute(gs + "async").AsBool(true)) {
                    // fixup file can set gs:async="0" to skip this automatic fixup
                    continue;
                }

                if (element.Attribute(gs + "pinvoke-only").AsBool()) {
                    // ignore these too
                    continue;
                }

                var callbackElement = element.Element(gi + "parameters").Elements(gi + "parameter")
                    .SingleOrDefault(x => x.Element(gi + "type")?.Attribute(c + "type").AsString() == "GAsyncReadyCallback");
                if (callbackElement is null) {
                    // this doesn't fit the code generator async pattern
                    continue;
                }

                element.SetAttributeValue(gs + "async", "1");

                // see if the fixup file specified a finish-for method
                var asyncMethodName = element.Attribute("name").Value;
                var finishMethodElement = element.Parent.Elements()
                    .SingleOrDefault(x => x.Attribute(gs + "finish-for").AsString() == asyncMethodName);

                if (finishMethodElement is null) {
                    // try to find a matching method heuristically
                    var finishMethodName = asyncMethodName.Replace("_async", "_finish");
                    finishMethodElement = element.Parent.Elements(gi + "function")
                        .Concat(element.Parent.Elements(gi + "method"))
                        .SingleOrDefault(x => x.Attribute("name").AsString() == finishMethodName);

                    if (finishMethodElement is null) {
                        logger.LogWarning($"missing finish function for {element.GetXPath()}");
                        continue;
                    }

                    finishMethodElement.Name = element.Name;
                    finishMethodElement.SetAttributeValue(gs + "pinvoke-only", "1");
                    finishMethodElement.SetAttributeValue(gs + "finish-for", asyncMethodName);
                }

                element.SetAttributeValue(gs + "async-finish", finishMethodElement.Attribute(gs + "managed-name").Value);
            }

            // flag ref methods

            var elementsWithRefMethod = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "ref"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any());
            foreach (var element in elementsWithRefMethod) {
                element.SetAttributeValue(gs + "special-func", "ref");
                element.SetAttributeValue(gs + "pinvoke-only", "1");
            }

            // flag unref methods

            var elementsWithUnrefMethod = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "unref"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any());
            foreach (var element in elementsWithUnrefMethod) {
                element.SetAttributeValue(gs + "special-func", "unref");
                element.SetAttributeValue(gs + "pinvoke-only", "1");
            }

            // flag copy methods

            var elementsWithCopyMethod = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "copy"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any());
            foreach (var element in elementsWithCopyMethod) {
                element.SetAttributeValue(gs + "special-func", "copy");
                element.SetAttributeValue(gs + "pinvoke-only", "1");
            }

            // flag free methods

            var elementsWithFreeMethod = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "free"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any());
            foreach (var element in elementsWithFreeMethod) {
                element.SetAttributeValue(gs + "special-func", "free");
                element.SetAttributeValue(gs + "pinvoke-only", "1");
            }

            // flag compare methods

            var elementsWithCompareFunction = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "compare"
                   && d.Element(gi + "parameters").Elements(gi + "parameter").Count() == 1);
            foreach (var element in elementsWithCompareFunction) {
                element.SetAttributeValue(gs + "special-func", "compare");
                // convert to function
                element.Name = gi + "function";
                element.Element(gi + "parameters").Element(gi + "instance-parameter").Name = gi + "parameter";
            }

            // flag hash methods

            foreach (var element in document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "hash"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any()
                   && d.Element(gi + "return-value")?.Element(gi + "type")?.Attribute("name")?.Value == "guint")) {
                if (!element.Attribute(gs + "hash").AsBool(true)) {
                    continue;
                }

                element.SetAttributeValue(gs + "hash", 1);

                // change stuff to override built-in .NET method
                element.SetAttributeValue(gs + "managed-name", "GetHashCode");
                element.Element(gi + "return-value").Element(gi + "type")
                    .SetAttributeValue(gs + "managed-name", typeof(int));
            }

            // flag equal methods

            foreach (var element in document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "equal"
                   && d.Element(gi + "parameters").Elements(gi + "parameter").Count() == 1
                   && d.Element(gi + "return-value")?.Element(gi + "type")?.Attribute("name")?.Value == "gboolean")) {
                if (!element.Attribute(gs + "equal").AsBool(true)) {
                    continue;
                }

                element.SetAttributeValue(gs + "equal", 1);

                // change name to match IEquatable<T> built-in .NET method
                element.SetAttributeValue(gs + "managed-name", "Equals");
            }

            // flag to_string methods

            var elementsWithToStringFunction = document.Descendants(gi + "method")
                .Where(d => d.Attribute("name").Value == "to_string"
                   && !d.Element(gi + "parameters").Elements(gi + "parameter").Any());
            foreach (var element in elementsWithToStringFunction) {
                if (element.Attribute(gs + "to-string") is not null) {
                    continue;
                }
                element.SetAttributeValue(gs + "to-string", "1");
            }

            // flag extension methods

            var elementNamesThatRequireExtensionMethods = new[] {
                gi + "enumeration",
                gi + "bitfield",
                gi + "interface",
                gs + "static-class",
            };

            foreach (var element in document.Descendants(gi + "method")
                .Where(e => elementNamesThatRequireExtensionMethods.Contains(e.Parent.Name))) {
                element.SetAttributeValue(gs + "extension-method", "1");
            }

            // add is-pointer attribute to pointer types

            var typeElements = document.Descendants(gi + "type");
            foreach (var element in typeElements) {
                if (element.Parent.Name == gi + "array") {
                    // all arrays are pointers
                    element.Parent.SetAttributeValue(gs + "is-pointer", "1");
                }

                if (element.Attribute(gs + "is-pointer") is not null) {
                    // don't overwrite existing values
                    continue;
                }

                // special base types
                var name = element.Attribute("name").AsString();
                if (name == "utf8" || name == "filename") {
                    element.SetAttributeValue(gs + "is-pointer", "1");
                    continue;
                }

                // https://gitlab.gnome.org/GNOME/gobject-introspection/-/blob/master/girepository/girparser.c
                var pointerDepth = 0;
                var cType = element.Attribute(c + "type").AsString();
                if (cType is not null) {
                    pointerDepth += cType.Count(x => x == '*');
                    if (cType.StartsWith("gpointer", StringComparison.Ordinal)
                       || cType.StartsWith("gconstpointer", StringComparison.Ordinal)) {
                        pointerDepth++;
                    }
                }
                else if (element.Ancestors(glib + "signal").Any()) {
                    // signal parameters don't have c:type for non-basic types for some reason
                    pointerDepth++;
                }

                if (element.Parent.Name == gi + "parameter" && element.Parent.Attribute("direction").AsString("in") != "in") {
                    pointerDepth--;
                }

                // TODO: need to handle disguised structs. This probably means
                // resolving is-pointer later since the type may not be defined
                // in the GIR XML.
                if (pointerDepth > 0) {
                    element.SetAttributeValue(gs + "is-pointer", "1");
                }
            }

            // add skip attribute for bool return values on functions that throw

            foreach (var element in document.Descendants(gi + "return-value")
                .Where(x => x.Element(gi + "type")?.Attribute("name").AsString() == "gboolean"
                    && x.Parent.Attribute("throws").AsBool())) {
                if (element.Attribute("skip") is not null) {
                    continue;
                }
                element.SetAttributeValue("skip", "1");
            }

            // set a value for parameters without direction attribute

            foreach (var element in document.Descendants(gi + "parameter")
                .Concat(document.Descendants(gi + "instance-parameter"))
                .Concat(document.Descendants(gi + "return-value"))
                .Where(x => x.Attribute("direction") is null)) {
                element.SetAttributeValue("direction", "in");
            }

            // make all cancellable parameters have default value

            foreach (var element in document.Descendants(gi + "parameter")
                .Where(x => x.Element(gi + "type")?.Attribute(c + "type")?.Value == "GCancellable*"
                    && x.Attribute("nullable").AsBool())) {
                element.SetAttributeValue(gs + "default", "null");
            }

            // remove closure attribute from user data parameters in methods and functions

            foreach (var element in document.Descendants(gi + "parameter")
                .Where(x => (x.Parent.Parent.Name == gi + "method" || x.Parent.Parent.Name == gi + "function") &&
                    x.Attribute("closure") is not null &&
                    x.Element(gi + "type")?.Attribute("name")?.AsString() == "gpointer")
            ) {
                element.Attribute("closure").Remove();
            }

            // add managed-parameters element

            foreach (var element in document.Descendants(gi + "parameters")) {
                var managedParametersElement = new XElement(gs + "managed-parameters");
                foreach (var managedParameterElement in element.EnumerateManagedParameters()) {
                    managedParametersElement.Add(new XElement(managedParameterElement));
                }
                element.Parent.Add(managedParametersElement);
            }

            // fix up the async method return value based on the finish method

            foreach (var element in document.Descendants().Where(x => x.Attribute(gs + "finish-for") is not null)) {
                var returnValues = new List<XElement>();
                var finishReturnValueElement = element.Element(gi + "return-value");
                if (!finishReturnValueElement.Attribute("skip").AsBool() &&
                    finishReturnValueElement.Attribute(gs + "managed-name").Value != typeof(void).ToString()) {
                    returnValues.Add(finishReturnValueElement);
                }
                foreach (var p in element.Element(gs + "managed-parameters").Elements(gi + "parameter")
                    .Where(x => x.Attribute("direction").AsString("in") != "in")) {
                    returnValues.Add(p);
                }

                var asyncMethodName = element.Attribute(gs + "finish-for").Value;
                foreach (var asyncMethodElement in element.Parent.Elements(gi + "function")
                        .Concat(element.Parent.Elements(gi + "method"))
                        .Where(x => x.Attribute("name")?.Value == asyncMethodName)) {
                    var asyncReturnValueType = asyncMethodElement.Element(gi + "return-value").Element(gi + "type");
                    asyncReturnValueType.SetAttributeValue(gs + "managed-name", typeof(Task));

                    foreach (var r in returnValues) {
                        var newElement = new XElement(r.Element(gi + "type") ?? r.Element(gi + "array"));
                        asyncReturnValueType.Add(newElement);
                    }
                }
            }

            // add a <type> node for fields with <callback>

            foreach (var element in document.Descendants(gi + "callback")
                .Where(x => x.Parent.Name == gi + "field")) {
                var typeElement = new XElement(element);
                typeElement.RemoveNodes();
                typeElement.Name = gi + "type";
                element.AddBeforeSelf(typeElement);
            }

            // flag getters as properties

            var getters = document.Descendants()
                .Where(d => (d.Name == gi + "function" || d.Name == gi + "method")
                   && !d.Attribute(gs + "extension-method").AsBool()
                   && !d.Attribute(gs + "pinvoke-only").AsBool()
                   && (d.Attribute("name").Value.StartsWith("get_", StringComparison.Ordinal) || d.Attribute("name").Value.StartsWith("is_", StringComparison.Ordinal))
                   && (d.Element(gs + "managed-parameters") is null || !d.Element(gs + "managed-parameters").Elements(gi + "parameter").Any()));
            foreach (var element in getters) {
                var methodName = element.Attribute(gs + "managed-name").Value;
                var propertyName = methodName;
                if (element.Attribute("name").Value.StartsWith("get_", StringComparison.Ordinal)) {
                    // drop the Get prefix, but not the Is
                    propertyName = propertyName[3..];
                }
                else {
                    // In this case, the name starts with "Is", so add "Get"
                    // prefix to managed name of getter so that it doesn't
                    // conflict with the property name.
                    methodName = "Get" + methodName;
                    element.SetAttributeValue(gs + "managed-name", methodName);
                }

                // avoid conflict with object.GetType()
                if (element.Attribute(gs + "managed-name").AsString() == "GetType") {
                    element.Attribute(gs + "managed-name").SetValue("GetType_");
                }

                // create a new <gs:managed-property> element
                var propertyElement = new XElement(element) {
                    Name = gs + "managed-property"
                };
                propertyElement.SetAttributeValue(gs + "managed-name", propertyName);
                propertyElement.SetAttributeValue(c + "identifier", null);
                element.AddBeforeSelf(propertyElement);

                element.SetAttributeValue(gs + "property-getter-for", propertyName);
                element.SetAttributeValue(gs + "access-modifiers", "private");
            }

            // flag setters as properties (if there is a matching getter only)

            var setters = document.Descendants()
                .Where(d => (d.Name == gi + "function" || d.Name == gi + "method")
                   && !d.Attribute(gs + "pinvoke-only").AsBool()
                   && d.Attribute("name").Value.StartsWith("set_", StringComparison.Ordinal)
                   && d.Element(gi + "return-value")?.Element(gi + "type")?.Attribute("name").AsString("none") == "none"
                   && d.Element(gs + "managed-parameters") is not null
                   && d.Element(gs + "managed-parameters").Elements(gi + "parameter").Count() == 1);
            foreach (var element in setters) {
                var name = element.Attribute(gs + "managed-name").Value;
                // drop the Set prefix
                name = name[3..];
                var matchingGetter = element.Parent.Elements(element.Name)
                    .SingleOrDefault(e => e.Attribute(gs + "property-getter-for").AsString() == name);
                if (matchingGetter is null) {
                    // we don't want set-only properties
                    continue;
                }
                var returnValue = matchingGetter.Element(gi + "return-value");
                var getterReturnType = returnValue.Element(gi + "type") ?? returnValue.Element(gi + "array");
                var getterReturnTypeName = getterReturnType.Attribute(gs + "managed-name").Value;
                var setterParameter = element.Element(gs + "managed-parameters").Element(gi + "parameter");
                var setterParameterType = setterParameter.Element(gi + "type") ?? setterParameter.Element(gi + "array");
                var setterParameterTypeName = setterParameterType.Attribute(gs + "managed-name").Value;
                if (getterReturnTypeName != setterParameterTypeName) {
                    // this isn't the setter if the types don't match
                    continue;
                }
                // TODO: should store access-modifiers in property if different
                // than getter before overwriting
                element.SetAttributeValue(gs + "property-setter-for", name);
                element.SetAttributeValue(gs + "access-modifiers", "private");
            }

            // fix conflicting property names

            foreach (var element in document.Descendants(gi + "property")) {
                var managedName = element.Attribute(gs + "managed-name").Value;
                var managedPropertyElement = element.Parent.Elements(gs + "managed-property")
                    .SingleOrDefault(x => x.Attribute(gs + "managed-name").Value == managedName);
                if (managedPropertyElement is null) {
                    continue;
                }
                element.SetAttributeValue(gs + "managed-name", managedName + "_");
            }
        }

        /// <summary>
        /// Runs some tests to validate the XML before trying to use it
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="doc">Document.</param>
        public static void Validate(this XDocument doc)
        {
            foreach (var e in doc.Descendants().Where(d => ElementsThatDefineAType.Contains(d.Name))) {
                if (e.Attribute("name") is null) {
                    logger.LogWarning($"Missing name attribute at {e.GetXPath()}");
                }
                if (e.Attribute(gs + "managed-name") is null) {
                    logger.LogWarning($"Missing gs:managed-name attribute at {e.GetXPath()}");
                }
            }

            foreach (var e in doc.Descendants(gi + "namespace").Elements(gi + "constant").Where(x => !x.IsSkipped())) {
                logger.LogWarning($"Unused constant at {e.GetXPath()}");
            }
            foreach (var e in doc.Descendants(gi + "namespace").Elements(gi + "function").Where(x => !x.IsSkipped())) {
                logger.LogWarning($"Unused function at {e.GetXPath()}");
            }
        }

        /// <summary>
        /// Gets the GIRs included by this one (aka dependencies).
        /// </summary>
        public static IEnumerable<string> GetIncludes(this XDocument doc)
        {
            foreach (var element in doc.Descendants(gi + "include")) {
                yield return $"{element.Attribute("name").Value}-{element.Attribute("version").Value}";
            }
        }

        /// <summary>
        /// Enumerates the 'parameter' child elements of a 'parameters' element,
        /// filtering and sorting them for use in managed code.
        /// </summary>
        /// <remarks>
        /// Parameters that are closure, destory and array length arguments are
        /// omitted. The elements are reordered so that any parameter with a
        /// default value is moved to the end.
        /// </remarks>
        /// <returns>The parameter elements.</returns>
        /// <param name="parameters">A 'parameters' element.</param>
        static IEnumerable<XElement> EnumerateManagedParameters(this XElement parameters)
        {
            if (parameters.Name != gi + "parameters") {
                throw new ArgumentException("Requires <parameters> element.", nameof(parameters));
            }

            var list = parameters.Elements(gi + "parameter").ToList();

            // hide parameters that are handled internally

            var indexesToRemove = new List<int>();
            var isMethod = parameters.Parent.Name == gi + "method";
            // Closure args are tricky. Most of the time, the "closure" attribute
            // is on the callback argument. But, sometimes the user data argument
            // is annotated with (closure) or (closure <func>), in which case it
            // will also have a "closure" attribute. We don't want to expose the
            // user data args as a managed parameter but not accidentally hide
            // the callback parameter.
            //
            // This should be read as: remove parmeters at indexes specified by
            // closure attributes that are either callbacks (!= gpointer) or
            // user data args that point to themselves (== i).
            indexesToRemove.AddRange(list
                .Where((p, i) => p.GetClosureIndex() >= 0 &&
                       (p.Element(gi + "type").Attribute("name")?.Value != "gpointer" ||
                        p.GetClosureIndex(isMethod) == i))
                .Select(p => p.GetClosureIndex()));
            indexesToRemove.AddRange(list
                .Where(p => p.GetDestroyIndex() >= 0 &&
                       p.Element(gi + "type").Attribute("name")?.Value != "DestroyNotify")
                .Select(p => p.GetDestroyIndex()));
            indexesToRemove.AddRange(list
                .Where(p => p.GetLengthIndex() >= 0)
                .Select(p => p.GetLengthIndex()));
            indexesToRemove.AddRange(list
                .Where(p => p.Element(gi + "type")?.Attribute(c + "type")?.Value == "GAsyncReadyCallback")
                .Where(p => p.Parent.Parent.Attribute(gs + "async").AsBool())
                .Select(p => list.IndexOf(p)));
            var returnValueElement = parameters.Parent.Element(gi + "return-value");
            if (returnValueElement.GetClosureIndex() >= 0) {
                indexesToRemove.Add(returnValueElement.GetClosureIndex());
            }
            if (returnValueElement.GetDestroyIndex() >= 0) {
                indexesToRemove.Add(returnValueElement.GetDestroyIndex());
            }
            if (returnValueElement.GetLengthIndex() >= 0) {
                indexesToRemove.Add(returnValueElement.GetLengthIndex());
            }
            list = list.Where((p, i) => !indexesToRemove.Contains(i)).ToList();

            // reorder the parameters to that those with default values are at
            // the end and params are at the very end

            list = list.Where(p => p.Attribute(gs + "default") is null && p.Attribute(gs + "params") is null)
                       .Union(list.Where(p => p.Attribute(gs + "default") is not null && p.Attribute(gs + "params") is null))
                       .Union(list.Where(p => p.Attribute(gs + "params") is not null)).ToList();

            // In the GObject type system, enums and interfaces can have methods.
            // This is not allowed directly in C#, but it can be made to work
            // using extension methods, in which case we will need the instance
            // parameter. Otherwise, the instance parameter is skipped.

            if (parameters.Parent.Attribute(gs + "extension-method").AsBool() || parameters.Parent.Name == glib + "signal") {
                var instanceParameter = parameters.Element(gi + "instance-parameter");
                if (instanceParameter is not null) {
                    list.Insert(0, instanceParameter);
                }
            }

            return list;
        }

        public static IEnumerable<XName> ElementsThatDefineAType {
            get {
                yield return gi + "alias";
                yield return gi + "bitfield";
                yield return gi + "callback";
                yield return gi + "class";
                yield return gi + "enumeration";
                yield return gi + "interface";
                yield return gi + "record";
                yield return gi + "union";
                yield return gs + "static-class";
            }
        }

        public static IEnumerable<XName> ElementsThatReferenceAType {
            get {
                yield return gi + "return-value";
                yield return gi + "instance-parameter";
                yield return gi + "parameter";
                yield return gs + "error-parameter";
                yield return gi + "field";
                yield return gi + "constant";
                yield return gi + "property";
            }
        }

        /// <summary>
        /// Gets a list of basic GLib types that translate to primitives in managed code.
        /// </summary>
        /// <value>The list of type names.</value>
        /// <remarks>
        /// These are used in the "name" attribute of "type" elements.
        /// </remarks>
        static IEnumerable<string> PrimitiveGirTypeNames {
            get {
                yield return "gboolean";
                yield return "gpointer";
                yield return "gconstpointer";
                yield return "gchar";
                yield return "guchar";
                yield return "gunichar";
                yield return "gunichar2";
                yield return "gint";
                yield return "guint";
                yield return "gshort";
                yield return "gushort";
                yield return "gulong";
                yield return "glong";
                yield return "gint8";
                yield return "guint8";
                yield return "gint16";
                yield return "guint16";
                yield return "gint32";
                yield return "guint32";
                yield return "gint64";
                yield return "guint64";
                yield return "gfloat";
                yield return "gdouble";
                yield return "gsize";
                yield return "gssize";
                yield return "goffset";
                yield return "gintptr";
                yield return "guintptr";
            }
        }

        /// <summary>
        /// Gets a list of special type names used in .gir files.
        /// </summary>
        /// <value>The list of type names.</value>
        /// <remarks>
        /// These are used in the "name" attribute of "type" elements.
        /// </remarks>
        static IEnumerable<string> SpecialGirTypeNames {
            get {
                yield return "none";
                yield return "utf8";
                yield return "filename";
                yield return "va_list";
            }
        }

        public static string GetXPath(this XElement element)
        {
            if (element is null) {
                throw new ArgumentNullException(nameof(element));
            }

            var builder = new StringBuilder();
            foreach (var e in element.AncestorsAndSelf().Reverse()) {
                builder.Append('/');
                var prefix = e.GetPrefixOfNamespace(e.Name.Namespace);
                if (string.IsNullOrEmpty(prefix)) {
                    prefix = "gi";
                }
                builder.Append(prefix);
                builder.Append(':');
                builder.Append(e.Name.LocalName);
                var nameAttr = e.Attribute("name")?.Value;
                if (nameAttr is not null) {
                    builder.AppendFormat("[@name='{0}']", nameAttr);
                }
            }

            return builder.ToString();
        }

        static string GetManagedTypeName(string name)
        {
            switch (name) {
            // basic/fundamental types
            case "none":
                return typeof(void).ToString();
            case "gboolean":
                return typeof(bool).ToString();
            case "gchar":
            case "gint8":
                return typeof(sbyte).ToString();
            case "guchar":
            case "guint8":
                return typeof(byte).ToString();
            case "gshort":
            case "gint16":
                return typeof(short).ToString();
            case "gushort":
            case "guint16":
                return typeof(ushort).ToString();
            case "gunichar2":
                return typeof(char).ToString();
            case "gint":
            case "gint32":
            // size/offset are cast to int to match .NET convention
            case "gsize":
            case "gssize":
            case "goffset":
                return typeof(int).ToString();
            case "guint":
            case "guint32":
                return typeof(uint).ToString();
            case "gint64":
                return typeof(long).ToString();
            case "guint64":
                return typeof(ulong).ToString();
            case "glong":
                return typeof(CLong).ToString();
            case "gulong":
                return typeof(CULong).ToString();
            case "gfloat":
                return typeof(float).ToString();
            case "gdouble":
                return typeof(double).ToString();
            case "gpointer":
            case "gconstpointer":
                return typeof(IntPtr).ToString();
            case "gintptr":
                return "nint";
            case "guintptr":
                return "nuint";
            case "gunichar":
                return "GISharp.Lib.GLib.Unichar";
            case "GType":
                return "GISharp.Lib.GObject.GType";
            case "filename":
                return "GISharp.Lib.GLib.Filename";
            case "utf8":
                return "GISharp.Lib.GLib.Utf8";
            case "GObject.Callback":
                return typeof(Delegate).ToString();
            case "va_list":
                // va_list should be filtered out, but just in case...
                throw new NotSupportedException("va_list is not supported");
            }

            if (name.EndsWith("Private")) {
                return typeof(IntPtr).ToString();
            }

            if (name.Contains('.')) {
                return "GISharp.Lib." + name;
            }

            return name;
        }

        public static bool AsBool(this XAttribute attr, bool defaultValue = false)
        {
            if (attr is null) {
                return defaultValue;
            }
            return attr.Value != "0";
        }

        public static int AsInt(this XAttribute attr, int defaultValue = 0)
        {
            if (attr is null) {
                return defaultValue;
            }
            return int.Parse(attr.Value);
        }

        public static string AsString(this XAttribute attr, string defaultValue = null)
        {
            if (attr is null) {
                return defaultValue;
            }
            return attr.Value;
        }

        public static Transfer AsTransfer(this XAttribute attribute, string defaultValue)
        {
            return (attribute?.Value ?? defaultValue) switch {
                "none" => Transfer.None,
                "container" => Transfer.Container,
                "full" => Transfer.Full,
                _ => throw new ArgumentException("Unknown transfer-ownership type"),
            };
        }

        public static EmissionStage ToEmissionStage(this XAttribute attribute)
        {
            return attribute.Value switch {
                "first" => EmissionStage.First,
                "last" => EmissionStage.Last,
                "cleanup" => EmissionStage.Cleanup,
                _ => throw new ArgumentException("Unknown when value", nameof(attribute)),
            };
        }

        public static string ToPascalCase(this string str)
        {
            if (str is null) {
                return null;
            }

            if (str.Contains('_') || str.Contains('-')) {
                var words = str.Split('_', '-').Select(w => w.ToPascalCase());
                str = string.Join("", words);
            }
            else {
                if (str == str.ToUpper()) {
                    str = str.ToLower();
                }
                str = ((str.Length > 0) ? str.Substring(0, 1).ToUpper() : "")
                    + ((str.Length > 1) ? str[1..] : "");
            }

            return str;
        }

        public static string ToCamelCase(this string str)
        {
            if (str is null) {
                return null;
            }
            str = str.ToPascalCase();
            str = ((str.Length > 0) ? str.Substring(0, 1).ToLower() : "")
                + ((str.Length > 1) ? str[1..] : "");
            if (ParseToken(str).IsReservedKeyword()) {
                str = "@" + str;
            }
            return str;
        }

        public static string ToSnakeCase(this string str)
        {
            if (str is null) {
                return null;
            }

            str = Regex.Replace(str, @"[A-Z]", m => $"_{m.Value.ToLowerInvariant()}")[1..];

            return str;
        }

        // Thanks, http://stackoverflow.com/a/3584742/1976323
        static XElement ParseElement(string xml)
        {
            var context = new XmlParserContext(null, Manager, null, XmlSpace.None);
            var reader = XmlReader.Create(new StringReader(xml), null, context);
            return XElement.Load(reader);
        }

        // YAML data structures

#pragma warning disable CS0649
        public abstract class Command
        {
        }

        public class AddElement : Command
        {
            public string Xml { get; set; }
            public string Xpath { get; set; }
        }

        public class SetAttribute : Command
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Xpath { get; set; }
        }

        public class ChangeAttribute : Command
        {
            public string Name { get; set; }
            public string Regex { get; set; }
            public string Replace { get; set; }
            public string Xpath { get; set; }
        }

        public class ChangeElement : Command
        {
            public string NewName { get; set; }
            public string Xpath { get; set; }
        }

        public class MoveElement : Command
        {
            public string Xpath { get; set; }
            public string NewParentXpath { get; set; }
        }
#pragma warning restore CS0649
    }
}
