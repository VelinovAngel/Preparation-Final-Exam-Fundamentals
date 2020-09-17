using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, People> users = new Dictionary<string, People>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Results")
            {
                string[] splittedInput = input.Split(':');
                string command = splittedInput[0];

                if (command == "Add")
                {
                    string people = splittedInput[1];
                    int health = int.Parse(splittedInput[2]);
                    int energy = int.Parse(splittedInput[3]);

                    if (!users.ContainsKey(people))
                    {
                        users.Add(people, new People(health, energy));
                    }
                    else
                    {
                        users[people].HP += health;
                    }
                }
                else if (command == "Attack")
                {
                    string attackerName = splittedInput[1];
                    string defenderName = splittedInput[2];
                    int damege = int.Parse(splittedInput[3]);

                    if (users.ContainsKey(attackerName) && users.ContainsKey(defenderName))
                    {
                        users[defenderName].HP -= damege;
                        if (users[defenderName].HP <= 0)
                        {
                            users.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        users[attackerName].Energy--;
                        if (users[attackerName].Energy <= 0)
                        {
                            users.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (command == "Delete")
                {
                    string username = splittedInput[1];
                    if (username == "All")
                    {
                        users = new Dictionary<string, People>();
                    }
                    else if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
            }

            if (users.Count > 0)
            {
                Console.WriteLine($"People count: {users.Count}");
                foreach (var kvp in users.OrderByDescending(hp => hp.Value.HP).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value.HP} - {kvp.Value.Energy}");
                }
            }

        }
    }

    class People
    {
        public int HP { get; set; }

        public int Energy { get; set; }

        public People(int hp, int energy)
        {
            this.HP = hp;
            this.Energy = energy;
        }
    }
}
