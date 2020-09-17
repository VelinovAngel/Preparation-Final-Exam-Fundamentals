using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] splittedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = splittedInput[0];

                if (command == "Case")
                {
                    string action = splittedInput[1];
                    if (action == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (action == "upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(splittedInput[1]);
                    int endIndex = int.Parse(splittedInput[2]);

                    if (startIndex >= 0 && startIndex <= username.Length
                        && endIndex >= 0 && endIndex <= username.Length)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        char[] reverse = substring.Reverse().ToArray();
                        Console.WriteLine(reverse);

                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Cut")
                {
                    string substring = splittedInput[1];
                    if (username.Contains(substring))
                    {
                        username = username.Remove(username.IndexOf(substring), substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    char letters = char.Parse(splittedInput[1]);

                    username = username.Replace(letters, '*');
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    char letters = char.Parse(splittedInput[1]);
                    if (username.Contains(letters))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {letters}.");
                    }
                }
            }
        }
    }
}
