using System;

namespace Chapter_20
{
    class Program
    {
        static void Main(string[] args)
        {

            Test newTest = new Test();
            newTest.PrintTest();


            //Question 3
            Student[] StudentArray = new Student[]
            {
                new Student(30),
                new Student(40),
                new Student(50),
                new Student(60),
                new Student(20),
                new Student(15),
                new Student(55),
                new Student(25),
                new Student(75),
                new Student(65),
            };

            Array.Sort<Student>(StudentArray);
            foreach(Student student in StudentArray)
            {
                Console.WriteLine(student.Mark);
            }


            //Question 4
            Worker[] WorkerArray = new Worker[]
            {
                new Worker(17.00m, 39.23m),
                new Worker(16.00m, 38.43m),
                new Worker(15.00m, 35.90m),
                new Worker(21.00m, 39.20m),
                new Worker(22.00m, 40.25m),
                new Worker(29.00m, 29.10m),
                new Worker(35.00m, 30.10m),
                new Worker(27.00m, 37.39m),
                new Worker(23.00m, 36.90m),
                new Worker(16.00m, 39.56m),
            };

            foreach(Worker worker in WorkerArray)
            {
                worker.CalculateHourlyWage();
            }
            Array.Sort<Worker>(WorkerArray);
            Array.Reverse<Worker>(WorkerArray);
            foreach (Worker worker in WorkerArray)
            {
                Console.WriteLine(worker.CalculateHourlyWage());
            }

            //Question 6

            Animal[] AnimalArray = new Animal[]
            {
                new Dog(5, "gigi", false),
                new Cat(7, "garfield", true),
                new Frog(4, "Froggy", true),
                new Kitten(0, "Kitten", false),
                new Tomcat(3, "Jerry", true),
                new Dog(1, "lulu", false),

            };

            foreach(Animal animal in AnimalArray)
            {
                Console.Write($"Name: {animal.Name}\nAge: {animal.Age}\n\nThe {animal.GetType()} says ");
                animal.MakeSound();
                Console.WriteLine("\n----------\n");
            }

        }
    }
}
