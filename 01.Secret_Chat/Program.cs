using System;
using System.Text;
using System.Linq;

namespace _01.Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string messages = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] splittedCommand = command.Split(":|:");

                if (command.Contains("InsertSpace"))
                {
                    int index = int.Parse(splittedCommand[1]);
                    messages = messages.Insert(index, " ");
                    Console.WriteLine(messages);
                }
                else if (command.Contains("Reverse"))
                {

                    string substring = splittedCommand[1];
                    if (messages.Contains(substring))
                    {
                        messages = messages.Remove(messages.IndexOf(substring), substring.Length);
                        StringBuilder reverse = new StringBuilder();
                        for (int i = 0; i < substring.Length; i++)
                        {
                            reverse.Append(substring[substring.Length - i - 1]);
                        }

                        messages = messages + reverse;
                        //char[] reverseTest = substring.Reverse().ToArray();
                        Console.WriteLine(messages);
                        //Console.WriteLine(string.Join("",reverseTest));
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command.Contains("ChangeAll"))
                {
                    //•	ChangeAll:|:{substring}:|:{replacement}
                    string substring = splittedCommand[1];
                    string replace = splittedCommand[2];

                    messages = messages.Replace(substring, replace);
                    Console.WriteLine(messages);
                }

            }
            Console.WriteLine($"You have a new text message: {messages}");
        }
    }
}
