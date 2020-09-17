using System;
using System.Linq;
using System.Text;

namespace _01.Warriors_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "For Azeroth")
            {
                if (command == "GladiatorStance")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (command == "DefensiveStance")
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command.Contains("Dispel"))
                {
                    string[] options = command.Split();
                    char[] charArray = input.ToCharArray();
                    int index = int.Parse(options[1]);
                    char letters = char.Parse(options[2]);

                    if (index < 0 || index >= input.Length)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                    else
                    {
                        charArray[index] = letters;
                        input = new string(charArray);
                        Console.WriteLine("Success!");
                    }

                    //    Way With StringBuilder
                    //StringBuilder sb = new StringBuilder(input);
                    //sb[index] = letters;
                    //input = sb.ToString();
                }
                else if (command.Contains("Target Change"))
                {
                    string[] options = command.Split();
                    string substring = options[2];
                    string newString = options[3];

                    input = input.Replace(substring, newString);
                    Console.WriteLine(input);

                }
                else if (command.Contains("Target Remove"))
                {
                    string[] options = command.Split();
                    string substring = options[2];

                    input = input.Replace(substring, "");
                    Console.WriteLine(input);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

            }
        }
    }
}
