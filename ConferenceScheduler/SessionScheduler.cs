using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceScheduler
{
    public class SessionScheduler
    {
        public IEnumerable<Track> Schedule(IEnumerable<Talk> talks)
        {
            var tracks = GetTracks();

            foreach (var talk in talks)
            {
                AddTalk(tracks, talk);
            }

            return tracks;
        }

        private void AddTalk(List<Track> tracks, Talk talk)
        {
            foreach (var track in tracks)
            {
                if (track.MorningSession.Remaining.TotalMinutes >= talk.Duration)
                {
                    track.MorningSession.AddTalk(talk);
                    return;
                }

                if(track.AfternoonSession.Remaining.TotalMinutes >= talk.Duration)
                {
                    track.AfternoonSession.AddTalk(talk);
                    return;
                }

            }
        }

        private List<Track> GetTracks()
        {
            var tracks = new List<Track>();

            var track1 = new Track
            {
                MorningSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(180),
                    EndTime = "12PM",
                    StartTime = 9,
                    Filled = TimeSpan.FromMinutes(0),
                    Remaining = TimeSpan.FromMinutes(180),
                    Talks = new List<Talk>()
                },

                LunchSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(60),
                    EndTime = "1PM",
                    StartTime = 12,
                    //Filled = TimeSpan.FromMinutes(0),
                    //Remaining = TimeSpan.FromMinutes(60),
                    Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Lunch Break" } }
                },
                AfternoonSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(180),
                    EndTime = "4PM",
                    StartTime = 1,
                    Filled = TimeSpan.FromMinutes(0),
                    Remaining = TimeSpan.FromMinutes(180),
                    Talks = new List<Talk>()
                },
                NetworkingSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(60),
                    StartTime = 4,
                    EndTime = "5PM",
                    //Filled = TimeSpan.FromMinutes(0),
                    //Remaining = TimeSpan.FromMinutes(60),
                    Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Networking" } }
                }
            };

            var track2 = new Track()
            {
                MorningSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(180),
                    EndTime = "12PM",
                    StartTime = 9,
                    Filled = TimeSpan.FromMinutes(0),
                    Remaining = TimeSpan.FromMinutes(180),
                    Talks = new List<Talk>()
                },

                LunchSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(60),
                    EndTime = "1PM",
                    StartTime = 12,
                    //Filled = TimeSpan.FromMinutes(0),
                    //Remaining = TimeSpan.FromMinutes(60),
                    Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Lunch Break" } }
                },
                AfternoonSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(180),
                    EndTime = "4PM",
                    StartTime = 1,
                    Filled = TimeSpan.FromMinutes(0),
                    Remaining = TimeSpan.FromMinutes(180),
                    Talks = new List<Talk>()
                },
                NetworkingSession = new Session()
                {
                    Duration = TimeSpan.FromMinutes(60),
                    StartTime = 4,
                    EndTime = "5PM",
                    //Filled = TimeSpan.FromMinutes(0),
                    //Remaining = TimeSpan.FromMinutes(60),
                    Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Networking" } }
                }
            };




            tracks.Add(track1);
            tracks.Add(track2);

            return tracks;
        }
    }
}
