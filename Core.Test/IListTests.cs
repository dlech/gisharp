using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    public class IListTests<TList, TItem> where TList : IList<TItem>, IDisposable, new()
    {
        readonly Func<TList, int, TItem> getItemAt;
        readonly TItem[] values = new TItem[5];

        protected IListTests(Func<TList, int, TItem> getItemAt, TItem value0, TItem value1, TItem value2, TItem value3, TItem value4)
        {
            this.getItemAt = getItemAt ?? throw new ArgumentNullException(nameof(getItemAt));
            values[0] = value0;
            values[1] = value1;
            values[2] = value2;
            values[3] = value3;
            values[4] = value4;
            }

        [Test]
        public void TestCount ()
        {
            var l = new TList ();
            Assert.That (l.Count, Is.EqualTo (0));

            l.Dispose ();
            Assert.Throws<ObjectDisposedException> (() => l.Count.GetType ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestIsReadOnly ()
        {
            var l = new TList ();
            Assert.That (l.IsReadOnly, Is.False);

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestIndexer ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            Assert.That (() => l[-1], Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => l[0], Throws.TypeOf<ArgumentOutOfRangeException> ());

            l.Add(values[1]);
            Assert.That(l[0], Is.EqualTo(values[1]));

            l[0] = values[2];
            Assert.That(l[0], Is.EqualTo(values[2]));

            l.Dispose ();
            Assert.That (() => l[0], Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestAdd ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            l.Add(values[1]);
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[1]));

            l.Dispose ();
            Assert.That (() => l.Count, Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestClear ()
        {
            var l = new TList ();
            l.Add(values[1]);
            Assume.That (l.Count, Is.EqualTo (1));

            l.Clear ();
            Assert.That (l.Count, Is.EqualTo (0));

            l.Dispose ();
            Assert.That (() => l.Clear (), Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestContains ()
        {
            var l = new TList ();
            l.Add(values[1]);

            Assert.That(l.Contains(values[0]), Is.False);
            Assert.That(l.Contains(values[1]), Is.True);

            l.Dispose ();
            Assert.That(() => l.Contains(values[0]), Throws.TypeOf<ObjectDisposedException>());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestCopyTo ()
        {
            var l = new TList ();
            l.Add(values[1]);
            l.Add(values[2]);
            Assume.That (l.Count, Is.EqualTo (2));

            var a = new TItem[3];
            // TItem may not be a value type, so we need to explicitly initialize
            // the array with values.
            for (int i = 0; i < 3; i++) {
                a[i] = values[0];
                Assume.That(a[i], Is.EqualTo(values[0]));
            }
            l.CopyTo(a, 0);
            Assert.That(a[0], Is.EqualTo(values[1]));
            Assert.That(a[1], Is.EqualTo(values[2]));
            Assert.That(a[2], Is.EqualTo(values[0]));

            l.CopyTo (a, 1);
            Assert.That(a[0], Is.EqualTo(values[1]));
            Assert.That(a[1], Is.EqualTo(values[1]));
            Assert.That(a[2], Is.EqualTo(values[2]));

            Assert.That (() => a.CopyTo (null, 0), Throws.TypeOf<ArgumentNullException> ());
            Assert.That (() => a.CopyTo (a, -1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => a.CopyTo (a, 2), Throws.TypeOf<ArgumentException> ());

            l.Dispose ();
            Assert.That (() => l.CopyTo (a, 0), Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestGetEnumerator ()
        {
            var l = new TList ();
            l.Add(values[1]);
            l.Add(values[2]);
            l.Add(values[3]);

            var expected = 1;
            foreach (var i in l) {
                Assert.That (i, Is.EqualTo (values[expected++]));
            }
            Assert.That (expected, Is.EqualTo (4));

            l.Dispose ();
            Assert.That(() => l.Any(), Throws.TypeOf<ObjectDisposedException>());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestIndexOf ()
        {
            var l = new TList ();
            l.Add(values[1]);
            l.Add(values[1]);

            Assert.That(l.IndexOf(values[0]), Is.EqualTo(-1));
            Assert.That(l.IndexOf(values[1]), Is.EqualTo(0));

            l.Dispose ();
            Assert.That(() => l.IndexOf(values[0]), Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestInsert ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            l.Insert(0, values[1]);
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[1]));

            l.Insert(0, values[2]);
            Assert.That (l.Count, Is.EqualTo (2));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[2]));
            Assert.That(getItemAt(l, 1), Is.EqualTo(values[1]));

            l.Insert(1, values[3]);
            Assert.That (l.Count, Is.EqualTo (3));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[2]));
            Assert.That(getItemAt(l, 1), Is.EqualTo(values[3]));
            Assert.That(getItemAt(l, 2), Is.EqualTo(values[1]));

            l.Insert(3, values[4]);
            Assert.That (l.Count, Is.EqualTo (4));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[2]));
            Assert.That(getItemAt(l, 1), Is.EqualTo(values[3]));
            Assert.That(getItemAt(l, 2), Is.EqualTo(values[1]));
            Assert.That(getItemAt(l, 3), Is.EqualTo(values[4]));

            Assert.That(() => l.Insert(-1, values[0]), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => l.Insert(5, values[0]), Throws.TypeOf<ArgumentOutOfRangeException>());

            l.Dispose ();
            Assert.That(() => l.Insert(0, values[0]), Throws.TypeOf<ObjectDisposedException>());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestRemove ()
        {
            var l = new TList ();
            Assume.That (l.Count, Is.EqualTo (0));

            Assert.That(l.Remove(values[0]), Is.False);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add(values[1]);
            Assume.That (l.Count, Is.EqualTo (1));

            Assert.That(l.Remove(values[0]), Is.False);
            Assert.That (l.Count, Is.EqualTo (1));
            Assert.That(l.Remove(values[1]), Is.True);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add(values[1]);
            l.Add(values[2]);
            l.Add(values[3]);
            l.Add(values[4]);
            Assume.That (l.Count, Is.EqualTo (4));

            Assert.That(l.Remove(values[0]), Is.False);
            Assert.That (l.Count, Is.EqualTo (4));
            Assert.That(l.Remove(values[2]), Is.True);
            Assert.That (l.Count, Is.EqualTo (3));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[1]));
            Assert.That(getItemAt(l, 1), Is.EqualTo(values[3]));
            Assert.That(getItemAt(l, 2), Is.EqualTo(values[4]));

            l.Dispose ();
            Assert.That(() => l.Remove(values[0]), Throws.TypeOf<ObjectDisposedException>());

            Utility.AssertNoGLibLog();
        }

        [Test]
        public void TestRemoveAt ()
        {
            var l = new TList ();
            l.Add(values[1]);
            Assume.That (l.Count, Is.EqualTo (1));

            l.RemoveAt (0);
            Assert.That (l.Count, Is.EqualTo (0));

            l.Add(values[1]);
            l.Add(values[2]);
            l.Add(values[3]);
            l.Add(values[4]);
            Assume.That (l.Count, Is.EqualTo (4));

            l.RemoveAt (1);
            Assert.That (l.Count, Is.EqualTo (3));
            Assert.That(getItemAt(l, 0), Is.EqualTo(values[1]));
            Assert.That(getItemAt(l, 1), Is.EqualTo(values[3]));
            Assert.That(getItemAt(l, 2), Is.EqualTo(values[4]));

            Assert.That (() => l.RemoveAt (-1), Throws.TypeOf<ArgumentOutOfRangeException> ());
            Assert.That (() => l.RemoveAt (3), Throws.TypeOf<ArgumentOutOfRangeException> ());

            l.Dispose ();
            Assert.That (() => l.RemoveAt (0), Throws.TypeOf<ObjectDisposedException> ());

            Utility.AssertNoGLibLog();
        }
    }

    /// <summary>
    /// This test class is used to validate the tests in IListTests using the
    /// standard .NET List&lt;int&gt; implementation.
    /// </summary>
    [TestFixture]
    public class ListTests : IListTests<DisposableList, int>
    {
        public ListTests() : base(HandleFunc, 0, 1, 2, 3, 4)
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
