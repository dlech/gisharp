using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Xml.XPath;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis.CSharp;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using GISharp.Runtime;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;

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
                if (_Manager == null) {
                    _Manager = new XmlNamespaceManager (new NameTable ());
                    _Manager.AddNamespace (string.Empty, gi.NamespaceName);
                    // default namespace does not seem to work in XPathGetElement(s) extension methods
                    // so we add a named namespace for it too.
                    _Manager.AddNamespace ("gi", gi.NamespaceName);
                    _Manager.AddNamespace ("c", c.NamespaceName);
                    _Manager.AddNamespace ("glib", glib.NamespaceName);
                    _Manager.AddNamespace ("gs", gs.NamespaceName);
                }
                return _Manager;
            }
        }

        /// <summary>
        /// Creates a new gir-fixup.yml file that skips everything in the GIR
        /// XML file.
        /// </summary>
        /// <param name="gir">The GIR XML document</param>
        /// <param name="writer">TextWriter where the YAML will be written</param>
        public static void Generate(this XDocument gir, TextWriter writer)
        {
            if (gir == null) {
                throw new ArgumentNullException(nameof(gir));
            }
            if (writer == null) {
                throw new ArgumentNullException(nameof(writer));
            }

            // we want everything lower-case and hyphenated
            var hyphenator = new HyphenatedNamingConvention();

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

            var commands = gir.Element(gi + "repository").Element(gi + "namespace").Elements()
                .Where(e => !e.IsSkipped()) // these will be handled by ApplyBuiltinFixup()
                .Select(e => new SetAttribute {
                    Name = "introspectable",
                    Value = "0",
                    Xpath = $"gi:repository/gi:namespace/gi:{e.Name.LocalName}[@name='{e.Attribute("name").Value}']"
                }).ToList<Command>();

            serializer.Serialize(writer, commands);
        }

        /// <summary>
        /// Parses data from a gir-fixup.yml file
        /// </summary>
        /// <param name="yaml"/>YAML text data</param>
        public static Command[] Parse(TextReader reader)
        {
            if (reader == null) {
                throw new ArgumentNullException(nameof(reader));
            }

            // we expect everything lower-case and hyphenated
            var hyphenator = new HyphenatedNamingConvention();

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

        public static void ApplyFixup(this XDocument document, Command[] commands)
        {
            if (document == null) {
                throw new ArgumentNullException(nameof(document));
            }
            if (commands == null) {
                throw new ArgumentNullException (nameof(commands));
            }

            foreach (var command in commands) {
                switch (command) {
                case AddElement addElement:
                    var newElement = parseElement(addElement.Xml);
                    var addParent = document.XPathSelectElement(addElement.Xpath, Manager);
                    if (addParent == null) {
                        Console.Error.WriteLine($"Could not find element at '{addElement.Xpath}'");
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
                        Console.Error.WriteLine($"Could not find any elements matching '{setAttr.Xpath}'");
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
                        Console.Error.WriteLine($"Could not find any elements matching '{changeAttr.Xpath}'");
                        break;
                    }
                    foreach (var element in changeAttrElements) {
                        var attribute = element.Attribute(changeAttrNamespace + changeAttrLocalName);
                        var oldValue = attribute == null ? string.Empty : attribute.Value;
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
                    if (elementsToChange == null) {
                        Console.Error.WriteLine($"Could not find elements matching '{changeElement.Xpath}'");
                        break;
                    }
                    foreach (var element in elementsToChange) {
                        element.Name = elementNamespace + elementLocalName;
                    }
                    break;
                case MoveElement moveElement:
                    var moveElements = document.XPathSelectElements(moveElement.Xpath, Manager).ToList();
                    if (moveElements.Count == 0) {
                        Console.Error.WriteLine($"Could not find any elements matching '{moveElement.Xpath}'");
                    }
                    var moveParent = document.XPathSelectElement(moveElement.NewParentXpath, Manager);
                    if (moveParent == null) {
                        Console.Error.WriteLine($"Could not find element at '{moveElement.NewParentXpath}'");
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
                || element.Attribute("moved-to") != null
                || element.Attribute ("shadowed-by") != null
                || IsCallableWithVarArgs()
                || IsAutoptrAlias();

            bool IsCallableWithVarArgs()
            {
                var parameters = element.Element(gi + "parameters");
                if (parameters == null) {
                    return false;
                }
                foreach (var child in parameters.Elements(gi + "parameter")) {
                    if (child.Element(gi + "type")?.Attribute("name").AsString() == "va_list") {
                        return true;
                    }
                    if (child.Element(gi + "varargs") != null) {
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

        public static void ApplyBuiltinFixup (this XDocument document)
        {
            var dllName = document.Element(gi + "repository").Element(gi + "package").Attribute("name").Value;
            
            // add the gs namespace prefix

            document.Root.SetAttributeValue (XNamespace.Xmlns + "gs", gs.NamespaceName);

            // all fields must be included for proper struct sizes

            foreach (var element in document.Descendants(gi + "field")
                .Where(x => !x.Attribute("introspectable").AsBool(true)))
            {
                element.SetAttributeValue("introspectable", "1");

                // if it is a callback, change it to an IntPtr
                var callbackElement = element.Element(gi + "callback");
                if (callbackElement != null) {
                    callbackElement.Name = gi + "type";
                    callbackElement.SetAttributeValue("name", "gpointer");
                }
            }

            // remove non-introspectable nodes

            var elementsToRemove = document.Descendants ()
                .Where (d => d.Name != gi + "return-value" && d.Name != gi + "parameter")
                .Where (d => d.IsSkipped())
                .ToList ();
            foreach (var element in elementsToRemove) {
                element.Remove ();
            }

            // add functions for GType getters

            var elementsWithGTypeGetter = document.Descendants ()
                .Where (d => d.Attribute (glib + "get-type").AsString ("intern") != "intern");
            foreach (var element in elementsWithGTypeGetter) {
                var functionElement = new XElement (
                    gi + "function",
                    new XAttribute("name", "get_g_type"),
                    new XAttribute(gs + "pinvoke-only", "1"),
                    new XAttribute (c + "identifier", element.Attribute (glib + "get-type").Value),
                    new XAttribute (gs + "access-modifiers", "private"),
                    new XElement (
                        gi + "return-value",
                        new XElement (
                            gi + "type",
                            new XAttribute("name", "GType"),
                            new XAttribute(c + "type", "GType"))));
                // GLib get_type functions are defined in GObject library
                if (dllName == "glib-2.0") {
                    functionElement.SetAttributeValue(gs + "dll-name", "gobject-2.0");
                }
                element.Add (functionElement);
            }

            // add value field to all alias elements

            var aliasElements = document.Descendants (gi + "alias");
            foreach (var element in aliasElements) {
                var valueFieldElement = new XElement (gi + "field",
                    new XAttribute ("name", "value"),
                    new XAttribute (gs + "access-modifiers", "private"),
                    new XElement (element.Element (gi + "type")));
                element.Add (valueFieldElement);
            }

            // add error parameters for anything that throws

            var elementsThatThrow = document.Descendants ()
                .Where (d => d.Attribute ("throws") != null);
            foreach (var element in elementsThatThrow) {
                var errorElement = new XElement (gs + "error-parameter",
                    new XAttribute ("name", "error"),
                    new XAttribute("direction", "inout"),
                    new XAttribute("transfer-ownership", "full"),
                    new XElement (gi + "doc", "return location for a #GError"),
                    new XElement (gi + "type",
                        new XAttribute("name", "GLib.Error"),
                        new XAttribute(c + "type", "GError**")));
                if (element.Element (gi + "parameters") == null) {
                    element.Add (new XElement (gi + "parameters"));
                }
                element.Element (gi + "parameters").Add (errorElement);
            }

            // create dll-name attributes

            foreach (var element in document.Descendants().Where(x => x.Element(gi + "parameters") != null || x.Element(gi + "return-value") != null)) {
                if (element.Attribute(gs + "dll-name") != null) {
                    // don't overwrite value from fixup.yml
                    continue;
                }
                element.SetAttributeValue(gs + "dll-name", dllName);
            }

            // create managed-name attributes

            foreach (var element in document.Descendants ()) {
                if (element.Attribute (gs + "managed-name") != null) {
                    continue;
                }

                if (element.Name == gi + "return-value") {
                    element.SetAttributeValue (gs + "managed-name", "ret");
                    continue;
                }

                // C arrays don't have a name attribute

                if (element.Name == gi + "array" && element.Attribute("name") == null) {
                    // special case for null-terminated arrays of strings
                    if (element.Attribute("zero-terminated").AsBool()) {
                        var elementType = element.Element(gi + "type").Attribute("name").AsString();
                        if (elementType == "utf8") {
                            element.SetAttributeValue(gs + "managed-name", typeof(Strv));
                            continue;
                        }
                        if (elementType == "filename") {
                            element.SetAttributeValue(gs + "managed-name", typeof(FilenameArray));
                            continue;
                        }
                    }
                    element.SetAttributeValue(gs + "managed-name", typeof(IArray<>));
                    continue;
                }

                var attr = element.Attribute ("name");
                if (attr == null) {
                    continue;
                }
                var name = attr.Value;

                // fix up type names

                if (element.Name == gi + "type" || element.Name == gi + "array") {
                    name = GetManagedTypeName(name);
                }

                // replace name by shadows if it exists (i.e. drop _full suffix)
                var shadows = element.Attribute ("shadows");
                if (shadows != null) {
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

                // add "ed" suffix to events
                if (element.Name == glib + "signal") {
                    if (!name.EndsWith("ed") && !name.EndsWith("ing")) {
                        if (name.EndsWith('y')) {
                            name = name.Substring(name.Length - 1) + "i";
                        }
                        if (!name.EndsWith('e')) {
                            name += "e";
                        }
                        name += "d";
                    }
                }

                // check various conditions where we might want camelCase
                var camelCase = false;
                var accessModifier = element.Attribute (gs + "access-modifiers");
                if (accessModifier != null && (element.Name == gi + "field" || element.Name == gi + "constant")) {
                    camelCase = accessModifier.Value.Contains ("private");
                }
                if (element.Name == gi + "parameter" || element.Name == gi + "instance-parameter" || element.Name == gs + "error-parameter") {
                    camelCase = true;
                }

                name = camelCase ? name.ToCamelCase () : name.ToPascalCase ();

                element.SetAttributeValue (gs + "managed-name", name);
            }

            // flag extension methods
            var elementNamesThatRequireExtensionMethods = new [] {
                gi + "enumeration",
                gi + "bitfield",
                gi + "interface",
            };
            var elementsThatRequireExtensionMethods = document.Descendants (gi + "method")
                .Where (e => elementNamesThatRequireExtensionMethods.Contains (e.Parent.Name));
            foreach (var element in elementsThatRequireExtensionMethods) {
                element.SetAttributeValue (gs + "extension-method", "1");
            }

            // flag ref functions

            var elementsWithRefMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "ref"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithRefMethod) {
                element.SetAttributeValue (gs + "special-func", "ref");
                element.SetAttributeValue (gs + "pinvoke-only", "1");
            }

            // flag unref functions

            var elementsWithUnrefMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "unref"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithUnrefMethod) {
                element.SetAttributeValue (gs + "special-func", "unref");
                element.SetAttributeValue (gs + "pinvoke-only", "1");
            }

            // flag copy functions

            var elementsWithCopyMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "copy"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithCopyMethod) {
                element.SetAttributeValue (gs + "special-func", "copy");
                element.SetAttributeValue (gs + "pinvoke-only", "1");
            }

            // flag free functions

            var elementsWithFreeMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "free"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithFreeMethod) {
                element.SetAttributeValue (gs + "special-func", "free");
                element.SetAttributeValue (gs + "pinvoke-only", "1");
            }

            // flag equals functions

            var elementsWithEqualsFunction = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "equal"
                    && d.Element (gi + "parameters").Elements (gi + "parameter").Count () == 1);
            foreach (var element in elementsWithEqualsFunction) {
                element.SetAttributeValue (gs + "special-func", "equal");
                element.SetAttributeValue (gs + "managed-name", "Equals");
            }

            // flag compare functions

            var elementsWithCompareFunction = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "compare"
                    && d.Element (gi + "parameters").Elements (gi + "parameter").Count () == 1);
            foreach (var element in elementsWithCompareFunction) {
                element.SetAttributeValue (gs + "special-func", "compare");
                element.SetAttributeValue (gs + "managed-name", "CompareTo");
            }

            // flag hash functions

            var elementsWithHashFunction = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "hash"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ()
                    && d.Element (gi + "return-value").Element (gi + "type") != null
                    && d.Element (gi + "return-value").Element (gi + "type").Attribute ("name").Value == "guint");
            foreach (var element in elementsWithHashFunction) {
                element.SetAttributeValue (gs + "special-func", "hash");
                element.SetAttributeValue (gs + "access-modifiers", "public override");
                // set managed-name here so it don't get turned into a property getter
                element.SetAttributeValue (gs + "managed-name", "GetHashCode");
                // change return type to match .NET
                element.Element (gi + "return-value").Element (gi + "type").SetAttributeValue ("name", "gint");
            }

            // flag to_string functions

            var elementsWithToStringFunction = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "to_string"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithToStringFunction) {
                element.SetAttributeValue (gs + "special-func", "to-string");
                element.SetAttributeValue (gs + "access-modifiers", "public override");
            }

            // add is-pointer attribute to pointer types

            var typeElements = document.Descendants(gi + "type");
            foreach (var element in typeElements) {

                if (element.Parent.Name == gi + "array") {
                    // all arrays are pointers
                    element.Parent.SetAttributeValue(gs + "is-pointer", "1");
                    continue;
                }

                if (element.Attribute(gs + "is-pointer") != null) {
                    // don't overwrite existing values
                    continue;
                }

                var cType = element.Attribute(c + "type").AsString();
                if (cType == null) {
                    // if there is no C type, it is probably a pointer
                    element.SetAttributeValue(gs + "is-pointer", "1");
                }
                else if (IsPointerType(cType)) {
                    element.SetAttributeValue(gs + "is-pointer", "1");
                }
            }

            // add skip attribute for bool return values on functions that throw

            foreach (var element in document.Descendants(gi + "return-value")
                .Where(x => x.Element(gi + "type")?.Attribute("name").AsString() == "gboolean"
                    && x.Parent.Attribute("throws").AsBool()))
            {
                if (element.Attribute("skip") != null) {
                    continue;
                }
                element.SetAttributeValue("skip", "1");
            }

            // ensure that functions without parameters have an empty <parameters> element

            foreach (var element in document.Descendants(gi + "function")
                .Concat(document.Descendants(gi + "constructor"))
                .Concat(document.Descendants(gi + "method"))
                .Concat(document.Descendants(glib + "signal"))
                .Where(x => x.Element(gi + "parameters") == null))
            {
                element.Add(new XElement(gi + "parameters"));
            }

            // set a value for parameters without transfer-ownership attribute

            foreach (var element in document.Descendants(gi + "return-value")
                .Where(x => x.Attribute("transfer-ownership") == null))
            {
                element.SetAttributeValue("transfer-ownership", "full");
            }

            foreach (var element in document.Descendants(gi + "parameter")
                .Concat(document.Descendants(gi + "instance-parameter"))
                .Where(x => x.Attribute("transfer-ownership") == null))
            {
                element.SetAttributeValue("transfer-ownership", "none");
            }

            // set a value for parameters without direction attribute

            foreach (var element in document.Descendants(gi + "return-value")
                .Where(x => x.Attribute("direction") == null))
            {
                element.SetAttributeValue("direction", "out");
            }

            foreach (var element in document.Descendants(gi + "parameter")
                .Concat(document.Descendants(gi + "instance-parameter"))
                .Where(x => x.Attribute("direction") == null))
            {
                element.SetAttributeValue("direction", "in");
            }

            // TODO: add instance parameter and user data parameter for signals

            // first parameter virtual method is instance parameter

            foreach (var element in document.Descendants(gi + "virtual-method")
                .Concat(document.Descendants(gi + "callback").Where(x => x.Parent.Name == gi + "field")))
            {
                if (element.Element(gi + "parameters").Element(gi + "instance-parameter") != null) {
                    // there is already an instance parameter, so don't make another
                    continue;
                }
                var instanceParam = element.Element(gi + "parameters").Elements(gi + "parameter").First();
                instanceParam.Name = gi + "instance-parameter";
            }

            // make all cancellable parameters have default value

            foreach (var element in document.Descendants(gi + "parameter")
                .Where(x => x.Element(gi + "type")?.Attribute(c + "type")?.Value == "GCancellable*"
                    && x.Attribute("nullable").AsBool()))
            {
                element.SetAttributeValue(gs + "default", "null");
            }


            // add managed-parameters element

            var parameterElements = document.Descendants (gi + "parameters");
            foreach (var element in parameterElements) {
                var managedParametersElement = new XElement(gs + "managed-parameters");
                foreach (var managedParameterElement in element.EnumerateManagedParameters ()) {
                    managedParametersElement.Add(new XElement(managedParameterElement));
                }
                element.Parent.Add(managedParametersElement);
            }

            // fix the callback type names for (unmanaged) parameters

            foreach (var element in document.Descendants(gi + "parameter")
                .Where(p => p.Parent.Name == gi + "parameters" && p.Attribute("scope") != null))
            {
                var typeElement = element.Element(gi + "type");
                var managedName = typeElement.Attribute(gs + "managed-name").Value;
                if (managedName == typeof(Delegate).ToString()) {
                    continue;
                }
                var index = managedName.LastIndexOf('.') + 1;
                managedName = managedName.Substring(0, index) + "Unmanaged" + managedName.Substring(index);
                typeElement.SetAttributeValue(gs + "managed-name", managedName);
            }

            // add a <type> node for fields with <callback>

            foreach (var element in document.Descendants(gi + "callback")
                .Where(x => x.Parent.Name == gi + "field"))
            {
                var typeElement = new XElement(element);
                typeElement.RemoveNodes();
                typeElement.Name = gi + "type";
                element.AddBeforeSelf(typeElement);
            }

            // flag getters as properties

            var getters = document.Descendants ()
                .Where (d => (d.Name == gi + "function" || d.Name == gi + "method")
                    && !d.Attribute (gs + "extension-method").AsBool ()
                    && !d.Attribute (gs + "pinvoke-only").AsBool ()
                    && (d.Attribute ("name").Value.StartsWith ("get_", StringComparison.Ordinal) || d.Attribute ("name").Value.StartsWith ("is_", StringComparison.Ordinal))
                    && (d.Element (gs + "managed-parameters") == null || !d.Element (gs + "managed-parameters").Elements (gi + "parameter").Any ()));
            foreach (var element in getters) {
                var methodName = element.Attribute(gs + "managed-name").Value;
                var propertyName = methodName;
                if (element.Attribute("name").Value.StartsWith("get_", StringComparison.Ordinal)) {
                    // drop the Get prefix, but not the Is
                    propertyName = propertyName.Substring(3);
                }
                else {
                    // In this case, the name starts with "Is", so add "Get"
                    // prefix to managed name of getter so that it doesn't
                    // conflict with the property name.
                    methodName = "Get" + methodName;
                    element.SetAttributeValue(gs + "managed-name", methodName);
                }

                // create a new <gs:managed-property> element
                var propertyElement = new XElement(element);
                propertyElement.Name = gs + "managed-property";
                propertyElement.SetAttributeValue(gs + "managed-name", propertyName);
                element.AddBeforeSelf(propertyElement);

                element.SetAttributeValue(gs + "property-getter-for", propertyName);
                element.SetAttributeValue(gs + "access-modifiers", "private");
            }

            // flag setters as properties (if there is a matching getter only)

            var setters = document.Descendants ()
                .Where (d => (d.Name == gi + "function" || d.Name == gi + "method")
                    && !d.Attribute (gs + "pinvoke-only").AsBool ()
                    && d.Attribute ("name").Value.StartsWith ("set_", StringComparison.Ordinal)
                    && d.Element (gs + "managed-parameters") != null
                    && d.Element (gs + "managed-parameters").Elements (gi + "parameter").Count () == 1);
            foreach (var element in setters) {
                var name = element.Attribute (gs + "managed-name").Value;
                // drop the Set prefix
                name = name.Substring (3);
                var matchingGetter = element.Parent.Elements(element.Name)
                    .SingleOrDefault(e => e.Attribute(gs + "property-getter-for").AsString() == name);
                if (matchingGetter == null) {
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
        }

        /// <summary>
        /// Runs some tests to validate the XML before trying to use it
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="doc">Document.</param>
        public static void Validate (this XDocument doc)
        {
            foreach (var e in doc.Descendants ().Where (d => ElementsThatDefineAType.Contains (d.Name))) {
                if (e.Attribute ("name") == null) {
                    Console.WriteLine ("Missing name attribute at {0}", e.GetXPath ());
                }
                if (e.Attribute (gs + "managed-name") == null) {
                    Console.WriteLine ("Missing gs:managed-name attribute at {0}", e.GetXPath ());
                }
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
        static IEnumerable<XElement> EnumerateManagedParameters (this XElement parameters)
        {
            if (parameters.Name != gi + "parameters") {
                throw new ArgumentException("Requires <parameters> element.", nameof(parameters));
            }

            var list = parameters.Elements (gi + "parameter").ToList ();

            // hide parameters that are handled internally

            var indexesToRemove = new System.Collections.Generic.List<int>();
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
            indexesToRemove.AddRange (list
                .Where ((p, i) => p.GetClosureIndex () >= 0 &&
                        (p.Element (gi + "type").Attribute ("name")?.Value != "gpointer" ||
                         p.GetClosureIndex (isMethod) == i))
                .Select (p => p.GetClosureIndex ()));
            indexesToRemove.AddRange (list
                .Where (p => p.GetDestroyIndex () >= 0 &&
                        p.Element (gi + "type").Attribute ("name")?.Value != "DestroyNotify")
                .Select (p => p.GetDestroyIndex ()));
            indexesToRemove.AddRange (list
                .Where (p => p.GetLengthIndex () >= 0)
                .Select (p => p.GetLengthIndex ()));
            var returnValueElement = parameters.Parent.Element (gi + "return-value");
            if (returnValueElement.GetClosureIndex () >= 0) {
                indexesToRemove.Add (returnValueElement.GetClosureIndex ());
            }
            if (returnValueElement.GetDestroyIndex () >= 0) {
                indexesToRemove.Add (returnValueElement.GetDestroyIndex ());
            }
            if (returnValueElement.GetLengthIndex () >= 0) {
                indexesToRemove.Add (returnValueElement.GetLengthIndex ());
            }
            list = list.Where ((p, i) => !indexesToRemove.Contains (i)).ToList ();

            // reorder the parameters to that those with default values are at
            // the end and params are at the very end

            list = list.Where (p => p.Attribute (gs + "default") == null && p.Attribute (gs + "params") == null)
                       .Union (list.Where (p => p.Attribute (gs + "default") != null && p.Attribute (gs + "params") == null))
                       .Union (list.Where (p => p.Attribute (gs + "params") != null)).ToList ();

            // In the GObject type system, enums and interfaces can have methods.
            // This is not allowed directly in C#, but it can be made to work
            // using extension methods, in which case we will need the instance
            // parameter. Otherwise, the instance parameter is skipped.

            if (parameters.Parent.Attribute (gs + "extension-method").AsBool ()) {
                var instanceParameter = parameters.Element (gi + "instance-parameter");
                if (instanceParameter != null) {
                    list.Insert (0, instanceParameter);
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

        static bool IsPointerType(string cType)
        {
            if (cType.EndsWith("*", StringComparison.Ordinal)) {
                return true;
            }

            switch (cType) {
            case "gpointer":
            case "gconstpointer":
            case "GLib.Array":
            case "GLib.PtrArray":
            case "GLib.ByteArray":
                return true;
            default:
                return false;
            }
        }

        public static string GetXPath (this XElement element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof (element));
            }

            var builder = new StringBuilder ();
            foreach (var e in element.AncestorsAndSelf ().Reverse ()) {
                builder.Append ("/");
                builder.Append (e.Name.LocalName);
                var nameAttr = e.Attribute ("name")?.Value;
                if (nameAttr != null) {
                    builder.AppendFormat ("[@name='{0}']", nameAttr);
                }
            }

            return builder.ToString ();
        }

        public static string GetNamespace (this XElement element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            var namespaceElement = element.Ancestors (gi + "namespace").Single ();
            var @namespace = namespaceElement.Attribute (gs + "managed-name").Value;

            return @namespace;
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
                // hiding the fact that glong could be 32-bit
                // this could cause trouble, but it is not used frequently
                case "glong":
                    return typeof(long).ToString();
                case "guint64":
                // hiding the fact that gulong could be 32-bit
                // this could cause trouble, but it is not used frequently
                case "gulong":
                    return typeof(ulong).ToString();
                case "gfloat":
                    return typeof(float).ToString();
                case "gdouble":
                    return typeof(double).ToString();
                case "gpointer":
                case "gconstpointer":
                case "gintptr":
                    return typeof(IntPtr).ToString();
                case "guintptr":
                    return typeof(UIntPtr).ToString();
                case "gunichar":
                    return typeof(Unichar).ToString();
                case "GType":
                    return typeof(GType).ToString();
                case "filename":
                    return typeof(Filename).ToString();
                case "utf8":
                    return typeof(Utf8).ToString();
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

        public static bool AsBool (this XAttribute attr, bool defaultValue = false)
        {
            if (attr == null) {
                return defaultValue;
            }
            return attr.Value != "0";
        }

        public static int AsInt (this XAttribute attr, int defaultValue = 0)
        {
            if (attr == null) {
                return defaultValue;
            }
            return int.Parse (attr.Value);
        }

        public static string AsString (this XAttribute attr, string defaultValue = null)
        {
            if (attr == null) {
                return defaultValue;
            }
            return attr.Value;
        }

        public static Transfer AsTransfer(this XAttribute attribute, string defaultValue)
        {
            switch (attribute?.Value ?? defaultValue) {
            case "none":
                return Transfer.None;
            case "container":
                return Transfer.Container;
            case "full":
                return Transfer.Full;
            default:
                throw new ArgumentException("Unknown transfer-ownership type");
            }
        }

        public static EmissionStage ToEmissionStage(this XAttribute attribute)
        {
            switch (attribute.Value) {
                case "first":
                    return EmissionStage.First;
                case "last":
                    return EmissionStage.Last;
                case "cleanup":
                    return EmissionStage.Cleanup;
                default:
                    throw new ArgumentException("Unknown when value", nameof(attribute));
            }
        }

        public static string ToPascalCase (this string str)
        {
            if (str == null) {
                return null;
            }

            if (str.Contains ('_') || str.Contains ('-')) {
                var words = str.Split ('_', '-').Select (w => w.ToPascalCase ());
                str = string.Join ("", words);
            } else {
                if (str == str.ToUpper ()) {
                    str = str.ToLower ();
                }
                str = ((str.Length > 0) ? str.Substring (0, 1).ToUpper () : "")
                    + ((str.Length > 1) ? str.Substring (1) : "");
            }

            return str;
        }

        public static string ToCamelCase (this string str)
        {
            if (str == null) {
                return null;
            }
            str = str.ToPascalCase ();
            str = ((str.Length > 0) ? str.Substring (0, 1).ToLower () : "")
                + ((str.Length > 1) ? str.Substring (1) : "");
            if (ParseToken (str).IsReservedKeyword ()) {
                str = "@" + str;
            }
            return str;
        }

        // Thanks, http://stackoverflow.com/a/3584742/1976323
        static XElement parseElement (string xml)
        {
            var context = new XmlParserContext (null, Manager, null, XmlSpace.None);
            var reader = XmlReader.Create (new StringReader (xml), null, context);
            return XElement.Load (reader);
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

        public class SetAttribute: Command
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
