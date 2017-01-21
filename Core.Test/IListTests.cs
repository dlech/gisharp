using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace GISharp.Core.Test
{
    public class IListTests<TList, TItem> where TList : IList<TItem>, IDisposable, new()
    {
        readonly Func<TList, int, TItem> getItemAt;

        protected IListTests (Func<TList, int, TItem> getItemAt)
        {
            if (getItemAt == null) {
                throw new ArgumentNullException (nameof (getItemAt));
            }
            this.getItemAt = getItemAt;
        }

        [Test]
        public void TestCount ()
        {
            var l = new TList ();
            Assert.That (l.Count, Is.EqualTo (0));

            l.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => l.Count.GetType ());
        }

        [Test]
        public void TestIsReadOnly ()
        {
            var l = new TList ();
            Assert.That (l.IsReadOnly, Is.False);

            l.Dispose ();
            Assert.That (() => l.IsReadOnly, Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestIndexer ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            Assert.That (() => l[-1], Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => l[0], Throws.TypeOf<ArgumentOutOfRangeException> ());

            l.Add (_ (1));
            Assert.That (l[0], Is.EqualTo (_ (1)));

            l[0] = _ (2);
            Assert.That (l[0], Is.EqualTo (_ (2)));

            l.Dispose ();
            Assert.That (() => l[0], Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestAdd ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            l.Add (_ (1));
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (1)));

            l.Dispose ();
            Assert.That (() => l.Count, Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestClear ()
        {
            var l = new TList ();
            l.Add (_ (1));
            Assume.That (l.Count, Is.EqualTo (1));

            l.Clear ();
            Assert.That (l.Count, Is.EqualTo (0));

            l.Dispose ();
            Assert.That (() => l.Clear (), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestContains ()
        {
            var l = new TList ();
            l.Add (_ (1));

            Assert.That (l.Contains (_ (0)), Is.False);
            Assert.That (l.Contains (_ (1)), Is.True);

            l.Dispose ();
            Assert.That (() => l.Contains (_ (0)), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestCopyTo ()
        {
            var l = new TList ();
            l.Add (_ (1));
            l.Add (_ (2));
            Assume.That (l.Count, Is.EqualTo (2));

            var a = new TItem[3];
            l.CopyTo (a, 0);
            Assert.That (a[0], Is.EqualTo (_ (1)));
            Assert.That (a[1], Is.EqualTo (_ (2)));
            Assert.That (a[2], Is.EqualTo (_ (0)));

            l.CopyTo (a, 1);
            Assert.That (a[0], Is.EqualTo (_ (1)));
            Assert.That (a[1], Is.EqualTo (_ (1)));
            Assert.That (a[2], Is.EqualTo (_ (2)));

            Assert.That (() => a.CopyTo (null, 0), Throws.TypeOf<ArgumentNullException> ());
            Assert.That (() => a.CopyTo (a, -1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => a.CopyTo (a, 2), Throws.TypeOf<ArgumentException> ());

            l.Dispose ();
            Assert.That (() => l.CopyTo (a, 0), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestGetEnumerator ()
        {
            var l = new TList ();
            l.Add (_ (1));
            l.Add (_ (2));
            l.Add (_ (3));

            var expected = 1;
            foreach (var i in l) {
                Assert.That (i, Is.EqualTo (_ (expected++)));
            }
            Assert.That (expected, Is.EqualTo (4));

            l.Dispose ();
            Assert.That (() => l.GetEnumerator (), Throws.TypeOf<ObjectDisposedException> ());
            Assert.That (() => ((IEnumerable)l).GetEnumerator (), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestIndexOf ()
        {
            var l = new TList ();
            l.Add (_ (1));
            l.Add (_ (1));

            Assert.That (l.IndexOf (_ (0)), Is.EqualTo (-1));
            Assert.That (l.IndexOf (_ (1)), Is.EqualTo (0));

            l.Dispose ();
            Assert.That (() => l.IndexOf (_ (0)), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestInsert ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            l.Insert (0, _ (1));
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (1)));

            l.Insert (0, _ (2));
            Assert.That (l.Count, Is.EqualTo (2));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (2)));
            Assert.That (getItemAt (l, 1), Is.EqualTo (_ (1)));

            l.Insert (1, _ (3));
            Assert.That (l.Count, Is.EqualTo (3));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (2)));
            Assert.That (getItemAt (l, 1), Is.EqualTo (_ (3)));
            Assert.That (getItemAt (l, 2), Is.EqualTo (_ (1)));

            l.Insert (3, _ (4));
            Assert.That (l.Count, Is.EqualTo (4));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (2)));
            Assert.That (getItemAt (l, 1), Is.EqualTo (_ (3)));
            Assert.That (getItemAt (l, 2), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (l, 3), Is.EqualTo (_ (4)));

            Assert.That (() => l.Insert (-1, _ (0)), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => l.Insert (5, _ (0)), Throws.TypeOf<ArgumentOutOfRangeException> ());

            l.Dispose ();
            Assert.That (() => l.Insert (0, _ (0)), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestRemove ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            Assert.That (l.Remove (_ (0)), Is.False);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add (_ (1));
            Assume.That (l.Count, Is.EqualTo (1));

            Assert.That (l.Remove (_ (0)), Is.False);
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That (l.Remove (_ (1)), Is.True);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add (_ (1));
            l.Add (_ (2));
            l.Add (_ (3));
            Assume.That (l.Count, Is.EqualTo (3));

            Assert.That (l.Remove (_ (0)), Is.False);
            Assert.That (l.Count, Is.EqualTo (3));
            Assert.That (l.Remove (_ (2)), Is.True);
            Assert.That (l.Count, Is.EqualTo (2));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (l, 1), Is.EqualTo (_ (3)));

            l.Dispose ();
            Assert.That (() => l.Remove (_ (0)), Throws.TypeOf<ObjectDisposedException> ());
        }

        [Test]
        public void TestRemoveAt ()
        {
            var l = new TList ();
            l.Add (_ (1));
            Assume.That (l.Count, Is.EqualTo (1));

            l.RemoveAt (0);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add (_ (1));
            l.Add (_ (2));
            l.Add (_ (3));
            Assume.That (l.Count, Is.EqualTo (3));

            l.RemoveAt (1);
            Assert.That (l.Count, Is.EqualTo (2));
            Assert.That (getItemAt (l, 0), Is.EqualTo (_ (1)));
            Assert.That (getItemAt (l, 1), Is.EqualTo (_ (3)));

            Assert.That (() => l.RemoveAt (-1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => l.RemoveAt (2), Throws.TypeOf<ArgumentOutOfRangeException> ());

            l.Dispose ();
            Assert.That (() => l.RemoveAt (0), Throws.TypeOf<ObjectDisposedException> ());
        }

        TItem _ (int value)
        {
            return (TItem)Convert.ChangeType (value, typeof (TItem));
        }
    }

    /// <summary>
    /// This test class is used to validate the tests in IListTests using the
    /// standard .NET List&lt;int&gt; implementation.
    /// </summary>
    [TestFixture]
    public class ListTests : IListTests<DisposableList, int>
    {
        public ListTests () : base (HandleFunc)
        {
        }

        static int HandleFunc (DisposableList arg1, int arg2)
        {
            return arg1[arg2];
        }
    }

    public class DisposableList : IList<int>, IDisposable
    {
        readonly List<int> list = new List<int> ();
        bool isDisposed;

        public void Dispose ()
        {
            isDisposed = true;
        }

        void AssertNotDisposed ()
        {
            if (isDisposed) {
                throw new ObjectDisposedException (string.Empty);
            }
        }

        public int Count {
            get {
                AssertNotDisposed ();
                return list.Count;
            }
        }

        public bool IsReadOnly {
            get {
                AssertNotDisposed ();
                return ((IList<int>)list).IsReadOnly;
            }
        }

        public int this[int index] {
            get {
                AssertNotDisposed ();
                return list[index];
            }

            set {
                AssertNotDisposed ();
                list[index] = value;
            }
        }

        public int IndexOf (int item)
        {
            AssertNotDisposed ();
            return list.IndexOf (item);
        }

        public void Insert (int index, int item)
        {
            AssertNotDisposed ();
            list.Insert (index, item);
        }

        public void RemoveAt (int index)
        {
            AssertNotDisposed ();
            list.RemoveAt (index);
        }

        public void Add (int item)
        {
            AssertNotDisposed ();
            list.Add (item);
        }

        public void Clear ()
        {
            AssertNotDisposed ();
            list.Clear ();
        }

        public bool Contains (int item)
        {
            AssertNotDisposed ();
            return list.Contains (item);
        }

        public void CopyTo (int[] array, int arrayIndex)
        {
            AssertNotDisposed ();
            list.CopyTo (array, arrayIndex);
        }

        public bool Remove (int item)
        {
            AssertNotDisposed ();
            return list.Remove (item);
        }

        public IEnumerator<int> GetEnumerator ()
        {
            AssertNotDisposed ();
            return list.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            AssertNotDisposed ();
            return ((IEnumerable)list).GetEnumerator ();
        }
    }
}
