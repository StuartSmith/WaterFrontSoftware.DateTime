using System;

namespace WaterFrontSoftware.DateTimeFunctions
{
    public class DateTimeOverRideSetterUTC : IDisposable
    {
        private DateTime? _dateTimeCurrent = null;

        public DateTimeOverRideSetterUTC(DateTime TimeToOverRideTo)
        {
            _dateTimeCurrent = DateTimeOverride.CurrentDateTime;
            DateTimeOverride.CurrentDateTimeUtc = TimeToOverRideTo;
        }

        public void Dispose()
        {
            DateTimeOverride.CurrentDateTimeUtc = _dateTimeCurrent.GetValueOrDefault();
        }
    }
}