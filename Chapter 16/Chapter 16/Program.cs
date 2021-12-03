using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Chapter_16
{
	class Program
	{
		static void Main(string[] args)
		{
			Question1();
			Question8();
			Ch18Question1();
			Ch18Question2();
			Ch18Question3();
		}
		static void Question1()
		{
			List<int> intList = new List<int>();
			Console.WriteLine("Please enter a sequence of positive numbers. To exit enter nothing.");
			bool test = true;
			while (test == true)
			{
				string newValue = Console.ReadLine();
				try
				{
					intList.Add(int.Parse(newValue));
				}
				catch
				{
					if (newValue == "")
					{
						test = false;
						Console.WriteLine("\n");
					}
					else
					{
						Console.WriteLine("Input not number or exit command");
					}
				}
			}
			int sum = 0;
			foreach (int number in intList)
			{
				if (intList.Count == 0)
				{

				}
				sum += number;
			}
			decimal average = (decimal)sum / intList.Count;
			Console.WriteLine("Sum: {0}\nAverage: {1}", sum, average);
			Console.WriteLine(intList.Count);
		}
		static void Question8()
		{
			int[] intArray = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
			int majorant = (intArray.Length / 2) + 1;
			bool hasMajorant = false;
			int returnedNumber = 0;

			foreach (int number in intArray)
			{
				int numberValue = intArray.Count(x => x == number);
				if (numberValue >= majorant)
				{
					returnedNumber = number;
					hasMajorant = true;
				}
			}
			Console.WriteLine(hasMajorant ? string.Format("Majorant: {0}\nCount: {1}", returnedNumber, intArray.Count(x => x == returnedNumber)) : "No Majorant");
		}
		static void Ch18Question1()
		{
			int[] intArray = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
			Array.Sort(intArray);
			int lastNumber = 200003201;
			foreach (int number in intArray)
			{
				if (number != lastNumber)
				{
					Console.Write("| {0} -> {1} times ", number, intArray.Count(x => x == number));
				}
				lastNumber = number;
			}
			Console.Write("|");
		}
		static void Ch18Question2()
		{
			List<int> startList = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };

			List<int> returnList = new List<int>();

			foreach (int number in startList)
			{
				if (startList.Count(x => x == number) % 2 == 0)
				{
					returnList.Add(number);
				}
			}
			foreach (int number in returnList)
            {
                Console.Write("{0} ", number);
            }
		}
		static void Ch18Question3()
        {
			try
			{
				StreamReader sr = new StreamReader(@"C:\Users\Ross.Henke\source\repos\csharp assessments\Chapter 16\words.txt");
				string line = sr.ReadLine();
				char[] delimiterChar = { ' ', '.', '?', '!', ',', '-'};
				IDictionary<string, int> returnDictionary = new Dictionary<string, int>();
				while (line != null)
				{
					string[] words = line.Split(delimiterChar);
                    Console.WriteLine(words);
					foreach(string word in words)
                    {
                        Console.WriteLine("Word is {0}", word);
						if (returnDictionary.ContainsKey(word.ToLower()))
                        {
							returnDictionary[word.ToLower()]++;
                        }
                        else
                        {
							returnDictionary[word.ToLower()] = 1;
                        }
                    }

					Console.WriteLine(line);
					line = sr.ReadLine();
				}
				sr.Close();
				Console.ReadLine();

				foreach (KeyValuePair<string, int> wordCounts in returnDictionary.OrderBy(x => x.Value))
                {
                    Console.WriteLine("{0} -> {1} |", wordCounts.Key, wordCounts.Value);
                }
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("File not found");

			}
        }
	}
}

