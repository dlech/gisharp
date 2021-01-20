// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

using GISharp.CodeGen.Model;
using Gtk;

namespace GISharp.GirBrowser
{
    public class GirTreeModel : GLib.Object, TreeModelImplementor
    {
        static readonly XNamespace glib = "http://www.gtk.org/introspection/glib/1.0";

        readonly Dictionary<XElement, TreeIter> iterMap = new();
        readonly NamespaceInfo namespaceInfo;

        public readonly XElement Root;

        public GirTreeModel (XElement root)
        {
            Root = root;
            namespaceInfo = new(root.Document);
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
            var element = getNode (iter);
            var path = new TreePath ();

            if (element is null) {
                return path;
            }
            while (element.Parent is not null) {
                path.PrependIndex (element.ElementsBeforeSelf ().Count ());
                element = element.Parent;
            }
            path.PrependIndex (0);

            return path;
        }

        public void GetValue (TreeIter iter, int column, ref GLib.Value value)
        {
            var element = getNode (iter);
            switch (column) {
            case 0: // element column
                var name = element.Name.LocalName;
                if (element.Name.Namespace != element.GetDefaultNamespace ()) {
                    var prefix = element.GetPrefixOfNamespace (element.Name.Namespace);
                    name = string.Format ("{0}:{1}", prefix, name);
                }
                value = new GLib.Value (name);
                break;
            case 1: // name column
                value = new GLib.Value (element.Attribute ("name")?.Value ?? string.Empty);
                break;
            case 2: // N column (count)
                value = new GLib.Value (IterNChildren (iter).ToString ());
                break;
            case 3: // color - all columns
                if (element.Attribute ("deprecated") is not null) {
                    value = new GLib.Value ("red");
                } else if (element.Attribute (glib + "is-gtype-struct-for") is not null) {
                    value = new GLib.Value ("magenta");
                } else if (element.Attribute (glib + "get-type") is not null) {
                    value = new GLib.Value ("blue");
                } else if (element.Attribute (glib + "error-domain") is not null) {
                    value = new GLib.Value ("orange");
                } else {
                    value = new GLib.Value ("black");
                }
                break;
            case 4: // strikethrough - all columns
                value = new GLib.Value (element.Attribute ("moved-to") is not null);
                break;
            }
        }

        public bool IterNext (ref TreeIter iter)
        {
            var element = getNode (iter);

            if (element is null || !element.ElementsAfterSelf ().Any ()) {
                return false;
            }
            iter = getIter (element.ElementsAfterSelf ().First ());

            return true;
        }

        public bool IterChildren (out TreeIter iter, TreeIter parent)
        {
            iter = TreeIter.Zero;
            var element = getNode (parent);

            if (element is null) {
                iter = getIter (Root);
                return true;
            }
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
            var element = getNode (iter);

            if (element is null) {
                return 1;
            }
            if (!element.HasElements) {
                return 0;
            }

            return element.Elements ().Count ();
        }

        public bool IterNthChild (out TreeIter iter, TreeIter parent, int n)
        {
            iter = TreeIter.Zero;
            var element = getNode (parent);

            if (element is null) {
                iter = getIter (Root);
                return true;
            }
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

            if (element is null || element.Parent is null) {
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
                return 5;
            }
        }

        #endregion

        public Dictionary<string, string> GetAttributes (TreeIter iter)
        {
            var element = getNode (iter);
            if (element is null || !element.HasAttributes) {
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
            if (element is null) {
                return null;
            }
            var textNode = element.Nodes ().OfType <XText> ().SingleOrDefault ();
            if (textNode is not null) {
                return textNode.Value;
            }
            return null;
        }

        public string GetCodeFragment (TreeIter iter)
        {
            var element = getNode (iter);
            if (element is null) {
                return null;
            }

            return namespaceInfo.FindInfo (element)?.ToString ();
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
