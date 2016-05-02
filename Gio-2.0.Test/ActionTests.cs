using NUnit.Framework;
using System;
using GISharp.Gio;
using GISharp.Runtime;
using GISharp.GLib;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void TestThatActivateImplementationIsCalled ()
        {
            var obj = new ActionImpl ();
            var parameter = new Variant (1);

            Assume.That (obj.ActivateCallbackCount, Is.EqualTo (0));
            obj.Activate (parameter);
            Assert.That (obj.ActivateCallbackCount, Is.EqualTo (1));
        }
    }

    [GType]
    class ActionImpl : GObject.Object, Action
    {
        public int ActivateCallbackCount;

        void Action.Activate (Variant parameter)
        {
            Assert.That ((int)parameter, Is.EqualTo (1));
            ActivateCallbackCount++;
        }
        void Action.ChangeState (Variant value)
        {
            throw new NotImplementedException ();
        }
        bool Action.GetEnabled ()
        {
            throw new NotImplementedException ();
        }
        string Action.GetName ()
        {
            throw new NotImplementedException ();
        }
        VariantType Action.GetParameterType ()
        {
            throw new NotImplementedException ();
        }
        Variant Action.GetState ()
        {
            throw new NotImplementedException ();
        }
        Variant Action.GetStateHint ()
        {
            throw new NotImplementedException ();
        }
        VariantType Action.GetStateType ()
        {
            throw new NotImplementedException ();
        }

        public ActionImpl () : this (New<ActionImpl> (), Transfer.All)
        {
        }

        protected ActionImpl (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
