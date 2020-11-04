using System;

namespace GISharp.Lib.GLib
{
    partial class DateTime
    {
        static void CheckArgs(int year, int month, int day, int hour, int minute, double seconds)
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

        static partial void CheckNewArgs(TimeZone tz, int year, int month, int day, int hour, int minute, double seconds)
        {
            CheckArgs(year, month, day, hour, minute, seconds);
        }

        static partial void CheckGetLocalArgs(int year, int month, int day, int hour, int minute, double seconds)
        {
            CheckArgs(year, month, day, hour, minute, seconds);
        }

        static partial void CheckGetUtcArgs(int year, int month, int day, int hour, int minute, double seconds)
        {
            CheckArgs(year, month, day, hour, minute, seconds);
        }
    }
}
