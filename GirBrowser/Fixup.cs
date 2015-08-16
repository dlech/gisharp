using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace GirBrowser
{
    public static class Fixup
    {
        static readonly XNamespace gi = "http://www.gtk.org/introspection/core/1.0";
        static readonly XNamespace c = "http://www.gtk.org/introspection/c/1.0";
        static readonly XNamespace glib = "http://www.gtk.org/introspection/glib/1.0";
        static readonly XNamespace gs = "http://lechnology.com/introspection/gisharp/1.0";

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

        public static void ApplyMoveFile (this XDocument document, string filename)
        {
            if (document == null) {
                throw new ArgumentNullException ("document");
            }
            if (filename == null) {
                throw new ArgumentNullException ("filename");
            }
            var commands = new List<Tuple<string,List<string>>> ();
            var lineNo = 0;
            foreach (var line in File.ReadLines (filename)) {
                lineNo++;
                if (string.IsNullOrWhiteSpace (line) || line.StartsWith ("#", StringComparison.Ordinal)) {
                    // ignore empty lines and comments
                    continue;
                }
                var charNo = 0;
                var quoteCount = 0;
                var lastCharWasEscape = false;
                var builder = new StringBuilder ();
                string command = null;
                var parameters = new List<string> ();
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
                            if (!char.IsWhiteSpace (c)) {
                                throw new Exception (string.Format ("Expecting whitespace at {0}:{1}", lineNo, charNo));
                            }
                        } else {
                            builder.Append (c);
                        }
                    }
                    lastCharWasEscape = (c == '\\');
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
            foreach (var command in commands) {
                var parameters = command.Item2;
                switch (command.Item1) {
                case "addelement":
                    var newElement = parseElement (parameters [0]);
                    var addParent = document.XPathSelectElement (parameters [1], Manager);
                    if (addParent == null) {
                        throw new Exception (string.Format ("Could not find element at '{0}'", parameters [1]));
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
                        throw new Exception (string.Format ("Could not find any elements matching '{0}'", parameters[3]));
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
                    var elementToChange = document.XPathSelectElement (parameters [3], Manager);
                    if (elementToChange == null) {
                        throw new Exception (string.Format ("Could not find element matching '{0}'", parameters [3]));
                    }
                    elementToChange.Name = elementNamespace + elementLocalName;
                    break;
                case "move":
                    var moveElements = document.XPathSelectElements (parameters[0], Manager).ToList ();
                    if (moveElements.Count == 0) {
                        throw new Exception (string.Format ("Could not find any elements matching '{0}'", parameters[0]));
                    }
                    var moveParent = document.XPathSelectElement (parameters[1], Manager);
                    if (moveParent == null) {
                        throw new Exception (string.Format ("Could not find element at '{0}'", parameters[1]));
                    }
                    foreach (var element in moveElements) {
                        element.Remove ();
                        moveParent.Add (element);
                    }
                    break;
                }
            }
        }

        public static void ApplyBuiltinFixup (this XDocument document)
        {
            // add the gs namespace prefix

            document.Root.SetAttributeValue (XNamespace.Xmlns + "gs", gs.NamespaceName);

            // remove all elements marked as "skip" or "moved-to" or "shadowed-by"

            var elementsToRemove = document.Descendants ()
                .Where (d => d.Attribute ("skip").ToBool () || d.Attribute ("moved-to") != null || d.Attribute ("shadowed-by") != null)
                .ToList ();
            foreach (var element in elementsToRemove) {
                element.Remove ();
            }

            // add the dll name for pinvoke as a constant

            var package = document.Descendants (gi + "package")
                .Single ().Attribute ("name").Value;
            document.Descendants (gi + "namespace").Single ().Add (
                new XElement (gi + "constant",
                    new XAttribute ("name", "DLL_NAME"),
                    new XAttribute ("value", package + ".dll"),
                    new XElement (gi + "type",
                        new XAttribute ("name", "utf8"),
                        new XAttribute ("type", "gchar*"))));

            // convert snake_case names to PascalCase

            var elementsToChangeCase = document.Descendants (gi + "constant")
                .Union (document.Descendants (gi + "field"))
                .Union (document.Descendants (gi + "member"))
                .Union (document.Descendants (gi + "property"))
                .Union (document.Descendants (gi + "function"))
                .Union (document.Descendants (gi + "method"))
                .Union (document.Descendants (gi + "constructor"))
                .Union (document.Descendants (glib + "signal"));
            foreach (var element in elementsToChangeCase) {
                var attr = element.Attribute ("name");
                if (attr == null) {
                    continue;
                }
                // replace name by shadows if it exists (i.e. drop _full suffix)
                var shadows = element.Attribute ("shadows");
                if (shadows != null) {
                    attr.Value = shadows.Value.ToPascalCase ();
                    continue;
                }
                attr.Value = attr.Value.ToPascalCase ();
            }

            // convert snake_case names to camelCase

            elementsToChangeCase = document.Descendants (gi + "parameter");
            foreach (var element in elementsToChangeCase) {
                var attr = element.Attribute ("name");
                if (attr == null) {
                    continue;
                }
                attr.Value = attr.Value.ToCamelCase ();
            }
        }

        public static bool ToBool (this XAttribute attr, bool defaultValue = false)
        {
            if (attr == null) {
                return defaultValue;
            }
            return attr.Value != "0";
        }

        public static string ToPascalCase (this string str)
        {
            if (str == null) {
                return null;
            }
            var words = str.Split ('_')
                .Select (w => ((w.Length > 0) ? w.Substring (0, 1).ToUpper () : "")
                    + ((w.Length > 1) ? w.Substring (1).ToLower () : ""));
            return string.Join ("", words);
        }

        public static string ToCamelCase (this string str)
        {
            if (str == null) {
                return null;
            }
            str = str.ToPascalCase ();
            return ((str.Length > 0) ? str.Substring (0, 1).ToLower () : "")
                + ((str.Length > 1) ? str.Substring (1) : "");
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
