using System;

namespace GISharp.Lib.GLib
{
    partial class DateTime
    {
        static void AssertArgs(int year, int month, int day, int hour, int minute, double seconds)
        {
            if (year < 1 || year > 9999) {
                throw new ArgumentOutOfRangeException(nameof(year));
            }
            if (month < 1 || month > 12) {
                throw new ArgumentOutOfRangeException(nameof(month));
            }
            if (day < 1 || day > System.DateTime.DaysInMonth(year, month)) {
                throw new ArgumentOutOfRangeException(nameof(month));
            }
            if (hour < 0 || hour > 23) {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }
            if (minute < 0 || minute > 59) {
                throw new ArgumentOutOfRangeException(nameof(minute));
            }
            if (seconds < 0.0 || seconds >= 60.0) {
                throw new ArgumentOutOfRangeException(nameof(seconds));
            }
        }

        static void AssertNewArgs(TimeZone tz, int year, int month, int day, int hour, int minute, double seconds)
        {
            AssertArgs(year, month, day, hour, minute, seconds);
        }

        static void AssertGetLocalArgs(int year, int month, int day, int hour, int minute, double seconds)
        {
            AssertArgs(year, month, day, hour, minute, seconds);
        }

        static void AssertGetUtcArgs(int year, int month, int day, int hour, int minute, double seconds)
        {
            AssertArgs(year, month, day, hour, minute, seconds);
        }
    }
}
