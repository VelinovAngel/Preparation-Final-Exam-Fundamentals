using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)(?<name>[A-Z][A-Za-z]{2,})\1";
            //(=|\/)(?<name>[A-Z][A-Za-z]{2,})\1
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            int lenght = 0;
            List<string> validMatch = new List<string>();

            if (matches.Count > 0)
            {

                foreach (Match item in matches)
                {
                    lenght += item.Groups["name"].Length;

                }

                Console.Write("Destinations: ");

                foreach (Match item in matches)
                {
                    validMatch.Add(item.Groups["name"].Value);
                }

                Console.WriteLine(string.Join(", ", validMatch));

                Console.WriteLine($"Travel Points: {lenght}");
            }
            else
            {

                Console.WriteLine("Destinations:");
                Console.WriteLine($"Travel Points: {lenght}");
            }
        }

    }
}
