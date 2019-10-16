# WaterFrontSoftware.DateTime
This is a .net standard library used for setting and retrieving the Datetime used in C#. It gives a level of abstraction from the Datetime function given in C#, so it is possible to change the datetime used by an application without actually changing the datetime of the server that the code is running on. 

Below is a very simple example of using the UTC version of this function

             DateTimeTestsHelper.DateTimesAreWithIn2Seconds(currentDataTime, overRideDataTime);

            //Sets the current date time to be Christmas 1900
            WriteLine($"The UTC Date/Time before the using is {DateTime.UtcNow} ");
            using (new DateTimeOverRideSetterUTC(Christmas1900))
            {
                WriteLine($"The UTC Date/Time with in the using statement is Christmase 1900 {DateTimeOverride.UtcNow} ");
               
            }

            WriteLine($"The UTC Date/Time after the using statement is {DateTime.UtcNow} ");

Output from this function is ...
            
            The UTC Date/Time before the using is 10/13/2019 10:48:12 PM 
            The UTC Date/Time with in the using statement is Christmase 1900  12/25/1900 10:30:00 AM 
            The UTC Date/Time after the using statement is 10/13/2019 10:48:12 PM 

So if we wrap our test code in a using statement and use the date time overwrite vs the standard date time, We are able to override the datetime to all code that is called via the using block. This way we can change the system date in our businesslogic by just wrapping it in a using statement.


