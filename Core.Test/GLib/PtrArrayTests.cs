using System;

using NUnit.Framework;
using GISharp.GLib;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using GISharp.GObject;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class PtrArrayTests : IListTests<PtrArray<OpaqueInt>, OpaqueInt>
    {
        public PtrArrayTests () : base (getItemAt)
        {
        }

        static OpaqueInt getItemAt (PtrArray<OpaqueInt> array, int index)
        {
            var dataPtr = Marshal.ReadIntPtr (array.Handle);
            var data = Marshal.ReadIntPtr (dataPtr, IntPtr.Size * index);
            return Opaque.GetInstance<OpaqueInt> (data, Transfer.None);
        }

        [Test]
        public void TestRemoveFast ()
        {
            var a = new PtrArray<OpaqueInt> ();
            Assume.That (a.Count, Is.EqualTo (0));

            Assert.That (a.RemoveFast (_ (0)), Is.False);
            Assert.That (a.Count, Is.EqualTo (0));

            a.Add (_ (1));
            Assume.That (a.Count, Is.EqualTo (1));

            Assert.That (a.RemoveFast (_ (0)), Is.False);
            Assert.That (a.Count, Is.EqualTo (1));
            Assert.That (a.RemoveFast (_ (1)), Is.True);
            Assert.That (a.Count, Is.EqualTo (0));

            a.Add (_ (1));
            a.Add (_ (2));
            a.Add (_ (3));
            a.Add (_ (4));
            Assume.That (a.Count, Is.EqualTo (4));

            Assert.That (a.RemoveFast (_ (0)), Is.False);
            Assert.That (a.Count, Is.EqualTo (4));
            Assert.That (a.RemoveFast (_ (2)), Is.True);
            Assert.That (a.Count, Is.EqualTo (3));
            Assert.That (getItemAt (a, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (a, 1), Is.EqualTo (_ (4)));
            Assert.That (getItemAt (a, 2), Is.EqualTo (_ (3)));

            a.Dispose ();
            Assert.That (() => a.RemoveFast (_ (0)), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestRemoveAtFast ()
        {
            var a = new PtrArray<OpaqueInt> ();
            a.Add (_ (1));
            Assume.That (a.Count, Is.EqualTo (1));

            a.RemoveAtFast (0);
            Assert.That (a.Count, Is.EqualTo (0));

            a.Add (_ (1));
            a.Add (_ (2));
            a.Add (_ (3));
            a.Add (_ (4));
            Assume.That (a.Count, Is.EqualTo (4));

            a.RemoveAtFast (1);
            Assert.That (a.Count, Is.EqualTo (3));
            Assert.That (getItemAt (a, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (a, 1), Is.EqualTo (_ (4)));
            Assert.That (getItemAt (a, 2), Is.EqualTo (_ (3)));

            Assert.That (() => a.RemoveAtFast (-1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => a.RemoveAtFast (3), Throws.TypeOf<ArgumentOutOfRangeException> ());

            a.Dispose ();
            Assert.That (() => a.RemoveAtFast (0), Throws.TypeOf<ObjectDisposedException> ());
        }


        [Test]
        public void TestRemoveRange ()
        {
            var a = new PtrArray<OpaqueInt> ();
            a.Add (_ (1));
            a.Add (_ (2));
            a.Add (_ (3));
            a.Add (_ (4));
            a.Add (_ (5));
            a.Add (_ (6));
            Assume.That (a.Count, Is.EqualTo (6));

            a.RemoveRange (0, 0);
            Assert.That (a.Count, Is.EqualTo (6));

            a.RemoveRange (1, 2);
            Assert.That (a.Count, Is.EqualTo (4));
            Assert.That (getItemAt (a, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (a, 1), Is.EqualTo (_ (4)));
            Assert.That (getItemAt (a, 2), Is.EqualTo (_ (5)));
            Assert.That (getItemAt (a, 3), Is.EqualTo (_ (6)));

            Assert.That (() => a.RemoveRange (-1, 0), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => a.RemoveRange (0, -1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => a.RemoveRange (3, 4), Throws.TypeOf<ArgumentException> ());

            a.Dispose ();
            Assert.That (() => a.RemoveRange (0, 0), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestSort ()
        {
            var a = new PtrArray<OpaqueInt> ();
            a.Add (_ (3));
            a.Add (_ (1));
            a.Add (_ (2));
            Assume.That (getItemAt (a, 0), Is.EqualTo (_ (3)));
            Assume.That (getItemAt (a, 1), Is.EqualTo (_ (1)));
            Assume.That (getItemAt (a, 2), Is.EqualTo (_ (2)));

            a.Sort ((x, y) => x.Value - y.Value);
            Assert.That (getItemAt (a, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (a, 1), Is.EqualTo (_ (2)));
            Assert.That (getItemAt (a, 2), Is.EqualTo (_ (3)));

            Assert.That (() => a.Sort (null), Throws.TypeOf<ArgumentNullException> ());

            a.Dispose ();
            Assert.That (() => a.Sort ((x, y) => 0), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestSetSize ()
        {
            var a = new PtrArray<OpaqueInt> ();
            Assume.That (a.Count, Is.EqualTo (0));

            a.SetSize (5);
            Assert.That (a.Count, Is.EqualTo (5));

            a.Dispose ();
            Assert.That (() => a.SetSize (0), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestGType ()
        {
            var gtype = typeof (PtrArray<OpaqueInt>).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That (gtype.Name, Is.EqualTo ("GPtrArray"));
        }

        static OpaqueInt _ (int value)
        {
            return new OpaqueInt (value);
        }
    }
}
