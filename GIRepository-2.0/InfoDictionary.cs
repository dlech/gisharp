using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Dictionary of type info objects.
    /// </summary>
    /// <remarks>
    /// Members are read at initalization and cached for faster lookup later.
    /// </remarks>
    [DebuggerDisplay ("Count: {Count}")]
    public sealed class InfoDictionary<T> : IOrderedDictionary, IEnumerable<T> where T : BaseInfo
    {
        readonly Dictionary<string, int> nameMap;
        readonly List<T> infos;

        readonly int _Count;
        /// <summary>
        /// Gets the number if items in this collection.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get { return _Count; } }

        public bool IsFixedSize { get { return true; } }

        public bool IsReadOnly { get { return true; } }

        public bool IsSynchronized { get { return false; } }

        /// <summary>
        /// Gets the metadata entry at the specified index.
        /// </summary>
        /// <param name="index">0-based offset into namespace metadata for entry.</param>
        public T this[int index] {
            get {
                return infos[index];
            }
        }

        object IOrderedDictionary.this[int index] {
            get {
                return this[index];
            }
            set {
                throw new InvalidOperationException ();
            }
        }

        public T this[string key] {
            get {
                return infos[nameMap[key]];
            }
        }

        object IDictionary.this[object key] {
            get {
                return this[key.ToString ()];
            }
            set {
                throw new InvalidOperationException ();
            }
        }

        public IEnumerable<string> Keys {
            get {
                return nameMap.Keys;
            }
        }

        ICollection IDictionary.Keys {
            get {
                return nameMap.Keys;
            }
        }

        public object SyncRoot { get { throw new InvalidOperationException (); } }

        public ICollection<T> Values {
            get {
                return infos;
            }
        }

        ICollection IDictionary.Values {
            get {
                return infos;
            }
        }

        public InfoDictionary (int count, Func<int, T> getInfoAtIndex)
        {
            if (getInfoAtIndex == null) {
                throw new ArgumentException (nameof (getInfoAtIndex));
            }
            _Count = count;
            nameMap = new Dictionary<string, int> (count);
            infos = new List<T> (count);
            for (int i = 0; i < count; i++) {
                var info = getInfoAtIndex (i);
                infos.Add (info);
                nameMap.Add(info.Name!, i);
            }
        }

        void IDictionary.Add (object key, object value)
        {
            throw new InvalidOperationException ();
        }

        void IDictionary.Clear ()
        {
            throw new InvalidOperationException ();
        }

        public bool ContainsKey (string key)
        {
            return nameMap.ContainsKey (key);
        }

        bool IDictionary.Contains (object key)
        {
            return ContainsKey (key.ToString ());
        }

        void ICollection.CopyTo (Array array, int index)
        {
            infos.CopyTo ((T[])array, index);
        }

        public IEnumerator<T> GetEnumerator ()
        {
            return infos.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return infos.GetEnumerator ();
        }

        IDictionaryEnumerator IOrderedDictionary.GetEnumerator ()
        {
            return new Enumerator (infos);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator ()
        {
            return new Enumerator (infos);
        }

        public int IndexOf (T info)
        {
            int index;
            if (nameMap.TryGetValue(info.Name!, out index)) {
                return index;
            }
            return -1;
        }

        void IOrderedDictionary.Insert (int index, object key, object value)
        {
            throw new InvalidOperationException ();
        }

        void IDictionary.Remove (object key)
        {
            throw new InvalidOperationException ();
        }

        void IOrderedDictionary.RemoveAt (int index)
        {
            throw new InvalidOperationException ();
        }

        class Enumerator : IDictionaryEnumerator
        {
            List<T> list;
            int index;

            public object Current {
                get {
                    return list[index];
                }
            }

            public DictionaryEntry Entry {
                get {
                    var value = list[index];
                    return new DictionaryEntry (value.Name, value);
                }
            }

            public object Key {
                get {
                    return list[index].Name!;
                }
            }

            public object Value {
                get {
                    return list[index];
                }
            }

            public Enumerator (List<T> list)
            {
                this.list = list;
            }

            public bool MoveNext ()
            {
                index++;
                return index >= list.Count;
            }

            public void Reset ()
            {
                index = 0;
            }
        }
    }
}
