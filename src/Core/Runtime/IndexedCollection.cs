// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019,2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;

namespace GISharp.Runtime
{
    /// <summary>
    /// A class for wrapping indexed properties.
    /// </summary>
    public class IndexedCollection<T> : IReadOnlyList<T>
    {
        readonly Func<int> getCount;
        readonly Func<int, T> getInfoAtIndex;

        /// <summary>
        /// Creates a new instance>
        /// </summary>
        public IndexedCollection(Func<int> getCount, Func<int, T> getInfoAtIndex)
        {
            this.getCount = getCount;
            this.getInfoAtIndex = getInfoAtIndex;
        }

        /// <summary>
        /// Gets the metadata entry at the specified index.
        /// </summary>
        /// <param name="index">0-based offset into namespace metadata for entry.</param>
        public T this[int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new IndexOutOfRangeException();
                }
                return getInfoAtIndex(index);
            }
        }

        /// <summary>
        /// Gets the number if items in this collection.
        /// </summary>
        /// <value>The count.</value>
        public int Count => getCount();

        #region IEnumerable implementation

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            var count = getCount();
            for (int i = 0; i < count; i++) {
                yield return getInfoAtIndex(i);
            }
        }

        #endregion

        #region IEnumerable implementation

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}

