using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    public class Battery
    {
        public string Model { get; set; }
        public decimal IdleTime { get; set; }
        public decimal HoursTalk { get; set; }
        public enum BatteryType
        {
            Lilon, NiMH, NiCd
        }

        public Battery(string model, decimal idleTime, decimal hoursTalk)
        {
            this.Model = model;
            this.IdleTime = idleTime;
            this.HoursTalk = hoursTalk;
        }
        public Battery(decimal idleTime, decimal hoursTalk): this(null, idleTime, hoursTalk)
        {

        }
    }
}
