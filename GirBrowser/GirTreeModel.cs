using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using Gtk;
using GISharp.CodeGen;

namespace GirBrowser
{
    public class GirTreeModel : GLib.Object, TreeModelImplementor
    {
        readonly Dictionary<XElement, TreeIter> iterMap = new Dictionary<XElement, TreeIter> ();

        public readonly XElement Root;

        public GirTreeModel (XElement root)
        {
            Root = root;
        }

        #region TreeModelImplementor implementation

        public GLib.GType GetColumnType (int index)
        {
            if (index < 0 || index >= NColumns) {
                throw new ArgumentOutOfRangeException ("index");
            }
            return GLib.GType.String;
        }

        public bool GetIter (out TreeIter iter, TreePath path)
        {
            iter = TreeIter.Zero;
            try {
                var element = Root;
                foreach (var index in path.Indices.Skip (1)) {
                    element = element.Elements ().ElementAt (index);
                }
                iter = getIter (element);
                return true;
            } catch {
                return false;
            }
        }

        public TreePath GetPath (TreeIter iter)
        {
            var element = getNode (iter) ?? Root;
            var path = new TreePath ();
            while (element.Parent != null) {
                path.PrependIndex (element.Parent.Elements ().ToList ().IndexOf (element));
                element = element.Parent;
            }
            path.PrependIndex (0);
            return path;
        }

        public void GetValue (TreeIter iter, int column, ref GLib.Value value)
        {
            var element = getNode (iter);
            switch (column) {
            case 0:
                var name = element.Name.LocalName;
                if (element.Name.Namespace != element.GetDefaultNamespace ()) {
                    var prefix = element.GetPrefixOfNamespace (element.Name.Namespace);
                    name = string.Format ("{0}:{1}", prefix, name);
                }
                value = new GLib.Value (name);
                break;
            case 1:
                if (element.HasAttributes && element.Attribute ("name") != null) {
                    value = new GLib.Value (element.Attribute ("name").Value);
                } else {
                    value = new GLib.Value (string.Empty);
                }
                break;
            case 2:
                value = new GLib.Value (IterNChildren (iter).ToString ());
                break;
            }
        }

        public bool IterNext (ref TreeIter iter)
        {
            var element = getNode (iter) ?? Root;
            if (!element.ElementsAfterSelf ().Any ()) {
                return false;
            }
            iter = getIter (element.ElementsAfterSelf ().First ());
            return true;
        }

        public bool IterChildren (out TreeIter iter, TreeIter parent)
        {
            iter = TreeIter.Zero;
            var element = getNode (parent) ?? Root;
            if (!element.HasElements) {
                return false;
            }
            iter = getIter (element.Elements ().First ());
            return true;
        }

        public bool IterHasChild (TreeIter iter)
        {
            var element = getNode (iter) ?? Root;
            return element.HasElements;
        }

        public int IterNChildren (TreeIter iter)
        {
            var element = getNode (iter) ?? Root;
            if (!element.HasElements) {
                return 0;
            }
            return element.Elements ().Count ();
        }

        public bool IterNthChild (out TreeIter iter, TreeIter parent, int n)
        {
            iter = TreeIter.Zero;
            var element = getNode (parent) ?? Root;
            try {
                iter = getIter (element.Elements ().ElementAt (n));
                return true;
            } catch {
                return false;
            }
        }

        public bool IterParent (out TreeIter iter, TreeIter child)
        {
            iter = TreeIter.Zero;
            var element = getNode (child);
            if (element == null || element.Parent == null) {
                return false;
            }
            iter = getIter (element.Parent);
            return true;
        }

        public void RefNode (TreeIter iter)
        {
        }

        public void UnrefNode (TreeIter iter)
        {
        }

        public TreeModelFlags Flags {
            get {
                return TreeModelFlags.ItersPersist;
            }
        }

        public int NColumns {
            get {
                return 3;
            }
        }

        #endregion

        public Dictionary<string, string> GetAttributes (TreeIter iter)
        {
            var element = getNode (iter);
            if (element == null || !element.HasAttributes) {
                return null;
            }
            var defaultNamespace = element.GetDefaultNamespace ();
            return element.Attributes ().ToDictionary (a => {
                var name = a.Name.LocalName;
                if (a.Name.Namespace !=  XNamespace.None && a.Name.Namespace != defaultNamespace) {
                    string prefix;
                    if (a.Name.Namespace == XNamespace.Xml) {
                        prefix = "xml";
                    } else if (a.Name.Namespace == XNamespace.Xmlns) {
                        prefix = "xmlns";
                    } else {
                        prefix = element.GetPrefixOfNamespace (a.Name.Namespace);
                    }
                    name = string.Format ("{0}:{1}", prefix, name);
                }
                return name;
            }, a => a.Value);
        }

        public string GetText (TreeIter iter)
        {
            var element = getNode (iter);
            if (element == null) {
                return null;
            }
            var textNode = element.Nodes ().OfType <XText> ().SingleOrDefault ();
            if (textNode != null) {
                return textNode.Value;
            }
            return null;
        }

        public string GetCodeFragment (TreeIter iter)
        {
            var element = getNode (iter);
            if (element == null) {
                return null;
            }
            return element.ToCodeFragment ();
        }

        XElement getNode (TreeIter iter)
        {
            var ptr = iter.UserData;
            if (ptr == IntPtr.Zero) {
                return null;
            }
            return GCHandle.FromIntPtr (ptr).Target as XElement;
        }

        TreeIter getIter (XElement element)
        {
            if (!iterMap.ContainsKey (element)) {
                var ptr = GCHandle.ToIntPtr (GCHandle.Alloc (element));
                iterMap [element] = new TreeIter { UserData = ptr };
            }
            return iterMap [element];
        }
    }
}
