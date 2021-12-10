using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    class Kitten : Animal
    {
        public Kitten(int age, string name, bool ismale)
        {
            base.Age = age;
            base.Name = name;
            base.Male = ismale;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Small Meow");
        }
    }
}
