using System;

namespace WaterFrontSoftware.DateTimeFunctions
{
    public class DateTimeOverride : DateTimeOverrideBase
    {
        public static DateTime Now
        {
            get
            {
                if (CurrentDateTime != DateTime.MinValue)
                    return CurrentDateTime;
                else
                {
                    return DateTime.Now;
                }
            }
        }

        public static DateTime UtcNow
        {
            get
            {
                if (CurrentDateTimeUtc != DateTime.MinValue)
                    return CurrentDateTimeUtc;
                else
                {
                    return DateTime.UtcNow;
                }
            }
        }
    }
}