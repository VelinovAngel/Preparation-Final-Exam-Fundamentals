using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //“swap { index1}{ index2}” take two elements and swap their places.
            //“multiply { index1}{ index2}” take element at the 1st index and multiply it with element at 2nd index. Save the product at the 1st index.
            //“decrease” decreases all elements in the array with 1.

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = splittedInput[0];

                switch (command)
                {
                    case "swap":
                        int indexOne = int.Parse(splittedInput[1]);
                        int indexTwo = int.Parse(splittedInput[2]);
                        //Use this logic to swap 2 elements
                        //T tmp = list[indexA];
                        //list[indexA] = list[indexB];
                        //list[indexB] = tmp;
                        int temp = numbers[indexOne];
                        numbers[indexOne] = numbers[indexTwo];
                        numbers[indexTwo] = temp;
                        break;
                    case "multiply":
                        int indexMultiplyOne = int.Parse(splittedInput[1]);
                        int indexMUltiplyTwo = int.Parse(splittedInput[2]);
                        int multiply = numbers[indexMultiplyOne] * numbers[indexMUltiplyTwo];
                        numbers[indexMultiplyOne] = multiply;
                        break;
                    case "decrease":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] -= 1;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
