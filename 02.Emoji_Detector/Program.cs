using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Emoji_Detector_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"([:]{2}|[*]{2})(?<name>[A-Z][a-z]{2,})\1");
            Regex digit = new Regex(@"\d");

            List<string> validWords = new List<string>();
            int sumEmoji = 0;
            int emojisInText = 0;
            int coolThreshold = 0;

            string inputText = Console.ReadLine();

            if (validator.IsMatch(inputText) || digit.IsMatch(inputText))
            {

                MatchCollection matchesThreshold = digit.Matches(inputText);
                int[] machesToArr = matchesThreshold.Select(x => int.Parse(x.Value)).ToArray();
                coolThreshold = machesToArr.Aggregate(1, (a, b) => (a * b));
                MatchCollection machesEmoji = validator.Matches(inputText);
                emojisInText += machesEmoji.Count;

                foreach (Match emoji in machesEmoji)
                {
                    string emojiToString = emoji.Groups["name"].Value;
                    for (int i = 0; i < emojiToString.Length; i++)
                    {
                        if (char.IsLetter(emojiToString[i]))
                        {
                            sumEmoji += emojiToString[i];
                        }

                    }
                    if (sumEmoji > coolThreshold)
                    {
                        validWords.Add(emoji.Value);
                    }
                    sumEmoji = 0;
                }

            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojisInText} emojis found in the text. The cool ones are:");

            foreach (var item in validWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
