using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> timesOfbands = new Dictionary<string, int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "start of concert")
            {
                string[] splittedInput = input.Split("; ");
                string command = splittedInput[0];
                string bandName = splittedInput[1];

                if (command == "Add")
                {
                    string[] members = splittedInput[2].Split(", ");

                    if (!bands.ContainsKey(bandName))
                    {
                        bands.Add(bandName, new List<string>());
                        for (int i = 0; i < members.Length; i++)
                        {
                            bands[bandName].Add(members[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            if (!bands[bandName].Contains(members[i]))
                            {
                                bands[bandName].Add(members[i]);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else if (command == "Play")
                {
                    int time = int.Parse(splittedInput[2]);

                    if (!timesOfbands.ContainsKey(bandName))
                    {
                        timesOfbands.Add(bandName, time);
                    }
                    else
                    {
                        timesOfbands[bandName] += time;
                    }

                }

            }
            int totalTime = 0;

            foreach (var time in timesOfbands.Values)
            {
                totalTime += time;

            }
            Console.WriteLine($"Total time: {totalTime}");
            foreach (var kvp in timesOfbands.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            string bandNames = Console.ReadLine();
            if (bands.ContainsKey(bandNames))
            {
                Console.WriteLine(bandNames);
                foreach (var item in bands[bandNames])
                {
                    Console.WriteLine($"=> {string.Join(Environment.NewLine, item)}");
                }
            }
        }
    }
}
