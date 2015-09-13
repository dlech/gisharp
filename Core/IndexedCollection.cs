using System;
using System.Collections.Generic;

namespace GISharp.Core
{
    public class IndexedCollection<T> : IEnumerable<T>
    {
        System.Func<int> getCount;
        System.Func<int, T> getInfoAtIndex;

        public IndexedCollection (System.Func<int> getCount, System.Func<int, T> getInfoAtIndex)
        {
            if (getCount == null) {
                throw new ArgumentException ("getCount");
            }
            if (getInfoAtIndex == null) {
                throw new ArgumentException ("getInfoAtIndex");
            }
            this.getCount = getCount;
            this.getInfoAtIndex = getInfoAtIndex;
        }

        public IndexedCollection (System.Func<uint> getCount, System.Func<uint, T> getInfoAtIndex)
            : this (() => (int)getCount (), i => getInfoAtIndex ((uint)i))
        {
        }

        public IndexedCollection (System.Func<long> getCount, System.Func<long, T> getInfoAtIndex)
            : this (() => (int)getCount (), i => getInfoAtIndex (i))
        {
        }

        public IndexedCollection (System.Func<ulong> getCount, System.Func<ulong, T> getInfoAtIndex)
            : this (() => (int)getCount (), i => getInfoAtIndex ((ulong)i))
        {
        }

        /// <summary>
        /// Gets the metadata entry at the specified index.
        /// </summary>
        /// <param name="index">0-based offset into namespace metadata for entry.</param>
        public T this [int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new IndexOutOfRangeException ();
                }
                return getInfoAtIndex (index);
            }
        }

        /// <summary>
        /// Gets the number if items in this collection.
        /// </summary>
        /// <value>The count.</value>
        public int Count {
            get { return getCount (); }
        }

        #region IEnumerable implementation

        public IEnumerator<T> GetEnumerator ()
        {
            var count = getCount ();
            for (int i = 0; i < count; i++) {
                yield return getInfoAtIndex (i);
            }
        }

        #endregion

        #region IEnumerable implementation

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        {
            return GetEnumerator ();
        }

        #endregion
    }
}

