using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<messages>[A-Za-z]{8,})\]";


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }



                string[] inputInfo = input.Split(':');
                string command = inputInfo[0].Replace("!", "");
                string messages = inputInfo[1].Replace("[", "").Replace("]", "");

                //          First Way
                //int[] result = messages.Select(x => (int)x)
                //    .ToArray();

                //          Second Way
                //string result = string.Empty;

                //for (int j = 0; j < messages.Length; j++)
                //{
                //    result += (int)messages[j] + " ";
                //    result.TrimEnd();
                //}


                Regex regex = new Regex(pattern);

                Match match = regex.Match(input);
                if (match.Success)
                {

                    int[] ASCIICode = new int[match.Groups["messages"].Length];

                    for (int j = 0; j < match.Groups["messages"].Length; j++)
                    {
                        ASCIICode[j] += match.Groups["messages"].Value[j];
                    }
                    Console.WriteLine($"{command}: {string.Join(' ', ASCIICode)}");

                }
            }
        }
    }
}
