using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    class Dog : Animal
    {
        public Dog() { }
        public Dog(int age, string name, bool ismale)
        {
            base.Age = age;
            base.Name = name;
            base.Male = ismale;
        }
        public override void MakeSound()
        {
            Console.WriteLine("Bow Wow");
        }
    }
}
