using System;

namespace _01.String_Manipulator_Group1
{
    class Program
    {
        static void Main(string[] args)
        {
            string messages = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                //•	"Translate {char} {replacement}"
                //o Replace all occurences of { char} with { replacement}, then print the string.

                string[] splittedInput = input.Split();
                string command = splittedInput[0];

                if (command == "Translate")
                {
                    char oldChar = char.Parse(splittedInput[1]);
                    char newChar = char.Parse(splittedInput[2]);
                    messages = messages.Replace(oldChar, newChar);
                    Console.WriteLine(messages);
                }
                else if (command == "Includes")
                {
                    //•	"Includes {string}"
                    //o Check if the string includes { string} and print "True/False".
                    string containsString = splittedInput[1];
                    bool isFind = messages.Contains(containsString);
                    Console.WriteLine(isFind);
                }
                else if (command == "Start")
                {
                    //•	"Start {string}"
                    //o Check if the string starts with { string} and print "True/False".
                    string startString = splittedInput[1];
                    bool startStringCheck = messages.StartsWith(startString);
                    Console.WriteLine(startStringCheck);
                }
                else if (command == "Lowercase")
                {
                    messages = messages.ToLower();
                    Console.WriteLine(messages);
                }
                else if (command == "FindIndex")
                {
                    char findChar = char.Parse(splittedInput[1]);
                    int indexFind = messages.LastIndexOf(findChar);
                    Console.WriteLine(indexFind);
                }
                else if (command == "Remove")
                {
                    int startIndex = int.Parse(splittedInput[1]);
                    int count = int.Parse(splittedInput[2]);
                    messages = messages.Remove(startIndex, count);
                    Console.WriteLine(messages);

                }

            }
        }
    }
}
