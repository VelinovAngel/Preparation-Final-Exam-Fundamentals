using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\*|@)(?<name>[A-Z][a-z]{2,})\1: \[(?<first>[A-Za-z])\]\|\[(?<second>[A-Za-z])\]\|\[(?<thirt>[A-Za-z])\]\|$";

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    char[] letters = new char[]
                        {
                            char.Parse(match.Groups["first"].Value) ,
                            char.Parse(match.Groups["second"].Value),
                            char.Parse(match.Groups["thirt"].Value)

                        };

                    Console.WriteLine($"{match.Groups["name"].Value}: {(int)letters[0]} {(int)letters[1]} {(int)letters[2]}");

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
