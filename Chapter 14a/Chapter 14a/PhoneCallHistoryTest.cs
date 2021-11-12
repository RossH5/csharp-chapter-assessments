using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    class PhoneCallHistoryTest
    {
        public bool GivenNewCall_AddsCallToCallHistory()
        {
            //arrange
            Phone testPhone = new Phone("iPhone", "Apple", 1000.00m, "Tyler");
            Call testCall = new Call(DateTime.Parse("11/12/2021 4:36 PM"), TimeSpan.FromMinutes(30));

            //act
            testPhone.AddCall(testCall);

            //assert
            Console.WriteLine("Prints True if Call is able to be added to Call History");
            return testPhone.CallHistory.Contains(testCall);
        }
    }
}
