using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using WaterFrontSoftware.DateTimeFunctions;
using static System.Math;
using static Waterfrontsoftware.DateTimeFunctions.Tests.DateTimeTestsHelper;

namespace Waterfrontsoftware.DateTimeFunctions.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TestDateTimeOverRideFunctions
    {
        private const string dateFormat = "MM/dd/yyyy";

        [Test]
        public void TestOverridingTheCurrentDateTime()
        {
            DateTime currentDataTime = DateTime.Now;
            DateTime overRideDataTime = DateTimeOverride.Now;

            DateTimeTestsHelper.CheckDateTime(currentDataTime, overRideDataTime);

            using (new DateTimeOverRideSetter(Christmas1900))
            {
                DateShouldBeChristmas1900(DateTimeOverride.Now, dateFormat);
            }

            Assert.IsFalse(DateTimeOverride.Now.ToString(dateFormat) == Christmas1900.ToString(dateFormat));
        }

        [Test]
        public void TestOverridingTheCurrentDateTimeUTC()
        {
            DateTime currentDataTime = DateTime.UtcNow;
            DateTime overRideDataTime = DateTimeOverride.UtcNow;

            DateTimeTestsHelper.CheckDateTime(currentDataTime, overRideDataTime);

            using (new DateTimeOverRideSetterUTC(Christmas1900))
            {
                DateShouldBeChristmas1900(DateTimeOverride.UtcNow, dateFormat);
            }

            //Make sure the current data time is not that of Christmas
            var CurrentDate = DateTimeOverride.UtcNow;
            Assert.IsFalse(CurrentDate.ToString(dateFormat) == Christmas1900.ToString(dateFormat));
        }

        [Test]
        public void TestOverridingTheCurrentDateTimeWithTwoUsings()
        {
            DateTime currentDataTime = DateTime.Now;
            DateTime overRideDataTime = DateTimeOverride.Now;

            using (new DateTimeOverRideSetter(Christmas1900))
            {
                var currentDateIs = DateTimeOverride.Now;

                using (new DateTimeOverRideSetter(Christmas1800))
                {
                    currentDateIs = DateTimeOverride.Now;
                    Assert.IsTrue(currentDateIs.ToString(dateFormat) == Christmas1800.ToString(dateFormat), $"The current date should be Christmas 2018 but it is { currentDateIs.ToString(dateFormat)}");
                }

                DateShouldBeChristmas1900(DateTimeOverride.Now, dateFormat);
            }
        }
    }


    [ExcludeFromCodeCoverage]
    internal static class DateTimeTestsHelper
    {
        static internal void CheckDateTime(DateTime currentDataTime, DateTime overRideDataTime)
        {
            bool checkTime = (Abs((currentDataTime - overRideDataTime).TotalSeconds) < 2) || (Abs((overRideDataTime - currentDataTime).TotalSeconds) < 2);
            Assert.IsTrue(checkTime, "The current datetime and the one in returned by the date Time Over Ride should be no less that 2 seconds apart");
        }

        static internal DateTime Christmas1900
        {
            get
            {
                return Convert.ToDateTime("12/25/1900 10:30 AM");
            }
        }

        static internal DateTime Christmas1800
        {
            get
            {
                return Convert.ToDateTime("12/25/1800 10:30 AM");
            }
        }

        static internal void DateShouldBeChristmas1900(DateTime currentDateIs, string dateFormat)
        {
            Assert.IsTrue(currentDateIs.ToString(dateFormat) == Christmas1900.ToString(dateFormat), $"The current date should be Christmas 1900 but it is { currentDateIs.ToString(dateFormat)}");
        }
    }
}