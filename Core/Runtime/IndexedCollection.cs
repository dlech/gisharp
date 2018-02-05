using System;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    public class IndexedCollection<T> : IReadOnlyList<T>
    {
        Func<int> getCount;
        Func<int, T> getInfoAtIndex;

        public IndexedCollection (Func<int> getCount, Func<int, T> getInfoAtIndex)
        {
            if (getCount == null) {
                throw new ArgumentNullException (nameof (getCount));
            }
            if (getInfoAtIndex == null) {
                throw new ArgumentNullException (nameof (getInfoAtIndex));
            }
            this.getCount = getCount;
            this.getInfoAtIndex = getInfoAtIndex;
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

