using System;

namespace _0._1.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstGroupStudentForHours = int.Parse(Console.ReadLine());
            int secondGroupStudentForHours = int.Parse(Console.ReadLine());
            int thirtGroupStudentForHours = int.Parse(Console.ReadLine());

            int studentsHelp = int.Parse(Console.ReadLine());

            int totalGroupPeopleForHours = firstGroupStudentForHours + secondGroupStudentForHours + thirtGroupStudentForHours;

            int timeNeed = 0;

            while (studentsHelp > 0)
            {
                timeNeed++;
                if (timeNeed % 4 == 0)
                {
                    continue;
                }
                studentsHelp -= totalGroupPeopleForHours;
            }
            Console.WriteLine($"Time needed: {timeNeed}h.");
        }
    }
}
