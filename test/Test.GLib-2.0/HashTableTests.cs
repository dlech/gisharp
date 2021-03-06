// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;

using NUnit.Framework;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;

namespace GISharp.Test.GLib
{
    public class HashTableTests : Tests
    {
        [Test]
        public void TestConstructor()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
        }

        [Test]
        public void TestInsert()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt?>();
            Assume.That(hashTable.Size, Is.EqualTo(0));

            // inserting a value returns true
            var ret = hashTable.Insert(new OpaqueInt(0), new OpaqueInt(0));
            Assert.That(ret, Is.True);

            // replacing a value returns false
            ret = hashTable.Insert(new OpaqueInt(0), new OpaqueInt(1));
            Assert.That(ret, Is.False);

            // null key works
            ret = hashTable.Insert(null, new OpaqueInt(0));
            Assert.That(ret, Is.False);

            // null value works
            ret = hashTable.Insert(null, null);
            Assert.That(ret, Is.False);

            hashTable.Dispose();
            Assert.That(() => hashTable.Insert(null, null),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestReplace()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt?>();
            Assume.That(hashTable.Size, Is.EqualTo(0));

            // adding a new key returns true
            var ret = hashTable.Replace(new OpaqueInt(0), new OpaqueInt(0));
            Assert.That(ret, Is.True);

            // replacing a key returns false
            ret = hashTable.Replace(new OpaqueInt(0), new OpaqueInt(1));
            Assert.That(ret, Is.False);

            // null key works
            ret = hashTable.Replace(null, new OpaqueInt(0));
            Assert.That(ret, Is.False);

            // null value works
            ret = hashTable.Replace(null, null);
            Assert.That(ret, Is.False);

            hashTable.Dispose();
            Assert.That(() => hashTable.Replace(null, null),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestAdd()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt>();
            Assume.That(hashTable.Size, Is.EqualTo(0));

            // adding a new key returns true
            var ret = hashTable.TryAdd(new OpaqueInt(0));
            Assert.That(ret, Is.True);

            // replacing a key returns false
            ret = hashTable.TryAdd(new OpaqueInt(0));
            Assert.That(ret, Is.False);

            // null key works
            ret = hashTable.TryAdd(null);
            Assert.That(ret, Is.False);

            hashTable.Dispose();
            Assert.That(() => hashTable.Add(null),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestContains()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt>();

            // no match returns false
            var ret = hashTable.Contains(new OpaqueInt(0));
            Assert.That(ret, Is.False);

            // match returns true
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Contains(new OpaqueInt(0));
            Assert.That(ret, Is.True);

            // null key works
            ret = hashTable.Contains(null);
            Assert.That(ret, Is.True);

            hashTable.Dispose();
            Assert.That(() => hashTable.Contains(null),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestSize()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            Assume.That(hashTable.Size, Is.EqualTo(0));

            hashTable.Add(new OpaqueInt(0));
            Assert.That(hashTable.Size, Is.EqualTo(1));

            hashTable.Dispose();
            Assert.That(() => hashTable.Size,
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestLookup()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt>();
            // no match returns false
            var ret = hashTable.Lookup(new OpaqueInt(0));
            // Lookup cannot tell the difference between null and IntPtr.Zero
            Assert.That(ret, Is.Null.Or.EqualTo(new OpaqueInt(0)));

            // match returns true
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Lookup(new OpaqueInt(1));
            Assert.That(ret, Is.EqualTo(new OpaqueInt(1)));

            // null key works
            ret = hashTable.Lookup(null);
            // Lookup cannot tell the difference between null and IntPtr.Zero
            Assert.That(ret, Is.Null.Or.EqualTo(new OpaqueInt(0)));

            hashTable.Dispose();
            Assert.That(() => hashTable.Lookup(null),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestLookupExtended()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt>();
            // no match returns false
            var ret = hashTable.Lookup(new OpaqueInt(0), out OpaqueInt? key, out OpaqueInt value);
            Assert.That(ret, Is.False);
            // match returns true
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Lookup(new OpaqueInt(0), out key, out value);
            Assert.That(ret, Is.True);
            // null key works
            ret = hashTable.Lookup(null, out key, out value);
            Assert.That(ret, Is.True);

            hashTable.Dispose();
            Assert.That(() => hashTable.Lookup(null, out key, out value),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestForeach()
        {
            var count = 0;
            void foreachFunc(OpaqueInt k, OpaqueInt v)
            {
                count++;
            }

            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            // function is called back
            hashTable.Foreach(foreachFunc);
            Assert.That(count, Is.EqualTo(1));

            hashTable.Dispose();
            Assert.That(() => hashTable.Foreach(foreachFunc),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestFind()
        {
            static bool findFunc(OpaqueInt key, OpaqueInt value)
            {
                return true;
            }

            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();

            // no match returns null
            var ret = hashTable.Find(findFunc);
            Assert.That(ret, Is.Null.Or.EqualTo(new OpaqueInt(0)));

            // match returns non-null
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Find(findFunc);
            Assert.That(ret, Is.Not.Null);

            hashTable.Dispose();
            Assert.That(() => hashTable.Find(findFunc),
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestRemove()
        {
            using var hashTable = new HashTable<OpaqueInt?, OpaqueInt>();

            // no match returns false
            var ret = hashTable.Remove(new OpaqueInt(0));
            Assert.That(ret, Is.False);

            // match returns true
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Remove(new OpaqueInt(0));
            Assert.That(ret, Is.True);

            // null key works
            ret = hashTable.Remove(null);
            Assert.That(ret, Is.False);

            hashTable.Dispose();
            Assert.That(() => hashTable.Remove(null),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#if false
        [Test]
        public void TestSteal()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            // no match returns false
            var ret = hashTable.Steal(new OpaqueInt(1));
            Assert.That(ret, Is.False);

            // match returns true
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            ret = hashTable.Steal(new OpaqueInt(1));
            Assert.That(ret, Is.True);

            // null key works
            ret = hashTable.Steal(null);
            Assert.That(ret, Is.False);

            hashTable.Dispose();
            Assert.That(() => hashTable.Steal(null),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#endif
        [Test]
        public void TestForeachRemove()
        {
            var count = 0;
            bool foreachFunc(OpaqueInt key, OpaqueInt value)
            {
                count++;
                return true;
            }

            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            // function is called back
            var ret = hashTable.ForeachRemove(foreachFunc);
            Assert.That(ret, Is.EqualTo(count));

            hashTable.Dispose();
            Assert.That(
                () => hashTable.ForeachRemove(foreachFunc),
                Throws.TypeOf<ObjectDisposedException>()
            );
        }
#if false
        [Test]
        public void TestForeachSteal()
        {
            var count = 0;
            bool foreachFunc(OpaqueInt key, OpaqueInt value)
            {
                count++;
                return true;
            }

            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>(); hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));
            // function is called back
            var ret = hashTable.ForeachSteal((HRFunc<OpaqueInt, OpaqueInt>)foreachFunc);
            Assert.That(ret, Is.EqualTo(count));

            hashTable.Dispose();
            Assert.That(() => hashTable.ForeachSteal((HRFunc<OpaqueInt, OpaqueInt>)foreachFunc),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#endif
        [Test]
        public void TestRemoveAll()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(0));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            hashTable.RemoveAll();
            Assert.That(hashTable.Size, Is.EqualTo(0));

            hashTable.Dispose();
            Assert.That(() => hashTable.RemoveAll(),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#if false
        [Test]
        public void TestStealAll()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            hashTable.StealAll();
            Assert.That(hashTable.Size, Is.EqualTo(0));

            hashTable.Dispose();
            Assert.That(() => hashTable.StealAll(),
                         Throws.TypeOf<ObjectDisposedException>());
        }
#endif
        [Test]
        public void TestGetKeys()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            var ret = hashTable.Keys;
            Assert.That(ret.Length, Is.EqualTo(1));

            hashTable.Dispose();
            Assert.That(() => hashTable.Keys,
                         Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestGetValues()
        {
            using var hashTable = new HashTable<OpaqueInt, OpaqueInt>();
            hashTable.Add(new OpaqueInt(1));
            Assume.That(hashTable.Size, Is.EqualTo(1));

            var ret = hashTable.Values;
            Assert.That(ret.Length, Is.EqualTo(1));

            hashTable.Dispose();
            Assert.That(
                () => hashTable.Values,
                Throws.TypeOf<ObjectDisposedException>());
        }

        [Test]
        public void TestGType()
        {
            var gtype = GType.Of<HashTable<OpaqueInt, OpaqueInt>>();
            Assert.That(gtype, Is.Not.EqualTo(GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GHashTable"));
        }
    }
}
