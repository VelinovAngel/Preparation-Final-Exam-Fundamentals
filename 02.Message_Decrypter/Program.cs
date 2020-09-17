using System;
using System.Text.RegularExpressions;

namespace _02.Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\$|%)(?<name>[A-Z][a-z]{2,})\1: \[(?<first>\d+)\]\|\[(?<second>\d+)\]\|\[(?<thirt>\d+)\]\|$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);

                string decriptedMessages = string.Empty;
                if (match.Success)
                {
                    decriptedMessages += $"{match.Groups["name"].Value}: {(char)int.Parse(match.Groups["first"].Value)}{(char)int.Parse(match.Groups["second"].Value)}{(char)int.Parse(match.Groups["thirt"].Value)}";
                    Console.WriteLine(decriptedMessages);
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }

        }
    }
}
