using System;

namespace Chapter_9
{
    class Program
    {
        static int GetMax(int numberOne, int numberTwo)
        {
            int maxNumber = numberOne;
            if (numberTwo > numberOne)
            {
                maxNumber = numberTwo;
            }
            return maxNumber;
        }
        static void Question2()
        {
            Console.WriteLine(GetMax(4, 5));
            Console.WriteLine("Input 3 Numbers:");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(GetMax(a, b), c));

        }
        static string LastDigitReturn(int inputNumber)
        {
            int lastDigit = inputNumber % 10;
            switch (lastDigit)
            {
                case 0: 
                    return "Zero";
                case 1: 
                    return "One";
                case 2: 
                    return "Two";
                case 3: 
                    return "Three";
                case 4: 
                    return "Four"; 
                case 5: 
                    return "Five"; 
                case 6: 
                    return "Six"; 
                case 7: 
                    return "Seven"; 
                case 8: 
                    return "Eight";
                case 9: 
                    return "Nine";
                default: 
                    return "Not a digit (0-9)";
            }
        }
        static void Question3()
        {
            Console.WriteLine("Input a number:");
            int inputNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitReturn(inputNumber));

        }
        static int greatestConnected(params int[] inputArray)
        {
            for (int i = 1; i < inputArray.Length - 1; i++)
            {
                if ((inputArray[i] > inputArray[i - 1]) && (inputArray[i] > inputArray[i + 1]))
                {
                    return i;
                }
            }
            return -1;
        }
        static void Question6()
        {
            Console.Write("Enter the length of the array:");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] testArray = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Input value for index [{0}]", i);
                testArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The first occurance is at index[{0}]", greatestConnected(testArray));
        }
        static void UserMenu()
        {
            Console.WriteLine("Input what you would like to do:\n" +
                "(1 = Reverse)\n(2 = Average)\n(3 = Equation)");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine("The inputed number in reverse is: {0}",reverseOrder());
            }
            else if (userInput == 2)
            {
                Console.WriteLine("The average number from the sequence is: {0}", AverageOfSequence());
            }
            else if (userInput == 3)
            {
                Console.WriteLine("The return for the linear equation is: {0}", LinearEquation());
            }
            else
            {
                Console.WriteLine("User input not an option");
                Environment.Exit(1);
            }
        }
        static int reverseOrder()
        {
            Console.Write("Enter a positive integer number: ");
            int inputNumber = int.Parse(Console.ReadLine());
            int returnNumber = 0;
            while (inputNumber > 0)
            {
                returnNumber = returnNumber * 10 + inputNumber % 10;
                inputNumber /= 10;
            }
            return returnNumber;
            
            
        }
        static double AverageOfSequence()
        {
            Console.Write("Enter the length of the array:");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] testArray = new int[arrayLength];
            double arrayTotal = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Input value for index [{0}]", i);
                testArray[i] = int.Parse(Console.ReadLine());
                arrayTotal += testArray[i];
            }
            return arrayTotal / arrayLength;

        }
        static double LinearEquation()
        {
            return 1;
        }
        static void Question11()
        {
            UserMenu();
        }
        static void Main(string[] args)
        {
            Question2();
            Question3();
            Question6();
            Question11();
        }
    }
}
