using System;
using System.Linq;

namespace _01.Nikuldens_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Finish")
            {

                string[] commandSplitted = command.Split();
                string action = commandSplitted[0];

                if (action == "Replace")
                {
                    char currentChar = char.Parse(commandSplitted[1]);
                    char newChar = char.Parse(commandSplitted[2]);

                    input = input.Replace(currentChar, newChar);
                    Console.WriteLine(input);
                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(commandSplitted[1]);
                    int endIndex = int.Parse(commandSplitted[2]);

                    //input = input.Substring(0, startIndex) + input.Substring(endIndex + 1);
                    //if (startIndex < 0 || startIndex >= input.Length ||
                    //    endIndex < 0 || endIndex >= input.Length)
                    //{
                    //        Console.WriteLine("Invalid indexes!");
                    //}

                    if (startIndex > 0 && startIndex <= input.Length &&
                        startIndex > 0 && endIndex <= input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);

                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }

                }
                else if (action == "Make")
                {
                    string options = commandSplitted[1];

                    if (options == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else if (options == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (action == "Check")
                {
                    string checkedString = commandSplitted[1];

                    if (input.Contains(checkedString))
                    {
                        Console.WriteLine($"Message contains {checkedString}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {checkedString}");
                    }
                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(commandSplitted[1]);
                    int endIndex = int.Parse(commandSplitted[2]);

                    if (startIndex > 0 && startIndex <= input.Length &&
                        startIndex > 0 && endIndex <= input.Length)
                    {
                        int sum = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += input[i];
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }



            }
        }
    }
}
