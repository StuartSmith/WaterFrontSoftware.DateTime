using NUnit.Framework;
using System;
using WaterFrontSoftware.DateTimeFunctions;

namespace Waterfrontsoftware.DateTimeFunctions.Tests
{
   [TestFixture]
    public class TestDateTimeOverRideFunctions
    {
        [Test]
        public void TestOverridingTheCurrentDateTime()
        {
            DateTime currentDataTime = DateTime.Now;
            DateTime OverRideDataTime = DateTimeOverride.Now;

            bool checkTime = ((currentDataTime - OverRideDataTime).TotalSeconds > 2) || ((OverRideDataTime -currentDataTime).TotalSeconds > 2);

            Assert.IsTrue(checkTime); 

        }

    }
}
