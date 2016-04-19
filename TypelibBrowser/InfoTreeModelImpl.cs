using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using Gtk;
using GISharp.GI;

namespace GISharp.TypelibBrowser
{
    public class InfoTreeModelImpl : GLib.Object, TreeModelImplementor
    {
        readonly IReadOnlyList<Group> topLevelGroups;

        public InfoTreeModelImpl (IEnumerable<BaseInfo> topLevelInfos)
        {
            topLevelGroups = recursiveAddGroupings (topLevelInfos.GroupBy (i => i.InfoType.ToString ()), null);
        }

        #region TreeModelImplementor implementation

        public GLib.GType GetColumnType (int index)
        {
            switch (index) {
            case 0:
            case 2:
                return GLib.GType.String;
            case 1:
                return GLib.GType.Boolean;
            }
            throw new ArgumentOutOfRangeException ("index");
        }

        public bool GetIter (out TreeIter iter, TreePath path)
        {
            iter = TreeIter.Zero;
            try {
                IReadOnlyList<INode> currentList = topLevelGroups;
                foreach (var index in path.Indices) {
                    iter = currentList [index].Iter;
                    currentList = currentList [index].Children;
                }
                return true;
            } catch {
                return false;
            }
        }

        public TreePath GetPath (TreeIter iter)
        {
            var path = new TreePath ();
            var node = GetNode (iter);
            while (node != null) {
                path.PrependIndex (node.Index);
                node = node.Parent;
            }
            return path;
        }

        public void GetValue (TreeIter iter, int column, ref GLib.Value value)
        {
            var node = GetNode (iter);
            if (node == null) {
                return;
            }
            switch (column) {
            case 0:
                value = new GLib.Value (node.Name);
                break;
            case 1:
                value = new GLib.Value (node.Deprecated);
                break;
            case 2:
                if (node is Group) {
                    value = new GLib.Value ("green");
                } else if (node.IsGType) {
                    value = new GLib.Value ("blue");
                } else if (node.IsGTypeStruct) {
                    value = new GLib.Value ("magenta");
                } else {
                    value = new GLib.Value ("black");
                }
                break;
            default:
                throw new ArgumentOutOfRangeException (nameof(column));
            }
        }

        public bool IterNext (ref TreeIter iter)
        {
            var node = GetNode (iter);
            if (node == null) {
                return false;
            }
            var siblings = node.Parent == null ? topLevelGroups : node.Parent.Children;
            if (node.Index + 1 >= siblings.Count) {
                return false;
            }
            iter = siblings [node.Index + 1].Iter;
            return true;
        }

        public bool IterChildren (out TreeIter iter, TreeIter parent)
        {
            var result = IterNthChild (out iter, parent, 0);
            return result;
        }

        public bool IterHasChild (TreeIter iter)
        {
            var count = IterNChildren (iter);
            return  count > 0;
        }

        public int IterNChildren (TreeIter iter)
        {
            var node = GetNode (iter);
            if (node == null) {
                return topLevelGroups.Count;
            }
            return node.Children.Count;
        }

        public bool IterNthChild (out TreeIter iter, TreeIter parent, int n)
        {
            iter = TreeIter.Zero;
            var node = GetNode (parent);
            var children = node == null ? topLevelGroups : node.Children;
            if (n >= children.Count) {
                return false;
            }
            iter = children[n].Iter;
            return true;
        }

        public bool IterParent (out TreeIter iter, TreeIter child)
        {
            iter = TreeIter.Zero;
            var node = GetNode (child);
            if (node == null || node.Parent == null) {
                return false;
            }
            iter = node.Parent.Iter;
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

        static IReadOnlyList<Group> recursiveAddGroupings (IEnumerable<IGrouping<string,BaseInfo>> groupings, Info parent)
        {
            var list = new List<Group> ();
            foreach (var grouping in groupings) {
                var group = new Group (grouping.Key, list.Count, parent, grouping);
                list.Add (group);
            }
            return list.AsReadOnly ();
        }

        static IReadOnlyList<Info> recursiveAddInfos (IEnumerable<BaseInfo> children, Group parent)
        {
            var list = new List<Info> ();
            foreach (var child in children) {
                var info = new Info (child, list.Count, parent);
                list.Add (info);
            }
            return list.AsReadOnly ();
        }

        static INode GetNode (TreeIter iter)
        {
            if (iter.UserData == IntPtr.Zero) {
                return null;
            }
            return (INode)GCHandle.FromIntPtr (iter.UserData).Target;
        }

        public interface INode
        {
            TreeIter Iter { get; }
            int Index { get; }
            string Name { get; }
            string Path { get; }
            bool Deprecated { get; }
            bool IsGType { get; }
            bool IsGTypeStruct { get; }
            INode Parent { get; }
            IReadOnlyList<INode> Children { get; }
        }

        public class Group : INode
        {
            public TreeIter Iter { get; private set; }
            public int Index { get; private set; }
            public string Name { get; private set; }
            public string Path {
                get {
                    if (Parent == null) {
                        return Name;
                    }
                    return Parent.Path + "." + Name;
                }
            }
            public bool Deprecated { get { return false; } }
            public bool IsGType { get { return false; } }
            public bool IsGTypeStruct { get { return false; } }
            public Info Parent { get; private set; }
            INode INode.Parent { get { return Parent; } }
            public IReadOnlyList<Info> Children { get; private set; }
            IReadOnlyList<INode> INode.Children { get { return Children; } }

            public Group (string name, int index, Info parent, IEnumerable<BaseInfo> children)
            {
                Iter = new TreeIter () {
                    UserData = (IntPtr)GCHandle.Alloc (this)
                };
                Name = name;
                Index = index;
                Parent = parent;
                Children = InfoTreeModelImpl.recursiveAddInfos (children, this);
            }
        }

        public class Info : INode
        {
            public BaseInfo BaseInfo { get; private set; }
            public TreeIter Iter { get; private set; }
            public int Index { get; private set; }
            public string Namespace { get { return BaseInfo.Namespace; } }
            public string Name { get { return BaseInfo.Name ?? "<unnamed>"; } }
            public string Path { get { return Parent.Path + "." + Name; } }
            public bool Deprecated { get { return BaseInfo.IsDeprecated; } }
            public bool IsGType {
                get {
                    var typeInfo = BaseInfo as RegisteredTypeInfo;
                    if (typeInfo == null) {
                        return false;
                    }
                    return !string.IsNullOrEmpty(typeInfo.TypeInit);
                }
            }
            public bool IsGTypeStruct {
                get {
                    var structInfo = BaseInfo as StructInfo;
                    if (structInfo == null) {
                        return false;
                    }
                    return structInfo.IsGTypeStruct;
                }
            }
            public Group Parent { get; private set; }
            INode INode.Parent { get { return Parent; } }
            Lazy<IReadOnlyList<Group>> _Children;
            public IReadOnlyList<Group> Children { get { return _Children.Value; } }
            IReadOnlyList<INode> INode.Children { get { return Children; } }

            public Info (BaseInfo info, int index, Group parent)
            {
                if (info == null) {
                    throw new ArgumentNullException ("info");
                }
                BaseInfo = info;
                Iter = new TreeIter () {
                    UserData = (IntPtr)GCHandle.Alloc (this)
                };
                Index = index;
                Parent = parent;
                _Children = new Lazy<IReadOnlyList<Group>> (() => {
                    var childGroups = new List<InfoGrouping> ();
                    foreach (var property in info.GetType().GetProperties ()) {
                        if (typeof(IEnumerable<BaseInfo>).IsAssignableFrom (property.PropertyType)) {
                            childGroups.Add (new InfoGrouping (property.Name,
                                (IEnumerable<BaseInfo>)property.GetValue (info)));
                        } else if (typeof(TypeInfo).IsAssignableFrom(property.PropertyType)
                            || typeof(PropertyInfo).IsAssignableFrom(property.PropertyType))
                        {
                            var value = (BaseInfo)property.GetValue (info);
                                childGroups.Add (new InfoGrouping (property.Name,
                                value == null ? new BaseInfo[] { } : new [] { value }));
                        }
                    }
                    return recursiveAddGroupings (childGroups, this);
                });
            }
        }

        class InfoGrouping: IGrouping<string, BaseInfo>
        {
            readonly List<BaseInfo> infoList;

            #region IEnumerable implementation

            public IEnumerator<BaseInfo> GetEnumerator ()
            {
                return infoList.GetEnumerator ();
            }

            #endregion


            #region IEnumerable implementation

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
            {
                return GetEnumerator ();
            }

            #endregion

            #region IGrouping implementation

            public string Key { get; private set; }

            #endregion

            public InfoGrouping (string key, IEnumerable<BaseInfo> infos)
            {
                Key = key;
                infoList = infos.ToList ();
            }
        }
    }
}
