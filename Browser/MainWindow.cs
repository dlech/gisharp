using System;
using System.Collections.Generic;
using System.Linq;

using Gtk;

namespace GI.Browser
{
  public partial class MainWindow : Gtk.Window
  {
    ListStore namespaceListStore;
    ListStore infoListStore;
    Label namespaceNameLabel;
    Label namespaceVersionLabel;

    public event EventHandler SelectedNamespaceChanged;

    public event EventHandler<InfoTypeEventArgs> SelectedInfoTypeChanged;

    public string SelectedNamespaceName {
      get { return namespaceNameLabel.Text; }
      set { namespaceNameLabel.Text = value; }
    }

    public string SelectedNamespaceVersion {
      get { return namespaceVersionLabel.Text; }
      set { namespaceVersionLabel.Text = value; }
    }

    public MainWindow () : base (Gtk.WindowType.Toplevel)
    {
      Title = "GObject Introspection Browser";
      SetDefaultGeometry (800, 600);

      var mainHBox = new HBox (false, 6);
      mainHBox.Margin = 12;
      Add (mainHBox);

      var namespaceVBox = new VBox (true, 12);
      mainHBox.PackStart (namespaceVBox, false, false, 0);

      namespaceListStore = new ListStore (typeof(string), typeof(string));
      var namespaceTreeView = new TreeView (namespaceListStore);
      namespaceTreeView.AppendColumn ("Namespace", new CellRendererText (), "text", 0);
      namespaceTreeView.AppendColumn ("Version", new CellRendererText (), "text", 1);
      namespaceVBox.PackStart (namespaceTreeView, false, true, 6);

      var namespaceInfoGrid = new Grid ();
      namespaceInfoGrid.RowSpacing = 6;
      namespaceInfoGrid.ColumnSpacing = 6;
      namespaceVBox.PackEnd (namespaceInfoGrid, false, false, 0);

      namespaceInfoGrid.Attach (new Label ("Name:") { Justify = Justification.Left }, 0, 0, 1, 1);
      namespaceNameLabel = new Label () { Justify = Justification.Right };
      namespaceInfoGrid.Attach (namespaceNameLabel, 1, 0, 1, 1);
      namespaceInfoGrid.Attach (new Label ("Version:") { Justify = Justification.Left }, 0, 1, 1, 1);
      namespaceVersionLabel = new Label () { Justify = Justification.Right };
      namespaceInfoGrid.Attach (namespaceVersionLabel, 1, 1, 1, 1);

      var typeVBox = new VBox (false, 3);
      RadioButton first = null;
      foreach (InfoType infoType in Enum.GetValues (typeof (InfoType))) {
        var typeButton = new RadioButton (first, infoType.ToString ());
        typeButton.Clicked += (sender, e) => {
          if (SelectedInfoTypeChanged != null)
            SelectedInfoTypeChanged (typeButton, new InfoTypeEventArgs (infoType));
        };
        typeVBox.PackStart (typeButton, false, false, 0);
        if (first == null)
          first = typeButton;
      }
      mainHBox.PackStart (typeVBox, false, false, 0);

      infoListStore = new ListStore (typeof(string));
      var infoTreeView = new TreeView (infoListStore);
      infoTreeView.AppendColumn ("Name", new CellRendererText (), "text", 0);
      var infoScroll = new ScrolledWindow ();
      infoScroll.Add (infoTreeView);
      mainHBox.PackStart (infoScroll, true, true, 6);
    }

    public void SetNamespaces (IEnumerable<string[]> namespaces) {
      namespaceListStore.Clear ();
      foreach (var @namespace in namespaces) {
        namespaceListStore.AppendValues (@namespace);
      }
    }

    public void SetInfos (IEnumerable<string[]> infos) {
      infoListStore.Clear ();
      foreach (var info in infos) {
        infoListStore.AppendValues (info);
      }
    }
  }
}
