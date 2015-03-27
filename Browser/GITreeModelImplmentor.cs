using System;
using System.Collections.Generic;
using System.Linq;

using Gtk;

using GI;

namespace GI.Browser
{
  public class GITreeModelImplmentor : GLib.Object, ITreeModelImplementor
	{
    static int nextStamp = 0;

    static GITreeModelImplmentor () {
      Repository.Require ("GLib", "2.0");
      Repository.Require ("Gio", "2.0");
    }

    Dictionary<int, Namespace> stampToNamespaceMap;
    Dictionary<Namespace, TreeIter> namespaceToIterMap;
    Dictionary<int, BaseInfo> stampToInfoMap;
    Dictionary<BaseInfo, TreeIter> infoToIterMap;
    Dictionary<int, TreePath> stampToPathMap;

    public GITreeModelImplmentor () {
      stampToNamespaceMap = new Dictionary<int, Namespace> ();
      namespaceToIterMap = new Dictionary<Namespace, TreeIter> ();
      stampToInfoMap = new Dictionary<int, BaseInfo> ();
      infoToIterMap = new Dictionary<BaseInfo, TreeIter> ();
      stampToPathMap = new Dictionary<int, TreePath> ();
    }

    #region ITreeModelImplementor implementation
    public GLib.GType GetColumnType (int index_)
    {
      return GLib.GType.String;
    }

    TreeIter EnsureNamespaceIter (Namespace @namespace) {
      TreeIter iter;
      if (namespaceToIterMap.ContainsKey (@namespace)) {
        iter = namespaceToIterMap[@namespace];
      } else {
        iter = new TreeIter () { Stamp = nextStamp++ };
        stampToNamespaceMap[iter.Stamp] = @namespace;
        namespaceToIterMap[@namespace] = iter;
      }
      return iter;
    }

    TreeIter EnsureInfoIter (BaseInfo info) {
      TreeIter iter;
      if (infoToIterMap.ContainsKey (info)) {
        iter = infoToIterMap[info];
      } else {
        iter = new TreeIter () { Stamp = nextStamp++ };
        stampToInfoMap[iter.Stamp] = info;
        infoToIterMap[info] = iter;
      }
      return iter;
    }

    public bool GetIter (out TreeIter iter, TreePath path)
    {
      try {
        var @namespace = Repository.Namespaces [path.Indices [0]];
        iter = EnsureNamespaceIter (@namespace);
        stampToPathMap[iter.Stamp] = path.Copy ();
        // first level is namespaces, everything else is infos.
        if (path.Depth == 1) {
          return true;
        }
        var info = @namespace.Infos [path.Indices [1]];
        if (path.Depth == 2) {
          iter = EnsureInfoIter (info);
          stampToPathMap[iter.Stamp] = path.Copy ();
          return true;
        }
      } catch (Exception) {
        // TODO
      }
      iter = TreeIter.Zero;
      return false;
    }

    public TreePath GetPath (TreeIter iter)
    {
//      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
//        var name = stampToNamespaceMap [iter.Stamp].Name;
//        var index = Array.IndexOf (repository.LoadedNamespaces, name);
//        return new TreePath (new [] { index });
//      }
//      if (stampToInfoMap.ContainsKey (iter.Stamp)) {
//        var info = stampToInfoMap [iter.Stamp];
//        var namespaceIndex = Array.IndexOf (repository.LoadedNamespaces, info.Namespace);
//      }
//      return new TreePath ();
      return stampToPathMap [iter.Stamp].Copy ();
    }

    public void GetValue (TreeIter iter, int column, ref GLib.Value value)
    {
      value.Init (GLib.GType.String);
      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
        value.Val = stampToNamespaceMap [iter.Stamp].Name;
      }
      if (stampToInfoMap.ContainsKey (iter.Stamp)) {
        value.Val = stampToInfoMap [iter.Stamp].Name;
      }
    }

    public bool IterNext (ref TreeIter iter)
    {
      var path = stampToPathMap [iter.Stamp].Copy ();
      path.Next ();
      var nextIndex = path.Indices.Last ();
      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
        if (nextIndex < Repository.LoadedNamespaces.Length) {
          iter = EnsureNamespaceIter (Repository.Namespaces [nextIndex]);
          stampToPathMap[iter.Stamp] = path;
          return true;
        }
      }
      if (stampToInfoMap.ContainsKey (iter.Stamp)) {
        var info = stampToInfoMap [iter.Stamp];
        var @namespace = Repository.Namespaces [info.Namespace];
        if (nextIndex < @namespace.Infos.Count) {
          iter = EnsureInfoIter (@namespace.Infos [nextIndex]);
          stampToPathMap[iter.Stamp] = path;
          return true;
        }
      }
      return false;
    }

    public bool IterPrevious (ref TreeIter iter)
    {
      var path = stampToPathMap [iter.Stamp].Copy ();
      path.Prev ();
      var prevIndex = path.Indices.Last ();
      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
        if (prevIndex >= 0) {
          iter = EnsureNamespaceIter (Repository.Namespaces [prevIndex]);
          stampToPathMap[iter.Stamp] = path;
          return true;
        }
      }
      if (stampToInfoMap.ContainsKey (iter.Stamp)) {
        var info = stampToInfoMap [iter.Stamp];
        var @namespace = Repository.Namespaces [info.Namespace];
        if (prevIndex >= 0) {
          iter = EnsureInfoIter (@namespace.Infos [prevIndex]);
          stampToPathMap[iter.Stamp] = path;
          return true;
        }
      }
      return false;
    }

    public bool IterChildren (out TreeIter iter, TreeIter parent)
    {
      var path = stampToPathMap [parent.Stamp];
      path.Down ();
      if (stampToNamespaceMap.ContainsKey (parent.Stamp)) {
        var info = stampToNamespaceMap [parent.Stamp].Infos [0];
        iter = EnsureInfoIter (info);
        stampToPathMap [iter.Stamp] = path;
        return true;
      }
      iter = TreeIter.Zero;
      return false;
    }

    public bool IterHasChild (TreeIter iter)
    {
      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
        return stampToNamespaceMap [iter.Stamp].Infos.Count > 0;
      }
      return false;
    }

    public int IterNChildren (TreeIter iter)
    {
      if (stampToNamespaceMap.ContainsKey (iter.Stamp)) {
        return stampToNamespaceMap [iter.Stamp].Infos.Count;
      }
      return 0;
    }

    public bool IterNthChild (out TreeIter iter, TreeIter parent, int n)
    {
      var path = stampToPathMap [parent.Stamp].Copy ();
      path.AppendIndex (n);
      if (stampToNamespaceMap.ContainsKey (parent.Stamp)) {
        var info = stampToNamespaceMap [parent.Stamp].Infos [n];
        iter = EnsureInfoIter (info);
        stampToPathMap [iter.Stamp] = path;
        return true;
      }
      iter = TreeIter.Zero;
      return false;
    }

    public bool IterParent (out TreeIter iter, TreeIter child)
    {
      if (stampToInfoMap.ContainsKey (child.Stamp)) {
        var info = stampToInfoMap [child.Stamp];
        if (info.Container == null) {
          iter = EnsureNamespaceIter (Repository.Namespaces [info.Namespace]);
          return true;
        }
        iter = EnsureInfoIter (info.Container);
        return true;
      }
      iter = TreeIter.Zero;
      return false;
    }

    public void RefNode (TreeIter iter)
    {
      // TODO: do we need to do anything here since C# is managed?
    }

    public void UnrefNode (TreeIter iter)
    {
      // TODO: do we need to do anything here since C# is managed?
    }

    public TreeModelFlags Flags {
      get {
        return (TreeModelFlags)0;
      }
    }

    public int NColumns {
      get {
        return 1;
      }
    }
    #endregion
	}

}

