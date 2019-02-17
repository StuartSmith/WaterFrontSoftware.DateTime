using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterFrontSoftware.DateTimeFunctions
{
    public class DateTimeOverRideSetter:IDisposable
    {
        private DateTime? _dateTimeCurrent = null;
        public DateTimeOverRideSetter(DateTime TimeToOverRideTo)
        {
           _dateTimeCurrent = DateTimeOverride.CurrentDateTime;
            DateTimeOverride.CurrentDateTime = TimeToOverRideTo;
        } 
        public void Dispose()
        {
            DateTimeOverride.CurrentDateTime = _dateTimeCurrent.GetValueOrDefault();
        }
    }
}
