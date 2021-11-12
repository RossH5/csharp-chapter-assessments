using System;

namespace Chapter_14a
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Ross = new Student("Ross Henke", "Marine Biology", "Science", "University of Missouri", "rosshenke@email.com", "8675309");
            Student Joe = new Student("Joe Bob", "Calculus", "Math", "University of Missouri", "joebob@email.com", "123-4567");
            Student Jill = new Student("Jill Bob", "Rocket Science", "Science", "University of Missouri", "jillbob@email.com", "123-4577");
            StudentTest tester = new StudentTest(Ross, Joe, Jill);
            tester.Printer();
        }
    }
}
