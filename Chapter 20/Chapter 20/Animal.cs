using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    public class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool Male { get; set; }

        public Animal() { }

        public Animal(int age, string name, bool ismale)
        {
            this.Age = age;
            this.Name = name;
            this.Male = ismale;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Rawr");
        }
    }
}
