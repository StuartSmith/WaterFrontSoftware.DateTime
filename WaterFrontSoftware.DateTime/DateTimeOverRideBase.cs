using System;

namespace WaterFrontSoftware.DateTimeFunctions
{
    public abstract class DateTimeOverrideBase
    {
        internal static DateTime CurrentDateTime { get; set; } = DateTime.MinValue;

        internal static DateTime CurrentDateTimeUtc { get; set; } = DateTime.MinValue;
    }
}