using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14a
{
    public class Screen
    {
        public string Size { get; set; }
        public string Colors { get; set; }

        public Screen(string size, string colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
        public Screen() { }
    }
}
