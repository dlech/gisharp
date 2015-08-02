using System;
using System.Collections.Generic;
using System.Linq;

using GISharp.GI;
using Gtk;
using System.Collections;

namespace GISharp.Browser
{
    public partial class MainWindow : Gtk.Window
    {
        static readonly string[] ignoredProperties = {
            "Attributes",
            "Container",
            "Handle",
            "Parent",
        };

        static readonly string[] childProperties = {
            "Args",
            "ClassStruct",
            "Constants",
            "Discriminators",
            "DiscriminatorType",
            "Fields",
            "IfaceStruct",
            "Interfaces",
            "Methods",
            "Prerequisites",
            "Properties",
            "ReturnTypeInfo",
            "Signals",
            "TypeInfo",
            "Values",
            "VFuncs",
        };

        public event EventHandler<SelectedNamespaceChangedEventArgs> SelectedNamespaceChanged;

        public event EventHandler<SelectedInfoChangedEventArgs> SelectedInfoChanged;

        public MainWindow () : base (Gtk.WindowType.Toplevel)
        {
            Build ();

            namespaceNodeview.AppendColumn ("Namespace", new CellRendererText (), "text", 0);
            namespaceNodeview.AppendColumn ("Version", new CellRendererText (), "text", 1);
            namespaceNodeview.NodeStore = new NodeStore (typeof(NamespaceTreeNode));
            namespaceNodeview.NodeSelection.Changed += (sender, e) => {
                if (SelectedNamespaceChanged != null) {
                    var selectedNode = namespaceNodeview.NodeSelection.SelectedNode as NamespaceTreeNode;
                    var @namespace = selectedNode == null ? null : selectedNode.Namespace;
                    SelectedNamespaceChanged (this, new SelectedNamespaceChangedEventArgs (@namespace));
                }
            };


            infoNodeview.AppendColumn ("Type", new CellRendererText(), "text", 0);
            infoNodeview.AppendColumn ("Name", new CellRendererText(), "text", 1, "strikethrough", 2);
            infoNodeview.NodeStore = new NodeStore (typeof(InfoTreeNode));
            infoNodeview.NodeSelection.Changed += (sender, e) => {
                if (SelectedInfoChanged != null) {
                    var selectedNamespaceNode = namespaceNodeview.NodeSelection.SelectedNode as NamespaceTreeNode;
                    var @namespace = selectedNamespaceNode == null ? null : selectedNamespaceNode.Namespace;
                    var selectedNode = infoNodeview.NodeSelection.SelectedNode as InfoTreeNode;
                    var name = selectedNode == null ? null : selectedNode.Name;
                    SelectedInfoChanged (this, new SelectedInfoChangedEventArgs (@namespace, name));
                }
            };

            ClearTypelibInfo();
            ClearTypeInfo ();
        }

        public void AddNamespace (string @namespace, string version)
        {
            if (@namespace == null) {
                throw new ArgumentNullException ("namespace");
            }
            if (version == null) {
                throw new ArgumentNullException ("version");
            }
            namespaceNodeview.NodeStore.AddNode (new NamespaceTreeNode (@namespace, version));
        }

        public void ClearTypelibInfo ()
        {
            pathLabel.LabelProp = null;
            versionsLabel.LabelProp = null;
            dependsLabel.LabelProp = null;
            libraryLabel.LabelProp = null;
        }

        public void SetTypelibInfo (string path, string versions, string depends, string library)
        {
            pathLabel.LabelProp = path;
            versionsLabel.LabelProp = versions;
            dependsLabel.LabelProp = depends;
            libraryLabel.LabelProp = library;
        }

        public void ClearInfos()
        {
            infoNodeview.NodeStore.Clear ();
        }

        public void AddInfo (string type, string name, bool isDeprecated)
        {
            if (type == null) {
                throw new ArgumentNullException ("type");
            }
            if (name == null) {
                throw new ArgumentNullException ("name");
            }
            infoNodeview.NodeStore.AddNode (new InfoTreeNode (type, name, isDeprecated));
        }

        public void ClearTypeInfo ()
        {
            typeInfoLabel.LabelProp = "<b>Type Info</b>";
            typeInfoVbox.Remove (typeInfoVbox.Children.FirstOrDefault());
        }

        public void SetTypeInfo (object obj)
        {
            var properties = obj.GetType ().GetProperties ();
            var propertyTable = new Table ((uint)properties.Length, 2, false) {
                RowSpacing = 6,
                ColumnSpacing = 6
            };
            uint row = 0;
            foreach (var property in properties) {
                
                if (ignoredProperties.Contains(property.Name) || childProperties.Contains(property.Name)) {
                    // skip these properties
                    continue;
                }
                var descLabel = new Label (property.Name + ":") {
                    Xalign = 1
                };
                propertyTable.Attach (descLabel, 0, 1, row, row + 1);
                var value = property.GetValue (obj) ?? "<null>";
                var valueLabel = new Label () {
                    LabelProp = value.ToString (),
                    Xalign = 0,
                };
                propertyTable.Attach (valueLabel, 1, 2, row, row + 1);
                row++;
            }
            propertyTable.ShowAll ();
            typeInfoVbox.PackStart (propertyTable, false, false, 12);
        }
    }

    [TreeNode (ListOnly=true)]
    public class NamespaceTreeNode : TreeNode
    {
        public NamespaceTreeNode (string @namespace, string version)
        {
            Namespace = @namespace;
            Version = version;
        }

        [TreeNodeValue (Column=0)]
        public string Namespace { get; private set; }

        [TreeNodeValue (Column=1)]
        public string Version { get; private set; }
    }

    [TreeNode (ListOnly=true)]
    public class InfoTreeNode : TreeNode
    {
        public InfoTreeNode (string type, string name, bool isDeprecated)
        {
            Type = type;
            Name = name;
            IsDeprecated = isDeprecated;
        }

        [TreeNodeValue (Column=0)]
        public string Type { get; private set; }

        [TreeNodeValue (Column=1)]
        public string Name { get; private set; }

        [TreeNodeValue (Column=2)]
        public bool IsDeprecated { get; private set; }
    }

    public class SelectedNamespaceChangedEventArgs : EventArgs
    {
        public string Namespace { get; private set; }

        public SelectedNamespaceChangedEventArgs (string @namespace)
        {
            Namespace = @namespace;
        }
    }

    public class SelectedInfoChangedEventArgs : EventArgs
    {
        public string Namespace { get; private set; }
        public string Name { get; private set; }

        public SelectedInfoChangedEventArgs (string @namespace, string name)
        {
            Namespace = @namespace;
            Name = name;
        }
    }
}
