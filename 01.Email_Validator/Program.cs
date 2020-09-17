using System;

namespace Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Complete")
            {

                if (command == "Make Upper")
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (command == "Make Lower")
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (command.Contains("GetDomain"))
                {
                    string[] options = command.Split();
                    int startIndex = email.Length - int.Parse(options[1]);
                    string newEmail = string.Empty;
                    Console.WriteLine(newEmail = email.Substring(startIndex, int.Parse(options[1])));
                }
                else if (command == "GetUsername")
                {
                    if (email.Contains('@'))
                    {

                        string[] nameOfEmail = email.Split('@');
                        Console.WriteLine(nameOfEmail[0]);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command.Contains("Replace"))
                {
                    //Replace all occurences of the {char} with a dash "-" and print the result.
                    string[] charToReplace = command.Split();
                    char singleChar = char.Parse(charToReplace[1]);

                    for (int i = 0; i < email.Length; i++)
                    {
                        if (email[i] == singleChar)
                        {
                            int startIndex = email.IndexOf(email[i]);
                            email = email.Replace(email[i], '-');
                        }
                    }
                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    int[] ASCIICode = new int[email.Length];

                    for (int i = 0; i < email.Length; i++)
                    {
                        ASCIICode[i] += email[i];
                    }
                    Console.WriteLine(string.Join(' ', ASCIICode));
                }

            }
        }
    }
}
