using System;
using System.Linq;

namespace ConferenceScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var talks = new FileInputParser().Parse("input.txt");

            var sortedTalks = talks.OrderByDescending(t => t, new TalkComparer()).ToList();

            var schedule = new SessionScheduler().Schedule(sortedTalks);

            new ConsoleWriter().Write(schedule);

            Console.ReadKey();
        }
    }
}
