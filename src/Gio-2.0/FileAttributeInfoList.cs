
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GISharp.Lib.Gio
{
    partial class FileAttributeInfoList : IReadOnlyList<FileAttributeInfo>
    {
        /// <summary>
        /// Gets the <see cref="FileAttributeInfo"/> at the specified index.
        /// </summary>
        public unsafe FileAttributeInfo this[int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new IndexOutOfRangeException();
                }
                var infos_ = ((UnmanagedStruct*)Handle)->Infos;
                var info = infos_[index];
                return info;
            }
        }

        /// <summary>
        /// the number of values in the list.
        /// </summary>
        public unsafe int Count => ((UnmanagedStruct*)Handle)->NInfos;

        private IEnumerator<FileAttributeInfo> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) {
                yield return this[i];
            }
        }

        IEnumerator<FileAttributeInfo> IEnumerable<FileAttributeInfo>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
