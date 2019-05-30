using System;
using System.Linq;
using ConferenceScheduler.Parsers;
using ConferenceScheduler.Scheduler;
using ConferenceScheduler.Talk;
using ConferenceScheduler.Writer;

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
