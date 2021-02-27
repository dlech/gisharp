// SPDX-License-Identifier: MIT
// Copyright (c) 20201 David Lechner <david@lechnology.com>

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class Repository
    {
        private ConcurrentDictionary<string, IndexedCollection<BaseInfo>> infos = new();

        /// <summary>
        /// This function returns a particular metadata entry in the
        /// given namespace @namespace_.  The namespace must have
        /// already been loaded before calling this function.
        /// See g_irepository_get_n_infos() to find the maximum number of
        /// entries.
        /// </summary>
        /// <param name="namespace">
        /// Namespace to inspect
        /// </param>
        public IndexedCollection<BaseInfo> GetInfos(UnownedUtf8 @namespace)
        {
            return infos.GetOrAdd(@namespace, (ns) =>
                new IndexedCollection<BaseInfo>(() => GetNInfos(ns), (i) => GetInfo(ns, i))
            );
        }
    }
}
