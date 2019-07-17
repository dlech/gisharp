using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Gtk;
using GISharp.CodeGen;
using GISharp.CodeGen.Model;
using GISharp.GirBrowser.Freedesktop.Xdg;

namespace GISharp.GirBrowser
{
    public partial class MainWindow: Gtk.Window
    {
        public MainWindow () : base (Gtk.WindowType.Toplevel)
        {
            Build ();

            girBrowseButton.Clicked += girBrowseButton_Clicked;
            girLoadButton.Clicked += girLoadButton_Clicked;

            girTreeView.AppendColumn ("Element", new CellRendererText (),
                "text", 0, "foreground", 3, "strikethrough", 4);
            girTreeView.AppendColumn ("N", new CellRendererText (),
                "text", 2, "foreground", 3, "strikethrough", 4);
            girTreeView.AppendColumn ("Name", new CellRendererText (),
                "text", 1, "foreground", 3, "strikethrough", 4);
            girTreeView.Selection.Changed += girTreeView_Selection_Changed;

            girAttrNodeView.NodeStore = new NodeStore (typeof(AttributeNode));
            girAttrNodeView.AppendColumn ("Attribute", new CellRendererText (),
                "text", 0);
            girAttrNodeView.AppendColumn ("Value", new CellRendererText (),
                "text", 1);

            fixupBrowseButton.Clicked += fixupBrowseButton_Clicked;
            fixupApplyButton.Clicked += fixupApplyButton_Clicked;

            fixupTreeView.AppendColumn ("Element", new CellRendererText (),
                "text", 0, "foreground", 3, "strikethrough", 4);
            fixupTreeView.AppendColumn ("N", new CellRendererText (),
                "text", 2, "foreground", 3, "strikethrough", 4);
            fixupTreeView.AppendColumn ("Name", new CellRendererText (),
                "text", 1, "foreground", 3, "strikethrough", 4);
            fixupTreeView.Selection.Changed += fixupTreeView_Selection_Changed;

            fixupAttrNodeView.NodeStore = new NodeStore (typeof(AttributeNode));
            fixupAttrNodeView.AppendColumn ("Attribute", new CellRendererText (),
                "text", 0);
            fixupAttrNodeView.AppendColumn ("Value", new CellRendererText (),
                "text", 1);

            #if DEBUG
            girFileNameEntry.Text = BaseDirectory.FindDataFile (
                System.IO.Path.Combine ("gir-1.0", "Gio-2.0.gir")) ?? "";
            fixupFileNameEntry.Text = "../../../Gio-2.0/Gio-2.0.girfixup";
            girLoadButton.Click ();
            #endif
        }

        public static XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
                (from n in e.Nodes()
                    select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
                (e.HasAttributes) ?
                (from a in e.Attributes()
                    where (!a.IsNamespaceDeclaration)
                    select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }      

        void fixupApplyButton_Clicked (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace (fixupFileNameEntry.Text)) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Must specify a fixup file name.");
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
            if (!File.Exists (fixupFileNameEntry.Text)) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "The fixup file '{0}' could not be found.",
                    fixupFileNameEntry.Text);
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
            try {
                var model = girTreeView.Model as TreeModelAdapter;
                var impl = model.Implementor as GirTreeModel;
                var newDoc = new XDocument (impl.Root.Document);
                newDoc.ApplyFixupFile (fixupFileNameEntry.Text);
                newDoc.ApplyBuiltinFixup ();
                var fixupImpl = new GirTreeModel (newDoc.Root);
                fixupTreeView.Model = new TreeModelAdapter (fixupImpl);
                fixupTreeView.ExpandToPath (new TreePath ("0:2"));
            } catch (Exception ex) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Error while applying fixup file '{0}':\n\n{1}.",
                    fixupFileNameEntry.Text, ex.Message);
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
        }

        void girLoadButton_Clicked (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace (girFileNameEntry.Text)) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                                 ButtonsType.Ok, "Must specify a gir file name.");
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
            if (!File.Exists (girFileNameEntry.Text)) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                                 ButtonsType.Ok, "The gir file '{0}' could not be found.",
                                 girFileNameEntry.Text);
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
            try {
                var xmlDoc = XDocument.Load (girFileNameEntry.Text);
                var implementor = new GirTreeModel (xmlDoc.Root);
                girTreeView.Model = new TreeModelAdapter (implementor);
                girTreeView.ExpandToPath (new TreePath ("0:2"));
                fixupApplyButton.Click ();
            } catch (Exception ex) {
                var dialog = new MessageDialog (this, DialogFlags.Modal, MessageType.Error,
                                 ButtonsType.Ok, "Error while loading gir file:\n\n {0}.", ex.Message);
                dialog.Run ();
                dialog.Destroy ();
                return;
            }
        }

        void girBrowseButton_Clicked (object sender, EventArgs e)
        {
            var girFilter = new FileFilter { Name = "Gir files (*.gir)" };
            girFilter.AddPattern ("*.gir");
            var allFilesFilter = new FileFilter { Name = "All files (*.*)" };
            allFilesFilter.AddPattern ("*.*");

            var fileDialog = new FileChooserDialog ("Select", this, FileChooserAction.Open,
                                 "_Cancel", ResponseType.Cancel,
                                 "_Open", ResponseType.Ok);
            fileDialog.AddFilter (girFilter);
            fileDialog.AddFilter (allFilesFilter);
            if (File.Exists (girFileNameEntry.Text)) {
                fileDialog.SetFilename (girFileNameEntry.Text);
            } else {
                fileDialog.SetCurrentFolder ("/usr/share/gir-1.0/");
            }
            if (fileDialog.Run () == (int)ResponseType.Ok) {
                girFileNameEntry.Text = fileDialog.Filename;
            }
            fileDialog.Destroy ();
        }

        void fixupBrowseButton_Clicked (object sender, EventArgs e)
        {
            var fixupFilter = new FileFilter { Name = "Gir fixup files (*.girfixup)" };
            fixupFilter.AddPattern ("*.girfixup");
            var allFilesFilter = new FileFilter { Name = "All files (*.*)" };
            allFilesFilter.AddPattern ("*.*");

            var fileDialog = new FileChooserDialog ("Select", this, FileChooserAction.Open,
                "_Cancel", ResponseType.Cancel,
                "_Open", ResponseType.Ok);
            fileDialog.AddFilter (fixupFilter);
            fileDialog.AddFilter (allFilesFilter);
            if (File.Exists (fixupFileNameEntry.Text)) {
                fileDialog.SetFilename (fixupFileNameEntry.Text);
            } else {
                fileDialog.SetCurrentFolder (".");
            }
            if (fileDialog.Run () == (int)ResponseType.Ok) {
                fixupFileNameEntry.Text = fileDialog.Filename;
            }
            fileDialog.Destroy ();
        }

        void girTreeView_Selection_Changed (object sender, EventArgs e)
        {
            updateAttributes (girTreeView, girAttrNodeView, girTextView);
        }

        void fixupTreeView_Selection_Changed (object sender, EventArgs e)
        {
            updateAttributes (fixupTreeView, fixupAttrNodeView, fixupTextView);
            try {
                TreeIter iter;
                fixupTreeView.Selection.GetSelected (out iter);
                var model = fixupTreeView.Model as TreeModelAdapter;
                var impl = model.Implementor as GirTreeModel;
                generatedTextView.Buffer.Text = impl.GetCodeFragment (iter) ?? "";
            } catch (Exception ex) {
                generatedTextView.Buffer.Text = ex.ToString ();
            }
        }

        static void updateAttributes (TreeView treeView, NodeView nodeView, TextView textView)
        {
            nodeView.NodeStore.Clear ();
            textView.Buffer.Clear ();
            TreeIter iter;
            treeView.Selection.GetSelected (out iter);
            var model = treeView.Model as TreeModelAdapter;
            var impl = model.Implementor as GirTreeModel;
            var attributes = impl.GetAttributes (iter);
            if (attributes != null) {
                foreach (var item in attributes) {
                    nodeView.NodeStore.AddNode (new AttributeNode (item.Key, item.Value));
                }
            }
            var text = impl.GetText (iter);
            if (text != null) {
                textView.Buffer.Text = text;
            }
        }

        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
            a.RetVal = true;
        }

        [TreeNode (ListOnly = true)]
        class AttributeNode : TreeNode
        {
            public AttributeNode (string key, string value)
            {
                Key = key;
                Value = value;
            }

            [TreeNodeValue (Column = 0)]
            public string Key { get; private set; }

            [TreeNodeValue (Column = 1)]
            public string Value { get; private set; }
        }
    }
}
