// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using Gtk;
using GISharp.Lib.GIRepository;

namespace GISharp.TypelibBrowser
{
    public class InfoTreeModelImpl : global::GLib.Object, TreeModelImplementor
    {
        readonly IReadOnlyList<Group> topLevelGroups;

        public InfoTreeModelImpl (IEnumerable<BaseInfo> topLevelInfos)
        {
            topLevelGroups = recursiveAddGroupings (topLevelInfos.GroupBy (i => i.InfoType.ToString ()), null);
        }

        #region TreeModelImplementor implementation

        public global::GLib.GType GetColumnType (int index)
        {
            switch (index) {
            case 0:
            case 2:
                return global::GLib.GType.String;
            case 1:
                return global::GLib.GType.Boolean;
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
            while (node is not null) {
                path.PrependIndex (node.Index);
                node = node.Parent;
            }
            return path;
        }

        public void GetValue (TreeIter iter, int column, ref global::GLib.Value value)
        {
            var node = GetNode (iter);
            if (node is null) {
                return;
            }
            switch (column) {
            case 0: // name column
                value = new global::GLib.Value (node.Name);
                break;
            case 1: // strikethrough
                value = new global::GLib.Value (node.Deprecated);
                break;
            case 2: // color
                if (node is Group) {
                    value = new global::GLib.Value ("green");
                } else if (node.IsErrorDomain) {
                    value = new global::GLib.Value ("orange");
                } else if (node.IsGType) {
                    value = new global::GLib.Value ("blue");
                } else if (node.IsGTypeStruct) {
                    value = new global::GLib.Value ("magenta");
                } else {
                    value = new global::GLib.Value ("black");
                }
                break;
            default:
                throw new ArgumentOutOfRangeException (nameof(column));
            }
        }

        public bool IterNext (ref TreeIter iter)
        {
            var node = GetNode (iter);
            if (node is null) {
                return false;
            }
            var siblings = node.Parent is null ? topLevelGroups : node.Parent.Children;
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
            if (node is null) {
                return topLevelGroups.Count;
            }
            return node.Children.Count;
        }

        public bool IterNthChild (out TreeIter iter, TreeIter parent, int n)
        {
            iter = TreeIter.Zero;
            var node = GetNode (parent);
            var children = node is null ? topLevelGroups : node.Children;
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
            if (node is null || node.Parent is null) {
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
            bool IsErrorDomain { get; }
            INode Parent { get; }
            IReadOnlyList<INode> Children { get; }
        }

        public class Group : INode
        {
            public TreeIter Iter { get; }
            public int Index { get; }
            public string Name { get; }
            public string Path {
                get {
                    if (Parent is null) {
                        return Name;
                    }
                    return Parent.Path + "." + Name;
                }
            }
            public bool Deprecated { get { return false; } }
            public bool IsGType { get { return false; } }
            public bool IsGTypeStruct { get { return false; } }
            public bool IsErrorDomain { get { return false; } }
            public Info Parent { get; }
            INode INode.Parent { get { return Parent; } }
            public IReadOnlyList<Info> Children { get; }
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
            public BaseInfo BaseInfo { get; }
            public TreeIter Iter { get; }
            public int Index { get; }
            public string Namespace { get { return BaseInfo.Namespace; } }
            public string Name { get { return BaseInfo.Name.ToString() ?? "<unnamed>"; } }
            public string Path { get { return Parent.Path + "." + Name; } }
            public bool Deprecated { get { return BaseInfo.IsDeprecated; } }
            public bool IsGType {
                get {
                    var typeInfo = BaseInfo as RegisteredTypeInfo;
                    if (typeInfo is null) {
                        return false;
                    }
                    return !string.IsNullOrEmpty(typeInfo.TypeInit);
                }
            }
            public bool IsGTypeStruct {
                get {
                    var structInfo = BaseInfo as StructInfo;
                    if (structInfo is null) {
                        return false;
                    }
                    return structInfo.IsGTypeStruct;
                }
            }
            public bool IsErrorDomain {
                get {
                    var enumInfo = BaseInfo as EnumInfo;
                    if (enumInfo is null) {
                        return false;
                    }
                    return enumInfo.ErrorDomain is not null;
                }
            }
            public Group Parent { get; }
            INode INode.Parent { get { return Parent; } }
            Lazy<IReadOnlyList<Group>> _Children;
            public IReadOnlyList<Group> Children { get { return _Children.Value; } }
            IReadOnlyList<INode> INode.Children { get { return Children; } }

            public Info (BaseInfo info, int index, Group parent)
            {
                if (info is null) {
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
                        } else if (typeof(TypeInfo).IsAssignableFrom(property.PropertyType)) {
                            // type info will be show with parent
                            continue;
                        } else if (typeof(PropertyInfo).IsAssignableFrom(property.PropertyType)) {
                            var value = (BaseInfo)property.GetValue (info);
                                childGroups.Add (new InfoGrouping (property.Name,
                                value is null ? new BaseInfo[] { } : new [] { value }));
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

            public string Key { get; }

            #endregion

            public InfoGrouping (string key, IEnumerable<BaseInfo> infos)
            {
                Key = key;
                infoList = infos.ToList ();
            }
        }
    }
}
