using System;
using System.Linq;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;
using ActionSet = System.Collections.Generic.HashSet<GISharp.Lib.Gio.IAction>;

namespace GISharp.Test.Gio
{
    public class ActionMapTests : Tests
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
        }
    }

    [GType]
    class TestActionMap : Object, IActionMap
    {
        public TestActionMap() : base(New<TestActionMap>(), Transfer.Full)
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
