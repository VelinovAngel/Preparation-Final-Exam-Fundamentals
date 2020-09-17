using System;
using System.Text.RegularExpressions;

namespace _02.Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<strenght>[A-Za-z]+) (?<armour>[A-Za-z]+)#";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Access denied!");
                    continue;
                }

                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (match.Success)
                {
                    string title = match.Groups["strenght"].ToString() + " " + match.Groups["armour"].ToString();
                    Console.WriteLine($"{match.Groups["name"]}, The {title}");
                    Console.WriteLine($">> Strength: {match.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {match.Groups["armour"].Length + match.Groups["strenght"].Length + 1}");
                }
            }
        }
    }
}
