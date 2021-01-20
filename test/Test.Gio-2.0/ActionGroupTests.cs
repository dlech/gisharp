// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.Gio
{
    public class ActionGroupTests : Tests
    {
        [Test]
        public void TestListActions()
        {
            using var ag = TestActionGroup.New();
            using var list = ag.ListActions();
            Assert.That<string>(list.First(), Is.EqualTo("test-action-1"));
        }

        [Test]
        public void TestQueryAction()
        {
            using var ag = TestActionGroup.New();
            if (ag.TryQueryAction("does-not-exist", out var enabled, out var paramType,
                out var stateType, out var stateHint, out var state)) {
                Assert.Fail("The action does not exist, so we should not get here.");
            }
        }

        [Test]
        public void TestHasAction()
        {
            using var ag = TestActionGroup.New();
            Assert.That(ag.HasAction("does-not-exist")!, Is.False);
        }

        [Test]
        public void TestGetActionEnabled()
        {
            using var ag = TestActionGroup.New();
            Assert.That(ag.GetActionEnabled("does-not-exist")!, Is.False);
        }

        [Test]
        public void TestGetParameterType()
        {
            using var ag = TestActionGroup.New();
            Assert.That(ag.GetActionParameterType("does-not-exist")!, Is.EqualTo(VariantType.Int32));
        }

        [Test]
        public void TestGetStateType()
        {
            using var ag = TestActionGroup.New();
            Assert.That(ag.GetActionStateType("does-not-exist")!, Is.EqualTo(VariantType.Boolean));
        }

        [Test]
        public void TestGetActionStateHint()
        {
            using var ag = TestActionGroup.New();
            Assert.That((int)ag.GetActionStateHint("does-not-exist")!, Is.EqualTo(1));
        }

        [Test]
        public void TestGetActionState()
        {
            using var ag = TestActionGroup.New();
            Assert.That((int)ag.GetActionState("does-not-exist")!, Is.EqualTo(2));
        }

        [Test]
        public void TestChangeActionState()
        {
            using var ag = TestActionGroup.New();
            var expected = new Variant(7);
            var actual = default(Variant);
            ag.StateChanged += (s, a) => actual = a;
            ag.ChangeActionState("does-not-exist", expected);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestActivateAction()
        {
            using var ag = TestActionGroup.New();
            var expected = new Variant(9);
            var actual = default(Variant);
            ag.ActionActivated += (s, a) => actual = a;
            ag.ActivateAction("does-not-exist", expected);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestActionAdded()
        {
            using var ag = TestActionGroup.New();
            var actual = default(string);
            const string expected = "some-action";
            ag.ActionAddedSignal += (action, actionName) => actual = actionName;
            ActionGroup.ActionAdded(ag, expected);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestActionRemoved()
        {
            using var ag = TestActionGroup.New();
            var actual = default(string);
            const string expected = "some-action";
            ag.ActionRemovedSignal += (action, actionName) => actual = actionName;
            ActionGroup.ActionRemoved(ag, expected);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestActionEnabledChanged()
        {
            using var ag = TestActionGroup.New();
            var actual = default(string);
            const string expected = "some-action";
            ag.ActionEnabledChangedSignal += (action, actionName, enabled) => actual = actionName;
            ActionGroup.ActionEnabledChanged(ag, expected, true);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestActionStateChanged()
        {
            using var ag = TestActionGroup.New();
            var actual = default(string);
            const string expected = "some-action";
            ag.ActionStateChangedSignal += (action, actionName, value) => actual = actionName;
            ActionGroup.ActionStateChanged(ag, expected, new Variant(11));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [GType]
    class TestActionGroup : Object, IActionGroup
    {
        static readonly GType gtype = GType.Of<TestActionGroup>();

        public static TestActionGroup New()
        {
            return CreateInstance<TestActionGroup>();
        }

        public TestActionGroup(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        void IActionGroup.DoActionAdded(UnownedUtf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.DoActionEnabledChanged(UnownedUtf8 actionName, bool enabled)
        {
            // default signal handler
        }

        void IActionGroup.DoActionRemoved(UnownedUtf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.DoActionStateChanged(UnownedUtf8 actionName, Variant state)
        {
            // default signal handler
        }

        public event EventHandler<Variant?>? ActionActivated;

        void IActionGroup.DoActivateAction(UnownedUtf8 actionName, Variant? parameter) => ActionActivated?.Invoke(this, parameter);

        readonly GSignalManager<IActionGroup.ActionAddedSignalHandler> actionAddedSignalManager =
            new("action-added", gtype);

        public event IActionGroup.ActionAddedSignalHandler ActionAddedSignal {
            add => actionAddedSignalManager.Add(this, value);
            remove => actionAddedSignalManager.Remove(value);
        }

        readonly GSignalManager<IActionGroup.ActionEnabledChangedSignalHandler> actionEnabledChangedSignalManager =
            new("action-enabled-changed", gtype);

        public event IActionGroup.ActionEnabledChangedSignalHandler ActionEnabledChangedSignal {
            add => actionEnabledChangedSignalManager.Add(this, value);
            remove => actionEnabledChangedSignalManager.Remove(value);
        }

        readonly GSignalManager<IActionGroup.ActionRemovedSignalHandler> actionRemovedSignalManager =
            new("action-removed", gtype);

        public event IActionGroup.ActionRemovedSignalHandler ActionRemovedSignal {
            add => actionRemovedSignalManager.Add(this, value);
            remove => actionRemovedSignalManager.Remove(value);
        }

        readonly GSignalManager<IActionGroup.ActionStateChangedSignalHandler> actionStateChangedSignalManager =
            new("action-state-changed", gtype);

        public event IActionGroup.ActionStateChangedSignalHandler ActionStateChangedSignal {
            add => actionStateChangedSignalManager.Add(this, value);
            remove => actionStateChangedSignalManager.Remove(value);
        }

        public event EventHandler<Variant>? StateChanged;
        void IActionGroup.DoChangeActionState(UnownedUtf8 actionName, Variant value) => StateChanged?.Invoke(this, value);

        bool IActionGroup.DoGetActionEnabled(UnownedUtf8 actionName) => false;

        VariantType? IActionGroup.DoGetActionParameterType(UnownedUtf8 actionName) => VariantType.Int32;

        Variant? IActionGroup.DoGetActionState(UnownedUtf8 actionName) => new Variant(2);

        Variant? IActionGroup.DoGetActionStateHint(UnownedUtf8 actionName) => new Variant(1);

        VariantType? IActionGroup.DoGetActionStateType(UnownedUtf8 actionName) => VariantType.Boolean;

        bool IActionGroup.DoHasAction(UnownedUtf8 actionName) => false;

        Strv IActionGroup.DoListActions() => new Strv("test-action-1");
    }
}
