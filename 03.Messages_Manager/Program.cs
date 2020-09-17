using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            int capacity = int.Parse(Console.ReadLine());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] splittedInput = input.Split('=');
                string command = splittedInput[0];
                string usernama = splittedInput[1];

                if (command == "Add")
                {
                    int sent = int.Parse(splittedInput[2]);
                    int received = int.Parse(splittedInput[3]);

                    if (!users.ContainsKey(usernama))
                    {
                        users.Add(usernama, new User(sent, received));
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Message")
                {
                    string sender = splittedInput[1];
                    string receiver = splittedInput[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender].Sent++;
                        if (users[sender].Sent + users[sender].Received >= capacity)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        users[receiver].Received++;
                        if (users[receiver].Sent + users[receiver].Received >= capacity)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    if (users.ContainsKey(usernama))
                    {
                        users.Remove(usernama);
                    }
                    if (usernama == "All")
                    {
                        users = new Dictionary<string, User>();
                    }
                }
            }

            if (users.Count > 0)
            {
                Console.WriteLine($"Users count: {users.Count}");
                foreach (var kvp in users.OrderByDescending(x => x.Value.Received).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value.Sent + kvp.Value.Received}");
                }
            }
        }
    }

    class User
    {

        public int Sent { get; set; }

        public int Received { get; set; }

        public User(int sent, int received)
        {
            this.Sent = sent;
            this.Received = received;
        }
    }
}
