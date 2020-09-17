using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> users = new Dictionary<string, User>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Log out")
            {
                string[] splittedInput = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = splittedInput[0];
                string username = splittedInput[1];

                if (command == "New follower")
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new User());
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Like")
                {
                    int likes = int.Parse(splittedInput[2]);
                    if (users.ContainsKey(username))
                    {
                        users[username].Like += likes;
                    }
                    else
                    {
                        users.Add(username, new User(likes));
                    }
                }
                else if (command == "Comment")
                {
                    if (users.ContainsKey(username))
                    {
                        users[username].Comment++;
                    }
                    else
                    {
                        users.Add(username, new User(0, 1));
                    }
                }
                else if (command == "Blocked")
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

            }
            Console.WriteLine($"{users.Count} followers");

            foreach (var user in users.OrderByDescending(like => like.Value.Like).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Like + user.Value.Comment}");
            }

        }
    }

    class User
    {
        public int Like { get; set; }

        public int Comment { get; set; }

        public User(int like = 0, int comment = 0)
        {
            this.Like = like;
            this.Comment = comment;
        }

    }
}
