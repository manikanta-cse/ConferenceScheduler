using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceScheduler
{
    public class Session
    {
        public int StartTime { get; set; }
        public string EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan Remaining { get; set; }

        public TimeSpan Filled { get; set; }

        public List<Talk> Talks { get; set; }

        public Session()
        {
            Remaining = Duration;
        }

        public void AddTalk(Talk talk)
        {
            Talks.Add(talk);
            Remaining = TimeSpan.FromMinutes(Remaining.TotalMinutes - talk.Duration);
            Filled += TimeSpan.FromMinutes(talk.Duration);
        }
    }
}
