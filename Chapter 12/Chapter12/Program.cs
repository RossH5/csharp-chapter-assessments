using System;
using System.IO;
using System.Net;

namespace Chapter12
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException()
        {

        }
        public InvalidNumberException(string message)
        {
            Console.WriteLine(message);
        }
        public InvalidNumberException(string message, Exception inner) : base(message, inner)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //QuestionSeven();
            //ReadNumber(1, 100);
            //Console.WriteLine(QuestionNine());
            QuestionThirteen();

        }
        static void QuestionSeven()
        {
            try
            {
                Console.WriteLine("Input an integer:");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput < 0)
                {
                    Console.WriteLine("Invalid Number");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(userInput));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                Console.WriteLine("Good Bye");
            }
        }
        static void ReadNumber(int start, int end)
        {
            int lastNum = start;
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    Console.WriteLine("Enter a number longer than the last entered and between {0} - {1} ({2} numbers remaining)", start, end, 10 - i);
                    int currentNum = int.Parse(Console.ReadLine());

                    if (currentNum <= lastNum)
                    {
                        throw new InvalidNumberException("Invalid number must be larger than last");
                    }
                    else if (currentNum >= end)
                    {
                        throw new InvalidNumberException("Number greater than range");
                    }
                    lastNum = currentNum;
                }
                catch (FormatException)
                {
                    i--;
                    Console.WriteLine("Please input a number");
                }
                catch (InvalidNumberException)
                {
                    i--;
                }
            }
        }
        static string QuestionNine()
        {
            string returnedText = "";
            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();
            try
            {
                returnedText = File.ReadAllText(filePath);
                return returnedText;
            }
            catch (IOException)
            {
                return "File not found";
            }
        }
        static void QuestionThirteen()
        {
            try
            {
                using (WebClient file = new WebClient())
                {
                    file.DownloadFile("https://introprogramming.info/wp-content/uploads/2017/08/csharp-book-nakov-en-v2013-cover.jpg", @"C:\Users\Ross.Henke\csharpbooknakov.jpg");
                    Console.WriteLine("Successful Download");
                }

            }
            catch (WebException)
            {
                Console.WriteLine("Incorrect file/url");
            }
        }
    }
}

