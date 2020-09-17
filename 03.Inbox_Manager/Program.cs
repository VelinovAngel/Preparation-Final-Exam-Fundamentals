using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {

                string[] command = input.Split("->");

                if (command[0] == "Add")
                {
                    string username = command[1];
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<string>());
                        ;
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (command[0] == "Send")
                {
                    //•	"Send->{username}->{Email}"
                    string username = command[1];
                    string email = command[2];

                    users[username].Add(email);
                }
                else if (command[0] == "Delete")
                {
                    //•	"Delete->{username}":
                    string username = command[1];
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }

                }

            }
            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value.Count).ThenBy(c => c.Key))
            {

                Console.WriteLine(user.Key);
                for (int i = 0; i < user.Value.Count; i++)
                {
                    Console.WriteLine($" - {user.Value[i]}");
                }

            }


        }
    }

}
