using System;
using System.Collections.Generic;
using System.Linq;

namespace GISharp.Core
{
    public sealed class CallbackCache<T1, T2> where T1 : class where T2 : class
    {
        Dictionary<WeakReference<T1>, WeakReference<T2>> cache =
            new Dictionary<WeakReference<T1>, WeakReference<T2>> ();
        object lockObj = new object ();

        public bool TryGet (T1 obj, out T2 other)
        {
            other = default(T2);
            lock (lockObj) {
                foreach (var key in cache.Keys.ToList ()) {
                    T1 target;
                    if (key.TryGetTarget (out target) && cache[key].TryGetTarget (out other)) {
                        if (object.ReferenceEquals (obj, target)) {
                            return true;
                        }
                    } else {
                        cache.Remove (key);
                    }
                }
            }
            return false;
        }

        public bool TryGet (T2 obj, out T1 other)
        {
            other = default(T1);
            lock (lockObj) {
                foreach (var key in cache.Keys.ToList ()) {
                    T2 target;
                    if (key.TryGetTarget (out other) && cache[key].TryGetTarget (out target)) {
                        if (object.ReferenceEquals (obj, target)) {
                            return true;
                        }
                    } else {
                        cache.Remove (key);
                    }
                }
            }
            return false;
        }
    }
}
