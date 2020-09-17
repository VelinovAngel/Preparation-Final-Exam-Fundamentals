using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"([@,#])(?<word>[A-Za-z]{3,})\1\1(?<reverse>[A-Za-z]{3,})\1");

            List<string> wordPairs = new List<string>();

            string input = Console.ReadLine();

            MatchCollection matchesWord = validator.Matches(input);
            foreach (Match matches in matchesWord)
            {
                string word = matches.Groups["word"].Value;
                string reverse = matches.Groups["reverse"].Value;

                string reversed = string.Concat(reverse.Reverse());

                if (word == reversed)
                {
                    wordPairs.Add($"{word} <=> {reverse}");
                }
            }

            if (matchesWord.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchesWord.Count} word pairs found!");
            }

            if (wordPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", wordPairs));
            }

        }
    }
}
