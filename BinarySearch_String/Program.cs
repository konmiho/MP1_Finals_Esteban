using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] randomList = {"banana","blue","red","orange","green","purple","violet","lavender","sunflower","poppy","dandelion","tulips","daisy","daffodil","rose","lily"};
            string[] wordList = new string[7];
            int[] minMidMax = {0,3,6};
            Random rnd = new Random();
            int minCharacter = 0;
            string temp = "";
            bool sorted = false;


            // RANDOM GENERATED WORDS
            Console.WriteLine("List of Words Unsorted:\n");
            for (int i = 0; i < wordList.Length; i++)
            {
                wordList[i] = randomList[rnd.Next(0,16)];
                Console.WriteLine(wordList[i]);
            }
            
            // SORTING THE WORDS
            for (int i = 0; i < wordList.Length; i++)
            {
                for (int j = 0; j < wordList.Length - 1; j++)
                {

                    sorted = false;
                    if (wordList[j].Length > wordList[j + 1].Length)
                    {
                        minCharacter = wordList[j + 1].Length;
                    }
                    else
                    {
                        minCharacter = wordList[j].Length;
                    }

                    for (int k = 0; k < minCharacter; k++)
                    {
                        if ((int)wordList[j][k] > (int)wordList[j + 1][k])
                        {
                            temp = wordList[j];
                            wordList[j] = wordList[j + 1];
                            wordList[j+1] = temp;
                            sorted = true;
                            break;
                        }
                        else if ((int)wordList[j][k] < (int)wordList[j + 1][k])
                        {
                            sorted = true;
                            break;
                        }
                    }

                    if (!sorted)
                    {
                        if (wordList[j].Length > minCharacter)
                        {
                            temp = wordList[j];
                            wordList[j] = wordList[j + 1];
                            wordList[j+1] = temp;
                        }
                    }

                }
            }

            string userInput;
            bool[] found = new bool[7];

            // GETTING VALID USER INPUT
            while (true) 
            {
                Console.WriteLine("List of Words Sorted:\n");
                for (int i = 0; i < wordList.Length; i++)
                {
                    Console.WriteLine(wordList[i]);
                }
                Console.WriteLine();

                Console.Write($"Word you are searching for:   ");
                userInput = Console.ReadLine().ToLower();

                if (wordList.Contains(userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"The list does not contain the word \"{userInput}\".");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════\n");

            int search = 0;
            int userInputCount = 0;

            // BINARY SEARCH
            while (true)
            {
                // FOR COLOUR
                for (int i = 0; i < wordList.Length; i++)
                {
                    if (minMidMax.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    if (minMidMax[1] == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write($"{wordList[i]}    ");
                    Console.ResetColor();
                }

                // IF MIDPOINT IS USERINPUT
                if (wordList[minMidMax[1]] == userInput)
                {
                    found[minMidMax[1]] = true;
                    userInputCount++;
                    break;
                }
                else if (wordList[minMidMax[1]][0] < userInput[0]) // IF USER INPUT IS TO THE RIGHT OF THE MIDPOINT
                {
                    if (minMidMax[1] <= wordList.Length) // 
                    {
                        minMidMax[1]++;
                    }
                    minMidMax[0] = minMidMax[1];
                    minMidMax[1] = (minMidMax[0] + minMidMax[2]) / 2;

                }
                else // IF USER INPUT IS TO THE LEFT OF THE MIDPOINT
                {
                    minMidMax[2] = minMidMax[1];
                    minMidMax[1] = ((minMidMax[0] + minMidMax[2]) / 2);
                }
                search++;
                Console.ReadKey();
            }

            Console.WriteLine($"\n\n\"{userInput}\" found!\n\n═══════════════════════════════════════════════════════════════════════════\n\nSearching for any remaining \"{userInput}\" in the list.\n");
            Console.ReadKey();

            int searchNext = minMidMax[1] - 1;

            while (true && searchNext >= 0)
            {
                search++;
                if ((wordList[searchNext] == userInput))
                {
                    found[searchNext] = true;
                    userInputCount++;
                    searchNext--;
                }
                else
                {
                    break;
                }
            }
            searchNext = minMidMax[1] + 1;
            while (true && searchNext < wordList.Length)
            {
                search++;
                if (wordList[searchNext] == userInput)
                {
                    found[searchNext] = true;
                    userInputCount++;
                    searchNext++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < wordList.Length; i++)
            {
                if (found[i])
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Write($"{wordList[i]}    ");
                Console.ResetColor();
            }
            Console.WriteLine($"\t\t\n\nSearch successfully completed.\n\n═══════════════════════════════════════════════════════════════════════════\n\n\tRESULTS FOR \"{userInput.ToUpper()}\".\n\tComparisons:\t{search}\n\tFound:\t{userInputCount}");
            Console.ReadKey();
        }
    }
}
