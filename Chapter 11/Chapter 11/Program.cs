using System;

namespace Chapter_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Question4();
            Question9();
            Question10();
            Question11();
        }
        static void Question4()
        {
            int startTime = Environment.TickCount;
            int days = startTime / 86400000;
            int remTime = (startTime - (days * 86400000));
            int hours = remTime / 3600000;
            remTime = remTime - (hours * 3600000);
            int minutes = remTime / 60000;
            Console.WriteLine("{0}d:{1}h:{2}m", days, hours, minutes);
        }
        static void Question9()
        {
            DateTime currentDate = DateTime.Now.Date;
            Console.Write("Calculate the amount of workdays to any future date. \nGive me a future date(MM/DD/YYYY):");
            bool userInput = DateTime.TryParse(Console.ReadLine(), out DateTime futureDate);

            if (!userInput)
            {
                do
                {
                    Console.Write("Not a valid date, Please enter future date in correct format \nGive me a future date(MM/DD/YYYY):");
                    userInput = DateTime.TryParse(Console.ReadLine(), out futureDate);

                } while (!userInput);
            }

            int workDays = 0;

            while (currentDate.Date != futureDate.Date)
            {
                workDays += DayCheck(currentDate);
                currentDate = currentDate.AddDays(1);

            }

            Console.WriteLine("The number of workdays from now to {0}/{1}/{2}, is: {3}", futureDate.Month, futureDate.Day, futureDate.Year, workDays);
        }
        static int DayCheck(DateTime date)
        {
            DateTime[] workSaturdays = new DateTime[]
            {
                new DateTime(2021, 11, 06),
                new DateTime(2021, 12, 18),
                new DateTime(2022, 01, 15),
            };

            DateTime[] holidayDates = new DateTime[]
            {
                new DateTime(2021, 11, 24),
                new DateTime(2021, 12, 24),
                new DateTime(2021, 12, 25),
                new DateTime(2021, 01, 01),
                new DateTime(2022, 05, 30),
                new DateTime(2022, 07, 04),
                new DateTime(2022, 09, 05)
            };

            foreach (var saturday in workSaturdays)
            {
                if (date.Date == saturday.Date)
                {
                    return 1;
                }
            }

            foreach (var holiday in holidayDates)
            {
                if (date.Date == holiday.Date)
                {
                    return 0;
                }
            }

            if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        static void Question10()
        {
            Console.Write("Input a list of positive integers:");
            string inputList = Console.ReadLine();
            int[] numArray = Array.ConvertAll(inputList.Split(' '), Int32.Parse);
            int sum = 0;
            for (int i = 0; i <numArray.Length; i++)
            {
                sum += numArray[i];
            }
            Console.WriteLine("The sum of the input list is: {0}", sum);


        }
        static void Question11()
        {
            string[] laudatoryPhrases = new string[]
            {
                "The product is excellent.", "This is a great product.",
                "I use this product constantly.", "This is the best product from this category."
            };

            string[] laudatoryStories = new string[]
            {
                "Now I feel better.", "I managed to change.",
                "It made some miracle.", "I can’t believe it, but now I am feeling great.",
                "You should try it, too. I am very satisfied."
            };

            string[] authorFirst = new string[]
            {
                "Dayan", "Stella", "Hellen", "Kate"
            };

            string[] authorLast = new string[]
            {
                "Johnson", "Peterson", "Charls"
            };

            string[] cities = new string[]
            {
                "London", "Paris", "Berlin", "New York", "Madrid"
            };

            Random rnd = new Random();

            int phrase = rnd.Next(laudatoryPhrases.Length);
            int story = rnd.Next(laudatoryStories.Length);
            int first = rnd.Next(authorFirst.Length);
            int last = rnd.Next(authorLast.Length);
            int city = rnd.Next(cities.Length);

            Console.WriteLine("{0} {1} {2} {3} {4}", laudatoryPhrases[phrase], laudatoryStories[story], authorFirst[first], authorLast[last], cities[city]);
        }
    }
}
