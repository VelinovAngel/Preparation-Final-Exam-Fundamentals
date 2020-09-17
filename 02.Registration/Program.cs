using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            //U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Z][a-z]{5,}[0-9]{1,})P@\$
            //U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[A-Za-z0-9]*[0-9])P@\$

            Regex validator =
                new Regex(@"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[0-9]{1,})P@\$");

            int numberOfUsers = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 0; i < numberOfUsers; i++)
            {
                string login = Console.ReadLine();

                Match match = validator.Match(login);
                if (match.Success)
                {
                    count++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"]}, Password: {match.Groups["password"]}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
