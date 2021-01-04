// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal']/*" />
    public unsafe partial struct TimeVal
    {
#pragma warning disable CS0169, CS0649
        /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal.TvSec']/*" />
        public readonly GISharp.Runtime.CLong TvSec;

        /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal.TvUsec']/*" />
        public readonly GISharp.Runtime.CLong TvUsec;
#pragma warning restore CS0169, CS0649
        static partial void CheckTryFromIso8601Args(GISharp.Lib.GLib.UnownedUtf8 isoDate);

        /// <summary>
        /// Converts a string containing an ISO 8601 encoded date and time
        /// to a #GTimeVal and puts it into @time_.
        /// </summary>
        /// <remarks>
        /// @iso_date must include year, month, day, hours, minutes, and
        /// seconds. It can optionally include fractions of a second and a time
        /// zone indicator. (In the absence of any time zone indication, the
        /// timestamp is assumed to be in local time.)
        /// 
        /// Any leading or trailing space in @iso_date is ignored.
        /// 
        /// This function was deprecated, along with #GTimeVal itself, in GLib 2.62.
        /// Equivalent functionality is available using code like:
        /// |[
        /// GDateTime *dt = g_date_time_new_from_iso8601 (iso8601_string, NULL);
        /// gint64 time_val = g_date_time_to_unix (dt);
        /// g_date_time_unref (dt);
        /// ]|
        /// </remarks>
        /// <param name="isoDate">
        /// an ISO 8601 encoded date string
        /// </param>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// %TRUE if the conversion was successful.
        /// </returns>
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use\n   g_date_time_new_from_iso8601() instead.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe GISharp.Runtime.Boolean g_time_val_from_iso8601(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr isoDate,
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        out GISharp.Lib.GLib.TimeVal time);

        /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal.TryFromIso8601(GISharp.Lib.GLib.UnownedUtf8,GISharp.Lib.GLib.TimeVal)']/*" />
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use\n   g_date_time_new_from_iso8601() instead.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        [GISharp.Runtime.SinceAttribute("2.12")]
        public static unsafe System.Boolean TryFromIso8601(GISharp.Lib.GLib.UnownedUtf8 isoDate, out GISharp.Lib.GLib.TimeVal time)
        {
            CheckTryFromIso8601Args(isoDate);
            var isoDate_ = isoDate.Handle;
            var ret_ = g_time_val_from_iso8601(isoDate_,out var time_);
            time = (GISharp.Lib.GLib.TimeVal)time_;
            var ret = GISharp.Runtime.BooleanExtensions.IsTrue(ret_);
            return ret;
        }

        /// <summary>
        /// Adds the given number of microseconds to @time_. @microseconds can
        /// also be negative to decrease the value of @time_.
        /// </summary>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <param name="microseconds">
        /// number of microseconds to add to @time
        /// </param>
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use `guint64` for\n   representing microseconds since the epoch, or use #GDateTime.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        private static extern unsafe void g_time_val_add(
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        in GISharp.Lib.GLib.TimeVal time,
        /* <type name="glong" type="glong" managed-name="GISharp.Runtime.CLong" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.CLong microseconds);
        static partial void CheckAddArgs(GISharp.Runtime.CLong microseconds);

        /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal.Add(GISharp.Runtime.CLong)']/*" />
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use `guint64` for\n   representing microseconds since the epoch, or use #GDateTime.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        public unsafe void Add(GISharp.Runtime.CLong microseconds)
        {
            CheckAddArgs(microseconds);
            ref var time_ = ref this;
            var microseconds_ = (GISharp.Runtime.CLong)microseconds;
            g_time_val_add(time_, microseconds_);
        }

        /// <summary>
        /// Converts @time_ into an RFC 3339 encoded string, relative to the
        /// Coordinated Universal Time (UTC). This is one of the many formats
        /// allowed by ISO 8601.
        /// </summary>
        /// <remarks>
        /// ISO 8601 allows a large number of date/time formats, with or without
        /// punctuation and optional elements. The format returned by this function
        /// is a complete date and time, with optional punctuation included, the
        /// UTC time zone represented as "Z", and the @tv_usec part included if
        /// and only if it is nonzero, i.e. either
        /// "YYYY-MM-DDTHH:MM:SSZ" or "YYYY-MM-DDTHH:MM:SS.fffffZ".
        /// 
        /// This corresponds to the Internet date/time format defined by
        /// [RFC 3339](https://www.ietf.org/rfc/rfc3339.txt),
        /// and to either of the two most-precise formats defined by
        /// the W3C Note
        /// [Date and Time Formats](http://www.w3.org/TR/NOTE-datetime-19980827).
        /// Both of these documents are profiles of ISO 8601.
        /// 
        /// Use g_date_time_format() or g_strdup_printf() if a different
        /// variation of ISO 8601 format is required.
        /// 
        /// If @time_ represents a date which is too large to fit into a `struct tm`,
        /// %NULL will be returned. This is platform dependent. Note also that since
        /// `GTimeVal` stores the number of seconds as a `glong`, on 32-bit systems it
        /// is subject to the year 2038 problem. Accordingly, since GLib 2.62, this
        /// function has been deprecated. Equivalent functionality is available using:
        /// |[
        /// GDateTime *dt = g_date_time_new_from_unix_utc (time_val);
        /// iso8601_string = g_date_time_format_iso8601 (dt);
        /// g_date_time_unref (dt);
        /// ]|
        /// 
        /// The return value of g_time_val_to_iso8601() has been nullable since GLib
        /// 2.54; before then, GLib would crash under the same conditions.
        /// </remarks>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a newly allocated string containing an ISO 8601 date,
        ///    or %NULL if @time_ was too large
        /// </returns>
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use\n   g_date_time_format_iso8601(dt) instead.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        private static extern unsafe System.IntPtr g_time_val_to_iso8601(
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        in GISharp.Lib.GLib.TimeVal time);
        static partial void CheckToIso8601Args();

        /// <include file="TimeVal.xmldoc" path="declaration/member[@name='TimeVal.ToIso8601()']/*" />
        [System.ObsoleteAttribute("#GTimeVal is not year-2038-safe. Use\n   g_date_time_format_iso8601(dt) instead.")]
        [GISharp.Runtime.DeprecatedSinceAttribute("2.62")]
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe GISharp.Lib.GLib.Utf8? ToIso8601()
        {
            CheckToIso8601Args();
            ref var time_ = ref this;
            var ret_ = g_time_val_to_iso8601(time_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }
}