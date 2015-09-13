using System;
using System.Runtime.InteropServices;

using GISharp.Core;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class HashTableTest
    {
        [Test]
        public void TestConstructor ()
        {
            var hashTable1 = new HashTable<TestWrappedNative, TestWrappedNative> ();
            HashFunc<TestWrappedNative> hashFunc = (key) =>
                (uint)key.GetHashCode ();
            EqualFunc<TestWrappedNative> keyEqualFunc = (a, b) =>
                a.Value == b.Value;
            DestroyNotify<TestWrappedNative> keyDestroyFunc = (data) => {
            };
            DestroyNotify<TestWrappedNative> valueDestroyFunc = (data) => {
            };
            var hashTable2 = new HashTable<TestWrappedNative, TestWrappedNative> (
                hashFunc, keyEqualFunc, keyDestroyFunc, valueDestroyFunc);
        }

        [Test]
        public void TestInsert ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // inserting a value returns true
            var ret = hashTable.Insert (new TestWrappedNative (0), new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // replacing a value returns false
            ret = hashTable.Insert (new TestWrappedNative (0), new TestWrappedNative (1));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Insert (null, new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // null value works
            ret = hashTable.Insert (null, null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestReplace ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // adding a new key returns true
            var ret = hashTable.Replace (new TestWrappedNative (0), new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // replacing a key returns false
            ret = hashTable.Replace (new TestWrappedNative (0), new TestWrappedNative (1));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Replace (null, new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // null value works
            ret = hashTable.Replace (null, null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestAdd ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            // adding a new key returns true
            var ret = hashTable.Add (new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // replacing a key returns false
            ret = hashTable.Add (new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // null key works
            ret = hashTable.Add (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestContains ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            // no match returns false
            var ret = hashTable.Contains (new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Contains (new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Contains (null);
            Assert.That (ret, Is.True);
        }

        [Test]
        public void TestSize ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            Assume.That (hashTable.Size, Is.EqualTo (0));
            hashTable.Add (new TestWrappedNative (0));
            Assert.That (hashTable.Size, Is.EqualTo (1));
        }

        [Test]
        public void TestLookup ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            // no match returns false
            var ret = hashTable.Lookup (new TestWrappedNative (0));
            Assert.That (ret, Is.Null);
            // match returns true
            hashTable.Add (new TestWrappedNative (1));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Lookup (new TestWrappedNative (1));
            Assert.That (ret, Is.Not.Null);
            // null key works
            ret = hashTable.Lookup (null);
            Assert.That (ret, Is.Null);
        }

        [Test]
        public void TestLookupExtended ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            TestWrappedNative key, value;
            // no match returns false
            var ret = hashTable.LookupExtended (new TestWrappedNative (0), out key, out value);
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.LookupExtended (new TestWrappedNative (0), out key, out value);
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.LookupExtended (null, out key, out value);
            Assert.That (ret, Is.True);
        }

        [Test]
        public void TestForeach ()
        {
            var count = 0;
            HFunc<TestWrappedNative,TestWrappedNative> foreachFunc = (key, value) => {
                count++;
            };
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
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
            HRFunc<TestWrappedNative,TestWrappedNative> findFunc = (key, value) => {
                return true;
            };
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            // no match returns null
            var ret = hashTable.Find (findFunc);
            Assert.That (ret, Is.Null);
            // match returns non-null
            hashTable.Add (new TestWrappedNative (1));
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
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            // no match returns false
            var ret = hashTable.Remove (new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Remove (new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Remove (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestSteal ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            // no match returns false
            var ret = hashTable.Steal (new TestWrappedNative (0));
            Assert.That (ret, Is.False);
            // match returns true
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            ret = hashTable.Steal (new TestWrappedNative (0));
            Assert.That (ret, Is.True);
            // null key works
            ret = hashTable.Steal (null);
            Assert.That (ret, Is.False);
        }

        [Test]
        public void TestForeachRemove ()
        {
            var count = 0;
            HRFunc<TestWrappedNative,TestWrappedNative> foreachFunc = (key, value) => {
                count++;
                return true;
            };
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
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
            HRFunc<TestWrappedNative,TestWrappedNative> foreachFunc = (key, value) => {
                count++;
                return true;
            };
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
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
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            hashTable.RemoveAll ();
            Assert.That (hashTable.Size, Is.EqualTo (0));
        }

        [Test]
        public void TestStealAll ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // function is called back
            hashTable.StealAll ();
            Assert.That (hashTable.Size, Is.EqualTo (0));
        }

        [Test]
        public void TestGetKeys ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // test case
            var ret = hashTable.Keys;
            Assert.That (ret.Length, Is.EqualTo (1));
        }

        [Test]
        public void TestGetValues ()
        {
            var hashTable = new HashTable<TestWrappedNative,TestWrappedNative> ();
            hashTable.Add (new TestWrappedNative (0));
            Assume.That (hashTable.Size, Is.EqualTo (1));
            // test case
            var ret = hashTable.Values;
            Assert.That (ret.Length, Is.EqualTo (1));
        }
    }
}
