// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Runtime.InteropServices;
using GISharp.Lib.Gio;
using GISharp.Lib.GIRepository;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using ActionSet = System.Collections.Generic.HashSet<GISharp.Lib.Gio.IAction>;
using InterfaceInfo = GISharp.Lib.GIRepository.InterfaceInfo;
using Object = GISharp.Lib.GObject.Object;
using Transfer = GISharp.Runtime.Transfer;

namespace GISharp.Test.Gio
{
    public class ActionMapTests
    {
        [Test]
        public void TestGType()
        {
            var gtype = typeof(IActionMap).ToGType();
            Assert.That(gtype.Name, Is.EqualTo("GActionMap"));
            var info = (InterfaceInfo)Repository.Default.FindByGtype(gtype);
            Assert.That(Marshal.SizeOf<ActionMapInterface.UnmanagedStruct>(), Is.EqualTo(info.IfaceStruct.Size));
        }

        [Test]
        public void TestLookupAction()
        {
            const string name = "test-action-name";
            using var am = TestActionMap.New();
            using var expected = TestAction.New(name);
            am.Actions.Add(expected);
            Assert.That(am.LookupAction(name), Is.SameAs(expected));
        }

        [Test]
        public void TestAddAction()
        {
            const string name = "test-action-name";
            using var am = TestActionMap.New();
            using var expected = TestAction.New(name);
            am.AddAction(expected);
            Assert.That(am.Actions, Has.Member(expected));
        }

        [Test]
        public void TestRemoveAction()
        {
            const string name = "test-action-name";
            using var am = TestActionMap.New();
            using var expected = TestAction.New(name);
            am.Actions.Add(expected);
            am.RemoveAction(name);
            Assert.That(am.Actions, Has.No.Member(expected));
        }
    }

    [GType]
    class TestActionMap : Object, IActionMap
    {
        public static TestActionMap New()
        {
            return CreateInstance<TestActionMap>();
        }

        public TestActionMap(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        public ActionSet Actions { get; } = new();

        void IActionMap.DoAddAction(IAction action)
        {
            Actions.Add(action);
        }

        IAction? IActionMap.DoLookupAction(UnownedUtf8 actionName)
        {
            var match = actionName.ToString();
            return Actions.SingleOrDefault(a => a.Name == match);
        }

        void IActionMap.DoRemoveAction(UnownedUtf8 actionName)
        {
            var match = actionName.ToString();
            Actions.RemoveWhere(a => a.Name == match);
        }
    }
}
