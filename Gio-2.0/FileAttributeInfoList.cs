
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GISharp.Lib.Gio
{
    partial class FileAttributeInfoList : IReadOnlyList<FileAttributeInfo>
    {
        public FileAttributeInfo this[int index] {
            get {
                if (index >= Count) {
                    throw new IndexOutOfRangeException();
                }
                var infos = Marshal.PtrToStructure<Struct>(Handle).Infos;
                return Marshal.PtrToStructure<FileAttributeInfo>(infos + index * IntPtr.Size);
            }
        }

        /// <summary>
        /// the number of values in the list.
        /// </summary>
        public int Count => Marshal.PtrToStructure<Struct>(Handle).NInfos;

        public IEnumerator<FileAttributeInfo> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
