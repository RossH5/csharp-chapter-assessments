﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human() { }
        public Human(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
    }
}
