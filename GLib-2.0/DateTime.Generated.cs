namespace GISharp.Lib.GLib
{
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
        /// This is equivalent to calling <see cref="DateTime.GetNow"/> with the time
        /// zone returned by <see cref="TimeZone.GetLocal"/>.
        /// </remarks>
        [GISharp.Runtime.SinceAttribute("2.26")]
        public static GISharp.Lib.GLib.DateTime NowLocal { get => GetNowLocal(); }

        /// <summary>
        /// Creates a <see cref="DateTime"/> corresponding to this exact instant in UTC.
        /// </summary>
        /// <remarks>
        /// This is equivalent to calling <see cref="DateTime.GetNow"/> with the time
        /// zone returned by <see cref="TimeZone.GetUtc"/>.
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
        /// This function, taken together with <see cref="DateTime.GetWeekOfYear"/> and
        /// <see cref="DateTime.GetDayOfWeek"/> can be used to determine the full ISO
        /// week date on which <paramref name="datetime"/> falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// <see cref="DateTime.GetYear"/>), except as detailed below:
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// This call is equivalent to calling <see cref="DateTime.New"/> with the time
        /// zone returned by <see cref="TimeZone.GetLocal"/>.
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// This is equivalent to calling <see cref="DateTime.GetNow"/> with the time
        /// zone returned by <see cref="TimeZone.GetLocal"/>.
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
        /// This is equivalent to calling <see cref="DateTime.GetNow"/> with the time
        /// zone returned by <see cref="TimeZone.GetUtc"/>.
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
        /// This call is equivalent to calling <see cref="DateTime.New"/> with the time
        /// zone returned by <see cref="TimeZone.GetUtc"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        ///   <see cref="DateTime.Unref"/>.
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
        /// As with <see cref="DateTime.AddMonths"/>, if the resulting date would be 29th
        /// February on a non-leap year, the day will be clamped to 28th February.
        /// </remarks>
        /// <param name="years">
        /// the number of years
        /// </param>
        /// <returns>
        /// the newly created <see cref="DateTime"/> which should be freed with
        ///   <see cref="DateTime.Unref"/>.
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
        ///   least 4 days in the new year. See <see cref="DateTime.GetWeekOfYear"/>.
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
        /// This function, taken together with <see cref="DateTime.GetWeekOfYear"/> and
        /// <see cref="DateTime.GetDayOfWeek"/> can be used to determine the full ISO
        /// week date on which <paramref name="datetime"/> falls.
        /// 
        /// This is usually equal to the normal Gregorian year (as returned by
        /// <see cref="DateTime.GetYear"/>), except as detailed below:
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
        /// This call is equivalent to calling <see cref="DateTime.ToTimezone"/> with the
        /// time zone returned by <see cref="TimeZone.GetLocal"/>.
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
        /// You should release the return value by calling <see cref="DateTime.Unref"/>
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
        /// This call is equivalent to calling <see cref="DateTime.ToTimezone"/> with the
        /// time zone returned by <see cref="TimeZone.GetUtc"/>.
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
}