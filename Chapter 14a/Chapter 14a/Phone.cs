using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    public class Phone
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Owner { get; set; }
        public Battery Battery { get; set; }
        public Screen Screen { get; set; }
        public List<Call> CallHistory { get; set; }

        public Phone(string model, string manufacturer, decimal price, string owner = null, Battery battery = null, Screen screen = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Screen = screen;
            this.CallHistory = new List<Call>();
        }
        public override string ToString()
        {
            return $"{Manufacturer} {Model} for ${Price} owned by {Owner}.";
        }
        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }
        public void DeleteCall(Call call)
        {
            CallHistory.Remove(call);
        }
        public decimal TotalCallCost(decimal costPerMinute)
        {
            decimal totalMinutes = 0.00m;
            foreach(Call call in CallHistory)
            {
                totalMinutes += (decimal) call.Duration.TotalMinutes;
            }
            decimal cost = totalMinutes * costPerMinute;
            return cost;
        }
    }

    public class PhoneTest
    {
        public bool GivenIphoneDetails_PrintsExpectedString()
        {
            //Arrange
            Phone testPhone = new Phone("iPhone 10", "Apple", 1000.00m, "John");

            //Act
            string actualString = testPhone.ToString();

            //Assert
            Console.WriteLine("Given Phone Details Works?");
            return actualString == "Apple iPhone 10 for $1000.00 owned by John.";
        }
    }
}
