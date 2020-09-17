using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+(?<barecode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barecodeInput = Console.ReadLine();
                Match match = regex.Match(barecodeInput);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barecode = match.Groups[1].Value;
                StringBuilder group = new StringBuilder();

                for (int j = 0; j < barecode.Length; j++)
                {
                    if (barecode[j] >= 48 && barecode[j] <= 57)
                    {
                        group.Append(barecode[j]);
                    }
                }
                //if (String.IsNullOrEmpty(group.ToString()))
                //{
                //    group.Append("00");
                //}
                if (group.Length <= 0)
                {
                    Console.WriteLine("Product group: 00");
                }
                else
                {
                    Console.WriteLine($"Product group: {group}");
                }
            }
        }
    }
}
