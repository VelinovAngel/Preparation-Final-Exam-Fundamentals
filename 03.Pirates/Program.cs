using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PeopleAndGold> towns = new Dictionary<string, PeopleAndGold>();

            string readPopulations = string.Empty;

            while ((readPopulations = Console.ReadLine()) != "Sail")
            {
                //Tortuga||345000||1250
                string[] splittedPopulation = readPopulations.Split("||");
                string city = splittedPopulation[0];
                int population = int.Parse(splittedPopulation[1]);
                int gold = int.Parse(splittedPopulation[2]);

                if (!towns.ContainsKey(city))
                {
                    towns.Add(city, new PeopleAndGold(population, gold));
                }
                else
                {
                    towns[city].People += population;
                    towns[city].Gold += gold;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = command.Split("=>");
                string city = splittedCommand[1];


                //"Plunder=>{town}=>{people}=>{gold}"

                if (command.Contains("Plunder"))
                {
                    int population = int.Parse(splittedCommand[2]);
                    int gold = int.Parse(splittedCommand[3]);
                    if (towns[city].Gold > 0 && towns[city].People > 0)
                    {
                        towns[city].Gold -= gold;
                        towns[city].People -= population;
                        Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");
                    }
                    if (towns[city].Gold <= 0 || towns[city].People <= 0)
                    {
                        towns.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");
                    }
                }
                else if (command.Contains("Prosper"))
                {
                    int gold = int.Parse(splittedCommand[2]);
                    //Prosper=>Santo Domingo=>180

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        towns[city].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {towns[city].Gold} gold.");
                    }
                }
            }

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var city in towns.OrderByDescending(gold => gold.Value.Gold).ThenBy(city => city.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.People} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    class PeopleAndGold
    {
        public int People { get; set; }

        public int Gold { get; set; }

        public PeopleAndGold(int people, int gold)
        {
            this.People = people;
            this.Gold = gold;
        }

    }
}
