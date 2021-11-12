using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    public class Call
    {
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Call(DateTime dateTime, TimeSpan callDuration)
        {
            this.DateTime = dateTime;
            this.Duration = callDuration;
        }
    }
}
