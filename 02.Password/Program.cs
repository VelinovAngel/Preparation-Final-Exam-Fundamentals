using System;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int inpNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < inpNumber; i++)
            {
                string password = Console.ReadLine();
                Regex pattern = new Regex(@"^(.+)\>(?<num>\d{3})\|(?<letLow>[a-z]{3})\|(?<letUpp>[A-Z]{3})\|(?<symb>[^\<\>]{3})\<\1$");
                Match passMatch = pattern.Match(password);

                if (passMatch.Success)
                {
                    string num = passMatch.Groups["num"].Value;
                    string letLow = passMatch.Groups["letLow"].Value;
                    string letUpp = passMatch.Groups["letUpp"].Value;
                    string symb = passMatch.Groups["symb"].Value;

                    string finPassword = num + letLow + letUpp + symb;
                    Console.WriteLine($"Password: {finPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
