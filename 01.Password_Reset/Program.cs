using System;
using System.Linq;
using System.Text;

namespace _01.Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split();

                if (input.Contains("TakeOdd"))
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        sb.Append(password[i]);
                    }
                    password = sb.ToString();

                    Console.WriteLine(password);
                }
                else if (input.Contains("Cut"))
                {
                    int index = int.Parse(command[1]);
                    int lenght = int.Parse(command[2]);

                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (input.Contains("Substitute"))
                {
                    string substring = command[1];
                    string substitute = command[2];

                    if (password.IndexOf(substring) >= 0)
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
