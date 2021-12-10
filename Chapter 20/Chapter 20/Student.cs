using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20
{
    class Student : Human, IComparable<Student>
    {
        public int Mark { get; set; }

        //public Student() { }

        public Student(int mark)
        {
            this.Mark = mark;
        }

        public int CompareTo(Student other)
        {
            return Mark.CompareTo(other.Mark);
        }
    }
}
