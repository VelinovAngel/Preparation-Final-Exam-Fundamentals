using System;
using System.Text.RegularExpressions;

namespace _02.Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Regex regex = new Regex(@"^([A-Z][a-z\' ]+)\:[A-Z]+(\s?[A-Z]+)*\b");
            while ((input = Console.ReadLine()) != "end")
            {
                if (regex.IsMatch(input))
                {
                    string[] splitInput = input.Split(":");
                    string artist = splitInput[0];
                    string encript = string.Empty;

                    char[] arrInput = input.ToCharArray();
                    for (int i = 0; i < arrInput.Length; i++)
                    {
                        int key = artist.Length;
                        char newSymbol = arrInput[i];
                        if (arrInput[i] != ' ' && arrInput[i] != '\'')
                        {
                            if (char.IsLetter(arrInput[i]) && char.IsLower(arrInput[i]))
                            {
                                int symbol = arrInput[i];
                                while (key > 0)
                                {
                                    symbol++;
                                    key--;
                                    if (symbol == 123)
                                    {
                                        symbol = 97;
                                    }

                                } //counter
                                newSymbol = (char)symbol;
                            }
                            else if (char.IsLetter(arrInput[i]) && char.IsUpper(arrInput[i]))
                            {
                                int symbol = arrInput[i];
                                while (key > 0)
                                {
                                    symbol++;
                                    key--;
                                    if (symbol == 91)
                                    {
                                        symbol = 65;
                                    }

                                } //counter
                                newSymbol = (char)symbol;
                            }
                            else if (arrInput[i] == ':')
                            {
                                newSymbol = '@';
                            }
                        } // encrypt
                        encript += newSymbol;
                    }
                    Console.WriteLine($"Successful encryption: {encript}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
