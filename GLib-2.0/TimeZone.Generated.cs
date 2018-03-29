namespace GISharp.Lib.GLib
{
    /// <summary>
    /// <see cref="TimeZone"/> is an opaque structure whose members cannot be accessed
    /// directly.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.26")]
    [GISharp.Runtime.GTypeAttribute("GTimeZone", IsProxyForUnmanagedType = true)]
    public sealed partial class TimeZone : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_time_zone_get_type();

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="TimeZone.New"/> with the value of
        /// the `TZ` environment variable (including the possibility of <c>null</c>).
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.TimeZone Local { get => GetLocal(); }

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="TimeZone.New"/> with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.TimeZone Utc { get => GetUtc(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public TimeZone(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to @identifier.
        /// </summary>
        /// <remarks>
        /// @identifier can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including %NULL).
        /// 
        /// In Windows, @identifier can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// g_time_zone_new_local() calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if @identifier is %NULL then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_time_zone_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr identifier);

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to <paramref name="identifier"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="identifier"/> can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including <c>null</c>).
        /// 
        /// In Windows, <paramref name="identifier"/> can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// <see cref="TimeZone.GetLocal"/> calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if <paramref name="identifier"/> is <c>null</c> then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        /// <returns>
        /// the requested timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.Utf8 identifier)
        {
            var identifier_ = identifier?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_time_zone_new(identifier_);
            return ret_;
        }

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to <paramref name="identifier"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="identifier"/> can either be an RFC3339/ISO 8601 time offset or
        /// something that would pass as a valid value for the `TZ` environment
        /// variable (including <c>null</c>).
        /// 
        /// In Windows, <paramref name="identifier"/> can also be the unlocalized name of a time
        /// zone for standard time, for example "Pacific Standard Time".
        /// 
        /// Valid RFC3339 time offsets are `"Z"` (for UTC) or
        /// `"±hh:mm"`.  ISO 8601 additionally specifies
        /// `"±hhmm"` and `"±hh"`.  Offsets are
        /// time values to be added to Coordinated Universal Time (UTC) to get
        /// the local time.
        /// 
        /// In UNIX, the `TZ` environment variable typically corresponds
        /// to the name of a file in the zoneinfo database, or string in
        /// "std offset [dst [offset],start[/time],end[/time]]" (POSIX) format.
        /// There  are  no spaces in the specification. The name of standard
        /// and daylight savings time zone must be three or more alphabetic
        /// characters. Offsets are time values to be added to local time to
        /// get Coordinated Universal Time (UTC) and should be
        /// `"[±]hh[[:]mm[:ss]]"`.  Dates are either
        /// `"Jn"` (Julian day with n between 1 and 365, leap
        /// years not counted), `"n"` (zero-based Julian day
        /// with n between 0 and 365) or `"Mm.w.d"` (day d
        /// (0 &lt;= d &lt;= 6) of week w (1 &lt;= w &lt;= 5) of month m (1 &lt;= m &lt;= 12), day
        /// 0 is a Sunday).  Times are in local wall clock time, the default is
        /// 02:00:00.
        /// 
        /// In Windows, the "tzn[+|–]hh[:mm[:ss]][dzn]" format is used, but also
        /// accepts POSIX format.  The Windows format uses US rules for all time
        /// zones; daylight savings time is 60 minutes behind the standard time
        /// with date and time of change taken from Pacific Standard Time.
        /// Offsets are time values to be added to the local time to get
        /// Coordinated Universal Time (UTC).
        /// 
        /// <see cref="TimeZone.GetLocal"/> calls this function with the value of the
        /// `TZ` environment variable. This function itself is independent of
        /// the value of `TZ`, but if <paramref name="identifier"/> is <c>null</c> then `/etc/localtime`
        /// will be consulted to discover the correct time zone on UNIX and the
        /// registry will be consulted or GetTimeZoneInformation() will be used
        /// to get the local time zone on Windows.
        /// 
        /// If intervals are not available, only time zone rules from `TZ`
        /// environment variable or other means, then they will be computed
        /// from year 1900 to 2037.  If the maximum year for the rules is
        /// available and it is greater than 2037, then it will followed
        /// instead.
        /// 
        /// See
        /// [RFC3339 §5.6](http://tools.ietf.org/html/rfc3339#section-5.6)
        /// for a precise definition of valid RFC3339 time offsets
        /// (the `time-offset` expansion) and ISO 8601 for the
        /// full list of valid time offsets.  See
        /// [The GNU C Library manual](http://www.gnu.org/s/libc/manual/html_node/TZ-Variable.html)
        /// for an explanation of the possible
        /// values of the `TZ` environment variable. See
        /// [Microsoft Time Zone Index Values](http://msdn.microsoft.com/en-us/library/ms912391%28v=winembedded.11%29.aspx)
        /// for the list of time zones on Windows.
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="identifier">
        /// a timezone identifier
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public TimeZone(GISharp.Lib.GLib.Utf8 identifier) : this(New(identifier), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with the value of
        /// the `TZ` environment variable (including the possibility of %NULL).
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_time_zone_new_local();

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to local time.  The local time
        /// zone may change between invocations to this function; for example,
        /// if the system administrator changes it.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="TimeZone.New"/> with the value of
        /// the `TZ` environment variable (including the possibility of <c>null</c>).
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the local timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private static unsafe GISharp.Lib.GLib.TimeZone GetLocal()
        {
            var ret_ = g_time_zone_new_local();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.TimeZone>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GTimeZone corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_time_zone_new() with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling g_time_zone_unref()
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_time_zone_new_utc();

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="TimeZone.New"/> with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling <see cref="TimeZone.Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <returns>
        /// the universal timezone
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private static unsafe GISharp.Lib.GLib.TimeZone GetUtc()
        {
            var ret_ = g_time_zone_new_utc();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.TimeZone>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_time_zone_get_type();

        /// <summary>
        /// Finds an interval within @tz that corresponds to the given @time_,
        /// possibly adjusting @time_ if required to fit into an interval.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// This function is similar to g_time_zone_find_interval(), with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where g_time_zone_find_interval() succeeds then
        /// this function returns the same value, without modifying @time_.
        /// 
        /// This function may, however, modify @time_ in order to deal with
        /// non-existent times.  If the non-existent local @time_ of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust @time_ to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, never -1
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_time_zone_adjust_time(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="TimeType" type="GTimeType" managed-name="TimeType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeType type,
        /* <type name="gint64" type="gint64*" managed-name="System.Int64" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.Int64* time);

        /// <summary>
        /// Finds an interval within <paramref name="tz"/> that corresponds to the given <paramref name="time"/>,
        /// possibly adjusting <paramref name="time"/> if required to fit into an interval.
        /// The meaning of <paramref name="time"/> depends on <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// This function is similar to <see cref="TimeZone.FindInterval"/>, with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where <see cref="TimeZone.FindInterval"/> succeeds then
        /// this function returns the same value, without modifying <paramref name="time"/>.
        /// 
        /// This function may, however, modify <paramref name="time"/> in order to deal with
        /// non-existent times.  If the non-existent local <paramref name="time"/> of 02:30 were
        /// requested on March 14th 2010 in Toronto then this function would
        /// adjust <paramref name="time"/> to be 03:00 and return the interval containing the
        /// adjusted time.
        /// </remarks>
        /// <param name="type">
        /// the <see cref="TimeType"/> of <paramref name="time"/>
        /// </param>
        /// <param name="time">
        /// a pointer to a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing <paramref name="time"/>, never -1
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Int32 AdjustTime(GISharp.Lib.GLib.TimeType type, System.Int64 time)
        {
            var tz_ = Handle;
            var type_ = (GISharp.Lib.GLib.TimeType)type;
            var time_ = (System.Int64)time;
            var ret_ = g_time_zone_adjust_time(tz_,type_,&time_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Finds an the interval within @tz that corresponds to the given @time_.
        /// The meaning of @time_ depends on @type.
        /// </summary>
        /// <remarks>
        /// If @type is %G_TIME_TYPE_UNIVERSAL then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise @time_ is treated as local time.  The distinction between
        /// %G_TIME_TYPE_STANDARD and %G_TIME_TYPE_DAYLIGHT is ignored except in
        /// the case that the given @time_ is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of @type would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="type">
        /// the #GTimeType of @time_
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing @time_, or -1 in case of failure
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_time_zone_find_interval(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="TimeType" type="GTimeType" managed-name="TimeType" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeType type,
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 time);

        /// <summary>
        /// Finds an the interval within <paramref name="tz"/> that corresponds to the given <paramref name="time"/>.
        /// The meaning of <paramref name="time"/> depends on <paramref name="type"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="type"/> is <see cref="TimeType.Universal"/> then this function will always
        /// succeed (since universal time is monotonic and continuous).
        /// 
        /// Otherwise <paramref name="time"/> is treated as local time.  The distinction between
        /// <see cref="TimeType.Standard"/> and <see cref="TimeType.Daylight"/> is ignored except in
        /// the case that the given <paramref name="time"/> is ambiguous.  In Toronto, for example,
        /// 01:30 on November 7th 2010 occurred twice (once inside of daylight
        /// savings time and the next, an hour later, outside of daylight savings
        /// time).  In this case, the different value of <paramref name="type"/> would result in a
        /// different interval being returned.
        /// 
        /// It is still possible for this function to fail.  In Toronto, for
        /// example, 02:00 on March 14th 2010 does not exist (due to the leap
        /// forward to begin daylight savings time).  -1 is returned in that
        /// case.
        /// </remarks>
        /// <param name="type">
        /// the <see cref="TimeType"/> of <paramref name="time"/>
        /// </param>
        /// <param name="time">
        /// a number of seconds since January 1, 1970
        /// </param>
        /// <returns>
        /// the interval containing <paramref name="time"/>, or -1 in case of failure
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Int32 FindInterval(GISharp.Lib.GLib.TimeType type, System.Int64 time)
        {
            var tz_ = Handle;
            var type_ = (GISharp.Lib.GLib.TimeType)type;
            var time_ = (System.Int64)time;
            var ret_ = g_time_zone_find_interval(tz_,type_,time_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to @tz
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_time_zone_get_abbreviation(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 interval);

        /// <summary>
        /// Determines the time zone abbreviation to be used during a particular
        /// <paramref name="interval"/> of time in the time zone <paramref name="tz"/>.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings time
        /// is in effect.
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the time zone abbreviation, which belongs to <paramref name="tz"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.Utf8 GetAbbreviation(System.Int32 interval)
        {
            var tz_ = Handle;
            var interval_ = (System.Int32)interval;
            var ret_ = g_time_zone_get_abbreviation(tz_,interval_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Determines the offset to UTC in effect during a particular @interval
        /// of time in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for @tz (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in @tz
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint32" type="gint32" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_time_zone_get_offset(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 interval);

        /// <summary>
        /// Determines the offset to UTC in effect during a particular <paramref name="interval"/>
        /// of time in the time zone <paramref name="tz"/>.
        /// </summary>
        /// <remarks>
        /// The offset is the number of seconds that you add to UTC time to
        /// arrive at local time for <paramref name="tz"/> (ie: negative numbers for time zones
        /// west of GMT, positive numbers for east).
        /// </remarks>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// the number of seconds that should be added to UTC to get the
        ///          local time in <paramref name="tz"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Int32 GetOffset(System.Int32 interval)
        {
            var tz_ = Handle;
            var interval_ = (System.Int32)interval;
            var ret_ = g_time_zone_get_offset(tz_,interval_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// @interval of time in the time zone @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_time_zone_is_dst(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 interval);

        /// <summary>
        /// Determines if daylight savings time is in effect during a particular
        /// <paramref name="interval"/> of time in the time zone <paramref name="tz"/>.
        /// </summary>
        /// <param name="interval">
        /// an interval within the timezone
        /// </param>
        /// <returns>
        /// <c>true</c> if daylight savings time is in effect
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Boolean IsDst(System.Int32 interval)
        {
            var tz_ = Handle;
            var interval_ = (System.Int32)interval;
            var ret_ = g_time_zone_is_dst(tz_,interval_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Increases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new reference to @tz.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_time_zone_ref(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz);
        public override System.IntPtr Take() => g_time_zone_ref(Handle);

        /// <summary>
        /// Decreases the reference count on @tz.
        /// </summary>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_time_zone_unref(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz);
    }
}