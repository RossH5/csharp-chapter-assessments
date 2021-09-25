using System;

namespace Chapter_1__2__4
{
    class Program
    {
        static void Main(string[] args)
        {
            //##Chapter 1##
            //1. n/a

            //2.

            //Represents the standard input, output, and error streams for console applications. This class cannot be inherited.

            //3.

            //Writes the text representation of the specified object, followed by the current line terminator, to the standard output
            //stream using the specified format information.

            //5.
            Console.WriteLine("Good day")

            //6.

            Console.Write("First"");
            Console.Write(" ");
            Console.Write("Last");

            //7. 

            Console.WriteLine(1);
            Console.WriteLine(101);
            Console.WriteLine(1001);

            //8.

            Console.WriteLine(DateTime.Now);

            //9.

            Console.WriteLine(Math.Sqrt(12345));


            //12.

            //C# is a programming language developed by microsoft that runs on the .NET Framework. The .NET framework is the environment that compiles programs (C#, VB.NET, C++ and F#) to develop applications (console applications, Windows applications with a graphical user interface, web applications)


            //##Chapter 2##
            //8.

            string hello = "Hello";
            string world = "World";
            object helloWorld = hello + " " + world;
            string worldFinal = (string)helloWorld;

            //12.

            string firstName;
            string lastName;
            int age;
            bool isManager;
            int employeeNumber;

            //##Chapter 4##
            //6.

            int a = 100;
            int b = 99;
            Console.WriteLine(Math.Max(a, b));

            //7.

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            long sumOutput = a + b + c + d + e;
            Console.WriteLine(sumOutput);
        }
    }
}
