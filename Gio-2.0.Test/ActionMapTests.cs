using System;
using System.Linq;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using System.Reflection;

using static GISharp.TestHelpers;
using Object = GISharp.Lib.GObject.Object;
using ActionSet = System.Collections.Generic.HashSet<GISharp.Lib.Gio.IAction>;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class ActionMapTests
    {
        [Test]
        public void TestLookupAction()
        {
            const string name = "test-action-name";
            using (var am = new TestActionMap())
            using (var expected = new TestAction(name)) {
                am.Actions.Add(expected);
                Assert.That(am.LookupAction(name), Is.SameAs(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestAddAction()
        {
            const string name = "test-action-name";
            using (var am = new TestActionMap())
            using (var expected = new TestAction(name)) {
                am.AddAction(expected);
                Assert.That(am.Actions, Has.Member(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveAction()
        {
            const string name = "test-action-name";
            using (var am = new TestActionMap())
            using (var expected = new TestAction(name)) {
                am.Actions.Add(expected);
                am.RemoveAction(name);
                Assert.That(am.Actions, Has.No.Member(expected));
            }
            AssertNoGLibLog();
        }
    }

    [GType]
    class TestActionMap : Object, IActionMap
    {
        static readonly GType gtype = GType.TypeOf<TestActionMap>();

        public TestActionMap() : base(New<TestActionMap>(), Transfer.Full)
        {
        }

        public ActionSet Actions { get; } = new ActionSet();

        void IActionMap.OnAddAction(IAction action)
        {
            Actions.Add(action);
        }

        IAction IActionMap.OnLookupAction(Utf8 actionName)
        {
            return Actions.SingleOrDefault(a => a.Name == actionName);
        }

        void IActionMap.OnRemoveAction(Utf8 actionName)
        {
            Actions.RemoveWhere(a => a.Name == actionName);
        }
    }
}
