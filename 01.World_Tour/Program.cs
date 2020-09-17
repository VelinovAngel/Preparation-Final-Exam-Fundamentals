using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string messages = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] splittedInput = input.Split(':');
                string command = splittedInput[0];

                if (command == "Add Stop")
                {
                    //•	Add Stop:{index}:{string} –
                    //insert the given string at that index only if the index is valid
                    int index = int.Parse(splittedInput[1]);
                    string subString = splittedInput[2];

                    if (index >= 0 && index <= messages.Length)
                    {
                        messages = messages.Insert(index, subString);
                        Console.WriteLine(messages);
                    }
                }
                else if (command == "Remove Stop")
                {
                    //•	Remove Stop:{start_index}:{end_index} –
                    //remove the elements of the string from the starting index to the end index (inclusive) if both indices are valid
                    int startIndex = int.Parse(splittedInput[1]);
                    int endIndex = int.Parse(splittedInput[2]);

                    if (startIndex >= 0 && startIndex <= messages.Length &&
                       endIndex >= 0 && endIndex <= messages.Length)
                    {
                        messages = messages.Remove(startIndex, endIndex - startIndex + 1);

                        Console.WriteLine(messages);
                    }

                }
                else if (command == "Switch")
                {
                    //•	Switch:{old_string}:{new_string} –
                    //if the old string is in the initial string, replace it with the new one. (all occurrences)

                    string oldString = splittedInput[1];
                    string newString = splittedInput[2];
                    string[] firstString = messages.Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);


                    messages = messages.Replace(oldString, newString);
                    Console.WriteLine(messages);


                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {messages}");
        }
    }
}
