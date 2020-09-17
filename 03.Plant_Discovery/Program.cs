using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Planet> planets = new Dictionary<string, Planet>();
            //Dictionary<string, List<double>> averageRating = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] planetInfo = Console.ReadLine().Split("<->");
                string planet = planetInfo[0];
                int rarity = int.Parse(planetInfo[1]);
                //"{plant}<->{rarity}"

                if (!planets.ContainsKey(planet))
                {
                    planets.Add(planet, new Planet(0, rarity, 0));

                }
                else
                {
                    planets[planet].Rarity += rarity;
                }

            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] splittedInput = input
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string command = splittedInput[0];
                string planet = splittedInput[1];

                if (command == "Rate")
                {
                    double rating = double.Parse(splittedInput[2]);
                    if (planets.ContainsKey(planet))
                    {

                        planets[planet].Rating += rating;
                        planets[planet].Count++;
                    }
                    else
                    {
                        Console.WriteLine("error");

                    }
                    //double average = planets[planet].Rating / planets[planet].Count;
                    //planets[planet].Rating = average;
                }
                else if (command == "Update")
                {
                    int newRarity = int.Parse(splittedInput[2]);
                    if (planets.ContainsKey(planet))
                    {
                        planets[planet].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (command == "Reset")
                {
                    if (planets.ContainsKey(planet))
                    {
                        planets[planet].Rating = 0;
                        planets[planet].Count = 0;
                    }

                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            //var sortedPlants = planets.OrderByDescending(plant => plant.Value.Rarity).ThenByDescending(plant => plant.Value.Rating.Average()).ToDictionary(item => item.Key, item => item.Value);
            //Where(p=>p.Votes!=null && p.Votes.Any()).OrderByDescending(item => item.Votes.Average());

            //var sorted = planets.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var planet in planets.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating / x.Value.Count))
            {
                double average = 1.0 * planet.Value.Rating / 1.0 * planet.Value.Count;
                if (average <= 0)
                {
                    Console.WriteLine($"- {planet.Key}; Rarity: {planet.Value.Rarity}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {planet.Key}; Rarity: {planet.Value.Rarity}; Rating: {planet.Value.Rating / planet.Value.Count:f2}");

                }

            }
        }
    }

    class Planet
    {
        public double Rating { get; set; }
        public int Rarity { get; set; }
        public int Count { get; set; }

        public Planet(double rating, int rarity, int count)
        {
            this.Rating = rating;
            this.Rarity = rarity;
            this.Count = count;
        }
    }
}
