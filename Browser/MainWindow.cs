using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

using Gtk;

namespace GISharp.Browser
{
    public partial class MainWindow : Window
    {
        static readonly string[] ignoredProperties = {
            "Attributes",
            "Container",
            "Handle",
            "Parent",
        };

        static readonly string[] childProperties = {
            "Args",
            "Constants",
            "Discriminators",
            "DiscriminatorType",
            "Fields",
            "Interfaces",
            "Methods",
            "Prerequisites",
            "Properties",
            "Property",
            "ReturnTypeInfo",
            "Signals",
            "TypeInfo",
            "Values",
            "VFuncs",
        };

        static readonly string[] linkProperties = {
            "ClassStruct",
            "IfaceStruct",
            "Interface",
            "Invoker",
            "VFunc",
        };

        Stack<Tuple<TreePath, TreePath>> backStack = new Stack<Tuple<TreePath, TreePath>> ();
        Stack<Tuple<TreePath, TreePath>> forwardStack = new Stack<Tuple<TreePath, TreePath>> ();

        public event EventHandler<SelectedNamespaceChangedEventArgs> SelectedNamespaceChanged;

        public event EventHandler<SelectedInfoChangedEventArgs> SelectedInfoChanged;

        public MainWindow () : base (Gtk.WindowType.Toplevel)
        {
            Build ();

            backButton.Label = null;
            backButton.Image = new Image (Stock.GoBack, IconSize.Button);
            forwardButton.Label = null;
            forwardButton.Image = new Image (Stock.GoForward, IconSize.Button);
            forwardButton.ImagePosition = PositionType.Right;

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

            infoTreeview.AppendColumn ("Name", new CellRendererText(), "text", 0, "strikethrough", 1, "foreground", 2);
            infoTreeview.Selection.Changed += (sender, e) => {
                if (SelectedInfoChanged != null) {
                    object selected = null;
                    TreeIter iter;
                    if (infoTreeview.Selection.GetSelected(out iter) && iter.UserData != IntPtr.Zero) {
                        selected = GCHandle.FromIntPtr (iter.UserData).Target;
                    }
                    SelectedInfoChanged (this, new SelectedInfoChangedEventArgs (selected));
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
            infoTreeview.Model = null;
        }

        public void AddInfo (TreeModelImplementor implementor)
        {
            if (implementor== null) {
                throw new ArgumentNullException ("implementor");
            }
            infoTreeview.Model = new TreeModelAdapter (implementor);
        }

        public void ClearTypeInfo ()
        {
            typeInfoLabel.LabelProp = "<b>Type Info</b>";
            foreach (var child in typeInfoVbox.Children.ToArray ()) {
                typeInfoVbox.Remove (child);
            }
        }

        public void SetTypeInfo (object obj)
        {
            var objValueLabel = new Label () {
                LabelProp = string.Format ("<b>{0}</b>",
                    System.Security.SecurityElement.Escape (obj.ToString ())),
                UseMarkup = true,
                Xalign = 0,
            };
            objValueLabel.Show ();
            typeInfoVbox.PackStart (objValueLabel, false, false, 12);

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

                var value = property.GetValue (obj);
                if (linkProperties.Contains (property.Name) && value != null) {
                    var linkLabel = new LinkButton ("", value.ToString ()) {
                        Xalign = 0,
                    };
                    propertyTable.Attach (linkLabel, 1, 2, row, row + 1);
                } else {
                    var valueLabel = new Label () {
                        LabelProp = (value ?? "<null>").ToString (),
                        Xalign = 0,
                    };
                    propertyTable.Attach (valueLabel, 1, 2, row, row + 1);
                }
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
        public object UserData { get; private set; }

        public SelectedInfoChangedEventArgs (object userData)
        {
            UserData = userData;
        }
    }
}
