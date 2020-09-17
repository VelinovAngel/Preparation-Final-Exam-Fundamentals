using System;
using System.Linq;

namespace _01.String_Manipulator_Group2
{
    class Program
    {
        static void Main(string[] args)
        {
            string messages = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] splittedInput = input.Split();
                string command = splittedInput[0];

                if (command == "Change")
                {
                    char oldChar = char.Parse(splittedInput[1]);
                    char newChar = char.Parse(splittedInput[2]);
                    messages = messages.Replace(oldChar, newChar);
                    Console.WriteLine(messages);
                }
                else if (command == "Includes")
                {
                    string includedString = splittedInput[1];
                    bool isFind = messages.Contains(includedString);
                    Console.WriteLine(isFind);
                }
                else if (command == "End")
                {
                    string stringEnd = splittedInput[1];
                    bool result = messages.EndsWith(stringEnd);
                    Console.WriteLine(result);
                }
                else if (command == "Uppercase")
                {
                    messages = messages.ToUpper();
                    Console.WriteLine(messages);
                }
                else if (command == "FindIndex")
                {
                    char charIndex = char.Parse(splittedInput[1]);
                    int index = messages.IndexOf(charIndex);
                    Console.WriteLine(index);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(splittedInput[1]);
                    int lenght = int.Parse(splittedInput[2]);

                    string substring = messages.Substring(startIndex, lenght);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
