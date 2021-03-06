﻿using System;
using System.Collections.Generic;

namespace ConferenceScheduler.Conference
{
    public class Session
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
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
