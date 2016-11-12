using System;

using NUnit.Framework;
using GISharp.GLib;

namespace GISharp.Core.Test.GLib
{
    [TestFixture]
    public class HashTableTests
    {
        [Test]
        public void TestConstructor ()
        {
            var hashTable1 = new HashTable<TestOpaque, TestOpaque> ();
            HashFunc<TestOpaque> hashFunc = (key) =>
                (uint)key.GetHashCode ();
            EqualFunc<TestOpaque> keyEqualFunc = (a, b) =>
                a.Value == b.Value;
            DestroyNotify<TestOpaque> keyDestroyFunc = (data) => {
            };
            DestroyNotify<TestOpaque> valueDestroyFunc = (data) => {
            };
            var hashTable2 = new HashTable<TestOpaque, TestOpaque> (
                hashFunc, keyEqualFunc, keyDestroyFunc, valueDestroyFunc);
        }

        [Test]
        public void TestInsert ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // inserting a value returns true
            var ret = hashTable.Insert (new TestOpaque (0), new TestOpaque (0));
            Assert.That (ret, Is.True);
            // replacing a value returns false
            ret = hashTable.Insert (new TestOpaque (0), new TestOpaque (1));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Insert (null, new TestOpaque (0));
            Assert.That (ret, Is.False);
            // null value works
            ret = hashTable.Insert (null, null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestReplace ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // adding a new key returns true
            var ret = hashTable.Replace (new TestOpaque (0), new TestOpaque (0));
            Assert.That (ret, Is.True);
            // replacing a key returns false
            ret = hashTable.Replace (new TestOpaque (0), new TestOpaque (1));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Replace (null, new TestOpaque (0));
            Assert.That (ret, Is.False);
            // null value works
            ret = hashTable.Replace (null, null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestAdd ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // adding a new key returns true
            var ret = hashTable.Add (new TestOpaque (0));
            Assert.That (ret, Is.True);
            // replacing a key returns false
            ret = hashTable.Add (new TestOpaque (0));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Add (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestContains ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            // no match returns false
            var ret = hashTable.Contains (new TestOpaque (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Contains (new TestOpaque (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Contains (null);
            Assert.That (ret, Is.True);
        }

        [Test]
        public void TestSize ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            hashTable.Add (new TestOpaque (0));
            Assert.That (hashTable.Size, Is.EqualTo (1));
        }

        [Test]
        public void TestLookup ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            // no match returns false
            var ret = hashTable.Lookup (new TestOpaque (0));
            Assert.That (ret, Is.Null);
            // match returns true
            hashTable.Add (new TestOpaque (1));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Lookup (new TestOpaque (1));
            Assert.That (ret, Is.Not.Null);
            // null key works
            ret = hashTable.Lookup (null);
            Assert.That (ret, Is.Null);
        }

        [Test]
        public void TestLookupExtended ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            TestOpaque key, value;
            // no match returns false
            var ret = hashTable.LookupExtended (new TestOpaque (0), out key, out value);
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.LookupExtended (new TestOpaque (0), out key, out value);
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.LookupExtended (null, out key, out value);
            Assert.That (ret, Is.True);
        }

        [Test]
        public void TestForeach ()
        {
            var count = 0;
            HFunc<TestOpaque,TestOpaque> foreachFunc = (key, value) => {
                count++;
            };
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            hashTable.Foreach (foreachFunc);
            Assert.That (count, Is.EqualTo (1));
            // null function is not OK
            Assert.That (() => hashTable.Foreach (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestFind ()
        {
            HRFunc<TestOpaque,TestOpaque> findFunc = (key, value) => {
                return true;
            };
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            // no match returns null
            var ret = hashTable.Find (findFunc);
            Assert.That (ret, Is.Null);
            // match returns non-null
            hashTable.Add (new TestOpaque (1));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Find (findFunc);
            Assert.That (ret, Is.Not.Null);
            // null function is not OK
            Assert.That (() => hashTable.Find (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestRemove ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            // no match returns false
            var ret = hashTable.Remove (new TestOpaque (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Remove (new TestOpaque (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Remove (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestSteal ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            // no match returns false
            var ret = hashTable.Steal (new TestOpaque (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Steal (new TestOpaque (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Steal (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestForeachRemove ()
        {
            var count = 0;
            HRFunc<TestOpaque,TestOpaque> foreachFunc = (key, value) => {
                count++;
                return true;
            };
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            var ret = hashTable.ForeachRemove (foreachFunc);
            Assert.That (ret, Is.EqualTo (count));
            // null function is not OK
            Assert.That (() => hashTable.ForeachRemove (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestForeachSteal ()
        {
            var count = 0;
            HRFunc <TestOpaque,TestOpaque> foreachFunc = (key, value) => {
                count++;
                return true;
            };
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            var ret = hashTable.ForeachSteal (foreachFunc);
            Assert.That (ret, Is.EqualTo (count));
            // null function is not OK
            Assert.That (() => hashTable.ForeachSteal (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestRemoveAll ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            hashTable.RemoveAll ();
            Assert.That (hashTable.Size, Is.EqualTo (0));
        }

        [Test]
        public void TestStealAll ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            hashTable.StealAll ();
            Assert.That (hashTable.Size, Is.EqualTo (0));
        }

        [Test]
        public void TestGetKeys ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // test case
            var ret = hashTable.Keys;
            Assert.That (ret.Length, Is.EqualTo (1));
        }

        [Test]
        public void TestGetValues ()
        {
            var hashTable = new HashTable<TestOpaque,TestOpaque> ();
            hashTable.Add (new TestOpaque (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // test case
            var ret = hashTable.Values;
            Assert.That (ret.Length, Is.EqualTo (1));
        }
    }
}
