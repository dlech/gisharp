namespace GISharp.Lib.GLib
{
    public partial struct TimeSpan
    {
        /// <summary>
        /// Evaluates to a time span of one day.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Day = 86400000000L;

        /// <summary>
        /// Evaluates to a time span of one hour.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Hour = 3600000000L;

        /// <summary>
        /// Evaluates to a time span of one millisecond.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Millisecond = 1000L;

        /// <summary>
        /// Evaluates to a time span of one minute.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Minute = 60000000L;

        /// <summary>
        /// Evaluates to a time span of one second.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public const System.Int64 Second = 1000000L;
    }

    /// <summary>
    /// `GDateTime` is an opaque structure whose members
    /// cannot be accessed directly.
    /// </summary>
    [GISharp.Runtime.SinceAttribute("2.26")]
    [GISharp.Runtime.GTypeAttribute("GDateTime", IsProxyForUnmanagedType = true)]
    public sealed partial class DateTime : GISharp.Lib.GObject.Boxed, System.IEquatable<DateTime>
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_date_time_get_type();

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetNow"/> with the time
        /// zone returned by <see cref="GetLocal"/>.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.DateTime NowLocal { get => GetNowLocal(); }

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetNow"/> with the time
        /// zone returned by <see cref="GetUtc"/>.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.DateTime NowUtc { get => GetNowUtc(); }

        /// <summary>
        /// Retrieves the day of the month represented by <paramref name="datetime"/> in the gregorian
        /// calendar.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 DayOfMonth { get => GetDayOfMonth(); }

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which <paramref name="datetime"/> falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 DayOfWeek { get => GetDayOfWeek(); }

        /// <summary>
        /// Retrieves the day of the year represented by <paramref name="datetime"/> in the Gregorian
        /// calendar.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 DayOfYear { get => GetDayOfYear(); }

        /// <summary>
        /// Retrieves the hour of the day represented by <paramref name="datetime"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Hour { get => GetHour(); }

        /// <summary>
        /// Retrieves the microsecond of the date represented by <paramref name="datetime"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Microsecond { get => GetMicrosecond(); }

        /// <summary>
        /// Retrieves the minute of the hour represented by <paramref name="datetime"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Minute { get => GetMinute(); }

        /// <summary>
        /// Retrieves the month of the year represented by <paramref name="datetime"/> in the Gregorian
        /// calendar.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Month { get => GetMonth(); }

        /// <summary>
        /// Retrieves the second of the minute represented by <paramref name="datetime"/>
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Second { get => GetSecond(); }

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Double Seconds { get => GetSeconds(); }

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of <paramref name="datetime"/>.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GLib.Utf8 TimezoneAbbreviation { get => GetTimezoneAbbreviation(); }

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of <paramref name="datetime"/>.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If <paramref name="datetime"/> represents UTC time, then the offset is always zero.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GLib.TimeSpan UtcOffset { get => GetUtcOffset(); }

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// <paramref name="datetime"/> falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with <see cref="GetWeekOfYear"/> and
        /// <see cref="GetDayOfWeek"/> can be used to determine the full ISO
        /// week date on which <paramref name="datetime"/> falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// <see cref="GetYear"/>), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 WeekNumberingYear { get => GetWeekNumberingYear(); }

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing <paramref name="datetime"/>.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 WeekOfYear { get => GetWeekOfYear(); }

        /// <summary>
        /// Retrieves the year represented by <paramref name="datetime"/> in the Gregorian calendar.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Int32 Year { get => GetYear(); }

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of <paramref name="datetime"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public System.Boolean IsDaylightSavings { get => GetIsDaylightSavings(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DateTime(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the time zone @tz.
        /// </summary>
        /// <remarks>
        /// The @year must be between 1 and 9999, @month between 1 and 12 and @day
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// @hour must be between 0 and 23 and @minute must be between 0 and 59.
        /// 
        /// @seconds must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return %NULL.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 year,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 month,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 day,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 hour,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 minute,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double seconds);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the given date and time in
        /// the time zone <paramref name="tz"/>.
        /// </summary>
        /// <remarks>
        /// The <paramref name="year"/> must be between 1 and 9999, <paramref name="month"/> between 1 and 12 and <paramref name="day"/>
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// <paramref name="hour"/> must be between 0 and 23 and <paramref name="minute"/> must be between 0 and 59.
        /// 
        /// <paramref name="seconds"/> must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return <c>null</c>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a <see cref="TimeZone"/>
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.TimeZone tz, System.Int32 year, System.Int32 month, System.Int32 day, System.Int32 hour, System.Int32 minute, System.Double seconds)
        {
            AssertNewArgs(tz, year, month, day, hour, minute, seconds);
            var tz_ = tz?.Handle ?? throw new System.ArgumentNullException(nameof(tz));
            var year_ = (System.Int32)year;
            var month_ = (System.Int32)month;
            var day_ = (System.Int32)day;
            var hour_ = (System.Int32)hour;
            var minute_ = (System.Int32)minute;
            var seconds_ = (System.Double)seconds;
            var ret_ = g_date_time_new(tz_,year_,month_,day_,hour_,minute_,seconds_);
            return ret_;
        }

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the given date and time in
        /// the time zone <paramref name="tz"/>.
        /// </summary>
        /// <remarks>
        /// The <paramref name="year"/> must be between 1 and 9999, <paramref name="month"/> between 1 and 12 and <paramref name="day"/>
        /// between 1 and 28, 29, 30 or 31 depending on the month and the year.
        /// 
        /// <paramref name="hour"/> must be between 0 and 23 and <paramref name="minute"/> must be between 0 and 59.
        /// 
        /// <paramref name="seconds"/> must be at least 0.0 and must be strictly less than 60.0.
        /// It will be rounded down to the nearest microsecond.
        /// 
        /// If the given time is not representable in the given time zone (for
        /// example, 02:30 on March 14th 2010 in Toronto, due to daylight savings
        /// time) then the time will be rounded up to the nearest existing time
        /// (in this case, 03:00).  If this matters to you then you should verify
        /// the return value for containing the same as the numbers you gave.
        /// 
        /// In the case that the given time is ambiguous in the given time zone
        /// (for example, 01:30 on November 7th 2010 in Toronto, due to daylight
        /// savings time) then the time falling within standard (ie:
        /// non-daylight) time is taken.
        /// 
        /// It not considered a programmer error for the values to this function
        /// to be out of range, but in the case that they are, the function will
        /// return <c>null</c>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a <see cref="TimeZone"/>
        /// </param>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public DateTime(GISharp.Lib.GLib.TimeZone tz, System.Int32 year, System.Int32 month, System.Int32 day, System.Int32 hour, System.Int32 minute, System.Double seconds) : this(New(tz, year, month, day, hour, minute, seconds), GISharp.Runtime.Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given
        /// [ISO 8601 formatted string](https://en.wikipedia.org/wiki/ISO_8601)
        /// @text. ISO 8601 strings of the form &lt;date&gt;&lt;sep&gt;&lt;time&gt;&lt;tz&gt; are supported.
        /// </summary>
        /// <remarks>
        /// &lt;sep&gt; is the separator and can be either 'T', 't' or ' '.
        /// 
        /// &lt;date&gt; is in the form:
        /// 
        /// - `YYYY-MM-DD` - Year/month/day, e.g. 2016-08-24.
        /// - `YYYYMMDD` - Same as above without dividers.
        /// - `YYYY-DDD` - Ordinal day where DDD is from 001 to 366, e.g. 2016-237.
        /// - `YYYYDDD` - Same as above without dividers.
        /// - `YYYY-Www-D` - Week day where ww is from 01 to 52 and D from 1-7,
        ///   e.g. 2016-W34-3.
        /// - `YYYYWwwD` - Same as above without dividers.
        /// 
        /// &lt;time&gt; is in the form:
        /// 
        /// - `hh:mm:ss(.sss)` - Hours, minutes, seconds (subseconds), e.g. 22:10:42.123.
        /// - `hhmmss(.sss)` - Same as above without dividers.
        /// 
        /// &lt;tz&gt; is an optional timezone suffix of the form:
        /// 
        /// - `Z` - UTC.
        /// - `+hh:mm` or `-hh:mm` - Offset from UTC in hours and minutes, e.g. +12:00.
        /// - `+hh` or `-hh` - Offset from UTC in hours, e.g. +12.
        /// 
        /// If the timezone is not provided in @text it must be provided in @default_tz
        /// (this field is otherwise ignored).
        /// 
        /// This call can fail (returning %NULL) if @text is not a valid ISO 8601
        /// formatted string.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="text">
        /// an ISO 8601 formatted time string.
        /// </param>
        /// <param name="defaultTz">
        /// a #GTimeZone to use if the text doesn't contain a
        ///                          timezone, or %NULL.
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.56")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_date_time_new_from_iso8601(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr text,
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr defaultTz);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to the given
        /// [ISO 8601 formatted string](https://en.wikipedia.org/wiki/ISO_8601)
        /// <paramref name="text"/>. ISO 8601 strings of the form &lt;date&gt;&lt;sep&gt;&lt;time&gt;&lt;tz&gt; are supported.
        /// </summary>
        /// <remarks>
        /// &lt;sep&gt; is the separator and can be either 'T', 't' or ' '.
        /// 
        /// &lt;date&gt; is in the form:
        /// 
        /// - `YYYY-MM-DD` - Year/month/day, e.g. 2016-08-24.
        /// - `YYYYMMDD` - Same as above without dividers.
        /// - `YYYY-DDD` - Ordinal day where DDD is from 001 to 366, e.g. 2016-237.
        /// - `YYYYDDD` - Same as above without dividers.
        /// - `YYYY-Www-D` - Week day where ww is from 01 to 52 and D from 1-7,
        ///   e.g. 2016-W34-3.
        /// - `YYYYWwwD` - Same as above without dividers.
        /// 
        /// &lt;time&gt; is in the form:
        /// 
        /// - `hh:mm:ss(.sss)` - Hours, minutes, seconds (subseconds), e.g. 22:10:42.123.
        /// - `hhmmss(.sss)` - Same as above without dividers.
        /// 
        /// &lt;tz&gt; is an optional timezone suffix of the form:
        /// 
        /// - `Z` - UTC.
        /// - `+hh:mm` or `-hh:mm` - Offset from UTC in hours and minutes, e.g. +12:00.
        /// - `+hh` or `-hh` - Offset from UTC in hours, e.g. +12.
        /// 
        /// If the timezone is not provided in <paramref name="text"/> it must be provided in <paramref name="defaultTz"/>
        /// (this field is otherwise ignored).
        /// 
        /// This call can fail (returning <c>null</c>) if <paramref name="text"/> is not a valid ISO 8601
        /// formatted string.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="text">
        /// an ISO 8601 formatted time string.
        /// </param>
        /// <param name="defaultTz">
        /// a <see cref="TimeZone"/> to use if the text doesn't contain a
        ///                          timezone, or <c>null</c>.
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.56")]
        public static unsafe GISharp.Lib.GLib.DateTime FromIso8601(GISharp.Lib.GLib.Utf8 text, GISharp.Lib.GLib.TimeZone defaultTz)
        {
            var text_ = text?.Handle ?? throw new System.ArgumentNullException(nameof(text));
            var defaultTz_ = defaultTz?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_date_time_new_from_iso8601(text_,defaultTz_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the
        /// local time offset.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_from_timeval_local(
        /* <type name="TimeVal" type="const GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* tv);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to the given <see cref="TimeVal"/> <paramref name="tv"/> in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// The time contained in a <see cref="TimeVal"/> is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the
        /// local time offset.
        /// 
        /// This call can fail (returning <c>null</c>) if <paramref name="tv"/> represents a time outside
        /// of the supported range of <see cref="DateTime"/>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a <see cref="TimeVal"/>
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime FromTimevalLocal(GISharp.Lib.GLib.TimeVal tv)
        {
            var tv_ = (GISharp.Lib.GLib.TimeVal)tv;
            var ret_ = g_date_time_new_from_timeval_local(&tv_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given #GTimeVal @tv in UTC.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @tv represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_from_timeval_utc(
        /* <type name="TimeVal" type="const GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* tv);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to the given <see cref="TimeVal"/> <paramref name="tv"/> in UTC.
        /// </summary>
        /// <remarks>
        /// The time contained in a <see cref="TimeVal"/> is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC.
        /// 
        /// This call can fail (returning <c>null</c>) if <paramref name="tv"/> represents a time outside
        /// of the supported range of <see cref="DateTime"/>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tv">
        /// a <see cref="TimeVal"/>
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime FromTimevalUtc(GISharp.Lib.GLib.TimeVal tv)
        {
            var tv_ = (GISharp.Lib.GLib.TimeVal)tv;
            var ret_ = g_date_time_new_from_timeval_utc(&tv_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_from_unix_local(
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 t);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to the given Unix time <paramref name="t"/> in the
        /// local time zone.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the local time offset.
        /// 
        /// This call can fail (returning <c>null</c>) if <paramref name="t"/> represents a time outside
        /// of the supported range of <see cref="DateTime"/>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime FromUnixLocal(System.Int64 t)
        {
            var t_ = (System.Int64)t;
            var ret_ = g_date_time_new_from_unix_local(t_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to the given Unix time @t in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning %NULL) if @t represents a time outside
        /// of the supported range of #GDateTime.
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_from_unix_utc(
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 t);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to the given Unix time <paramref name="t"/> in UTC.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC.
        /// 
        /// This call can fail (returning <c>null</c>) if <paramref name="t"/> represents a time outside
        /// of the supported range of <see cref="DateTime"/>.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="t">
        /// the Unix time
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime FromUnixUtc(System.Int64 t)
        {
            var t_ = (System.Int64)t;
            var ret_ = g_date_time_new_from_unix_utc(t_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_local(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 year,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 month,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 day,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 hour,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 minute,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double seconds);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the given date and time in
        /// the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling <see cref="New"/> with the time
        /// zone returned by <see cref="GetLocal"/>.
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime GetLocal(System.Int32 year, System.Int32 month, System.Int32 day, System.Int32 hour, System.Int32 minute, System.Double seconds)
        {
            AssertGetLocalArgs(year, month, day, hour, minute, seconds);
            var year_ = (System.Int32)year;
            var month_ = (System.Int32)month;
            var day_ = (System.Int32)day;
            var hour_ = (System.Int32)hour;
            var minute_ = (System.Int32)minute;
            var seconds_ = (System.Double)seconds;
            var ret_ = g_date_time_new_local(year_,month_,day_,hour_,minute_,seconds_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the given
        /// time zone @tz.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_now(
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz);

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in the given
        /// time zone <paramref name="tz"/>.  The time is as accurate as the system allows, to a
        /// maximum accuracy of 1 microsecond.
        /// </summary>
        /// <remarks>
        /// This function will always succeed unless the system clock is set to
        /// truly insane values (or unless GLib is still being used after the
        /// year 9999).
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// a <see cref="TimeZone"/>
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime GetNow(GISharp.Lib.GLib.TimeZone tz)
        {
            var tz_ = tz?.Handle ?? throw new System.ArgumentNullException(nameof(tz));
            var ret_ = g_date_time_new_now(tz_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_now_local();

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in the local
        /// time zone.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetNow"/> with the time
        /// zone returned by <see cref="GetLocal"/>.
        /// </remarks>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private static unsafe GISharp.Lib.GLib.DateTime GetNowLocal()
        {
            var ret_ = g_date_time_new_now_local();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a #GDateTime corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling g_date_time_new_now() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_now_utc();

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="GetNow"/> with the time
        /// zone returned by <see cref="GetUtc"/>.
        /// </remarks>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private static unsafe GISharp.Lib.GLib.DateTime GetNowUtc()
        {
            var ret_ = g_date_time_new_now_utc();
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_new() with the time
        /// zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_new_utc(
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 year,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 month,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 day,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 hour,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 minute,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double seconds);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the given date and time in
        /// UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling <see cref="New"/> with the time
        /// zone returned by <see cref="GetUtc"/>.
        /// </remarks>
        /// <param name="year">
        /// the year component of the date
        /// </param>
        /// <param name="month">
        /// the month component of the date
        /// </param>
        /// <param name="day">
        /// the day component of the date
        /// </param>
        /// <param name="hour">
        /// the hour component of the date
        /// </param>
        /// <param name="minute">
        /// the minute component of the date
        /// </param>
        /// <param name="seconds">
        /// the number of seconds past the minute
        /// </param>
        /// <returns>
        /// a <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe GISharp.Lib.GLib.DateTime GetUtc(System.Int32 year, System.Int32 month, System.Int32 day, System.Int32 hour, System.Int32 minute, System.Double seconds)
        {
            AssertGetUtcArgs(year, month, day, hour, minute, seconds);
            var year_ = (System.Int32)year;
            var month_ = (System.Int32)month;
            var day_ = (System.Int32)day;
            var hour_ = (System.Int32)hour;
            var minute_ = (System.Int32)minute;
            var seconds_ = (System.Double)seconds;
            var ret_ = g_date_time_new_utc(year_,month_,day_,hour_,minute_,seconds_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-%NULL.
        /// </summary>
        /// <param name="dt1">
        /// first #GDateTime to compare
        /// </param>
        /// <param name="dt2">
        /// second #GDateTime to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if @dt1 is less than, equal to or greater
        ///   than @dt2.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_compare(
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dt1,
        /* <type name="gpointer" type="gconstpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dt2);

        /// <summary>
        /// A comparison function for #GDateTimes that is suitable
        /// as a #GCompareFunc. Both #GDateTimes must be non-<c>null</c>.
        /// </summary>
        /// <param name="dt1">
        /// first <see cref="DateTime"/> to compare
        /// </param>
        /// <param name="dt2">
        /// second <see cref="DateTime"/> to compare
        /// </param>
        /// <returns>
        /// -1, 0 or 1 if <paramref name="dt1"/> is less than, equal to or greater
        ///   than <paramref name="dt2"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static unsafe System.Int32 Compare(System.IntPtr dt1, System.IntPtr dt2)
        {
            var dt1_ = (System.IntPtr)dt1;
            var dt2_ = (System.IntPtr)dt2;
            var ret_ = g_date_time_compare(dt1_,dt2_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_date_time_get_type();

        /// <summary>
        /// Creates a copy of @datetime and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="timespan">
        /// a #GTimeSpan
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="TimeSpan" type="GTimeSpan" managed-name="TimeSpan" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeSpan timespan);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified timespan to the copy.
        /// </summary>
        /// <param name="timespan">
        /// a <see cref="TimeSpan"/>
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime Add(GISharp.Lib.GLib.TimeSpan timespan)
        {
            var datetime_ = Handle;
            var timespan_ = (GISharp.Lib.GLib.TimeSpan)timespan;
            var ret_ = g_date_time_add(datetime_,timespan_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_days(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 days);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of days to the
        /// copy. Add negative values to subtract days.
        /// </summary>
        /// <param name="days">
        /// the number of days
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddDays(System.Int32 days)
        {
            var datetime_ = Handle;
            var days_ = (System.Int32)days;
            var ret_ = g_date_time_add_days(datetime_,days_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a new #GDateTime adding the specified values to the current date and
        /// time in @datetime. Add negative values to subtract.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime that should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_full(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 years,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 months,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 days,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 hours,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 minutes,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double seconds);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> adding the specified values to the current date and
        /// time in <paramref name="datetime"/>. Add negative values to subtract.
        /// </summary>
        /// <param name="years">
        /// the number of years to add
        /// </param>
        /// <param name="months">
        /// the number of months to add
        /// </param>
        /// <param name="days">
        /// the number of days to add
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> that should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddFull(System.Int32 years, System.Int32 months, System.Int32 days, System.Int32 hours, System.Int32 minutes, System.Double seconds)
        {
            var datetime_ = Handle;
            var years_ = (System.Int32)years;
            var months_ = (System.Int32)months;
            var days_ = (System.Int32)days;
            var hours_ = (System.Int32)hours;
            var minutes_ = (System.Int32)minutes;
            var seconds_ = (System.Double)seconds;
            var ret_ = g_date_time_add_full(datetime_,years_,months_,days_,hours_,minutes_,seconds_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_hours(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 hours);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of hours.
        /// Add negative values to subtract hours.
        /// </summary>
        /// <param name="hours">
        /// the number of hours to add
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddHours(System.Int32 hours)
        {
            var datetime_ = Handle;
            var hours_ = (System.Int32)hours;
            var ret_ = g_date_time_add_hours(datetime_,hours_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_minutes(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 minutes);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> adding the specified number of minutes.
        /// Add negative values to subtract minutes.
        /// </summary>
        /// <param name="minutes">
        /// the number of minutes to add
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddMinutes(System.Int32 minutes)
        {
            var datetime_ = Handle;
            var minutes_ = (System.Int32)minutes;
            var ret_ = g_date_time_add_minutes(datetime_,minutes_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <remarks>
        /// The day of the month of the resulting #GDateTime is clamped to the number
        /// of days in the updated calendar month. For example, if adding 1 month to
        /// 31st January 2018, the result would be 28th February 2018. In 2020 (a leap
        /// year), the result would be 29th February.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_months(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 months);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of months to the
        /// copy. Add negative values to subtract months.
        /// </summary>
        /// <remarks>
        /// The day of the month of the resulting <see cref="DateTime"/> is clamped to the number
        /// of days in the updated calendar month. For example, if adding 1 month to
        /// 31st January 2018, the result would be 28th February 2018. In 2020 (a leap
        /// year), the result would be 29th February.
        /// </remarks>
        /// <param name="months">
        /// the number of months
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddMonths(System.Int32 months)
        {
            var datetime_ = Handle;
            var months_ = (System.Int32)months;
            var ret_ = g_date_time_add_months(datetime_,months_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_seconds(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double seconds);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of seconds.
        /// Add negative values to subtract seconds.
        /// </summary>
        /// <param name="seconds">
        /// the number of seconds to add
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddSeconds(System.Double seconds)
        {
            var datetime_ = Handle;
            var seconds_ = (System.Double)seconds;
            var ret_ = g_date_time_add_seconds(datetime_,seconds_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_weeks(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 weeks);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of weeks to the
        /// copy. Add negative values to subtract weeks.
        /// </summary>
        /// <param name="weeks">
        /// the number of weeks
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddWeeks(System.Int32 weeks)
        {
            var datetime_ = Handle;
            var weeks_ = (System.Int32)weeks;
            var ret_ = g_date_time_add_weeks(datetime_,weeks_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Creates a copy of @datetime and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <remarks>
        /// As with g_date_time_add_months(), if the resulting date would be 29th
        /// February on a non-leap year, the day will be clamped to 28th February.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created #GDateTime which should be freed with
        ///   g_date_time_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_add_years(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 years);

        /// <summary>
        /// Creates a copy of <paramref name="datetime"/> and adds the specified number of years to the
        /// copy. Add negative values to subtract years.
        /// </summary>
        /// <remarks>
        /// As with <see cref="AddMonths"/>, if the resulting date would be 29th
        /// February on a non-leap year, the day will be clamped to 28th February.
        /// </remarks>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="Unref"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime AddYears(System.Int32 years)
        {
            var datetime_ = Handle;
            var years_ = (System.Int32)years;
            var ret_ = g_date_time_add_years(datetime_,years_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Calculates the difference in time between @end and @begin.  The
        /// #GTimeSpan that is returned is effectively @end - @begin (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="end">
        /// a #GDateTime
        /// </param>
        /// <param name="begin">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the difference between the two #GDateTime, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeSpan" type="GTimeSpan" managed-name="TimeSpan" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.TimeSpan g_date_time_difference(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr end,
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr begin);

        /// <summary>
        /// Calculates the difference in time between <paramref name="end"/> and <paramref name="begin"/>.  The
        /// <see cref="TimeSpan"/> that is returned is effectively <paramref name="end"/> - <paramref name="begin"/> (ie:
        /// positive if the first parameter is larger).
        /// </summary>
        /// <param name="begin">
        /// a <see cref="DateTime"/>
        /// </param>
        /// <returns>
        /// the difference between the two <see cref="DateTime"/>, as a time
        ///   span expressed in microseconds.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.TimeSpan Difference(GISharp.Lib.GLib.DateTime begin)
        {
            var end_ = Handle;
            var begin_ = begin?.Handle ?? throw new System.ArgumentNullException(nameof(begin));
            var ret_ = g_date_time_difference(end_,begin_);
            var ret = (GISharp.Lib.GLib.TimeSpan)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a newly allocated string representing the requested @format.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the preferred date and time representation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See g_date_time_get_week_of_year().
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// 
        /// Additionally, when O is used with B, b, or h, it produces the alternative
        /// form of a month name. The alternative form should be used when the month
        /// name is used without a day number (e.g., standalone). It is required in
        /// some languages (Baltic, Slavic, Greek, and more) due to their grammatical
        /// rules. For other languages there is no difference. \%OB is a GNU and BSD
        /// strftime() extension expected to be added to the future POSIX specification,
        /// \%Ob and \%Oh are GNU strftime() extensions. Since: 2.56
        /// </remarks>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          #GDateTime
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or %NULL in the case that there was an error (such as a format specifier
        ///     not being supported in the current locale). The string
        ///     should be freed with g_free().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_format(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr format);

        /// <summary>
        /// Creates a newly allocated string representing the requested <paramref name="format"/>.
        /// </summary>
        /// <remarks>
        /// The format strings understood by this function are a subset of the
        /// strftime() format language as specified by C99.  The \%D, \%U and \%W
        /// conversions are not supported, nor is the 'E' modifier.  The GNU
        /// extensions \%k, \%l, \%s and \%P are supported, however, as are the
        /// '0', '_' and '-' modifiers.
        /// 
        /// In contrast to strftime(), this function always produces a UTF-8
        /// string, regardless of the current locale.  Note that the rendering of
        /// many formats is locale-dependent and may not match the strftime()
        /// output exactly.
        /// 
        /// The following format specifiers are supported:
        /// 
        /// - \%a: the abbreviated weekday name according to the current locale
        /// - \%A: the full weekday name according to the current locale
        /// - \%b: the abbreviated month name according to the current locale
        /// - \%B: the full month name according to the current locale
        /// - \%c: the preferred date and time representation for the current locale
        /// - \%C: the century number (year/100) as a 2-digit integer (00-99)
        /// - \%d: the day of the month as a decimal number (range 01 to 31)
        /// - \%e: the day of the month as a decimal number (range  1 to 31)
        /// - \%F: equivalent to `%Y-%m-%d` (the ISO 8601 date format)
        /// - \%g: the last two digits of the ISO 8601 week-based year as a
        ///   decimal number (00-99). This works well with \%V and \%u.
        /// - \%G: the ISO 8601 week-based year as a decimal number. This works
        ///   well with \%V and \%u.
        /// - \%h: equivalent to \%b
        /// - \%H: the hour as a decimal number using a 24-hour clock (range 00 to 23)
        /// - \%I: the hour as a decimal number using a 12-hour clock (range 01 to 12)
        /// - \%j: the day of the year as a decimal number (range 001 to 366)
        /// - \%k: the hour (24-hour clock) as a decimal number (range 0 to 23);
        ///   single digits are preceded by a blank
        /// - \%l: the hour (12-hour clock) as a decimal number (range 1 to 12);
        ///   single digits are preceded by a blank
        /// - \%m: the month as a decimal number (range 01 to 12)
        /// - \%M: the minute as a decimal number (range 00 to 59)
        /// - \%p: either "AM" or "PM" according to the given time value, or the
        ///   corresponding  strings for the current locale.  Noon is treated as
        ///   "PM" and midnight as "AM".
        /// - \%P: like \%p but lowercase: "am" or "pm" or a corresponding string for
        ///   the current locale
        /// - \%r: the time in a.m. or p.m. notation
        /// - \%R: the time in 24-hour notation (\%H:\%M)
        /// - \%s: the number of seconds since the Epoch, that is, since 1970-01-01
        ///   00:00:00 UTC
        /// - \%S: the second as a decimal number (range 00 to 60)
        /// - \%t: a tab character
        /// - \%T: the time in 24-hour notation with seconds (\%H:\%M:\%S)
        /// - \%u: the ISO 8601 standard day of the week as a decimal, range 1 to 7,
        ///    Monday being 1. This works well with \%G and \%V.
        /// - \%V: the ISO 8601 standard week number of the current year as a decimal
        ///   number, range 01 to 53, where week 1 is the first week that has at
        ///   least 4 days in the new year. See <see cref="GetWeekOfYear"/>.
        ///   This works well with \%G and \%u.
        /// - \%w: the day of the week as a decimal, range 0 to 6, Sunday being 0.
        ///   This is not the ISO 8601 standard format -- use \%u instead.
        /// - \%x: the preferred date representation for the current locale without
        ///   the time
        /// - \%X: the preferred time representation for the current locale without
        ///   the date
        /// - \%y: the year as a decimal number without the century
        /// - \%Y: the year as a decimal number including the century
        /// - \%z: the time zone as an offset from UTC (+hhmm)
        /// - \%:z: the time zone as an offset from UTC (+hh:mm).
        ///   This is a gnulib strftime() extension. Since: 2.38
        /// - \%::z: the time zone as an offset from UTC (+hh:mm:ss). This is a
        ///   gnulib strftime() extension. Since: 2.38
        /// - \%:::z: the time zone as an offset from UTC, with : to necessary
        ///   precision (e.g., -04, +05:30). This is a gnulib strftime() extension. Since: 2.38
        /// - \%Z: the time zone or name or abbreviation
        /// - \%\%: a literal \% character
        /// 
        /// Some conversion specifications can be modified by preceding the
        /// conversion specifier by one or more modifier characters. The
        /// following modifiers are supported for many of the numeric
        /// conversions:
        /// 
        /// - O: Use alternative numeric symbols, if the current locale supports those.
        /// - _: Pad a numeric result with spaces. This overrides the default padding
        ///   for the specifier.
        /// - -: Do not pad a numeric result. This overrides the default padding
        ///   for the specifier.
        /// - 0: Pad a numeric result with zeros. This overrides the default padding
        ///   for the specifier.
        /// 
        /// Additionally, when O is used with B, b, or h, it produces the alternative
        /// form of a month name. The alternative form should be used when the month
        /// name is used without a day number (e.g., standalone). It is required in
        /// some languages (Baltic, Slavic, Greek, and more) due to their grammatical
        /// rules. For other languages there is no difference. \%OB is a GNU and BSD
        /// strftime() extension expected to be added to the future POSIX specification,
        /// \%Ob and \%Oh are GNU strftime() extensions. Since: 2.56
        /// </remarks>
        /// <param name="format">
        /// a valid UTF-8 string, containing the format for the
        ///          <see cref="DateTime"/>
        /// </param>
        /// <returns>
        /// a newly allocated string formatted to the requested format
        ///     or <c>null</c> in the case that there was an error (such as a format specifier
        ///     not being supported in the current locale). The string
        ///     should be freed with g_free().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.Utf8 Format(GISharp.Lib.GLib.Utf8 format)
        {
            var datetime_ = Handle;
            var format_ = format?.Handle ?? throw new System.ArgumentNullException(nameof(format));
            var ret_ = g_date_time_format(datetime_,format_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Retrieves the day of the month represented by @datetime in the gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the month
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_day_of_month(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the day of the month represented by <paramref name="datetime"/> in the gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the month
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetDayOfMonth()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_day_of_month(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which @datetime falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the week
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_day_of_week(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the ISO 8601 day of the week on which <paramref name="datetime"/> falls (1 is
        /// Monday, 2 is Tuesday... 7 is Sunday).
        /// </summary>
        /// <returns>
        /// the day of the week
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetDayOfWeek()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_day_of_week(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the day of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the day of the year
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_day_of_year(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the day of the year represented by <paramref name="datetime"/> in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the day of the year
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetDayOfYear()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_day_of_year(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the hour of the day represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_hour(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the hour of the day represented by <paramref name="datetime"/>
        /// </summary>
        /// <returns>
        /// the hour of the day
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetHour()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_hour(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the microsecond of the date represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_microsecond(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the microsecond of the date represented by <paramref name="datetime"/>
        /// </summary>
        /// <returns>
        /// the microsecond of the second
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetMicrosecond()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_microsecond(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the minute of the hour represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_minute(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the minute of the hour represented by <paramref name="datetime"/>
        /// </summary>
        /// <returns>
        /// the minute of the hour
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetMinute()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_minute(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the month of the year represented by @datetime in the Gregorian
        /// calendar.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the month represented by @datetime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_month(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the month of the year represented by <paramref name="datetime"/> in the Gregorian
        /// calendar.
        /// </summary>
        /// <returns>
        /// the month represented by <paramref name="datetime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetMonth()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_month(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the second of the minute represented by @datetime
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the second represented by @datetime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_second(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the second of the minute represented by <paramref name="datetime"/>
        /// </summary>
        /// <returns>
        /// the second represented by <paramref name="datetime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetSecond()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_second(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Double g_date_time_get_seconds(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the number of seconds since the start of the last minute,
        /// including the fractional part.
        /// </summary>
        /// <returns>
        /// the number of seconds
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Double GetSeconds()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_seconds(datetime_);
            var ret = (System.Double)ret_;
            return ret;
        }

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the #GDateTime and it should not be
        ///          modified or freed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_date_time_get_timezone_abbreviation(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Determines the time zone abbreviation to be used at the time and in
        /// the time zone of <paramref name="datetime"/>.
        /// </summary>
        /// <remarks>
        /// For example, in Toronto this is currently "EST" during the winter
        /// months and "EDT" during the summer months when daylight savings
        /// time is in effect.
        /// </remarks>
        /// <returns>
        /// the time zone abbreviation. The returned
        ///          string is owned by the <see cref="DateTime"/> and it should not be
        ///          modified or freed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe GISharp.Lib.GLib.Utf8 GetTimezoneAbbreviation()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_timezone_abbreviation(datetime_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of @datetime.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If @datetime represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="TimeSpan" type="GTimeSpan" managed-name="TimeSpan" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.TimeSpan g_date_time_get_utc_offset(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Determines the offset to UTC in effect at the time and in the time
        /// zone of <paramref name="datetime"/>.
        /// </summary>
        /// <remarks>
        /// The offset is the number of microseconds that you add to UTC time to
        /// arrive at local time for the time zone (ie: negative numbers for time
        /// zones west of GMT, positive numbers for east).
        /// 
        /// If <paramref name="datetime"/> represents UTC time, then the offset is always zero.
        /// </remarks>
        /// <returns>
        /// the number of microseconds that should be added to UTC to
        ///          get the local time
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe GISharp.Lib.GLib.TimeSpan GetUtcOffset()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_utc_offset(datetime_);
            var ret = (GISharp.Lib.GLib.TimeSpan)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// @datetime falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with g_date_time_get_week_of_year() and
        /// g_date_time_get_day_of_week() can be used to determine the full ISO
        /// week date on which @datetime falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// g_date_time_get_year()), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week-numbering year for @datetime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_week_numbering_year(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Returns the ISO 8601 week-numbering year in which the week containing
        /// <paramref name="datetime"/> falls.
        /// </summary>
        /// <remarks>
        /// This function, taken together with <see cref="GetWeekOfYear"/> and
        /// <see cref="GetDayOfWeek"/> can be used to determine the full ISO
        /// week date on which <paramref name="datetime"/> falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// <see cref="GetYear"/>), except as detailed below:
        /// 
        /// For Thursday, the week-numbering year is always equal to the usual
        /// calendar year.  For other days, the number is such that every day
        /// within a complete week (Monday to Sunday) is contained within the
        /// same week-numbering year.
        /// 
        /// For Monday, Tuesday and Wednesday occurring near the end of the year,
        /// this may mean that the week-numbering year is one greater than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring early in the next year).
        /// 
        /// For Friday, Saturday and Sunday occurring near the start of the year,
        /// this may mean that the week-numbering year is one less than the
        /// calendar year (so that these days have the same week-numbering year
        /// as the Thursday occurring late in the previous year).
        /// 
        /// An equivalent description is that the week-numbering year is equal to
        /// the calendar year containing the majority of the days in the current
        /// week (Monday to Sunday).
        /// 
        /// Note that January 1 0001 in the proleptic Gregorian calendar is a
        /// Monday, so this function never returns 0.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week-numbering year for <paramref name="datetime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetWeekNumberingYear()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_week_numbering_year(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing @datetime.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the ISO 8601 week number for @datetime.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_week_of_year(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Returns the ISO 8601 week number for the week containing <paramref name="datetime"/>.
        /// The ISO 8601 week number is the same for every day of the week (from
        /// Moday through Sunday).  That can produce some unusual results
        /// (described below).
        /// </summary>
        /// <remarks>
        /// The first week of the year is week 1.  This is the week that contains
        /// the first Thursday of the year.  Equivalently, this is the first week
        /// that has more than 4 of its days falling within the calendar year.
        /// 
        /// The value 0 is never returned by this function.  Days contained
        /// within a year but occurring before the first ISO 8601 week of that
        /// year are considered as being contained in the last week of the
        /// previous year.  Similarly, the final days of a calendar year may be
        /// considered as being part of the first ISO 8601 week of the next year
        /// if 4 or more days of that week are contained within the new year.
        /// </remarks>
        /// <returns>
        /// the ISO 8601 week number for <paramref name="datetime"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetWeekOfYear()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_week_of_year(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the year represented by @datetime in the Gregorian calendar.
        /// </summary>
        /// <param name="datetime">
        /// A #GDateTime
        /// </param>
        /// <returns>
        /// the year represented by @datetime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_date_time_get_year(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Retrieves the year represented by <paramref name="datetime"/> in the Gregorian calendar.
        /// </summary>
        /// <returns>
        /// the year represented by <paramref name="datetime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Int32 GetYear()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_get_year(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given #GDateTime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime.
        /// </param>
        /// <param name="year">
        /// the return location for the gregorian year, or %NULL.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or %NULL.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or %NULL.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_date_time_get_ymd(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="gint" type="gint*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.Int32* year,
        /* <type name="gint" type="gint*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.Int32* month,
        /* <type name="gint" type="gint*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.Int32* day);

        /// <summary>
        /// Retrieves the Gregorian day, month, and year of a given <see cref="DateTime"/>.
        /// </summary>
        /// <param name="year">
        /// the return location for the gregorian year, or <c>null</c>.
        /// </param>
        /// <param name="month">
        /// the return location for the month of the year, or <c>null</c>.
        /// </param>
        /// <param name="day">
        /// the return location for the day of the month, or <c>null</c>.
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe void GetYmd(out System.Int32 year, out System.Int32 month, out System.Int32 day)
        {
            var datetime_ = Handle;
            System.Int32 year_;
            System.Int32 month_;
            System.Int32 day_;
            g_date_time_get_ymd(datetime_, &year_, &month_, &day_);
            year = (System.Int32)year_;
            month = (System.Int32)month_;
            day = (System.Int32)day_;
        }

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of @datetime.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if daylight savings time is in effect
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_date_time_is_daylight_savings(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Determines if daylight savings time is in effect at the time and in
        /// the time zone of <paramref name="datetime"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if daylight savings time is in effect
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        private unsafe System.Boolean GetIsDaylightSavings()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_is_daylight_savings(datetime_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Atomically increments the reference count of @datetime by one.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the #GDateTime with the reference count increased
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_ref(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);
        public override System.IntPtr Take() => g_date_time_ref(Handle);

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_local().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_to_local(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the same instant in time as
        /// <paramref name="datetime"/>, but in the local time zone.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling <see cref="ToTimezone"/> with the
        /// time zone returned by <see cref="GetLocal"/>.
        /// </remarks>
        /// <returns>
        /// the newly created <see cref="DateTime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime ToLocal()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_to_local(datetime_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Stores the instant in time that @datetime represents into @tv.
        /// </summary>
        /// <remarks>
        /// The time contained in a #GTimeVal is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the time
        /// zone associated with @datetime.
        /// 
        /// On systems where 'long' is 32bit (ie: all 32bit systems and all
        /// Windows systems), a #GTimeVal is incapable of storing the entire
        /// range of values that #GDateTime is capable of expressing.  On those
        /// systems, this function returns %FALSE to indicate that the time is
        /// out of range.
        /// 
        /// On systems where 'long' is 64bit, this function never fails.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="tv">
        /// a #GTimeVal to modify
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_date_time_to_timeval(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* tv);

        /// <summary>
        /// Stores the instant in time that <paramref name="datetime"/> represents into <paramref name="tv"/>.
        /// </summary>
        /// <remarks>
        /// The time contained in a <see cref="TimeVal"/> is always stored in the form of
        /// seconds elapsed since 1970-01-01 00:00:00 UTC, regardless of the time
        /// zone associated with <paramref name="datetime"/>.
        /// 
        /// On systems where 'long' is 32bit (ie: all 32bit systems and all
        /// Windows systems), a <see cref="TimeVal"/> is incapable of storing the entire
        /// range of values that <see cref="DateTime"/> is capable of expressing.  On those
        /// systems, this function returns <c>false</c> to indicate that the time is
        /// out of range.
        /// 
        /// On systems where 'long' is 64bit, this function never fails.
        /// </remarks>
        /// <param name="tv">
        /// a <see cref="TimeVal"/> to modify
        /// </param>
        /// <returns>
        /// <c>true</c> if successful, else <c>false</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Boolean ToTimeval(GISharp.Lib.GLib.TimeVal tv)
        {
            var datetime_ = Handle;
            var tv_ = (GISharp.Lib.GLib.TimeVal)tv;
            var ret_ = g_date_time_to_timeval(datetime_,&tv_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Create a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in the time zone @tz.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling g_date_time_unref()
        /// when you are done with it.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <param name="tz">
        /// the new #GTimeZone
        /// </param>
        /// <returns>
        /// a new #GDateTime, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_to_timezone(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime,
        /* <type name="TimeZone" type="GTimeZone*" managed-name="TimeZone" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr tz);

        /// <summary>
        /// Create a new <see cref="DateTime"/> corresponding to the same instant in time as
        /// <paramref name="datetime"/>, but in the time zone <paramref name="tz"/>.
        /// </summary>
        /// <remarks>
        /// This call can fail in the case that the time goes out of bounds.  For
        /// example, converting 0001-01-01 00:00:00 UTC to a time zone west of
        /// Greenwich will fail (due to the year 0 being out of range).
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        /// <param name="tz">
        /// the new <see cref="TimeZone"/>
        /// </param>
        /// <returns>
        /// a new <see cref="DateTime"/>, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime ToTimezone(GISharp.Lib.GLib.TimeZone tz)
        {
            var datetime_ = Handle;
            var tz_ = tz?.Handle ?? throw new System.ArgumentNullException(nameof(tz));
            var ret_ = g_date_time_to_timezone(datetime_,tz_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Gives the Unix time corresponding to @datetime, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with @datetime.
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the Unix time corresponding to @datetime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int64 g_date_time_to_unix(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Gives the Unix time corresponding to <paramref name="datetime"/>, rounding down to the
        /// nearest second.
        /// </summary>
        /// <remarks>
        /// Unix time is the number of seconds that have elapsed since 1970-01-01
        /// 00:00:00 UTC, regardless of the time zone associated with <paramref name="datetime"/>.
        /// </remarks>
        /// <returns>
        /// the Unix time corresponding to <paramref name="datetime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Int64 ToUnix()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_to_unix(datetime_);
            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Creates a new #GDateTime corresponding to the same instant in time as
        /// @datetime, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling g_date_time_to_timezone() with the
        /// time zone returned by g_time_zone_new_utc().
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// the newly created #GDateTime
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_date_time_to_utc(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Creates a new <see cref="DateTime"/> corresponding to the same instant in time as
        /// <paramref name="datetime"/>, but in UTC.
        /// </summary>
        /// <remarks>
        /// This call is equivalent to calling <see cref="ToTimezone"/> with the
        /// time zone returned by <see cref="GetUtc"/>.
        /// </remarks>
        /// <returns>
        /// the newly created <see cref="DateTime"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe GISharp.Lib.GLib.DateTime ToUtc()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_to_utc(datetime_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.DateTime>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Atomically decrements the reference count of @datetime by one.
        /// </summary>
        /// <remarks>
        /// When the reference count reaches zero, the resources allocated by
        /// @datetime are freed
        /// </remarks>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_date_time_unref(
        /* <type name="DateTime" type="GDateTime*" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Checks to see if @dt1 and @dt2 are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt1">
        /// a #GDateTime
        /// </param>
        /// <param name="dt2">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// %TRUE if @dt1 and @dt2 are equal
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_date_time_equal(
        /* <type name="DateTime" type="gconstpointer" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dt1,
        /* <type name="DateTime" type="gconstpointer" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dt2);

        /// <summary>
        /// Checks to see if <paramref name="dt1"/> and <paramref name="dt2"/> are equal.
        /// </summary>
        /// <remarks>
        /// Equal here means that they represent the same moment after converting
        /// them to the same time zone.
        /// </remarks>
        /// <param name="dt2">
        /// a <see cref="DateTime"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="dt1"/> and <paramref name="dt2"/> are equal
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Boolean Equals(GISharp.Lib.GLib.DateTime dt2)
        {
            var dt1_ = Handle;
            var dt2_ = dt2?.Handle ?? throw new System.ArgumentNullException(nameof(dt2));
            var ret_ = g_date_time_equal(dt1_,dt2_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Hashes @datetime into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <param name="datetime">
        /// a #GDateTime
        /// </param>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint" type="guint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.UInt32 g_date_time_hash(
        /* <type name="DateTime" type="gconstpointer" managed-name="DateTime" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr datetime);

        /// <summary>
        /// Hashes <paramref name="datetime"/> into a #guint, suitable for use within #GHashTable.
        /// </summary>
        /// <returns>
        /// a #guint containing the hash
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public override System.Int32 GetHashCode()
        {
            var datetime_ = Handle;
            var ret_ = g_date_time_hash(datetime_);
            var ret = (System.Int32)ret_;
            return ret;
        }
    }

    /// <summary>
    /// The GKeyFile struct contains only private data
    /// and should not be accessed directly.
    /// </summary>
    [GISharp.Runtime.GTypeAttribute("GKeyFile", IsProxyForUnmanagedType = true)]
    public sealed partial class KeyFile : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_key_file_get_type();

        /// <summary>
        /// The name of the main group of a desktop entry file, as defined in the
        /// [Desktop Entry Specification](http://freedesktop.org/Standards/desktop-entry-spec).
        /// Consult the specification for more
        /// details about the meanings of the keys below.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopGroup = "Desktop Entry";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string list
        /// giving the available application actions.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public const System.String DesktopKeyActions = "Actions";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the categories in which the desktop entry
        /// should be shown in a menu.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyCategories = "Categories";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the tooltip for the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyComment = "Comment";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean set to true
        /// if the application is D-Bus activatable.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.38")]
        public const System.String DesktopKeyDbusActivatable = "DBusActivatable";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the command line to execute. It is only valid for desktop
        /// entries with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyExec = "Exec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the generic name of the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyGenericName = "GenericName";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry has been deleted by the user.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyHidden = "Hidden";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the name of the icon to be displayed for the desktop
        /// entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyIcon = "Icon";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list
        /// of strings giving the MIME types supported by this desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyMimeType = "MimeType";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a localized
        /// string giving the specific name of the desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyName = "Name";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should not display the
        /// desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyNotShowIn = "NotShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the desktop entry should be shown in menus.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyNoDisplay = "NoDisplay";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a list of
        /// strings identifying the environments that should display the
        /// desktop entry.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyOnlyShowIn = "OnlyShowIn";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// containing the working directory to run the program in. It is only
        /// valid for desktop entries with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyPath = "Path";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the application supports the
        /// [Startup Notification Protocol Specification](http://www.freedesktop.org/Standards/startup-notification-spec).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupNotify = "StartupNotify";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is string
        /// identifying the WM class or name hint of a window that the application
        /// will create, which can be used to emulate Startup Notification with
        /// older applications.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyStartupWmClass = "StartupWMClass";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a boolean
        /// stating whether the program should be run in a terminal window.
        /// It is only valid for desktop entries with the
        /// `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyTerminal = "Terminal";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the file name of a binary on disk used to determine if the
        /// program is actually installed. It is only valid for desktop entries
        /// with the `Application` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyTryExec = "TryExec";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the type of the desktop entry. Usually
        /// #G_KEY_FILE_DESKTOP_TYPE_APPLICATION,
        /// #G_KEY_FILE_DESKTOP_TYPE_LINK, or
        /// #G_KEY_FILE_DESKTOP_TYPE_DIRECTORY.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyType = "Type";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the URL to access. It is only valid for desktop entries
        /// with the `Link` type.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyUrl = "URL";

        /// <summary>
        /// A key under #G_KEY_FILE_DESKTOP_GROUP, whose value is a string
        /// giving the version of the Desktop Entry Specification used for
        /// the desktop entry file.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopKeyVersion = "Version";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing applications.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeApplication = "Application";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing directories.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeDirectory = "Directory";

        /// <summary>
        /// The value of the #G_KEY_FILE_DESKTOP_KEY_TYPE, key for desktop
        /// entries representing links to documents.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public const System.String DesktopTypeLink = "Link";

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Lib.GLib.Utf8 StartGroup { get => GetStartGroup(); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public KeyFile(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new empty #GKeyFile object. Use
        /// g_key_file_load_from_file(), g_key_file_load_from_data(),
        /// g_key_file_load_from_dirs() or g_key_file_load_from_data_dirs() to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty #GKeyFile.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_new();

        /// <summary>
        /// Creates a new empty <see cref="KeyFile"/> object. Use
        /// <see cref="LoadFromFile"/>, <see cref="LoadFromData"/>,
        /// <see cref="LoadFromDirs"/> or <see cref="LoadFromDataDirs"/> to
        /// read an existing key file.
        /// </summary>
        /// <returns>
        /// an empty <see cref="KeyFile"/>.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        static unsafe System.IntPtr New()
        {
            var ret_ = g_key_file_new();
            return ret_;
        }

        /// <summary>
        /// Creates a new empty <see cref="KeyFile"/> object. Use
        /// <see cref="LoadFromFile"/>, <see cref="LoadFromData"/>,
        /// <see cref="LoadFromDirs"/> or <see cref="LoadFromDataDirs"/> to
        /// read an existing key file.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public KeyFile() : this(New(), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_key_file_get_type();

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %FALSE is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with @key cannot be interpreted as a boolean then %FALSE
        /// is returned and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or %FALSE if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:0 direction:out */
        static extern unsafe System.Boolean g_key_file_get_boolean(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/> as a
        /// boolean.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then <c>false</c> is returned and <paramref name="error"/> is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value
        /// associated with <paramref name="key"/> cannot be interpreted as a boolean then <c>false</c>
        /// is returned and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a boolean,
        ///    or <c>false</c> if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe System.Boolean GetBoolean(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_boolean(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as booleans then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of booleans returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or %NULL if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gboolean*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gboolean" managed-name="System.Boolean" />
* </array> */
        /* transfer-ownership:container direction:out */
        static extern unsafe System.IntPtr g_key_file_get_boolean_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the values associated with <paramref name="key"/> under <paramref name="groupName"/> as
        /// booleans.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then <c>null</c> is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with <paramref name="key"/> cannot be interpreted as booleans then <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///    the values associated with the key as a list of booleans, or <c>null</c> if the
        ///    key was not found or could not be parsed. The returned list of booleans
        ///    should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Runtime.IArray<System.Boolean> GetBooleanList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_boolean_list(keyFile_,groupName_,key_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Boolean>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Retrieves a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be read from above
        /// @group_name. If both @key and @group_name are %NULL, then
        /// @comment will be read from above the first group in the file.
        /// </summary>
        /// <remarks>
        /// Note that the returned string includes the '#' comment markers.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Retrieves a comment above <paramref name="key"/> from <paramref name="groupName"/>.
        /// If <paramref name="key"/> is <c>null</c> then <paramref name="comment"/> will be read from above
        /// <paramref name="groupName"/>. If both <paramref name="key"/> and <paramref name="groupName"/> are <c>null</c>, then
        /// <paramref name="comment"/> will be read from above the first group in the file.
        /// </summary>
        /// <remarks>
        /// Note that the returned string includes the '#' comment markers.
        /// </remarks>
        /// <param name="groupName">
        /// a group name, or <c>null</c>
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a comment that should be freed with g_free()
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Utf8 GetComment(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_comment(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a
        /// double. If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0.0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as a double then 0.0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Double g_key_file_get_double(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/> as a
        /// double. If <paramref name="groupName"/> is <c>null</c>, the start_group is used.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then 0.0 is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with <paramref name="key"/> cannot be interpreted as a double then 0.0 is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as a double, or
        ///     0.0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe System.Double GetDouble(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_double(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Double)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as doubles then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of doubles returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or %NULL if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gdouble*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gdouble" managed-name="System.Double" />
* </array> */
        /* transfer-ownership:container direction:out */
        static extern unsafe System.IntPtr g_key_file_get_double_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the values associated with <paramref name="key"/> under <paramref name="groupName"/> as
        /// doubles.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then <c>null</c> is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with <paramref name="key"/> cannot be interpreted as doubles then <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of doubles, or <c>null</c> if the
        ///     key was not found or could not be parsed. The returned list of doubles
        ///     should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe GISharp.Runtime.IArray<System.Double> GetDoubleList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_double_list(keyFile_,groupName_,key_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Double>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Returns all groups in the key file loaded with @key_file.
        /// The array of returned groups will be %NULL-terminated, so
        /// @length may optionally be %NULL.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the number of returned groups, or %NULL
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_groups(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* length);

        /// <summary>
        /// Returns all groups in the key file loaded with <paramref name="keyFile"/>.
        /// The array of returned groups will be <c>null</c>-terminated, so
        /// <paramref name="length"/> may optionally be <c>null</c>.
        /// </summary>
        /// <param name="length">
        /// return location for the number of returned groups, or <c>null</c>
        /// </param>
        /// <returns>
        /// a newly-allocated <c>null</c>-terminated array of strings.
        ///   Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Strv GetGroups(out System.Int32 length)
        {
            var keyFile_ = Handle;
            System.UIntPtr length_;
            var ret_ = g_key_file_get_groups(keyFile_,&length_);
            length = (System.Int32)length_;
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as a signed
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int64 g_key_file_get_int64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/> as a signed
        /// 64-bit integer. This is similar to <see cref="GetInteger"/> but can return
        /// 64-bit results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-<c>null</c> group name
        /// </param>
        /// <param name="key">
        /// a non-<c>null</c> key
        /// </param>
        /// <returns>
        /// the value associated with the key as a signed 64-bit integer, or
        /// 0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.Int64 GetInt64(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_int64(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int64)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then 0 is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with @key cannot be interpreted as an integer, or is out of range
        /// for a #gint, then 0 is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Int32 g_key_file_get_integer(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/> as an
        /// integer.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then 0 is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the value associated
        /// with <paramref name="key"/> cannot be interpreted as an integer, or is out of range
        /// for a #gint, then 0 is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// the value associated with the key as an integer, or
        ///     0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe System.Int32 GetInteger(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_integer(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.Int32)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with @key cannot be interpreted as integers, or are out of range for
        /// #gint, then %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// the number of integers returned
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or %NULL if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="0" type="gint*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gint" managed-name="System.Int32" />
* </array> */
        /* transfer-ownership:container direction:out */
        static extern unsafe System.IntPtr g_key_file_get_integer_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the values associated with <paramref name="key"/> under <paramref name="groupName"/> as
        /// integers.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then <c>null</c> is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_KEY_NOT_FOUND. Likewise, if the values associated
        /// with <paramref name="key"/> cannot be interpreted as integers, or are out of range for
        /// #gint, then <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_INVALID_VALUE.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///     the values associated with the key as a list of integers, or <c>null</c> if
        ///     the key was not found or could not be parsed. The returned list of
        ///     integers should be freed with g_free() when no longer needed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Runtime.IArray<System.Int32> GetIntegerList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_integer_list(keyFile_,groupName_,key_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.CArray.GetInstance<System.Int32>(ret_, (int)length_, GISharp.Runtime.Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Returns all keys for the group name @group_name.  The array of
        /// returned keys will be %NULL-terminated, so @length may
        /// optionally be %NULL. In the event that the @group_name cannot
        /// be found, %NULL is returned and @error is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly-allocated %NULL-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array type="gchar**" zero-terminated="1" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_keys(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns all keys for the group name <paramref name="groupName"/>.  The array of
        /// returned keys will be <c>null</c>-terminated, so <paramref name="length"/> may
        /// optionally be <c>null</c>. In the event that the <paramref name="groupName"/> cannot
        /// be found, <c>null</c> is returned and <paramref name="error"/> is set to
        /// #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="length">
        /// return location for the number of keys returned, or <c>null</c>
        /// </param>
        /// <returns>
        /// a newly-allocated <c>null</c>-terminated array of strings.
        ///     Use g_strfreev() to free it.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Strv GetKeys(GISharp.Lib.GLib.Utf8 groupName, out System.Int32 length)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_keys(keyFile_,groupName_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            length = (System.Int32)length_;
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the actual locale which the result of
        /// g_key_file_get_locale_string() or g_key_file_get_locale_string_list()
        /// came from.
        /// </summary>
        /// <remarks>
        /// If calling g_key_file_get_locale_string() or
        /// g_key_file_get_locale_string_list() with exactly the same @key_file,
        /// @group_name, @key and @locale, the result of those functions will
        /// have originally been tagged with the locale that is the result of
        /// this function.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <returns>
        /// the locale from the file, or %NULL if the key was not
        ///   found or the entry in the file was was untranslated
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.56")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_key_file_get_locale_for_key(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr locale);

        /// <summary>
        /// Returns the actual locale which the result of
        /// <see cref="GetLocaleString"/> or <see cref="GetLocaleStringList"/>
        /// came from.
        /// </summary>
        /// <remarks>
        /// If calling <see cref="GetLocaleString"/> or
        /// <see cref="GetLocaleStringList"/> with exactly the same <paramref name="keyFile"/>,
        /// <paramref name="groupName"/>, <paramref name="key"/> and <paramref name="locale"/>, the result of those functions will
        /// have originally been tagged with the locale that is the result of
        /// this function.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or <c>null</c>
        /// </param>
        /// <returns>
        /// the locale from the file, or <c>null</c> if the key was not
        ///   found or the entry in the file was was untranslated
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.56")]
        public unsafe GISharp.Lib.GLib.Utf8 GetLocaleForKey(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 locale)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_key_file_get_locale_for_key(keyFile_,groupName_,key_,locale_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @locale is to be non-%NULL, or if the current locale will change over
        /// the lifetime of the #GKeyFile, it must be loaded with
        /// %G_KEY_FILE_KEEP_TRANSLATIONS in order to load strings for all locales.
        /// 
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with @key cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_locale_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr locale,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/>
        /// translated in the given <paramref name="locale"/> if available.  If <paramref name="locale"/> is
        /// <c>null</c> then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If <paramref name="locale"/> is to be non-<c>null</c>, or if the current locale will change over
        /// the lifetime of the <see cref="KeyFile"/>, it must be loaded with
        /// <see cref="KeyFileFlags.KeepTranslations"/> in order to load strings for all locales.
        /// 
        /// If <paramref name="key"/> cannot be found then <c>null</c> is returned and <paramref name="error"/> is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the value associated
        /// with <paramref name="key"/> cannot be interpreted or no suitable translation can
        /// be found then the untranslated value is returned.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or <c>null</c>
        /// </param>
        /// <returns>
        /// a newly allocated string or <c>null</c> if the specified
        ///   key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Utf8 GetLocaleString(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 locale)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_locale_string(keyFile_,groupName_,key_,locale_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name
        /// translated in the given @locale if available.  If @locale is
        /// %NULL then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If @locale is to be non-%NULL, or if the current locale will change over
        /// the lifetime of the #GKeyFile, it must be loaded with
        /// %G_KEY_FILE_KEEP_TRANSLATIONS in order to load strings for all locales.
        /// 
        /// If @key cannot be found then %NULL is returned and @error is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with @key cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is %NULL-terminated, so @length may optionally
        /// be %NULL.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or %NULL
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated %NULL-terminated string array
        ///   or %NULL if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="3" zero-terminated="1" type="gchar**" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_locale_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr locale,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the values associated with <paramref name="key"/> under <paramref name="groupName"/>
        /// translated in the given <paramref name="locale"/> if available.  If <paramref name="locale"/> is
        /// <c>null</c> then the current locale is assumed.
        /// </summary>
        /// <remarks>
        /// If <paramref name="locale"/> is to be non-<c>null</c>, or if the current locale will change over
        /// the lifetime of the <see cref="KeyFile"/>, it must be loaded with
        /// <see cref="KeyFileFlags.KeepTranslations"/> in order to load strings for all locales.
        /// 
        /// If <paramref name="key"/> cannot be found then <c>null</c> is returned and <paramref name="error"/> is set
        /// to #G_KEY_FILE_ERROR_KEY_NOT_FOUND. If the values associated
        /// with <paramref name="key"/> cannot be interpreted or no suitable translations
        /// can be found then the untranslated values are returned. The
        /// returned array is <c>null</c>-terminated, so <paramref name="length"/> may optionally
        /// be <c>null</c>.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier or <c>null</c>
        /// </param>
        /// <returns>
        /// a newly allocated <c>null</c>-terminated string array
        ///   or <c>null</c> if the key isn't found. The string array should be freed
        ///   with g_strfreev().
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Strv GetLocaleStringList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 locale)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? System.IntPtr.Zero;
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_locale_string_list(keyFile_,groupName_,key_,locale_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_start_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile);

        /// <summary>
        /// Returns the name of the start group of the file.
        /// </summary>
        /// <returns>
        /// The start group of the key file.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe GISharp.Lib.GLib.Utf8 GetStartGroup()
        {
            var keyFile_ = Handle;
            var ret_ = g_key_file_get_start_group(keyFile_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the string value associated with @key under @group_name.
        /// Unlike g_key_file_get_value(), this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///   key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the string value associated with <paramref name="key"/> under <paramref name="groupName"/>.
        /// Unlike <see cref="GetValue"/>, this function handles escape sequences
        /// like \s.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, <c>null</c> is returned and
        /// <paramref name="error"/> is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the <paramref name="groupName"/> cannot be found, <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or <c>null</c> if the specified
        ///   key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Utf8 GetString(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_string(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the values associated with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="length">
        /// return location for the number of returned strings, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// 
        ///  a %NULL-terminated string array or %NULL if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <array length="2" zero-terminated="1" type="gchar**" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the values associated with <paramref name="key"/> under <paramref name="groupName"/>.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, <c>null</c> is returned and
        /// <paramref name="error"/> is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the <paramref name="groupName"/> cannot be found, <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// 
        ///  a <c>null</c>-terminated string array or <c>null</c> if the specified
        ///  key cannot be found. The array should be freed with g_strfreev().
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Strv GetStringList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_string_list(keyFile_,groupName_,key_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Strv>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns the value associated with @key under @group_name as an unsigned
        /// 64-bit integer. This is similar to g_key_file_get_integer() but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="keyFile">
        /// a non-%NULL #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a non-%NULL group name
        /// </param>
        /// <param name="key">
        /// a non-%NULL key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.UInt64 g_key_file_get_uint64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the value associated with <paramref name="key"/> under <paramref name="groupName"/> as an unsigned
        /// 64-bit integer. This is similar to <see cref="GetInteger"/> but can return
        /// large positive results without truncation.
        /// </summary>
        /// <param name="groupName">
        /// a non-<c>null</c> group name
        /// </param>
        /// <param name="key">
        /// a non-<c>null</c> key
        /// </param>
        /// <returns>
        /// the value associated with the key as an unsigned 64-bit integer,
        /// or 0 if the key was not found or could not be parsed.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe System.UInt64 GetUint64(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_uint64(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = (System.UInt64)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the raw value associated with @key under @group_name.
        /// Use g_key_file_get_string() to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, %NULL is returned and
        /// @error is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the @group_name cannot be found, %NULL is returned
        /// and @error is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string or %NULL if the specified
        ///  key cannot be found.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_get_value(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Returns the raw value associated with <paramref name="key"/> under <paramref name="groupName"/>.
        /// Use <see cref="GetString"/> to retrieve an unescaped UTF-8 string.
        /// </summary>
        /// <remarks>
        /// In the event the key cannot be found, <c>null</c> is returned and
        /// <paramref name="error"/> is set to #G_KEY_FILE_ERROR_KEY_NOT_FOUND.  In the
        /// event that the <paramref name="groupName"/> cannot be found, <c>null</c> is returned
        /// and <paramref name="error"/> is set to #G_KEY_FILE_ERROR_GROUP_NOT_FOUND.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <returns>
        /// a newly allocated string or <c>null</c> if the specified
        ///  key cannot be found.
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Utf8 GetValue(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_get_value(keyFile_,groupName_,key_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Looks whether the key file has the group @group_name.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// %TRUE if @group_name is a part of @key_file, %FALSE
        /// otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_key_file_has_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName);

        /// <summary>
        /// Looks whether the key file has the group <paramref name="groupName"/>.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="groupName"/> is a part of <paramref name="keyFile"/>, <c>false</c>
        /// otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe System.Boolean HasGroup(GISharp.Lib.GLib.Utf8 groupName)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var ret_ = g_key_file_has_group(keyFile_,groupName_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Loads a key file from the data in @bytes into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.50")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_load_from_bytes(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="Bytes" type="GBytes*" managed-name="Bytes" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr bytes,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Loads a key file from the data in <paramref name="bytes"/> into an empty <see cref="KeyFile"/> structure.
        /// If the object cannot be created then %error is set to a <see cref="KeyFile"/>Error.
        /// </summary>
        /// <param name="bytes">
        /// a #GBytes
        /// </param>
        /// <param name="flags">
        /// flags from <see cref="KeyFileFlags"/>
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.50")]
        public unsafe void LoadFromBytes(GISharp.Lib.GLib.Bytes bytes, GISharp.Lib.GLib.KeyFileFlags flags)
        {
            var keyFile_ = Handle;
            var bytes_ = bytes?.Handle ?? throw new System.ArgumentNullException(nameof(bytes));
            var flags_ = (GISharp.Lib.GLib.KeyFileFlags)flags;
            var error_ = System.IntPtr.Zero;
            g_key_file_load_from_bytes(keyFile_, bytes_, flags_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Loads a key file from memory into an empty #GKeyFile structure.
        /// If the object cannot be created then %error is set to a #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of @data in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_load_from_data(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr data,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Loads a key file from memory into an empty <see cref="KeyFile"/> structure.
        /// If the object cannot be created then %error is set to a <see cref="KeyFile"/>Error.
        /// </summary>
        /// <param name="data">
        /// key file loaded in memory
        /// </param>
        /// <param name="length">
        /// the length of <paramref name="data"/> in bytes (or (gsize)-1 if data is nul-terminated)
        /// </param>
        /// <param name="flags">
        /// flags from <see cref="KeyFileFlags"/>
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void LoadFromData(GISharp.Lib.GLib.Utf8 data, System.Int32 length, GISharp.Lib.GLib.KeyFileFlags flags)
        {
            var keyFile_ = Handle;
            var data_ = data?.Handle ?? throw new System.ArgumentNullException(nameof(data));
            var length_ = (System.UIntPtr)length;
            var flags_ = (GISharp.Lib.GLib.KeyFileFlags)flags;
            var error_ = System.IntPtr.Zero;
            g_key_file_load_from_data(keyFile_, data_, length_, flags_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into @key_file and returns the file's full path in
        /// @full_path.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or #GKeyFileError.
        /// </summary>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE othewise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_load_from_data_dirs(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr file,
        /* <type name="filename" type="gchar**" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.IntPtr* fullPath,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// This function looks for a key file named <paramref name="file"/> in the paths
        /// returned from g_get_user_data_dir() and g_get_system_data_dirs(),
        /// loads the file into <paramref name="keyFile"/> and returns the file's full path in
        /// <paramref name="fullPath"/>.  If the file could not be loaded then an %error is
        /// set to either a #GFileError or <see cref="KeyFileError"/>.
        /// </summary>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or <c>null</c>
        /// </param>
        /// <param name="flags">
        /// flags from <see cref="KeyFileFlags"/>
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void LoadFromDataDirs(GISharp.Lib.GLib.Filename file, out GISharp.Lib.GLib.Filename fullPath, GISharp.Lib.GLib.KeyFileFlags flags)
        {
            var keyFile_ = Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            var flags_ = (GISharp.Lib.GLib.KeyFileFlags)flags;
            System.IntPtr fullPath_;
            var error_ = System.IntPtr.Zero;
            g_key_file_load_from_data_dirs(keyFile_, file_, &fullPath_, flags_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            fullPath = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Filename>(fullPath_, GISharp.Runtime.Transfer.Full);
        }

        /// <summary>
        /// This function looks for a key file named @file in the paths
        /// specified in @search_dirs, loads the file into @key_file and
        /// returns the file's full path in @full_path.
        /// </summary>
        /// <remarks>
        /// If the file could not be found in any of the @search_dirs,
        /// %G_KEY_FILE_ERROR_NOT_FOUND is returned. If
        /// the file is found but the OS returns an error when opening or reading the
        /// file, a %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// %NULL-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or %NULL
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_load_from_dirs(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr file,
        /* <array type="gchar**" zero-terminated="1" managed-name="GISharp.Runtime.FilenameArray" is-pointer="1">
*   <type name="filename" managed-name="GISharp.Lib.GLib.Filename" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr searchDirs,
        /* <type name="filename" type="gchar**" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.IntPtr* fullPath,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// This function looks for a key file named <paramref name="file"/> in the paths
        /// specified in <paramref name="searchDirs"/>, loads the file into <paramref name="keyFile"/> and
        /// returns the file's full path in <paramref name="fullPath"/>.
        /// </summary>
        /// <remarks>
        /// If the file could not be found in any of the <paramref name="searchDirs"/>,
        /// <see cref="KeyFileError.NotFound"/> is returned. If
        /// the file is found but the OS returns an error when opening or reading the
        /// file, a %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// </remarks>
        /// <param name="file">
        /// a relative path to a filename to open and parse
        /// </param>
        /// <param name="searchDirs">
        /// <c>null</c>-terminated array of directories to search
        /// </param>
        /// <param name="fullPath">
        /// return location for a string containing the full path
        ///   of the file, or <c>null</c>
        /// </param>
        /// <param name="flags">
        /// flags from <see cref="KeyFileFlags"/>
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public unsafe void LoadFromDirs(GISharp.Lib.GLib.Filename file, GISharp.Runtime.FilenameArray searchDirs, out GISharp.Lib.GLib.Filename fullPath, GISharp.Lib.GLib.KeyFileFlags flags)
        {
            var keyFile_ = Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            var searchDirs_ = searchDirs?.Handle ?? throw new System.ArgumentNullException(nameof(searchDirs));
            var flags_ = (GISharp.Lib.GLib.KeyFileFlags)flags;
            System.IntPtr fullPath_;
            var error_ = System.IntPtr.Zero;
            g_key_file_load_from_dirs(keyFile_, file_, searchDirs_, &fullPath_, flags_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            fullPath = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Filename>(fullPath_, GISharp.Runtime.Transfer.Full);
        }

        /// <summary>
        /// Loads a key file into an empty #GKeyFile structure.
        /// </summary>
        /// <remarks>
        /// If the OS returns an error when opening or reading the file, a
        /// %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// 
        /// This function will never return a %G_KEY_FILE_ERROR_NOT_FOUND error. If the
        /// @file is not found, %G_FILE_ERROR_NOENT is returned.
        /// </remarks>
        /// <param name="keyFile">
        /// an empty #GKeyFile struct
        /// </param>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from #GKeyFileFlags
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if a key file could be loaded, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_load_from_file(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="filename" type="const gchar*" managed-name="GISharp.Lib.GLib.Filename" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr file,
        /* <type name="KeyFileFlags" type="GKeyFileFlags" managed-name="KeyFileFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.KeyFileFlags flags,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Loads a key file into an empty <see cref="KeyFile"/> structure.
        /// </summary>
        /// <remarks>
        /// If the OS returns an error when opening or reading the file, a
        /// %G_FILE_ERROR is returned. If there is a problem parsing the file, a
        /// %G_KEY_FILE_ERROR is returned.
        /// 
        /// This function will never return a <see cref="KeyFileError.NotFound"/> error. If the
        /// <paramref name="file"/> is not found, %G_FILE_ERROR_NOENT is returned.
        /// </remarks>
        /// <param name="file">
        /// the path of a filename to load, in the GLib filename encoding
        /// </param>
        /// <param name="flags">
        /// flags from <see cref="KeyFileFlags"/>
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void LoadFromFile(GISharp.Lib.GLib.Filename file, GISharp.Lib.GLib.KeyFileFlags flags)
        {
            var keyFile_ = Handle;
            var file_ = file?.Handle ?? throw new System.ArgumentNullException(nameof(file));
            var flags_ = (GISharp.Lib.GLib.KeyFileFlags)flags;
            var error_ = System.IntPtr.Zero;
            g_key_file_load_from_file(keyFile_, file_, flags_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Removes a comment above @key from @group_name.
        /// If @key is %NULL then @comment will be removed above @group_name.
        /// If both @key and @group_name are %NULL, then @comment will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_remove_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Removes a comment above <paramref name="key"/> from <paramref name="groupName"/>.
        /// If <paramref name="key"/> is <c>null</c> then <paramref name="comment"/> will be removed above <paramref name="groupName"/>.
        /// If both <paramref name="key"/> and <paramref name="groupName"/> are <c>null</c>, then <paramref name="comment"/> will
        /// be removed above the first group in the file.
        /// </summary>
        /// <param name="groupName">
        /// a group name, or <c>null</c>
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void RemoveComment(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? System.IntPtr.Zero;
            var error_ = System.IntPtr.Zero;
            g_key_file_remove_comment(keyFile_, groupName_, key_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Removes the specified group, @group_name,
        /// from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the group was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_remove_group(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Removes the specified group, <paramref name="groupName"/>,
        /// from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void RemoveGroup(GISharp.Lib.GLib.Utf8 groupName)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var error_ = System.IntPtr.Zero;
            g_key_file_remove_group(keyFile_, groupName_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Removes @key in @group_name from the key file.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the key was removed, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_remove_key(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Removes <paramref name="key"/> in <paramref name="groupName"/> from the key file.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key name to remove
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void RemoveKey(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var error_ = System.IntPtr.Zero;
            g_key_file_remove_key(keyFile_, groupName_, key_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Writes the contents of @key_file to @filename using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if successful, else %FALSE with @error set
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_save_to_file(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr filename,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Writes the contents of <paramref name="keyFile"/> to <paramref name="filename"/> using
        /// g_file_set_contents().
        /// </summary>
        /// <remarks>
        /// This function can fail for any of the reasons that
        /// g_file_set_contents() may fail.
        /// </remarks>
        /// <param name="filename">
        /// the name of the file to write to
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe void SaveToFile(GISharp.Lib.GLib.Utf8 filename)
        {
            var keyFile_ = Handle;
            var filename_ = filename?.Handle ?? throw new System.ArgumentNullException(nameof(filename));
            var error_ = System.IntPtr.Zero;
            g_key_file_save_to_file(keyFile_, filename_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Associates a new boolean value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// %TRUE or %FALSE
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_boolean(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean value);

        /// <summary>
        /// Associates a new boolean value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// <c>true</c> or <c>false</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetBoolean(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, System.Boolean value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = (System.Boolean)value;
            g_key_file_set_boolean(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// Associates a list of boolean values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name is %NULL, the start_group is used.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        /// <param name="length">
        /// length of @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_boolean_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gboolean" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gboolean" type="gboolean" managed-name="System.Boolean" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of boolean values with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// If <paramref name="groupName"/> is <c>null</c>, the start_group is used.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of boolean values
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetBooleanList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Runtime.IArray<System.Boolean> list)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var (list_, length_) = ((System.IntPtr, System.UIntPtr))((list?.Data ?? throw new System.ArgumentNullException(nameof(list)), list?.Length ?? 0));
            g_key_file_set_boolean_list(keyFile_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Places a comment above @key from @group_name.
        /// </summary>
        /// <remarks>
        /// If @key is %NULL then @comment will be written above @group_name.
        /// If both @key and @group_name  are %NULL, then @comment will be
        /// written above the first group in the file.
        /// 
        /// Note that this function prepends a '#' comment marker to
        /// each line of @comment.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name, or %NULL
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// %TRUE if the comment was written, %FALSE otherwise
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none skip:1 direction:out */
        static extern unsafe System.Boolean g_key_file_set_comment(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr comment,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// Places a comment above <paramref name="key"/> from <paramref name="groupName"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> is <c>null</c> then <paramref name="comment"/> will be written above <paramref name="groupName"/>.
        /// If both <paramref name="key"/> and <paramref name="groupName"/>  are <c>null</c>, then <paramref name="comment"/> will be
        /// written above the first group in the file.
        /// 
        /// Note that this function prepends a '#' comment marker to
        /// each line of <paramref name="comment"/>.
        /// </remarks>
        /// <param name="groupName">
        /// a group name, or <c>null</c>
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="comment">
        /// a comment
        /// </param>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetComment(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 comment)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? System.IntPtr.Zero;
            var key_ = key?.Handle ?? System.IntPtr.Zero;
            var comment_ = comment?.Handle ?? throw new System.ArgumentNullException(nameof(comment));
            var error_ = System.IntPtr.Zero;
            g_key_file_set_comment(keyFile_, groupName_, key_, comment_, &error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }
        }

        /// <summary>
        /// Associates a new double value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_double(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gdouble" type="gdouble" managed-name="System.Double" /> */
        /* transfer-ownership:none direction:in */
        System.Double value);

        /// <summary>
        /// Associates a new double value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an double value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetDouble(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, System.Double value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = (System.Double)value;
            g_key_file_set_double(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// Associates a list of double values with @key under
        /// @group_name.  If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        /// <param name="length">
        /// number of double values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_double_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gdouble" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gdouble" type="gdouble" managed-name="System.Double" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of double values with <paramref name="key"/> under
        /// <paramref name="groupName"/>.  If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of double values
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetDoubleList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Runtime.IArray<System.Double> list)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var (list_, length_) = ((System.IntPtr, System.UIntPtr))((list?.Data ?? throw new System.ArgumentNullException(nameof(list)), list?.Length ?? 0));
            g_key_file_set_double_list(keyFile_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_int64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gint64" type="gint64" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        System.Int64 value);

        /// <summary>
        /// Associates a new integer value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe void SetInt64(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, System.Int64 value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = (System.Int64)value;
            g_key_file_set_int64(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_integer(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="gint" type="gint" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.Int32 value);

        /// <summary>
        /// Associates a new integer value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetInteger(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, System.Int32 value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = (System.Int32)value;
            g_key_file_set_integer(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// Associates a list of integer values with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        /// <param name="length">
        /// number of integer values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_integer_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <array length="3" zero-terminated="0" type="gint" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="gint" type="gint" managed-name="System.Int32" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length);

        /// <summary>
        /// Associates a list of integer values with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of integer values
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetIntegerList(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Runtime.IArray<System.Int32> list)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var (list_, length_) = ((System.IntPtr, System.UIntPtr))((list?.Data ?? throw new System.ArgumentNullException(nameof(list)), list?.Length ?? 0));
            g_key_file_set_integer_list(keyFile_, groupName_, key_, list_, length_);
        }

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_list_separator(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="gchar" type="gchar" managed-name="System.SByte" /> */
        /* transfer-ownership:none direction:in */
        System.SByte separator);

        /// <summary>
        /// Sets the character which is used to separate
        /// values in lists. Typically ';' or ',' are used
        /// as separators. The default list separator is ';'.
        /// </summary>
        /// <param name="separator">
        /// the separator
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetListSeparator(System.SByte separator)
        {
            var keyFile_ = Handle;
            var separator_ = (System.SByte)separator;
            g_key_file_set_list_separator(keyFile_, separator_);
        }

        /// <summary>
        /// Associates a string value for @key and @locale under @group_name.
        /// If the translation for @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_locale_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr locale,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr @string);

        /// <summary>
        /// Associates a string value for <paramref name="key"/> and <paramref name="locale"/> under <paramref name="groupName"/>.
        /// If the translation for <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetLocaleString(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 locale, GISharp.Lib.GLib.Utf8 @string)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var locale_ = locale?.Handle ?? throw new System.ArgumentNullException(nameof(locale));
            var @string_ = @string?.Handle ?? throw new System.ArgumentNullException(nameof(@string));
            g_key_file_set_locale_string(keyFile_, groupName_, key_, locale_, @string_);
        }

        /// <summary>
        /// Associates a list of string values for @key and @locale under
        /// @group_name.  If the translation for @key cannot be found then
        /// it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="locale">
        /// a locale identifier
        /// </param>
        /// <param name="list">
        /// a %NULL-terminated array of locale string values
        /// </param>
        /// <param name="length">
        /// the length of @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_locale_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr locale,
        /* <array length="4" zero-terminated="1" type="gchar*" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" type="gchar" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length);

        /// <summary>
        /// Associates a new string value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// Unlike g_key_file_set_value(), this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_string(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr @string);

        /// <summary>
        /// Associates a new string value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// If <paramref name="groupName"/> cannot be found then it is created.
        /// Unlike <see cref="SetValue"/>, this function handles characters
        /// that need escaping, such as newlines.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="string">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetString(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 @string)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var @string_ = @string?.Handle ?? throw new System.ArgumentNullException(nameof(@string));
            g_key_file_set_string(keyFile_, groupName_, key_, @string_);
        }

        /// <summary>
        /// Associates a list of string values for @key under @group_name.
        /// If @key cannot be found then it is created.
        /// If @group_name cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="list">
        /// an array of string values
        /// </param>
        /// <param name="length">
        /// number of string values in @list
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_string_list(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <array length="3" zero-terminated="1" type="gchar*" managed-name="GISharp.Lib.GLib.Strv" is-pointer="1">
*   <type name="utf8" managed-name="GISharp.Lib.GLib.Utf8" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr list,
        /* <type name="gsize" type="gsize" managed-name="System.Int32" /> */
        /* transfer-ownership:none direction:in */
        System.UIntPtr length);

        /// <summary>
        /// Associates a new integer value with @key under @group_name.
        /// If @key cannot be found then it is created.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_uint64(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="guint64" type="guint64" managed-name="System.UInt64" /> */
        /* transfer-ownership:none direction:in */
        System.UInt64 value);

        /// <summary>
        /// Associates a new integer value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// If <paramref name="key"/> cannot be found then it is created.
        /// </summary>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// an integer value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public unsafe void SetUint64(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, System.UInt64 value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = (System.UInt64)value;
            g_key_file_set_uint64(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// Associates a new value with @key under @group_name.
        /// </summary>
        /// <remarks>
        /// If @key cannot be found then it is created. If @group_name cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// g_key_file_set_string().
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_set_value(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr groupName,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Associates a new value with <paramref name="key"/> under <paramref name="groupName"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> cannot be found then it is created. If <paramref name="groupName"/> cannot
        /// be found then it is created. To set an UTF-8 string which may contain
        /// characters that need escaping (such as newlines or spaces), use
        /// <see cref="SetString"/>.
        /// </remarks>
        /// <param name="groupName">
        /// a group name
        /// </param>
        /// <param name="key">
        /// a key
        /// </param>
        /// <param name="value">
        /// a string
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetValue(GISharp.Lib.GLib.Utf8 groupName, GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Utf8 value)
        {
            var keyFile_ = Handle;
            var groupName_ = groupName?.Handle ?? throw new System.ArgumentNullException(nameof(groupName));
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_key_file_set_value(keyFile_, groupName_, key_, value_);
        }

        /// <summary>
        /// This function outputs @key_file as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass %NULL as @error.
        /// </remarks>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or %NULL
        /// </param>
        /// <param name="error">
        /// return location for a #GError
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the #GKeyFile
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_key_file_to_data(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile,
        /* <type name="gsize" type="gsize*" managed-name="System.Int32" is-pointer="1" /> */
        /* direction:out caller-allocates:0 transfer-ownership:full optional:1 allow-none:1 */
        System.UIntPtr* length,
        /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
        /* direction:inout transfer-ownership:full */
        System.IntPtr* error);

        /// <summary>
        /// This function outputs <paramref name="keyFile"/> as a string.
        /// </summary>
        /// <remarks>
        /// Note that this function never reports an error,
        /// so it is safe to pass <c>null</c> as <paramref name="error"/>.
        /// </remarks>
        /// <param name="length">
        /// return location for the length of the
        ///   returned string, or <c>null</c>
        /// </param>
        /// <returns>
        /// a newly allocated string holding
        ///   the contents of the <see cref="KeyFile"/>
        /// </returns>
        /// <exception name="GISharp.Runtime.GErrorException">
        /// On error
        /// </exception>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe GISharp.Lib.GLib.Utf8 ToData(out System.Int32 length)
        {
            var keyFile_ = Handle;
            System.UIntPtr length_;
            var error_ = System.IntPtr.Zero;
            var ret_ = g_key_file_to_data(keyFile_,&length_,&error_);
            if (error_ != System.IntPtr.Zero)
            {
                var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                throw new GISharp.Runtime.GErrorException(error);
            }

            length = (System.Int32)length_;
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Decreases the reference count of @key_file by 1. If the reference count
        /// reaches zero, frees the key file and all its allocated memory.
        /// </summary>
        /// <param name="keyFile">
        /// a #GKeyFile
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.32")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_key_file_unref(
        /* <type name="KeyFile" type="GKeyFile*" managed-name="KeyFile" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr keyFile);
    }

    /// <summary>
    /// Error codes returned by key file parsing.
    /// </summary>
    [GISharp.Runtime.GErrorDomainAttribute("g-key-file-error-quark")]
    public enum KeyFileError
    {
        /// <summary>
        /// the text being parsed was in
        ///     an unknown encoding
        /// </summary>
        UnknownEncoding = 0,
        /// <summary>
        /// document was ill-formed
        /// </summary>
        Parse = 1,
        /// <summary>
        /// the file was not found
        /// </summary>
        NotFound = 2,
        /// <summary>
        /// a requested key was not found
        /// </summary>
        KeyNotFound = 3,
        /// <summary>
        /// a requested group was not found
        /// </summary>
        GroupNotFound = 4,
        /// <summary>
        /// a value could not be parsed
        /// </summary>
        InvalidValue = 5
    }

    public partial class KeyFileErrorDomain
    {
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_key_file_error_quark();

        public static unsafe GISharp.Lib.GLib.Quark ErrorQuark()
        {
            var ret_ = g_key_file_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }

    /// <summary>
    /// Flags which influence the parsing.
    /// </summary>
    [System.FlagsAttribute]
    public enum KeyFileFlags
    {
        /// <summary>
        /// No flags, default behaviour
        /// </summary>
        None = 0,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise all comments will be lost when the key file is
        ///     written back.
        /// </summary>
        KeepComments = 1,
        /// <summary>
        /// Use this flag if you plan to write the
        ///     (possibly modified) contents of the key file back to a file;
        ///     otherwise only the translations for the current language will be
        ///     written back.
        /// </summary>
        KeepTranslations = 2
    }

    /// <summary>
    /// The <see cref="OptionArg"/> enum values determine which type of extra argument the
    /// options expect to find. If an option expects an extra argument, it can
    /// be specified in several ways; with a short option: `-x arg`, with a long
    /// option: `--name arg` or combined in a single argument: `--name=arg`.
    /// </summary>
    public enum OptionArg
    {
        /// <summary>
        /// No extra argument. This is useful for simple flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// The option takes a string argument.
        /// </summary>
        String = 1,
        /// <summary>
        /// The option takes an integer argument.
        /// </summary>
        Int = 2,
        /// <summary>
        /// The option provides a callback (of type
        ///     <see cref="OptionArgFunc"/>) to parse the extra argument.
        /// </summary>
        Callback = 3,
        /// <summary>
        /// The option takes a filename as argument.
        /// </summary>
        Filename = 4,
        /// <summary>
        /// The option takes a string argument, multiple
        ///     uses of the option are collected into an array of strings.
        /// </summary>
        StringArray = 5,
        /// <summary>
        /// The option takes a filename as argument,
        ///     multiple uses of the option are collected into an array of strings.
        /// </summary>
        FilenameArray = 6,
        /// <summary>
        /// The option takes a double argument. The argument
        ///     can be formatted either for the user's locale or for the "C" locale.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        Double = 7,
        /// <summary>
        /// The option takes a 64-bit integer. Like
        ///     <see cref="OptionArg.Int"/> but for larger numbers. The number can be in
        ///     decimal base, or in hexadecimal (when prefixed with `0x`, for
        ///     example, `0xffffffff`).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        Int64 = 8
    }

    /// <summary>
    /// The type of function to be passed as callback for %G_OPTION_ARG_CALLBACK
    /// options.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none skip:1 direction:out */
    public unsafe delegate System.Boolean UnmanagedOptionArgFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr optionName,
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr value,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    System.IntPtr* error);

    /// <summary>
    /// The type of function to be passed as callback for <see cref="OptionArg.Callback"/>
    /// options.
    /// </summary>
    public delegate void OptionArgFunc(GISharp.Lib.GLib.Utf8 optionName, GISharp.Lib.GLib.Utf8 value);

    /// <summary>
    /// Factory for creating <see cref="OptionArgFunc"/> methods.
    /// </summary>
    public static class OptionArgFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.OptionArgFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedOptionArgFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.OptionArgFunc Create(GISharp.Lib.GLib.UnmanagedOptionArgFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(GISharp.Lib.GLib.Utf8 optionName, GISharp.Lib.GLib.Utf8 value)
            {
                var data_ = userData;
                var optionName_ = optionName?.Handle ?? throw new System.ArgumentNullException(nameof(optionName));
                var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
                var error_ = System.IntPtr.Zero;
                callback(optionName_, value_, data_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="OptionArgFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static unsafe (GISharp.Lib.GLib.UnmanagedOptionArgFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.OptionArgFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe System.Boolean UnmanagedCallback(System.IntPtr optionName_, System.IntPtr value_, System.IntPtr data_, System.IntPtr* error_)
        {
            try
            {
                var optionName = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(optionName_, GISharp.Runtime.Transfer.None);
                var value = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(value_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                data.ManagedDelegate(optionName, value);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.Boolean);
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// A `GOptionContext` struct defines which options
    /// are accepted by the commandline option parser. The struct has only private
    /// fields and should not be directly accessed.
    /// </summary>
    public sealed partial class OptionContext : GISharp.Runtime.Opaque
    {
        /// <summary>
        /// Returns the description. See <see cref="SetDescription"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Lib.GLib.Utf8 Description { get => GetDescription(); set => SetDescription(value); }

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for <paramref name="context"/>. See <see cref="SetHelpEnabled"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean HelpEnabled { get => GetHelpEnabled(); set => SetHelpEnabled(value); }

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// <see cref="SetIgnoreUnknownOptions"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public System.Boolean IgnoreUnknownOptions { get => GetIgnoreUnknownOptions(); set => SetIgnoreUnknownOptions(value); }

        /// <summary>
        /// Returns a pointer to the main group of <paramref name="context"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public GISharp.Lib.GLib.OptionGroup MainGroup { get => GetMainGroup(); set => SetMainGroup(value); }

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See <see cref="SetStrictPosix"/> for more information.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.44")]
        public System.Boolean StrictPosix { get => GetStrictPosix(); set => SetStrictPosix(value); }

        /// <summary>
        /// Returns the summary. See <see cref="SetSummary"/>.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public GISharp.Lib.GLib.Utf8 Summary { get => GetSummary(); set => SetSummary(value); }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionContext(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// The @parameter_string can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the #GOptionContext, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the @arg_description of the corresponding #GOptionEntry in
        /// the usage summary.
        /// 
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use g_option_context_set_summary().
        /// 
        /// Note that the @parameter_string is translated using the
        /// function set with g_option_context_set_translate_func(), so
        /// it should normally be passed untranslated.
        /// </remarks>
        /// <param name="parameterString">
        /// a string which is displayed in
        ///    the first line of `--help` output, after the usage summary
        ///    `programname [OPTION...]`
        /// </param>
        /// <returns>
        /// a newly created #GOptionContext, which must be
        ///    freed with g_option_context_free() after use.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_context_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr parameterString);

        /// <summary>
        /// Creates a new option context.
        /// </summary>
        /// <remarks>
        /// The <paramref name="parameterString"/> can serve multiple purposes. It can be used
        /// to add descriptions for "rest" arguments, which are not parsed by
        /// the <see cref="OptionContext"/>, typically something like "FILES" or
        /// "FILE1 FILE2...". If you are using #G_OPTION_REMAINING for
        /// collecting "rest" arguments, GLib handles this automatically by
        /// using the <paramref name="argDescription"/> of the corresponding <see cref="OptionEntry"/> in
        /// the usage summary.
        /// 
        /// Another usage is to give a short summary of the program
        /// functionality, like " - frob the strings", which will be displayed
        /// in the same line as the usage. For a longer description of the
        /// program functionality that should be displayed as a paragraph
        /// below the usage line, use <see cref="SetSummary"/>.
        /// 
        /// Note that the <paramref name="parameterString"/> is translated using the
        /// function set with <see cref="SetTranslateFunc"/>, so
        /// it should normally be passed untranslated.
        /// </remarks>
        /// <param name="parameterString">
        /// a string which is displayed in
        ///    the first line of `--help` output, after the usage summary
        ///    `programname [OPTION...]`
        /// </param>
        /// <returns>
        /// a newly created <see cref="OptionContext"/>, which must be
        ///    freed with <see cref="Free"/> after use.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.Utf8 parameterString)
        {
            var parameterString_ = parameterString?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_option_context_new(parameterString_);
            return ret_;
        }

        /// <summary>
        /// Adds a #GOptionGroup to the @context, so that parsing with @context
        /// will recognize the options in the group. Note that this will take
        /// ownership of the @group and thus the @group should not be freed.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="group">
        /// the group to add
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_add_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr group);

        /// <summary>
        /// Adds a <see cref="OptionGroup"/> to the <paramref name="context"/>, so that parsing with <paramref name="context"/>
        /// will recognize the options in the group. Note that this will take
        /// ownership of the <paramref name="group"/> and thus the <paramref name="group"/> should not be freed.
        /// </summary>
        /// <param name="group">
        /// the group to add
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void AddGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var group_ = group?.Take() ?? throw new System.ArgumentNullException(nameof(group));
            g_option_context_add_group(context_, group_);
        }

        /// <summary>
        /// Frees context and all the groups which have been
        /// added to it.
        /// </summary>
        /// <remarks>
        /// Please note that parsed arguments need to be freed separately (see
        /// #GOptionEntry).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_free(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the description. See g_option_context_set_description().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the description
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_description(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the description. See <see cref="SetDescription"/>.
        /// </summary>
        /// <returns>
        /// the description
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe GISharp.Lib.GLib.Utf8 GetDescription()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_description(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Returns a formatted, translated help text for the given context.
        /// To obtain the text produced by `--help`, call
        /// `g_option_context_get_help (context, TRUE, NULL)`.
        /// To obtain the text produced by `--help-all`, call
        /// `g_option_context_get_help (context, FALSE, NULL)`.
        /// To obtain the help text for an option group, call
        /// `g_option_context_get_help (context, FALSE, group)`.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="mainHelp">
        /// if %TRUE, only include the main group
        /// </param>
        /// <param name="group">
        /// the #GOptionGroup to create help for, or %NULL
        /// </param>
        /// <returns>
        /// A newly allocated string containing the help text
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_context_get_help(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean mainHelp,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr group);

        /// <summary>
        /// Returns a formatted, translated help text for the given context.
        /// To obtain the text produced by `--help`, call
        /// `g_option_context_get_help (context, TRUE, NULL)`.
        /// To obtain the text produced by `--help-all`, call
        /// `g_option_context_get_help (context, FALSE, NULL)`.
        /// To obtain the help text for an option group, call
        /// `g_option_context_get_help (context, FALSE, group)`.
        /// </summary>
        /// <param name="mainHelp">
        /// if <c>true</c>, only include the main group
        /// </param>
        /// <param name="group">
        /// the <see cref="OptionGroup"/> to create help for, or <c>null</c>
        /// </param>
        /// <returns>
        /// A newly allocated string containing the help text
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.14")]
        public unsafe GISharp.Lib.GLib.Utf8 GetHelp(System.Boolean mainHelp, GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var mainHelp_ = (System.Boolean)mainHelp;
            var group_ = group?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_option_context_get_help(context_,mainHelp_,group_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for @context. See g_option_context_set_help_enabled().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if automatic help generation is turned on.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether automatic `--help` generation
        /// is turned on for <paramref name="context"/>. See <see cref="SetHelpEnabled"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if automatic help generation is turned on.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe System.Boolean GetHelpEnabled()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_help_enabled(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// g_option_context_set_ignore_unknown_options().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if unknown options are ignored.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether unknown options are ignored or not. See
        /// <see cref="SetIgnoreUnknownOptions"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if unknown options are ignored.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe System.Boolean GetIgnoreUnknownOptions()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_ignore_unknown_options(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns a pointer to the main group of @context.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the main group of @context, or %NULL if
        ///  @context doesn't have a main group. Note that group belongs to
        ///  @context and should not be modified or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_main_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns a pointer to the main group of <paramref name="context"/>.
        /// </summary>
        /// <returns>
        /// the main group of <paramref name="context"/>, or <c>null</c> if
        ///  <paramref name="context"/> doesn't have a main group. Note that group belongs to
        ///  <paramref name="context"/> and should not be modified or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe GISharp.Lib.GLib.OptionGroup GetMainGroup()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_main_group(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionGroup>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See g_option_context_set_strict_posix() for more information.
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// %TRUE if strict POSIX is enabled, %FALSE otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_option_context_get_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns whether strict POSIX code is enabled.
        /// </summary>
        /// <remarks>
        /// See <see cref="SetStrictPosix"/> for more information.
        /// </remarks>
        /// <returns>
        /// <c>true</c> if strict POSIX is enabled, <c>false</c> otherwise.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private unsafe System.Boolean GetStrictPosix()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_strict_posix(context_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the summary. See g_option_context_set_summary().
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <returns>
        /// the summary
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_option_context_get_summary(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context);

        /// <summary>
        /// Returns the summary. See <see cref="SetSummary"/>.
        /// </summary>
        /// <returns>
        /// the summary
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe GISharp.Lib.GLib.Utf8 GetSummary()
        {
            var context_ = Handle;
            var ret_ = g_option_context_get_summary(context_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output after the list
        /// of options. This text often includes a bug reporting address.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func()).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="description">
        /// a string to be shown in `--help` output
        ///   after the list of options, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_description(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr description);

        /// <summary>
        /// Adds a string to be displayed in `--help` output after the list
        /// of options. This text often includes a bug reporting address.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// <see cref="SetTranslateFunc"/>).
        /// </remarks>
        /// <param name="description">
        /// a string to be shown in `--help` output
        ///   after the list of options, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe void SetDescription(GISharp.Lib.GLib.Utf8 description)
        {
            var context_ = Handle;
            var description_ = description?.Handle ?? System.IntPtr.Zero;
            g_option_context_set_description(context_, description_);
        }

        /// <summary>
        /// Enables or disables automatic generation of `--help` output.
        /// By default, g_option_context_parse() recognizes `--help`, `-h`,
        /// `-?`, `--help-all` and `--help-groupname` and creates suitable
        /// output to stdout.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="helpEnabled">
        /// %TRUE to enable `--help`, %FALSE to disable it
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_help_enabled(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean helpEnabled);

        /// <summary>
        /// Enables or disables automatic generation of `--help` output.
        /// By default, g_option_context_parse() recognizes `--help`, `-h`,
        /// `-?`, `--help-all` and `--help-groupname` and creates suitable
        /// output to stdout.
        /// </summary>
        /// <param name="helpEnabled">
        /// <c>true</c> to enable `--help`, <c>false</c> to disable it
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetHelpEnabled(System.Boolean helpEnabled)
        {
            var context_ = Handle;
            var helpEnabled_ = (System.Boolean)helpEnabled;
            g_option_context_set_help_enabled(context_, helpEnabled_);
        }

        /// <summary>
        /// Sets whether to ignore unknown options or not. If an argument is
        /// ignored, it is left in the @argv array after parsing. By default,
        /// g_option_context_parse() treats unknown options as error.
        /// </summary>
        /// <remarks>
        /// This setting does not affect non-option arguments (i.e. arguments
        /// which don't start with a dash). But note that GOption cannot reliably
        /// determine whether a non-option belongs to a preceding unknown option.
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="ignoreUnknown">
        /// %TRUE to ignore unknown options, %FALSE to produce
        ///    an error when unknown options are met
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_ignore_unknown_options(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean ignoreUnknown);

        /// <summary>
        /// Sets whether to ignore unknown options or not. If an argument is
        /// ignored, it is left in the <paramref name="argv"/> array after parsing. By default,
        /// g_option_context_parse() treats unknown options as error.
        /// </summary>
        /// <remarks>
        /// This setting does not affect non-option arguments (i.e. arguments
        /// which don't start with a dash). But note that GOption cannot reliably
        /// determine whether a non-option belongs to a preceding unknown option.
        /// </remarks>
        /// <param name="ignoreUnknown">
        /// <c>true</c> to ignore unknown options, <c>false</c> to produce
        ///    an error when unknown options are met
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetIgnoreUnknownOptions(System.Boolean ignoreUnknown)
        {
            var context_ = Handle;
            var ignoreUnknown_ = (System.Boolean)ignoreUnknown;
            g_option_context_set_ignore_unknown_options(context_, ignoreUnknown_);
        }

        /// <summary>
        /// Sets a #GOptionGroup as main group of the @context.
        /// This has the same effect as calling g_option_context_add_group(),
        /// the only difference is that the options in the main group are
        /// treated differently when generating `--help` output.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="group">
        /// the group to set as main group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_main_group(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr group);

        /// <summary>
        /// Sets a <see cref="OptionGroup"/> as main group of the <paramref name="context"/>.
        /// This has the same effect as calling <see cref="AddGroup"/>,
        /// the only difference is that the options in the main group are
        /// treated differently when generating `--help` output.
        /// </summary>
        /// <param name="group">
        /// the group to set as main group
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        private unsafe void SetMainGroup(GISharp.Lib.GLib.OptionGroup group)
        {
            var context_ = Handle;
            var group_ = group?.Take() ?? throw new System.ArgumentNullException(nameof(group));
            g_option_context_set_main_group(context_, group_);
        }

        /// <summary>
        /// Sets strict POSIX mode.
        /// </summary>
        /// <remarks>
        /// By default, this mode is disabled.
        /// 
        /// In strict POSIX mode, the first non-argument parameter encountered
        /// (eg: filename) terminates argument processing.  Remaining arguments
        /// are treated as non-options and are not attempted to be parsed.
        /// 
        /// If strict POSIX mode is disabled then parsing is done in the GNU way
        /// where option arguments can be freely mixed with non-options.
        /// 
        /// As an example, consider "ls foo -l".  With GNU style parsing, this
        /// will list "foo" in long mode.  In strict POSIX style, this will list
        /// the files named "foo" and "-l".
        /// 
        /// It may be useful to force strict POSIX mode when creating "verb
        /// style" command line tools.  For example, the "gsettings" command line
        /// tool supports the global option "--schemadir" as well as many
        /// subcommands ("get", "set", etc.) which each have their own set of
        /// arguments.  Using strict POSIX mode will allow parsing the global
        /// options up to the verb name while leaving the remaining options to be
        /// parsed by the relevant subcommand (which can be determined by
        /// examining the verb name, which should be present in argv[1] after
        /// parsing).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="strictPosix">
        /// the new value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_strict_posix(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:in */
        System.Boolean strictPosix);

        /// <summary>
        /// Sets strict POSIX mode.
        /// </summary>
        /// <remarks>
        /// By default, this mode is disabled.
        /// 
        /// In strict POSIX mode, the first non-argument parameter encountered
        /// (eg: filename) terminates argument processing.  Remaining arguments
        /// are treated as non-options and are not attempted to be parsed.
        /// 
        /// If strict POSIX mode is disabled then parsing is done in the GNU way
        /// where option arguments can be freely mixed with non-options.
        /// 
        /// As an example, consider "ls foo -l".  With GNU style parsing, this
        /// will list "foo" in long mode.  In strict POSIX style, this will list
        /// the files named "foo" and "-l".
        /// 
        /// It may be useful to force strict POSIX mode when creating "verb
        /// style" command line tools.  For example, the "gsettings" command line
        /// tool supports the global option "--schemadir" as well as many
        /// subcommands ("get", "set", etc.) which each have their own set of
        /// arguments.  Using strict POSIX mode will allow parsing the global
        /// options up to the verb name while leaving the remaining options to be
        /// parsed by the relevant subcommand (which can be determined by
        /// examining the verb name, which should be present in argv[1] after
        /// parsing).
        /// </remarks>
        /// <param name="strictPosix">
        /// the new value
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        private unsafe void SetStrictPosix(System.Boolean strictPosix)
        {
            var context_ = Handle;
            var strictPosix_ = (System.Boolean)strictPosix;
            g_option_context_set_strict_posix(context_, strictPosix_);
        }

        /// <summary>
        /// Adds a string to be displayed in `--help` output before the list
        /// of options. This is typically a summary of the program functionality.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// g_option_context_set_translate_func() and
        /// g_option_context_set_translation_domain()).
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="summary">
        /// a string to be shown in `--help` output
        ///  before the list of options, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_summary(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr summary);

        /// <summary>
        /// Adds a string to be displayed in `--help` output before the list
        /// of options. This is typically a summary of the program functionality.
        /// </summary>
        /// <remarks>
        /// Note that the summary is translated (see
        /// <see cref="SetTranslateFunc"/> and
        /// <see cref="SetTranslationDomain"/>).
        /// </remarks>
        /// <param name="summary">
        /// a string to be shown in `--help` output
        ///  before the list of options, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        private unsafe void SetSummary(GISharp.Lib.GLib.Utf8 summary)
        {
            var context_ = Handle;
            var summary_ = summary?.Handle ?? System.IntPtr.Zero;
            g_option_context_set_summary(context_, summary_);
        }

        /// <summary>
        /// Sets the function which is used to translate the contexts
        /// user-visible strings, for `--help` output. If @func is %NULL,
        /// strings are not translated.
        /// </summary>
        /// <remarks>
        /// Note that option groups have their own translation functions,
        /// this function only affects the @parameter_string (see g_option_context_new()),
        /// the summary (see g_option_context_set_summary()) and the description
        /// (see g_option_context_set_description()).
        /// 
        /// If you are using gettext(), you only need to set the translation
        /// domain, see g_option_context_set_translation_domain().
        /// </remarks>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="func">
        /// the #GTranslateFunc, or %NULL
        /// </param>
        /// <param name="data">
        /// user data to pass to @func, or %NULL
        /// </param>
        /// <param name="destroyNotify">
        /// a function which gets called to free @data, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_translate_func(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="TranslateFunc" type="GTranslateFunc" managed-name="UnmanagedTranslateFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        GISharp.Lib.GLib.UnmanagedTranslateFunc func,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify destroyNotify);

        /// <summary>
        /// Sets the function which is used to translate the contexts
        /// user-visible strings, for `--help` output. If <paramref name="func"/> is <c>null</c>,
        /// strings are not translated.
        /// </summary>
        /// <remarks>
        /// Note that option groups have their own translation functions,
        /// this function only affects the <paramref name="parameterString"/> (see <see cref="New"/>),
        /// the summary (see <see cref="SetSummary"/>) and the description
        /// (see <see cref="SetDescription"/>).
        /// 
        /// If you are using gettext(), you only need to set the translation
        /// domain, see <see cref="SetTranslationDomain"/>.
        /// </remarks>
        /// <param name="func">
        /// the <see cref="TranslateFunc"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc func)
        {
            var context_ = Handle;
            var (func_, destroyNotify_, data_) = func == null ? (default(GISharp.Lib.GLib.UnmanagedTranslateFunc), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.GLib.TranslateFuncFactory.Create(func, GISharp.Runtime.CallbackScope.Notified);
            g_option_context_set_translate_func(context_, func_, data_, destroyNotify_);
        }

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="context">
        /// a #GOptionContext
        /// </param>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_context_set_translation_domain(
        /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr context,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr domain);

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe void SetTranslationDomain(GISharp.Lib.GLib.Utf8 domain)
        {
            var context_ = Handle;
            var domain_ = domain?.Handle ?? throw new System.ArgumentNullException(nameof(domain));
            g_option_context_set_translation_domain(context_, domain_);
        }
    }

    /// <summary>
    /// A GOptionEntry struct defines a single option. To have an effect, they
    /// must be added to a <see cref="OptionGroup"/> with g_option_context_add_main_entries()
    /// or <see cref="AddEntries"/>.
    /// </summary>
    public partial struct OptionEntry
    {
#pragma warning disable CS0649
        /// <summary>
        /// The long name of an option can be used to specify it
        ///     in a commandline as `--long_name`. Every option must have a
        ///     long name. To resolve conflicts if multiple option groups contain
        ///     the same long name, it is also possible to specify the option as
        ///     `--groupname-long_name`.
        /// </summary>
        public System.IntPtr LongName;

        /// <summary>
        /// If an option has a short name, it can be specified
        ///     `-short_name` in a commandline. <paramref name="shortName"/> must be  a printable
        ///     ASCII character different from '-', or zero if the option has no
        ///     short name.
        /// </summary>
        public System.SByte ShortName;

        /// <summary>
        /// Flags from <see cref="OptionFlags"/>
        /// </summary>
        public System.Int32 Flags;

        /// <summary>
        /// The type of the option, as a <see cref="OptionArg"/>
        /// </summary>
        public GISharp.Lib.GLib.OptionArg Arg;

        /// <summary>
        /// If the <paramref name="arg"/> type is <see cref="OptionArg.Callback"/>, then <paramref name="arg"/>_data
        ///     must point to a <see cref="OptionArgFunc"/> callback function, which will be
        ///     called to handle the extra argument. Otherwise, <paramref name="arg"/>_data is a
        ///     pointer to a location to store the value, the required type of
        ///     the location depends on the <paramref name="arg"/> type:
        ///     - <see cref="OptionArg.None"/>: %gboolean
        ///     - <see cref="OptionArg.String"/>: %gchar*
        ///     - <see cref="OptionArg.Int"/>: %gint
        ///     - <see cref="OptionArg.Filename"/>: %gchar*
        ///     - <see cref="OptionArg.String"/>_ARRAY: %gchar**
        ///     - <see cref="OptionArg.Filename"/>_ARRAY: %gchar**
        ///     - <see cref="OptionArg.Double"/>: %gdouble
        ///     If <paramref name="arg"/> type is <see cref="OptionArg.String"/> or <see cref="OptionArg.Filename"/>,
        ///     the location will contain a newly allocated string if the option
        ///     was given. That string needs to be freed by the callee using g_free().
        ///     Likewise if <paramref name="arg"/> type is <see cref="OptionArg.String"/>_ARRAY or
        ///     <see cref="OptionArg.Filename"/>_ARRAY, the data should be freed using g_strfreev().
        /// </summary>
        public System.IntPtr ArgData;

        /// <summary>
        /// the description for the option in `--help`
        ///     output. The <paramref name="description"/> is translated using the <paramref name="translateFunc"/>
        ///     of the group, see <see cref="SetTranslationDomain"/>.
        /// </summary>
        public System.IntPtr Description;

        /// <summary>
        /// The placeholder to use for the extra argument parsed
        ///     by the option in `--help` output. The <paramref name="argDescription"/> is translated
        ///     using the <paramref name="translateFunc"/> of the group, see
        ///     <see cref="SetTranslationDomain"/>.
        /// </summary>
        public System.IntPtr ArgDescription;
#pragma warning restore CS0649
    }

    /// <summary>
    /// Error codes returned by option parsing.
    /// </summary>
    [GISharp.Runtime.GErrorDomainAttribute("g-option-context-error-quark")]
    public enum OptionError
    {
        /// <summary>
        /// An option was not known to the parser.
        ///  This error will only be reported, if the parser hasn't been instructed
        ///  to ignore unknown options, see <see cref="SetIgnoreUnknownOptions"/>.
        /// </summary>
        UnknownOption = 0,
        /// <summary>
        /// A value couldn't be parsed.
        /// </summary>
        BadValue = 1,
        /// <summary>
        /// A <see cref="OptionArgFunc"/> callback failed.
        /// </summary>
        Failed = 2
    }

    public partial class OptionErrorDomain
    {
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Quark" type="GQuark" managed-name="Quark" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe GISharp.Lib.GLib.Quark g_option_error_quark();

        public static unsafe GISharp.Lib.GLib.Quark OptionErrorQuark()
        {
            var ret_ = g_option_error_quark();
            var ret = (GISharp.Lib.GLib.Quark)ret_;
            return ret;
        }
    }

    /// <summary>
    /// The type of function to be used as callback when a parse error occurs.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate void UnmanagedOptionErrorFunc(
    /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr context,
    /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr group,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    System.IntPtr* error);

    /// <summary>
    /// The type of function to be used as callback when a parse error occurs.
    /// </summary>
    public delegate void OptionErrorFunc(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group);

    /// <summary>
    /// Factory for creating <see cref="OptionErrorFunc"/> methods.
    /// </summary>
    public static class OptionErrorFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.OptionErrorFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedOptionErrorFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.OptionErrorFunc Create(GISharp.Lib.GLib.UnmanagedOptionErrorFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group)
            {
                var data_ = userData;
                var context_ = context?.Handle ?? throw new System.ArgumentNullException(nameof(context));
                var group_ = group?.Handle ?? throw new System.ArgumentNullException(nameof(group));
                var error_ = System.IntPtr.Zero;
                callback(context_, group_, data_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="OptionErrorFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static unsafe (GISharp.Lib.GLib.UnmanagedOptionErrorFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.OptionErrorFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe void UnmanagedCallback(System.IntPtr context_, System.IntPtr group_, System.IntPtr data_, System.IntPtr* error_)
        {
            try
            {
                var context = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionContext>(context_, GISharp.Runtime.Transfer.None);
                var group = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionGroup>(group_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                data.ManagedDelegate(context, group);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// Flags which modify individual options.
    /// </summary>
    [System.FlagsAttribute]
    public enum OptionFlags
    {
        /// <summary>
        /// No flags.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.42")]
        None = 0,
        /// <summary>
        /// The option doesn't appear in `--help` output.
        /// </summary>
        Hidden = 1,
        /// <summary>
        /// The option appears in the main section of the
        ///     `--help` output, even if it is defined in a group.
        /// </summary>
        InMain = 2,
        /// <summary>
        /// For options of the <see cref="OptionArg.None"/> kind, this
        ///     flag indicates that the sense of the option is reversed.
        /// </summary>
        Reverse = 4,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/> kind,
        ///     this flag indicates that the callback does not take any argument
        ///     (like a <see cref="OptionArg.None"/> option).
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        NoArg = 8,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/>
        ///     kind, this flag indicates that the argument should be passed to the
        ///     callback in the GLib filename encoding rather than UTF-8.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        Filename = 16,
        /// <summary>
        /// For options of the <see cref="OptionArg.Callback"/>
        ///     kind, this flag indicates that the argument supply is optional.
        ///     If no argument is given then data of %GOptionParseFunc will be
        ///     set to NULL.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        OptionalArg = 32,
        /// <summary>
        /// This flag turns off the automatic conflict
        ///     resolution which prefixes long option names with `groupname-` if
        ///     there is a conflict. This option should only be used in situations
        ///     where aliasing is necessary to model some legacy commandline interface.
        ///     It is not safe to use this option, unless all option groups are under
        ///     your direct control.
        /// </summary>
        [GISharp.Runtime.SinceAttribute("2.8")]
        NoAlias = 64
    }

    /// <summary>
    /// A `GOptionGroup` struct defines the options in a single
    /// group. The struct has only private fields and should not be directly accessed.
    /// </summary>
    /// <remarks>
    /// All options in a group share the same translation function. Libraries which
    /// need to parse commandline options are expected to provide a function for
    /// getting a `GOptionGroup` holding their options, which
    /// the application can then add to its <see cref="OptionContext"/>.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GOptionGroup", IsProxyForUnmanagedType = true)]
    public sealed partial class OptionGroup : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_option_group_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OptionGroup(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GOptionGroup.
        /// </summary>
        /// <param name="name">
        /// the name for the option group, this is used to provide
        ///   help for the options in this group with `--help-`@name
        /// </param>
        /// <param name="description">
        /// a description for this group to be shown in
        ///   `--help`. This string is translated using the translation
        ///   domain or translation function of the group
        /// </param>
        /// <param name="helpDescription">
        /// a description for the `--help-`@name option.
        ///   This string is translated using the translation domain or translation function
        ///   of the group
        /// </param>
        /// <param name="userData">
        /// user data that will be passed to the pre- and post-parse hooks,
        ///   the error hook and to callbacks of %G_OPTION_ARG_CALLBACK options, or %NULL
        /// </param>
        /// <param name="destroy">
        /// a function that will be called to free @user_data, or %NULL
        /// </param>
        /// <returns>
        /// a newly created option group. It should be added
        ///   to a #GOptionContext or freed with g_option_group_unref().
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_group_new(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr name,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr description,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr helpDescription,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr userData,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify destroy);
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_option_group_get_type();

        /// <summary>
        /// Adds the options specified in @entries to @group.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="entries">
        /// a %NULL-terminated array of #GOptionEntrys
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_add_entries(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <array zero-terminated="1" type="GOptionEntry*" managed-name="GISharp.Runtime.IArray`1[T]" is-pointer="1">
*   <type name="OptionEntry" type="1" managed-name="OptionEntry" />
* </array> */
        /* transfer-ownership:none direction:in */
        System.IntPtr entries);

        /// <summary>
        /// Increments the reference count of @group by one.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <returns>
        /// a #GoptionGroup
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_option_group_ref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);
        public override System.IntPtr Take() => g_option_group_ref(Handle);

        /// <summary>
        /// Associates two functions with @group which will be called
        /// from g_option_context_parse() before the first option is parsed
        /// and after the last option has been parsed, respectively.
        /// </summary>
        /// <remarks>
        /// Note that the user data to be passed to @pre_parse_func and
        /// @post_parse_func can be specified when constructing the group
        /// with g_option_group_new().
        /// </remarks>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="preParseFunc">
        /// a function to call before parsing, or %NULL
        /// </param>
        /// <param name="postParseFunc">
        /// a function to call after parsing, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_parse_hooks(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc preParseFunc,
        /* <type name="OptionParseFunc" type="GOptionParseFunc" managed-name="OptionParseFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GLib.UnmanagedOptionParseFunc postParseFunc);

        /// <summary>
        /// Sets the function which is used to translate user-visible strings,
        /// for `--help` output. Different groups can use different
        /// #GTranslateFuncs. If @func is %NULL, strings are not translated.
        /// </summary>
        /// <remarks>
        /// If you are using gettext(), you only need to set the translation
        /// domain, see g_option_group_set_translation_domain().
        /// </remarks>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="func">
        /// the #GTranslateFunc, or %NULL
        /// </param>
        /// <param name="data">
        /// user data to pass to @func, or %NULL
        /// </param>
        /// <param name="destroyNotify">
        /// a function which gets called to free @data, or %NULL
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_translate_func(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="TranslateFunc" type="GTranslateFunc" managed-name="UnmanagedTranslateFunc" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:notified closure:1 destroy:2 direction:in */
        GISharp.Lib.GLib.UnmanagedTranslateFunc func,
        /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr data,
        /* <type name="DestroyNotify" type="GDestroyNotify" managed-name="UnmanagedDestroyNotify" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 scope:async direction:in */
        GISharp.Lib.GLib.UnmanagedDestroyNotify destroyNotify);

        /// <summary>
        /// Sets the function which is used to translate user-visible strings,
        /// for `--help` output. Different groups can use different
        /// #GTranslateFuncs. If <paramref name="func"/> is <c>null</c>, strings are not translated.
        /// </summary>
        /// <remarks>
        /// If you are using gettext(), you only need to set the translation
        /// domain, see <see cref="SetTranslationDomain"/>.
        /// </remarks>
        /// <param name="func">
        /// the <see cref="TranslateFunc"/>, or <c>null</c>
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslateFunc(GISharp.Lib.GLib.TranslateFunc func)
        {
            var group_ = Handle;
            var (func_, destroyNotify_, data_) = func == null ? (default(GISharp.Lib.GLib.UnmanagedTranslateFunc), default(GISharp.Lib.GLib.UnmanagedDestroyNotify), default(System.IntPtr)) : GISharp.Lib.GLib.TranslateFuncFactory.Create(func, GISharp.Runtime.CallbackScope.Notified);
            g_option_group_set_translate_func(group_, func_, data_, destroyNotify_);
        }

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_set_translation_domain(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr domain);

        /// <summary>
        /// A convenience function to use gettext() for translating
        /// user-visible strings.
        /// </summary>
        /// <param name="domain">
        /// the domain to use
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public unsafe void SetTranslationDomain(GISharp.Lib.GLib.Utf8 domain)
        {
            var group_ = Handle;
            var domain_ = domain?.Handle ?? throw new System.ArgumentNullException(nameof(domain));
            g_option_group_set_translation_domain(group_, domain_);
        }

        /// <summary>
        /// Decrements the reference count of @group by one.
        /// If the reference count drops to 0, the @group will be freed.
        /// and all memory allocated by the @group is released.
        /// </summary>
        /// <param name="group">
        /// a #GOptionGroup
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.44")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_option_group_unref(
        /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr group);
    }

    /// <summary>
    /// The type of function that can be called before and after parsing.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
    /* transfer-ownership:none skip:1 direction:out */
    public unsafe delegate System.Boolean UnmanagedOptionParseFunc(
    /* <type name="OptionContext" type="GOptionContext*" managed-name="OptionContext" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr context,
    /* <type name="OptionGroup" type="GOptionGroup*" managed-name="OptionGroup" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr group,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:2 direction:in */
    System.IntPtr data,
    /* <type name="GLib.Error" type="GError**" managed-name="GISharp.Lib.GLib.Error" is-pointer="1" /> */
    /* direction:inout transfer-ownership:full */
    System.IntPtr* error);

    /// <summary>
    /// The type of function that can be called before and after parsing.
    /// </summary>
    public delegate void OptionParseFunc(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group);

    /// <summary>
    /// Factory for creating <see cref="OptionParseFunc"/> methods.
    /// </summary>
    public static class OptionParseFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.OptionParseFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedOptionParseFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.OptionParseFunc Create(GISharp.Lib.GLib.UnmanagedOptionParseFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe void callback_(GISharp.Lib.GLib.OptionContext context, GISharp.Lib.GLib.OptionGroup group)
            {
                var data_ = userData;
                var context_ = context?.Handle ?? throw new System.ArgumentNullException(nameof(context));
                var group_ = group?.Handle ?? throw new System.ArgumentNullException(nameof(group));
                var error_ = System.IntPtr.Zero;
                callback(context_, group_, data_, &error_);
                if (error_ != System.IntPtr.Zero)
                {
                    var error = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Error>(error_, GISharp.Runtime.Transfer.Full);
                    throw new GISharp.Runtime.GErrorException(error);
                }
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="OptionParseFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static unsafe (GISharp.Lib.GLib.UnmanagedOptionParseFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.OptionParseFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe System.Boolean UnmanagedCallback(System.IntPtr context_, System.IntPtr group_, System.IntPtr data_, System.IntPtr* error_)
        {
            try
            {
                var context = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionContext>(context_, GISharp.Runtime.Transfer.None);
                var group = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.OptionGroup>(group_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                data.ManagedDelegate(context, group);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.Boolean);
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// An enumeration specifying the base position for a
    /// g_io_channel_seek_position() operation.
    /// </summary>
    public enum SeekType
    {
        /// <summary>
        /// the current position in the file.
        /// </summary>
        Current = 0,
        /// <summary>
        /// the start of the file.
        /// </summary>
        Start = 1,
        /// <summary>
        /// the end of the file.
        /// </summary>
        End = 2
    }

    /// <summary>
    /// Disambiguates a given time in two ways.
    /// </summary>
    /// <remarks>
    /// First, specifies if the given time is in universal or local time.
    /// 
    /// Second, if the time is in local time, specifies if it is local
    /// standard time or local daylight time.  This is important for the case
    /// where the same local time occurs twice (during daylight savings time
    /// transitions, for example).
    /// </remarks>
    public enum TimeType
    {
        /// <summary>
        /// the time is in local standard time
        /// </summary>
        Standard = 0,
        /// <summary>
        /// the time is in local daylight time
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// the time is in UTC
        /// </summary>
        Universal = 2
    }

    /// <summary>
    /// Represents a precise time, with seconds and microseconds.
    /// Similar to the struct timeval returned by the gettimeofday()
    /// UNIX system call.
    /// </summary>
    /// <remarks>
    /// GLib is attempting to unify around the use of 64bit integers to
    /// represent microsecond-precision time. As such, this type will be
    /// removed from a future version of GLib.
    /// </remarks>
    public partial struct TimeVal
    {
#pragma warning disable CS0649
        /// <summary>
        /// seconds
        /// </summary>
        public GISharp.Runtime.NativeLong TvSec;

        /// <summary>
        /// microseconds
        /// </summary>
        public GISharp.Runtime.NativeLong TvUsec;

#pragma warning restore CS0649 /// <summary>
                               /// Converts a string containing an ISO 8601 encoded date and time
                               /// to a #GTimeVal and puts it into @time_.
                               /// </summary>
                               /// <remarks>
                               /// @iso_date must include year, month, day, hours, minutes, and
                               /// seconds. It can optionally include fractions of a second and a time
                               /// zone indicator. (In the absence of any time zone indication, the
                               /// timestamp is assumed to be in local time.)
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
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_time_val_from_iso8601(
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr isoDate,
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* direction:out caller-allocates:1 transfer-ownership:none */
        GISharp.Lib.GLib.TimeVal* time);

        /// <summary>
        /// Converts a string containing an ISO 8601 encoded date and time
        /// to a <see cref="TimeVal"/> and puts it into <paramref name="time"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="isoDate"/> must include year, month, day, hours, minutes, and
        /// seconds. It can optionally include fractions of a second and a time
        /// zone indicator. (In the absence of any time zone indication, the
        /// timestamp is assumed to be in local time.)
        /// </remarks>
        /// <param name="isoDate">
        /// an ISO 8601 encoded date string
        /// </param>
        /// <param name="time">
        /// a <see cref="TimeVal"/>
        /// </param>
        /// <returns>
        /// <c>true</c> if the conversion was successful.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public static unsafe System.Boolean TryFromIso8601(GISharp.Lib.GLib.Utf8 isoDate, out GISharp.Lib.GLib.TimeVal time)
        {
            var isoDate_ = isoDate?.Handle ?? throw new System.ArgumentNullException(nameof(isoDate));
            GISharp.Lib.GLib.TimeVal time_;
            var ret_ = g_time_val_from_iso8601(isoDate_,&time_);
            time = (GISharp.Lib.GLib.TimeVal)time_;
            var ret = (System.Boolean)ret_;
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
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_time_val_add(
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* time,
        /* <type name="glong" type="glong" managed-name="System.Int64" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Runtime.NativeLong microseconds);

        /// <summary>
        /// Adds the given number of microseconds to <paramref name="time"/>. <paramref name="microseconds"/> can
        /// also be negative to decrease the value of <paramref name="time"/>.
        /// </summary>
        /// <param name="microseconds">
        /// number of microseconds to add to <paramref name="time"/>
        /// </param>
        public unsafe void Add(System.Int64 microseconds)
        {
            var time_ = this;
            var microseconds_ = (GISharp.Runtime.NativeLong)microseconds;
            g_time_val_add(&time_, microseconds_);
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
        /// %NULL will be returned. This is platform dependent, but it is safe to assume
        /// years up to 3000 are supported. The return value of g_time_val_to_iso8601()
        /// has been nullable since GLib 2.54; before then, GLib would crash under the
        /// same conditions.
        /// </remarks>
        /// <param name="time">
        /// a #GTimeVal
        /// </param>
        /// <returns>
        /// a newly allocated string containing an ISO 8601 date,
        ///    or %NULL if @time_ was too large
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:full nullable:1 direction:out */
        static extern unsafe System.IntPtr g_time_val_to_iso8601(
        /* <type name="TimeVal" type="GTimeVal*" managed-name="TimeVal" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GLib.TimeVal* time);

        /// <summary>
        /// Converts <paramref name="time"/> into an RFC 3339 encoded string, relative to the
        /// Coordinated Universal Time (UTC). This is one of the many formats
        /// allowed by ISO 8601.
        /// </summary>
        /// <remarks>
        /// ISO 8601 allows a large number of date/time formats, with or without
        /// punctuation and optional elements. The format returned by this function
        /// is a complete date and time, with optional punctuation included, the
        /// UTC time zone represented as "Z", and the <paramref name="tvUsec"/> part included if
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
        /// Use <see cref="Format"/> or g_strdup_printf() if a different
        /// variation of ISO 8601 format is required.
        /// 
        /// If <paramref name="time"/> represents a date which is too large to fit into a `struct tm`,
        /// <c>null</c> will be returned. This is platform dependent, but it is safe to assume
        /// years up to 3000 are supported. The return value of <see cref="ToIso8601"/>
        /// has been nullable since GLib 2.54; before then, GLib would crash under the
        /// same conditions.
        /// </remarks>
        /// <returns>
        /// a newly allocated string containing an ISO 8601 date,
        ///    or <c>null</c> if <paramref name="time"/> was too large
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.12")]
        public unsafe GISharp.Lib.GLib.Utf8 ToIso8601()
        {
            var time_ = this;
            var ret_ = g_time_val_to_iso8601(&time_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }
    }

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
        /// This is equivalent to calling <see cref="New"/> with the value of
        /// the `TZ` environment variable (including the possibility of <c>null</c>).
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
        /// when you are done with it.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.TimeZone Local { get => GetLocal(); }

        /// <summary>
        /// Creates a <see cref="TimeZone"/> corresponding to UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="New"/> with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
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
        /// <see cref="GetLocal"/> calls this function with the value of the
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
        /// You should release the return value by calling <see cref="Unref"/>
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
        /// <see cref="GetLocal"/> calls this function with the value of the
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
        /// You should release the return value by calling <see cref="Unref"/>
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
        /// This is equivalent to calling <see cref="New"/> with the value of
        /// the `TZ` environment variable (including the possibility of <c>null</c>).
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
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
        /// This is equivalent to calling <see cref="New"/> with a value like
        /// "Z", "UTC", "+00", etc.
        /// 
        /// You should release the return value by calling <see cref="Unref"/>
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
        /// This function is similar to <see cref="FindInterval"/>, with the
        /// difference that it always succeeds (by making the adjustments
        /// described below).
        /// 
        /// In any of the cases where <see cref="FindInterval"/> succeeds then
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

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:out */
    public unsafe delegate System.IntPtr UnmanagedTranslateFunc(
    /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    System.IntPtr str,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 closure:1 direction:in */
    System.IntPtr data);

    /// <summary>
    /// The type of functions which are used to translate user-visible
    /// strings, for &lt;option&gt;--help&lt;/option&gt; output.
    /// </summary>
    public delegate GISharp.Lib.GLib.Utf8 TranslateFunc(GISharp.Lib.GLib.Utf8 str);

    /// <summary>
    /// Factory for creating <see cref="TranslateFunc"/> methods.
    /// </summary>
    public static class TranslateFuncFactory
    {
        unsafe class UserData
        {
            public GISharp.Lib.GLib.TranslateFunc ManagedDelegate;
            public GISharp.Lib.GLib.UnmanagedTranslateFunc UnmanagedDelegate;
            public GISharp.Lib.GLib.UnmanagedDestroyNotify DestroyDelegate;
            public GISharp.Runtime.CallbackScope Scope;
        }

        public static GISharp.Lib.GLib.TranslateFunc Create(GISharp.Lib.GLib.UnmanagedTranslateFunc callback, System.IntPtr userData)
        {
            if (callback == null)
            {
                throw new System.ArgumentNullException(nameof(callback));
            }

            unsafe GISharp.Lib.GLib.Utf8 callback_(GISharp.Lib.GLib.Utf8 str)
            {
                var data_ = userData;
                var str_ = str?.Handle ?? throw new System.ArgumentNullException(nameof(str));
                var ret_ = callback(str_,data_);
                var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
                return ret;
            }

            return callback_;
        }

        /// <summary>
        /// Wraps a <see cref="TranslateFunc"/> in an anonymous method that can
        /// be passed to unmanaged code.
        /// </summary>
        /// <param name="method">The managed method to wrap.</param>
        /// <param name="scope">The lifetime scope of the callback.</param>
        /// <returns>
        /// A tuple containing the unmanaged callback, the unmanaged
        /// notify function and a pointer to the user data.
        /// </returns>
        /// <remarks>
        /// This function is used to marshal managed callbacks to unmanged
        /// code. If the scope is <see cref="GISharp.Runtime.CallbackScope.Call"/>
        /// then it is the caller's responsibility to invoke the notify function
        /// when the callback is no longer needed. If the scope is
        /// <see cref="GISharp.Runtime.CallbackScope.Async"/>, then the notify
        /// function should be ignored.
        /// </remarks>
        public static unsafe (GISharp.Lib.GLib.UnmanagedTranslateFunc, GISharp.Lib.GLib.UnmanagedDestroyNotify, System.IntPtr) Create(GISharp.Lib.GLib.TranslateFunc callback, GISharp.Runtime.CallbackScope scope)
        {
            var userData = new UserData
            {
                ManagedDelegate = callback ?? throw new System.ArgumentNullException(nameof(callback)),
                UnmanagedDelegate = UnmanagedCallback,
                DestroyDelegate = Destroy,
                Scope = scope
            };
            var userData_ = (System.IntPtr)System.Runtime.InteropServices.GCHandle.Alloc(userData);
            return (userData.UnmanagedDelegate, userData.DestroyDelegate, userData_);
        }

        static unsafe System.IntPtr UnmanagedCallback(System.IntPtr str_, System.IntPtr data_)
        {
            try
            {
                var str = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(str_, GISharp.Runtime.Transfer.None);
                var gcHandle = (System.Runtime.InteropServices.GCHandle)data_;
                var data = (UserData)gcHandle.Target;
                var ret = data.ManagedDelegate(str);
                if (data.Scope == GISharp.Runtime.CallbackScope.Async)
                {
                    Destroy(data_);
                }
                var ret_ = ret?.Handle ?? throw new System.ArgumentNullException(nameof(ret));
                return ret_;
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }

            return default(System.IntPtr);
        }

        static void Destroy(System.IntPtr userData_)
        {
            try
            {
                var gcHandle = (System.Runtime.InteropServices.GCHandle)userData_;
                gcHandle.Free();
            }
            catch (System.Exception ex)
            {
                GISharp.Lib.GLib.Log.LogUnhandledException(ex);
            }
        }
    }

    /// <summary>
    /// A utility type for constructing container-type #GVariant instances.
    /// </summary>
    /// <remarks>
    /// This is an opaque structure and may only be accessed using the
    /// following functions.
    /// 
    /// <see cref="VariantBuilder"/> is not threadsafe in any way.  Do not attempt to
    /// access it from more than one thread.
    /// </remarks>
    [GISharp.Runtime.GTypeAttribute("GVariantBuilder", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantBuilder : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_variant_builder_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantBuilder(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantBuilder.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_builder_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a #GVariantBuilder directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a #GVariantBuilder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_builder_new(
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr type);

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantBuilder"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a <see cref="VariantBuilder"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        /// <returns>
        /// a <see cref="VariantBuilder"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.VariantType type)
        {
            AssertNewArgs(type);
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            var ret_ = g_variant_builder_new(type_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantBuilder"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In most cases it is easier to place a <see cref="VariantBuilder"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_builder_init().
        /// </remarks>
        /// <param name="type">
        /// a container type
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public VariantBuilder(GISharp.Lib.GLib.VariantType type) : this(New(type), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_variant_builder_get_type();

        /// <summary>
        /// Adds @value to @builder.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If @value is a floating reference (see g_variant_ref_sink()),
        /// the @builder instance takes ownership of @value.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_add_value(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Adds <paramref name="value"/> to <paramref name="builder"/>.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed.  Some examples of this are
        /// putting different types of items into an array, putting the wrong
        /// types or number of items in a tuple, putting more than one value into
        /// a variant, etc.
        /// 
        /// If <paramref name="value"/> is a floating reference (see g_variant_ref_sink()),
        /// the <paramref name="builder"/> instance takes ownership of <paramref name="value"/>.
        /// </remarks>
        /// <param name="value">
        /// a #GVariant
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Add(GISharp.Lib.GLib.Variant value)
        {
            var builder_ = Handle;
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_variant_builder_add_value(builder_, value_);
        }

        /// <summary>
        /// Closes the subcontainer inside the given @builder that was opened by
        /// the most recent call to g_variant_builder_open().
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_close(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);

        /// <summary>
        /// Closes the subcontainer inside the given <paramref name="builder"/> that was opened by
        /// the most recent call to <see cref="Open"/>.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: too few values added to the
        /// subcontainer).
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Close()
        {
            var builder_ = Handle;
            g_variant_builder_close(builder_);
        }

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @builder in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated #GVariantBuilder) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// g_variant_builder_end().
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_variant_builder_end(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);

        /// <summary>
        /// Ends the builder process and returns the constructed value.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use <paramref name="builder"/> in any way after this call
        /// except for reference counting operations (in the case of a
        /// heap-allocated <see cref="VariantBuilder"/>) or by reinitialising it with
        /// g_variant_builder_init() (in the case of stack-allocated). This
        /// means that for the stack-allocated builders there is no need to
        /// call g_variant_builder_clear() after the call to
        /// <see cref="End"/>.
        /// 
        /// It is an error to call this function in any way that would create an
        /// inconsistent value to be constructed (ie: insufficient number of
        /// items added to a container with a specific number of children
        /// required).  It is also an error to call this function if the builder
        /// was created with an indefinite array or maybe type and no children
        /// have been added; in this case it is impossible to infer the type of
        /// the empty array.
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe GISharp.Lib.GLib.Variant End()
        {
            var builder_ = Handle;
            var ret_ = g_variant_builder_end(builder_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Opens a subcontainer inside the given @builder.  When done adding
        /// items to the subcontainer, g_variant_builder_close() must be called. @type
        /// is the type of the container: so to build a tuple of several values, @type
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder
        /// </param>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_open(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr type);

        /// <summary>
        /// Opens a subcontainer inside the given <paramref name="builder"/>.  When done adding
        /// items to the subcontainer, <see cref="Close"/> must be called. <paramref name="type"/>
        /// is the type of the container: so to build a tuple of several values, <paramref name="type"/>
        /// must include the tuple itself.
        /// </summary>
        /// <remarks>
        /// It is an error to call this function in any way that would cause an
        /// inconsistent value to be constructed (ie: adding too many values or
        /// a value of an incorrect type).
        /// 
        /// Example of building a nested variant:
        /// |[&lt;!-- language="C" --&gt;
        /// GVariantBuilder builder;
        /// guint32 some_number = get_number ();
        /// g_autoptr (GHashTable) some_dict = get_dict ();
        /// GHashTableIter iter;
        /// const gchar *key;
        /// const GVariant *value;
        /// g_autoptr (GVariant) output = NULL;
        /// 
        /// g_variant_builder_init (&amp;builder, G_VARIANT_TYPE ("(ua{sv})"));
        /// g_variant_builder_add (&amp;builder, "u", some_number);
        /// g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("a{sv}"));
        /// 
        /// g_hash_table_iter_init (&amp;iter, some_dict);
        /// while (g_hash_table_iter_next (&amp;iter, (gpointer *) &amp;key, (gpointer *) &amp;value))
        ///   {
        ///     g_variant_builder_open (&amp;builder, G_VARIANT_TYPE ("{sv}"));
        ///     g_variant_builder_add (&amp;builder, "s", key);
        ///     g_variant_builder_add (&amp;builder, "v", value);
        ///     g_variant_builder_close (&amp;builder);
        ///   }
        /// 
        /// g_variant_builder_close (&amp;builder);
        /// 
        /// output = g_variant_builder_end (&amp;builder);
        /// ]|
        /// </remarks>
        /// <param name="type">
        /// the #GVariantType of the container
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        public unsafe void Open(GISharp.Lib.GLib.VariantType type)
        {
            var builder_ = Handle;
            var type_ = type?.Handle ?? throw new System.ArgumentNullException(nameof(type));
            g_variant_builder_open(builder_, type_);
        }

        /// <summary>
        /// Increases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        /// <returns>
        /// a new reference to @builder
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_builder_ref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr builder);
        public override System.IntPtr Take() => g_variant_builder_ref(Handle);

        /// <summary>
        /// Decreases the reference count on @builder.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantBuilder.
        /// 
        /// Don't call this on stack-allocated #GVariantBuilder instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="builder">
        /// a #GVariantBuilder allocated by g_variant_builder_new()
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.24")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_builder_unref(
        /* <type name="VariantBuilder" type="GVariantBuilder*" managed-name="VariantBuilder" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr builder);
    }

    /// <summary>
    /// <see cref="VariantDict"/> is a mutable interface to #GVariant dictionaries.
    /// </summary>
    /// <remarks>
    /// It can be used for doing a sequence of dictionary lookups in an
    /// efficient way on an existing #GVariant dictionary or it can be used
    /// to construct new dictionaries with a hashtable-like interface.  It
    /// can also be used for taking existing dictionaries and modifying them
    /// in order to create new ones.
    /// 
    /// <see cref="VariantDict"/> can only be used with %G_VARIANT_TYPE_VARDICT
    /// dictionaries.
    /// 
    /// It is possible to use <see cref="VariantDict"/> allocated on the stack or on the
    /// heap.  When using a stack-allocated <see cref="VariantDict"/>, you begin with a
    /// call to g_variant_dict_init() and free the resources with a call to
    /// g_variant_dict_clear().
    /// 
    /// Heap-allocated <see cref="VariantDict"/> follows normal refcounting rules: you
    /// allocate it with <see cref="New"/> and use <see cref="Ref"/>
    /// and <see cref="Unref"/>.
    /// 
    /// <see cref="End"/> is used to convert the <see cref="VariantDict"/> back into a
    /// dictionary-type #GVariant.  When used with stack-allocated instances,
    /// this also implicitly frees all associated memory, but for
    /// heap-allocated instances, you must still call <see cref="Unref"/>
    /// afterwards.
    /// 
    /// You will typically want to use a heap-allocated <see cref="VariantDict"/> when
    /// you expose it as part of an API.  For most other uses, the
    /// stack-allocated form will be more convenient.
    /// 
    /// Consider the following two examples that do the same thing in each
    /// style: take an existing dictionary and look up the "count" uint32
    /// key, adding 1 to it if it is found, or returning an error if the
    /// key is not found.  Each returns the new dictionary as a floating
    /// #GVariant.
    /// 
    /// ## Using a stack-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict dict;
    ///     guint32 count;
    /// 
    ///     g_variant_dict_init (&amp;dict, orig);
    ///     if (!g_variant_dict_lookup (&amp;dict, "count", "u", &amp;count))
    ///       {
    ///         g_set_error (...);
    ///         g_variant_dict_clear (&amp;dict);
    ///         return NULL;
    ///       }
    /// 
    ///     g_variant_dict_insert (&amp;dict, "count", "u", count + 1);
    /// 
    ///     return g_variant_dict_end (&amp;dict);
    ///   }
    /// ]|
    /// 
    /// ## Using heap-allocated GVariantDict
    /// 
    /// |[&lt;!-- language="C" --&gt;
    ///   GVariant *
    ///   add_to_count (GVariant  *orig,
    ///                 GError   **error)
    ///   {
    ///     GVariantDict *dict;
    ///     GVariant *result;
    ///     guint32 count;
    /// 
    ///     dict = g_variant_dict_new (orig);
    /// 
    ///     if (g_variant_dict_lookup (dict, "count", "u", &amp;count))
    ///       {
    ///         g_variant_dict_insert (dict, "count", "u", count + 1);
    ///         result = g_variant_dict_end (dict);
    ///       }
    ///     else
    ///       {
    ///         g_set_error (...);
    ///         result = NULL;
    ///       }
    /// 
    ///     g_variant_dict_unref (dict);
    /// 
    ///     return result;
    ///   }
    /// ]|
    /// </remarks>
    [GISharp.Runtime.SinceAttribute("2.40")]
    [GISharp.Runtime.GTypeAttribute("GVariantDict", IsProxyForUnmanagedType = true)]
    public sealed partial class VariantDict : GISharp.Lib.GObject.Boxed
    {
        static readonly GISharp.Lib.GObject.GType _GType = g_variant_dict_get_type();

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public VariantDict(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(_GType, handle, ownership)
        {
        }

        /// <summary>
        /// Allocates and initialises a new #GVariantDict.
        /// </summary>
        /// <remarks>
        /// You should call g_variant_dict_unref() on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a #GVariantDict directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using #GVariantDict to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a #GVariantDict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_new(
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr fromAsv);

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a <see cref="VariantDict"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using <see cref="VariantDict"/> to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        /// <returns>
        /// a <see cref="VariantDict"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        static unsafe System.IntPtr New(GISharp.Lib.GLib.Variant fromAsv)
        {
            AssertNewArgs(fromAsv);
            var fromAsv_ = fromAsv?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_new(fromAsv_);
            return ret_;
        }

        /// <summary>
        /// Allocates and initialises a new <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// You should call <see cref="Unref"/> on the return value when it
        /// is no longer needed.  The memory will not be automatically freed by
        /// any other call.
        /// 
        /// In some cases it may be easier to place a <see cref="VariantDict"/> directly on
        /// the stack of the calling function and initialise it with
        /// g_variant_dict_init().  This is particularly useful when you are
        /// using <see cref="VariantDict"/> to construct a #GVariant.
        /// </remarks>
        /// <param name="fromAsv">
        /// the #GVariant with which to initialise the
        ///   dictionary
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public VariantDict(GISharp.Lib.GLib.Variant fromAsv) : this(New(fromAsv), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe GISharp.Lib.GObject.GType g_variant_dict_get_type();

        /// <summary>
        /// Checks if @key exists in @dict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// %TRUE if @key is in @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_variant_dict_contains(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key);

        /// <summary>
        /// Checks if <paramref name="key"/> exists in <paramref name="dict"/>.
        /// </summary>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="key"/> is in <paramref name="dict"/>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe System.Boolean Contains(GISharp.Lib.GLib.Utf8 key)
        {
            var dict_ = Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var ret_ = g_variant_dict_contains(dict_,key_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Returns the current value of @dict as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use @dict in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// #GVariantDict) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr g_variant_dict_end(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict);

        /// <summary>
        /// Returns the current value of <paramref name="dict"/> as a #GVariant of type
        /// %G_VARIANT_TYPE_VARDICT, clearing it in the process.
        /// </summary>
        /// <remarks>
        /// It is not permissible to use <paramref name="dict"/> in any way after this call except
        /// for reference counting operations (in the case of a heap-allocated
        /// <see cref="VariantDict"/>) or by reinitialising it with g_variant_dict_init() (in
        /// the case of stack-allocated).
        /// </remarks>
        /// <returns>
        /// a new, floating, #GVariant
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe GISharp.Lib.GLib.Variant End()
        {
            var dict_ = Handle;
            var ret_ = g_variant_dict_end(dict_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Inserts (or replaces) a key in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// @value is consumed if it is floating.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_dict_insert_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr value);

        /// <summary>
        /// Inserts (or replaces) a key in a <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// <paramref name="value"/> is consumed if it is floating.
        /// </remarks>
        /// <param name="key">
        /// the key to insert a value for
        /// </param>
        /// <param name="value">
        /// the value to insert
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe void Insert(GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.Variant value)
        {
            var dict_ = Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var value_ = value?.Handle ?? throw new System.ArgumentNullException(nameof(value));
            g_variant_dict_insert_value(dict_, key_, value_);
        }

        /// <summary>
        /// Looks up a value in a #GVariantDict.
        /// </summary>
        /// <remarks>
        /// If @key is not found in @dictionary, %NULL is returned.
        /// 
        /// The @expected_type string specifies what type of value is expected.
        /// If the value associated with @key has a different type then %NULL is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If @expected_type was specified then any non-%NULL return
        /// value will have this type.
        /// </remarks>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or %NULL
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or %NULL
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Variant" type="GVariant*" managed-name="Variant" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_lookup_value(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key,
        /* <type name="VariantType" type="const GVariantType*" managed-name="VariantType" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        System.IntPtr expectedType);

        /// <summary>
        /// Looks up a value in a <see cref="VariantDict"/>.
        /// </summary>
        /// <remarks>
        /// If <paramref name="key"/> is not found in <paramref name="dictionary"/>, <c>null</c> is returned.
        /// 
        /// The <paramref name="expectedType"/> string specifies what type of value is expected.
        /// If the value associated with <paramref name="key"/> has a different type then <c>null</c> is
        /// returned.
        /// 
        /// If the key is found and the value has the correct type, it is
        /// returned.  If <paramref name="expectedType"/> was specified then any non-<c>null</c> return
        /// value will have this type.
        /// </remarks>
        /// <param name="key">
        /// the key to lookup in the dictionary
        /// </param>
        /// <param name="expectedType">
        /// a #GVariantType, or <c>null</c>
        /// </param>
        /// <returns>
        /// the value of the dictionary key, or <c>null</c>
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe GISharp.Lib.GLib.Variant Lookup(GISharp.Lib.GLib.Utf8 key, GISharp.Lib.GLib.VariantType expectedType = null)
        {
            var dict_ = Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var expectedType_ = expectedType?.Handle ?? System.IntPtr.Zero;
            var ret_ = g_variant_dict_lookup_value(dict_,key_,expectedType_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Variant>(ret_, GISharp.Runtime.Transfer.Full);
            return ret;
        }

        /// <summary>
        /// Increases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        /// <returns>
        /// a new reference to @dict
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:out */
        static extern unsafe System.IntPtr g_variant_dict_ref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict);
        public override System.IntPtr Take() => g_variant_dict_ref(Handle);

        /// <summary>
        /// Removes a key and its associated value from a #GVariantDict.
        /// </summary>
        /// <param name="dict">
        /// a #GVariantDict
        /// </param>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// %TRUE if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="gboolean" type="gboolean" managed-name="System.Boolean" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.Boolean g_variant_dict_remove(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr dict,
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        System.IntPtr key);

        /// <summary>
        /// Removes a key and its associated value from a <see cref="VariantDict"/>.
        /// </summary>
        /// <param name="key">
        /// the key to remove
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found and removed
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.40")]
        public unsafe System.Boolean Remove(GISharp.Lib.GLib.Utf8 key)
        {
            var dict_ = Handle;
            var key_ = key?.Handle ?? throw new System.ArgumentNullException(nameof(key));
            var ret_ = g_variant_dict_remove(dict_,key_);
            var ret = (System.Boolean)ret_;
            return ret;
        }

        /// <summary>
        /// Decreases the reference count on @dict.
        /// </summary>
        /// <remarks>
        /// In the event that there are no more references, releases all memory
        /// associated with the #GVariantDict.
        /// 
        /// Don't call this on stack-allocated #GVariantDict instances or bad
        /// things will happen.
        /// </remarks>
        /// <param name="dict">
        /// a heap-allocated #GVariantDict
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.40")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe void g_variant_dict_unref(
        /* <type name="VariantDict" type="GVariantDict*" managed-name="VariantDict" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        System.IntPtr dict);
    }

    public static partial class Version
    {
        /// <summary>
        /// The major version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #glib_major_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 major = 2;

        /// <summary>
        /// The micro version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_micro_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 micro = 0;

        /// <summary>
        /// The minor version number of the GLib library.
        /// </summary>
        /// <remarks>
        /// Like #gtk_minor_version, but from the headers used at
        /// application compile time, rather than from the library
        /// linked against at application run time.
        /// </remarks>
        private const System.Int32 minor = 56;

        /// <summary>
        /// A macro that should be defined by the user prior to including
        /// the glib.h header.
        /// The definition should be one of the predefined GLib version
        /// macros: %GLIB_VERSION_2_26, %GLIB_VERSION_2_28,...
        /// </summary>
        /// <remarks>
        /// This macro defines the earliest version of GLib that the package is
        /// required to be able to compile against.
        /// 
        /// If the compiler is configured to warn about the use of deprecated
        /// functions, then using functions that were deprecated in version
        /// %GLIB_VERSION_MIN_REQUIRED or earlier will cause warnings (but
        /// using functions deprecated in later releases will not).
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.32")]
        private const System.Int32 minRequired = 2;

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// @required_major.required_minor.@required_micro. Second
        /// the running library must be binary compatible with the
        /// version @required_major.required_minor.@required_micro
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// %NULL if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:out */
        static extern unsafe System.IntPtr glib_check_version(
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMajor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMinor,
        /* <type name="guint" type="guint" managed-name="System.UInt32" /> */
        /* transfer-ownership:none direction:in */
        System.UInt32 requiredMicro);

        /// <summary>
        /// Checks that the GLib library in use is compatible with the
        /// given version. Generally you would pass in the constants
        /// #GLIB_MAJOR_VERSION, #GLIB_MINOR_VERSION, #GLIB_MICRO_VERSION
        /// as the three arguments to this function; that produces
        /// a check that the library in use is compatible with
        /// the version of GLib the application or module was compiled
        /// against.
        /// </summary>
        /// <remarks>
        /// Compatibility is defined by two things: first the version
        /// of the running library is newer than the version
        /// <paramref name="requiredMajor"/>.required_minor.<paramref name="requiredMicro"/>. Second
        /// the running library must be binary compatible with the
        /// version <paramref name="requiredMajor"/>.required_minor.<paramref name="requiredMicro"/>
        /// (same major version.)
        /// </remarks>
        /// <param name="requiredMajor">
        /// the required major version
        /// </param>
        /// <param name="requiredMinor">
        /// the required minor version
        /// </param>
        /// <param name="requiredMicro">
        /// the required micro version
        /// </param>
        /// <returns>
        /// <c>null</c> if the GLib library is compatible with the
        ///     given version, or a string describing the version mismatch.
        ///     The returned string is owned by GLib and must not be modified
        ///     or freed.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.6")]
        public static unsafe GISharp.Lib.GLib.Utf8 Check(System.UInt32 requiredMajor, System.UInt32 requiredMinor, System.UInt32 requiredMicro)
        {
            var requiredMajor_ = (System.UInt32)requiredMajor;
            var requiredMinor_ = (System.UInt32)requiredMinor;
            var requiredMicro_ = (System.UInt32)requiredMicro;
            var ret_ = glib_check_version(requiredMajor_,requiredMinor_,requiredMicro_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GLib.Utf8>(ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }
    }
}