using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    public class Worker : Human, IComparable<Worker>
    {
        public decimal Wage { get; set; }
        public decimal HoursWorked { get; set; }
        private decimal calculatedtotalwage;

        public Worker(decimal wage, decimal hoursworked)
        {
            this.Wage = wage;
            this.HoursWorked = hoursworked;
        }
        public decimal CalculateHourlyWage()
        {
            calculatedtotalwage = this.Wage * this.HoursWorked;
            return calculatedtotalwage;
        }
        public int CompareTo(Worker other)
        {
            return calculatedtotalwage.CompareTo(other.calculatedtotalwage);
        }
    }
}
