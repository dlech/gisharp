using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Xml.XPath;
using System.Text.RegularExpressions;
//using GISharp.Core;
using Microsoft.CodeAnalysis.CSharp;

using nlong = NativeLong.NativeLong;
using nulong = NativeLong.NativeULong;

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

        public static void ApplyFixupFile (this XDocument document, string filename)
        {
            if (document == null) {
                throw new ArgumentNullException ("document");
            }
            if (filename == null) {
                throw new ArgumentNullException ("filename");
            }

            var quoteCount = 0;
            var lastCharWasEscape = false;
            var builder = new StringBuilder ();
            string command = null;
            var parameters = new List<string> ();

            var commands = new List<Tuple<string,List<string>>> ();
            var lineNo = 0;
            foreach (var line in File.ReadLines (filename)) {
                lineNo++;
                if (string.IsNullOrWhiteSpace (line) || line.StartsWith ("#", StringComparison.Ordinal)) {
                    // ignore empty lines and comments
                    continue;
                }
                var charNo = 0;
                if (!lastCharWasEscape) {
                    // if the previous line did not end with a backslash, then reset for next command
                    quoteCount = 0;
                    builder.Clear ();
                    command = null;
                    parameters = new List<string> ();
                }
                lastCharWasEscape = false;
                foreach (var c in line) {
                    charNo++;

                    // read the command - it is not quoted

                    if (command == null) {
                        if (char.IsWhiteSpace (c)) {
                            command = builder.ToString ();
                            builder.Clear ();
                        } else {
                            builder.Append (c);
                        }
                        continue;
                    }

                    // then read all of the parameters - they are all in quotes

                    if (c == '"' && !lastCharWasEscape) {
                        quoteCount++;
                        if ((quoteCount % 2) == 0) {
                            parameters.Add (builder.ToString ());
                            builder.Clear ();
                        }
                    } else {
                        if ((quoteCount % 2) == 0) {
                            if (!char.IsWhiteSpace (c) && (c != '\\')) {
                                throw new Exception (string.Format ("Expecting whitespace at {0}:{1}", lineNo, charNo));
                            }
                        } else {
                            builder.Append (c);
                        }
                    }
                    lastCharWasEscape = (c == '\\');
                }
                if (lastCharWasEscape) {
                    continue;
                }
                int paramCount;
                switch (command) {
                case "addelement":
                case "chelement":
                case "move":
                    paramCount = 2;
                    break;
                case "chattr":
                    paramCount = 4;
                    break;
                default:
                    throw new Exception (string.Format ("Unknown command '{0}'", command));
                }
                if (parameters.Count != paramCount) {
                    throw new Exception (string.Format ("{0} command on line {1} requires {3} parameters", command, lineNo, paramCount));
                }
                commands.Add (new Tuple<string,List<string>> (command, parameters));
            }
            if (commands.Count == 0) {
                Console.Error.WriteLine ("Warning: File '{0}' is empty.", filename);
            }
            foreach (var tuple in commands) {
                command = tuple.Item1;
                parameters = tuple.Item2;
                switch (command) {
                case "addelement":
                    var newElement = parseElement (parameters [0]);
                    var addParent = document.XPathSelectElement (parameters [1], Manager);
                    if (addParent == null) {
                        Console.Error.WriteLine ("Could not find element at '{0}'", parameters [1]);
                        break;
                    }
                    addParent.Add (newElement);
                    break;
                case "chattr":
                    var attributeParts = parameters [0].Split (':');
                    var localName = attributeParts [0];
                    var @namespace = XNamespace.None;
                    if (attributeParts.Length > 1) {
                        localName = attributeParts [1];
                        @namespace = (XNamespace)Manager.LookupNamespace (attributeParts [0]);
                    }
                    var chattrElements = document.XPathSelectElements (parameters[3], Manager).ToList ();
                    if (chattrElements.Count == 0) {
                        Console.Error.WriteLine ("Could not find any elements matching '{0}'", parameters[3]);
                        break;
                    }
                    foreach (var element in chattrElements) {
                        var attribute = element.Attribute (@namespace + localName);
                        var oldValue = attribute == null ? string.Empty : attribute.Value;
                        var newValue = parameters[1] == string.Empty ? parameters[2]
                            : Regex.Replace (oldValue, parameters[1], parameters[2]);
                        element.SetAttributeValue (@namespace + localName, newValue);
                    }
                    break;
                case "chelement":
                    var elementParts = parameters [0].Split (':');
                    var elementLocalName = elementParts [0];
                    var elementNamespace = XNamespace.None;
                    if (elementParts.Length > 1) {
                        elementLocalName = elementParts [1];
                        elementNamespace = (XNamespace)Manager.LookupNamespace (elementParts [0]);
                    }
                    var elementsToChange = document.XPathSelectElements (parameters [1], Manager);
                    if (elementsToChange == null) {
                        Console.Error.WriteLine ("Could not find elements matching '{0}'", parameters [1]);
                        break;
                    }
                    foreach (var element in elementsToChange) {
                        element.Name = elementNamespace + elementLocalName;
                    }
                    break;
                case "move":
                    var moveElements = document.XPathSelectElements (parameters[0], Manager).ToList ();
                    if (moveElements.Count == 0) {
                        Console.Error.WriteLine ("Could not find any elements matching '{0}'", parameters[0]);
                    }
                    var moveParent = document.XPathSelectElement (parameters[1], Manager);
                    if (moveParent == null) {
                        Console.Error.WriteLine ("Could not find element at '{0}'", parameters[1]);
                        break;
                    }
                    foreach (var element in moveElements) {
                        element.Remove ();
                        moveParent.Add (element);
                    }
                    break;
                }
            }
        }

        static bool IsCallableWithVarArgs (this XElement element)
        {
            element = element.Element (gi + "parameters");
            if (element == null) {
                return false;
            }
            foreach (var child in element.Elements (gi + "parameter")) {
                if (child.Element (gi + "varargs") != null) {
                    return true;
                }
            }
            return false;
        }

        public static void ApplyBuiltinFixup (this XDocument document)
        {
            // add the gs namespace prefix

            document.Root.SetAttributeValue (XNamespace.Xmlns + "gs", gs.NamespaceName);

            // remove all elements marked as "skip", "moved-to" or "shadowed-by"
            // and functions/methods with varagrs. On OS X/homebrew, there are
            // aliases that end with _autoptr that need to be ignored too.

            var elementsToRemove = document.Descendants ()
                .Where (d => d.Name != gi + "return-value" && d.Name != gi + "parameter")
                .Where (d => d.Attribute ("skip").AsBool ()
                    || d.Attribute ("moved-to") != null
                    || d.Attribute ("shadowed-by") != null
                    || d.IsCallableWithVarArgs ()
                    || d.Attribute ("name").AsString ("").EndsWith ("_autoptr", StringComparison.Ordinal))
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
                    new XAttribute ("name", "_get_g_type"),
                    new XAttribute (c + "identifier", element.Attribute (glib + "get-type").Value),
                    new XAttribute (gs + "access-modifiers", "private"),
                    new XElement (
                        gi + "return-value",
                        new XElement (
                            gi + "type",
                            new XAttribute ("name", "GType"))));
                element.Add (functionElement);
            }

            // rename all error_quark functions to get_error_quark so that they
            // become properties
            var errorQuarkElements = document.Descendants (gi + "function")
                .Where (d => d.Attribute ("name").Value.EndsWith ("error_quark", StringComparison.Ordinal));
            foreach (var element in errorQuarkElements) {
                if (element.Attribute ("name").Value.StartsWith ("get_", StringComparison.Ordinal)) {
                    continue;
                }
                element.SetAttributeValue ("name", "get_" + element.Attribute ("name").Value);
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
                    new XAttribute ("direction", "out"),
                    new XAttribute (gs + "managed-type", typeof(IntPtr).FullName),
                    new XElement (gi + "doc", "return location for a #GError"),
                    new XElement (gi + "type",
                        new XAttribute ("name", "GLib.Error")));
                if (element.Element (gi + "parameters") == null) {
                    element.Add (new XElement (gi + "parameters"));
                }
                element.Element (gi + "parameters").Add (errorElement);
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
                var attr = element.Attribute ("name");
                if (attr == null) {
                    continue;
                }
                var name = attr.Value;
                // replace name by shadows if it exists (i.e. drop _full suffix)
                var shadows = element.Attribute ("shadows");
                if (shadows != null) {
                    name = shadows.Value;
                }

                // check various conditions where we might want camelCase
                var camelCase = false;
                var accessModifier = element.Attribute (gs + "access-modifiers");
                if (accessModifier != null) {
                    camelCase = accessModifier.Value.Contains ("private");
                }
                if (element.Name == gi + "parameter" || element.Name == gi + "instance-parameter" || element.Name == gs + "error-parameter") {
                    camelCase = true;
                }

                name = camelCase ? name.ToCamelCase () : name.ToPascalCase ();

                // callbacks that are defined for a field tend to have name conflicts
                if (element.Name == gi + "field" && element.Element (gi + "callback") != null) {
                    // add "Impl" suffix to the field name
                    name += "Impl";
                }

                element.SetAttributeValue (gs + "managed-name", name);
            }

           // flag ref functions

            var elementsWithRefMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "ref"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithRefMethod) {
                element.SetAttributeValue (gs + "special-func", "ref");
                element.SetAttributeValue (gs + "access-modifiers", "protected override");
                element.Element (gi + "return-value").SetAttributeValue ("skip", "1");
            }

            // flag unref functions

            var elementsWithUnrefMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "unref"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithUnrefMethod) {
                element.SetAttributeValue (gs + "special-func", "unref");
                element.SetAttributeValue (gs + "access-modifiers", "protected override");
            }

            // flag free functions

            var elementsWithFreeMethod = document.Descendants (gi + "method")
                .Where (d => d.Attribute ("name").Value == "free"
                    && !d.Element (gi + "parameters").Elements (gi + "parameter").Any ());
            foreach (var element in elementsWithFreeMethod) {
                element.SetAttributeValue (gs + "special-func", "free");
                element.SetAttributeValue (gs + "access-modifiers", "protected override");
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

            // flag reference-counted opaques

            var recordsThatAreRefCounted = document.Descendants (gi + "record")
                .Where (d => d.Elements (gi + "method").Any (m => m.Attribute (gs + "special-func").AsString () == "ref")
                    && d.Elements (gi + "method").Any (m => m.Attribute (gs + "special-func").AsString () == "unref"));
            foreach (var element in recordsThatAreRefCounted) {
                element.SetAttributeValue (gs + "opaque", "ref-counted");
            }

            // flag owned opaques

            var recordsThatAreOwned = document.Descendants (gi + "record")
                .Where (d => d.Elements (gi + "method").Any (m => m.Attribute (gs + "special-func").AsString () == "free"));
            foreach (var element in recordsThatAreOwned) {
                element.SetAttributeValue (gs + "opaque", "owned");
            }

            // flag static opaques

            var recordsThatAreStatic = document.Descendants (gi + "record")
                .Where (d => d.Elements (gi + "constructor").Any (c => c.Attribute ("name").AsString () == "new"
                      && c.Element (gi + "return-value").Attribute ("transfer-ownership").AsString () == "none"));
            foreach (var element in recordsThatAreStatic) {
                element.SetAttributeValue (gs + "opaque", "static");
            }

            // flag gtype-struct opaques

            var recordsThatAreGTypeStructs = document.Descendants (gi + "record")
                .Where (d => d.Attribute (glib + "is-gtype-struct-for") != null);
            foreach (var element in recordsThatAreGTypeStructs) {
                element.SetAttributeValue (gs+ "opaque", "static");
            }

            // remove fields from opaques

            var recordsThatAreOpaque = document.Descendants (gi + "record")
                .Where (d => d.Attribute (gs + "opaque") != null);
            foreach (var element in recordsThatAreOpaque) {
                var fields = element.Elements (gi + "field").ToList ();
                foreach (var field in fields) {
                    field.Remove ();
                }
            }

            // remove fields from classes

            var classes = document.Descendants (gi + "class");
            foreach (var element in classes) {
                var fields = element.Elements (gi + "field").ToList ();
                foreach (var field in fields) {
                    field.Remove ();
                }
            }

            // add managed-type attribute (skipping existing managed-type attributes)

            var elementsWithManagedType = document.Descendants ()
                .Where (d => ElementsThatReferenceAType.Contains (d.Name))
                .Where (d => d.Attribute (gs + "managed-type") == null);
            foreach (var element in elementsWithManagedType) {
                var managedType = element.GetManagedTypeName ();
                element.SetAttributeValue (gs + "managed-type", managedType);
            }

            // add managed-parameters element

            var parameterElements = document.Descendants (gi + "parameters");
            foreach (var element in parameterElements) {
                var managedParamtersElement = new XElement (gs + "managed-parameters");
                foreach (var managedParameterElement in element.EnumerateManagedParameters ()) {
                    managedParamtersElement.Add (new XElement (managedParameterElement));
                }
                element.Parent.Add (managedParamtersElement);
            }

            // flag getters as properties

            var getters = document.Descendants ()
                .Where (d => (d.Name == gi + "function" || d.Name == gi + "method")
                    && !d.Attribute (gs + "pinvoke-only").AsBool ()
                    && (d.Attribute ("name").Value.StartsWith ("get_", StringComparison.Ordinal) || d.Attribute ("name").Value.StartsWith ("is_", StringComparison.Ordinal))
                    && (d.Element (gs + "managed-parameters") == null || !d.Element (gs + "managed-parameters").Elements (gi + "parameter").Any ()));
            foreach (var element in getters) {
                var name = element.Attribute (gs + "managed-name").Value;
                if (element.Attribute ("name").Value.StartsWith ("get_", StringComparison.Ordinal)) {
                    // drop the Get prefix, but not the Is
                    name = name.Substring (3);
                }
                element.SetAttributeValue (gs + "property", name);
                element.SetAttributeValue (gs + "managed-name", "get_" + name);
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
                var matchingGetter = element.Parent.Elements (element.Name).SingleOrDefault (e => e.Attribute (gs + "property").AsString () == name);
                if (matchingGetter == null) {
                    // we don't want set-only properties
                    continue;
                }
                var getterReturnType = matchingGetter.Element (gi + "return-value").Attribute (gs + "managed-type").Value;
                var setterParameterType = element.Element (gs + "managed-parameters").Element (gi + "parameter").Attribute (gs + "managed-type").Value;
                if (getterReturnType != setterParameterType) {
                    // this isn't the setter if the types don't match
                    continue;
                }
                element.SetAttributeValue (gs + "property", name);
                element.SetAttributeValue (gs + "managed-name", "set_" + name);
                // rename the parameter to "value" since that is what the set accessor in C# requires
                element.Element (gs + "managed-parameters").Element (gi + "parameter").SetAttributeValue (gs + "managed-name", "value");
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
                throw new ArgumentException ("Requires 'parameters' element.", "parameters");
            }

            var list = parameters.Elements (gi + "parameter").ToList ();
                // hide parameters that are used internally

            var indexesToRemove = new List<int> ();
            indexesToRemove.AddRange (list
                .Where (p => p.GetClosureIndex () >= 0)
                .Select (p => p.GetClosureIndex ()));
            indexesToRemove.AddRange (list
                .Where (p => p.GetDestroyIndex () >= 0)
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

        public static string GetNamespace (this XElement element)
        {
            if (element == null) {
                throw new ArgumentNullException (nameof(element));
            }
            var namespaceElement = element.Ancestors (gi + "namespace").Single ();
            var @namespace = namespaceElement.Attribute (gs + "managed-name").Value;

            return @namespace;
        }

//        public static Type LookupType (string @namespace, string typeName)
//        {
//            var type = Type.GetType (typeName);
//            if (!typeLookup.ContainsKey (@namespace)) {
//                throw new NotImplementedException ();
//            }
//            if (!typeLookup[@namespace].ContainsKey (typeName)) {
//                throw new NotImplementedException ();
//            }
//            var typeElement = typeLookup[@namespace][typeName];
//        }

        static string GetManagedTypeName (this XElement element)
        {
            string typeName = null;
            var typeElement = element.Element (gi + "type");
            if (typeElement != null) {
                typeName = typeElement.Attribute ("name").Value;

                switch (typeName) {

                // basic/fundamental types

                case "gboolean":
                    return typeof(bool).FullName;
                case "gchar":
                case "gint8":
                    return typeof(sbyte).FullName;
                case "guchar":
                case "guint8":
                    return typeof(byte).FullName;
                case "gshort":
                case "gint16":
                    return typeof(short).FullName;
                case "gushort":
                case "guint16":
                    return typeof(ushort).FullName;
                case "gunichar2":
                    return typeof(char).FullName;
                case "gint":
                case "gint32":
                case "gunichar":
                    return typeof(int).FullName;
                case "guint":
                case "guint32":
                    return typeof(uint).FullName;
                case "glong":
                    return typeof(nlong).FullName;
                case "gulong":
                    return typeof(nulong).FullName;
                case "gssize":
                case "goffset":
                case "gint64":
                    return typeof(long).FullName;
                case "gsize":
                case "guint64":
                    return typeof(ulong).FullName;
                case "gfloat":
                    return typeof(float).FullName;
                case "gdouble":
                    return typeof(double).FullName;
                case "gpointer":
                case "gconstpointer":
                case "gintptr":
                    return typeof(IntPtr).FullName;
                case "guintptr":
                    return typeof(UIntPtr).FullName;
                case "filename":
                case "utf8":
                    return typeof(string).FullName;
                case "va_list":
                    return typeof(object[]).FullName;
                case "none":
                    return typeof(void).FullName;

                // core callbacks

                case "CompareDataFunc":
                case "GLib.CompareDataFunc":
                case "CompareFunc":
                case "GLib.CompareFunc":
                    return typeof(GISharp.Core.NativeCompareFunc).FullName;
                case "CopyFunc":
                case "GLib.CopyFunc":
                    return typeof(GISharp.Core.NativeCopyFunc).FullName;
                case "DestroyNotify":
                case "GLib.DestroyNotify":
                    return typeof(GISharp.Core.NativeDestroyNotify).FullName;
                case "Func":
                case "GLib.Func":
                    return typeof(GISharp.Core.NativeFunc).FullName;

                case "GType":
                    return typeof(GISharp.Core.GType).FullName;
                }
                var typeParameterElements = typeElement.Elements (gi + "type").Union (element.Elements (gi + "array")).ToList ();
                if (typeParameterElements.Any ()) {
                    switch (typeName) {
                    case "GLib.List":
                        return string.Format ("{0}`1[{1}]",
                            string.Concat (typeof(GISharp.Core.List<>).FullName.TakeWhile (c => c != '`')),
                            typeParameterElements
                                .Select (c => c.Parent.GetManagedTypeName ())
                                .Single ());
                    case "GLib.SList":
                        return string.Format ("{0}`1[{1}]",
                            string.Concat (typeof(GISharp.Core.SList<>).FullName.TakeWhile (c => c != '`')),
                            typeParameterElements
                                .Select (c => c.Parent.GetManagedTypeName ())
                                .Single ());
                    case "GLib.HashTable":
                        return string.Format ("{0}`2[{1}]",
                            string.Concat (typeof(GISharp.Core.HashTable<,>).FullName.TakeWhile (c => c != '`')),
                            string.Join (",", typeParameterElements
                                 .Select (c => c.Parent.GetManagedTypeName ())));
                    default:
                        var message = string.Format ("Unknown type '{0} with type parameters.", typeName);
                        throw new ArgumentException (message, "element");
                    }
                }

                // if it wasn't one of the well-known types, then fixup the type name

                typeName = string.Join (".", typeName.Split ('.').Select (x => x.ToPascalCase ()));

                if (!typeName.Contains (".")) {
                    return string.Format ("{0}.{1}.{2}",
                        MainClass.parentNamespace,
                        element.GetNamespace (),
                        typeName);
                }

                return string.Format ("{0}.{1}", MainClass.parentNamespace, typeName);
            } 

            var arrayElement = element.Element (gi + "array");
            if (arrayElement != null) {
                var arrayNameAttr = element.Element (gi + "array").Attribute ("name");
                if (arrayNameAttr == null) {
                    return string.Format ("{0}[]", element.Element (gi + "array").GetManagedTypeName ());
                } else {
                    var arrayName = arrayNameAttr.Value;
                    switch (arrayName) {
                    case "GLib.ByteArray":
                        // GLib.ByteArray has array type, but it should always be System.Byte
                        return typeof(GISharp.Core.ByteArray).FullName;
                    case "GLib.Array":
                        // GLib.Array has generic parameters
                        return string.Format("{0}<{1}>",
                            string.Concat (typeof(GISharp.Core.Array<>).FullName.TakeWhile (c => c != '`')),
                            arrayElement.GetManagedTypeName ());
                    case "GLib.PtrArray":
                        //GLib.PtrArray has generic parameters
                        return string.Format("{0}<{1}>",
                            string.Concat (typeof(GISharp.Core.PtrArray<>).FullName.TakeWhile (c => c != '`')),
                            arrayElement.GetManagedTypeName ());
                    default:
                        var message = string.Format ("Unknown array type '{0}.", typeName);
                        throw new ArgumentException (message, "element");
                    }
                }
            }

            if (element.Element (gi + "callback") != null) {
                // fields can have a callback instead of a type
                return typeof(IntPtr).FullName;
                // TODO: implment fields with callback
                //typeName = element.Attribute ("name") + "Func";
            }
            
            throw new ArgumentException ("element must have <type>, <array> or <callback> child");
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

        public static string ToPascalCase (this string str)
        {
            if (str == null) {
                return null;
            }

            if (str.Contains ('_')) {
                var words = str.Split ('_').Select (w => w.ToPascalCase ());
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
            if (SyntaxFactory.ParseToken (str).IsReservedKeyword ()) {
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
    }
}
