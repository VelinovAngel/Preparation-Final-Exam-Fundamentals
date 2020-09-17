using System;
using System.Text;

namespace _01.Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                //•	Contains >>>{ substring} – checks if the raw activation key contains the given substring.
                //o If it does prints: "{raw activation key} contains {substring}".
                //o If not, prints: "Substring not found!"

                if (command.Contains("Contains"))
                {
                    string[] splittedCommand = command.Split(">>>");
                    string substring = splittedCommand[1];
                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command.Contains("Flip"))
                {
                    //•	Flip >>> Upper / Lower >>>{ startIndex}>>>{ endIndex}
                    //o Changes the substring between the given indices(the end index is exclusive) to upper or lower case. 
                    //o All given indexes will be valid.
                    //o Prints the activation key.

                    string[] splittedCommand = command.Split(">>>");
                    string options = splittedCommand[1];
                    int startIndex = int.Parse(splittedCommand[2]);
                    int endIndex = int.Parse(splittedCommand[3]);

                    if (options == "Upper")
                    {
                        StringBuilder upper = new StringBuilder(input);
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            upper[i] = char.Parse(upper[i].ToString().ToUpper());
                        }
                        input = upper.ToString();
                        Console.WriteLine(input);
                    }
                    else if (options == "Lower")
                    {
                        StringBuilder lower = new StringBuilder(input);
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            lower[i] = char.Parse(lower[i].ToString().ToLower());
                        }
                        input = lower.ToString();
                        Console.WriteLine(input);
                    }
                }
                else if (command.Contains("Slice"))
                {
                    //•	Slice >>>{ startIndex}>>>{ endIndex}
                    //o Deletes the characters between the start and end indices(end index is exclusive).
                    //o Both indices will be valid.
                    //o Prints the activation key.

                    string[] splittedCommand = command.Split(">>>");
                    int startIndex = int.Parse(splittedCommand[1]);
                    int endIndex = int.Parse(splittedCommand[2]);

                    input = input.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}
