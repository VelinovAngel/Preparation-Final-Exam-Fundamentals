using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Nikuldens_meals
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> usersList = new Dictionary<string, List<string>>();

            string input = string.Empty;
            int totalUnlikes = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] options = input.Split('-');
                string command = options[0];
                string guest = options[1];
                string meal = options[2];

                if (command == "Like")
                {
                    if (!usersList.ContainsKey(guest))
                    {
                        usersList.Add(guest, new List<string>());
                    }

                    if (!usersList[guest].Contains(meal))
                    {
                        usersList[guest].Add(meal);
                    }
                }
                else if (command == "Unlike")
                {
                    if (!usersList.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!usersList[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        usersList[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        totalUnlikes++;
                    }
                }
            }

            foreach (var kvp in usersList.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
            Console.WriteLine($"Unliked meals: {totalUnlikes}");


        }
    }
}
