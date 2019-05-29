using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceScheduler
{
    public class Track
    {
        public Session MorningSession { get; set; }
        public Session LunchSession { get; set; }
        public Session AfternoonSession { get; set; }
        public Session NetworkingSession { get; set; }
    }
}
