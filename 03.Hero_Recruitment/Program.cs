using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> listOfHero = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandSplitted = input.Split();

                if (input.Contains("Enroll"))
                {
                    string heroName = commandSplitted[1];

                    if (!listOfHero.ContainsKey(heroName))
                    {
                        listOfHero.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (input.Contains("Learn"))
                {
                    string heroName = commandSplitted[1];
                    string spellName = commandSplitted[2];
                    //•	Adds the {SpellName}to the {HeroName}'s spellbook.
                    //•	If the {HeroName} doesn’t exist in the collection, print: "{HeroName} doesn't exist."
                    //•	If the hero already has the spell in his spellbook print: "{HeroName} has already learnt {SpellName}."

                    if (!listOfHero.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (listOfHero[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        listOfHero[heroName].Add(spellName);
                    }

                }
                else if (input.Contains("Unlearn"))
                {
                    string heroName = commandSplitted[1];
                    string spellName = commandSplitted[2];

                    //•	Remove the {SpellName} from the {HeroName}'s spellbook.
                    //•	If the {HeroName} doesn’t exist in the collection, print: "{HeroName} doesn't exist."
                    //•	If the {SpellName} doesn't exist in the hero's spellbook, print: "{HeroName} doesn't know {SpellName}."
                    if (listOfHero.ContainsKey(heroName))
                    {

                        if (listOfHero[heroName].Contains(spellName))
                        {
                            listOfHero[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                }
            }

            if (listOfHero.Count > 0)
            {
                Console.WriteLine("Heroes:");
                foreach (var users in listOfHero.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"== {users.Key}: {string.Join(", ", users.Value)}");
                }
            }
        }
    }
}
