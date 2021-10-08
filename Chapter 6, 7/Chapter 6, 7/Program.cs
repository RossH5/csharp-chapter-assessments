using System;

namespace Chapter_6__7
{
    class Program
    {
        static void Main(string[] args)
        {
            //##Chapter 6##

            //4.

            string cardTitle = "Null";
            for (int card = 2; card <= 14; card++)
            {
                switch (card)
                {
                    case 2:
                        cardTitle = "Two";
                        break;
                    case 3:
                        cardTitle = "Three";
                        break;
                    case 4:
                        cardTitle = "Four";
                        break;
                    case 5:
                        cardTitle = "Five";
                        break;
                    case 6:
                        cardTitle = "Six";
                        break;
                    case 7:
                        cardTitle = "Seven";
                        break;
                    case 8:
                        cardTitle = "Eight";
                        break;
                    case 9:
                        cardTitle = "Nine";
                        break;
                    case 10:
                        cardTitle = "Ten";
                        break;
                    case 11:
                        cardTitle = "Jack";
                        break;
                    case 12:
                        cardTitle = "Queen";
                        break;
                    case 13:
                        cardTitle = "King";
                        break;
                    case 14:
                        cardTitle = "Ace";
                        break;
                    default:
                        break;
                }
                for (int suit = 1; suit <= 4; suit++)
                {
                    switch (suit)
                    {
                        case 1:
                            Console.WriteLine(cardTitle + " of Spades");
                            break;
                        case 2:
                            Console.WriteLine(cardTitle + " of Hearts");
                            break;
                        case 3:
                            Console.WriteLine(cardTitle + " of Diamonds");
                            break;
                        case 4:
                            Console.WriteLine(cardTitle + " of Clubs");
                            break;
                        default:
                            break;
                    }
                }
            }
            //10.

            Console.Write("Enter a Number 0-20:");
            int userNum = int.Parse(Console.ReadLine());

            for (int i = 0, roundCount = 1; i < userNum; i++, roundCount++)
            {
                for (int numCount = 0; numCount < userNum; numCount++)
                {
                    Console.Write(roundCount + numCount + "\t");
                }
                Console.WriteLine();
            }

            ////16.

            //Random rand = new Random();

            //Console.Write("Enter a Number:");
            //int N = int.Parse(Console.ReadLine());

            //int[] numArray = new int[N];

            //for (int i = 0; i < N; i++)
            //{
            //    numArray[i] = i + 1;
            //}
            //for (int i = 0; i < numArray.Length; i++)
            //{
            //    int randomVal = rand.Next(i, numArray.Length);
            //    int temp = numArray[i];
            //    numArray[i] = numArray[randomVal];
            //    numArray[randomVal] = temp;
            //}
            //for (int i = 0; i < N; i++)
            //{
            //    Console.WriteLine(numArray[i]);
            //}

            ////##Chapter 7##

            ////10.

            //int[] testArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            //Array.Sort(testArray);
            //int longestChain = 0;
            //int currentChain = 0;
            //int freqNum = 0;

            //for (int i = 0; i < testArray.Length; i++)
            //{
            //    if (i == testArray.Length - 1)
            //    {
            //        continue;
            //    }
            //    else if (testArray[i] == testArray[i + 1])
            //    {
            //        currentChain += 1;
            //    }
            //    else
            //    {
            //        currentChain = 0;
            //    }
            //    if (currentChain > longestChain)
            //    {
            //        freqNum = testArray[i];
            //    }
            //}
            //Console.WriteLine("Most frequent number is:" + freqNum);

            //14.

            //string[,] matrix =
            //{
            //    {"ha", "fifi", "ho", "hi" },
            //    {"fo", "ha", "hi", "xx" },
            //    {"xxx", "ho", "ha", "xx" },
            //};
            //
            //int colScore = 0;
            //int rowScore = 0;
            //int diagonalScore = 0;
            //int longestChainScore = 0;

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {


            //    }

            //}
        }
    }
}
