using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceScheduler.Scheduler
{
    public class SessionScheduler
    {
        private const int TRACK_DURATION = 420;
        public IEnumerable<Track> Schedule(IEnumerable<Talk> talks)
        {
           
            var requiredTracks = CalculateRequiredTracks(CalculateTotalDurationFor(talks));

            var tracks = GenerateTracks(requiredTracks);

            foreach (var talk in talks)
            {
                AddTalk(tracks, talk);
            }

            return tracks;
        }

        private int CalculateRequiredTracks(int totalTalksDuration)
        {
            return (int) Math.Round((double) totalTalksDuration / TRACK_DURATION);
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

                if (track.AfternoonSession.Remaining.TotalMinutes >= talk.Duration)
                {
                    track.AfternoonSession.AddTalk(talk);
                    return;
                }

            }
        }

        private int CalculateTotalDurationFor(IEnumerable<Talk> talks)
        {
            return talks.Sum(t => t.Duration);
        }

        private List<Track> GenerateTracks(int requiredTracks)
        {
            var tracks = new List<Track>();

            for (int i = 0; i < requiredTracks; i++)
            {
                var track = new Track
                {
                    MorningSession = new Session()
                    {
                        Duration = TimeSpan.FromMinutes(180),
                        EndTime = new TimeSpan(hours: 12, minutes: 0, seconds: 0),
                        StartTime = new TimeSpan(hours: 9, minutes: 0, seconds: 0),
                        Filled = TimeSpan.FromMinutes(0),
                        Remaining = TimeSpan.FromMinutes(180),
                        Talks = new List<Talk>()
                    },

                    LunchSession = new Session()
                    {
                        Duration = TimeSpan.FromMinutes(60),
                        EndTime = new TimeSpan(13),
                        StartTime = new TimeSpan(12),
                        Filled = TimeSpan.FromMinutes(0),
                        Remaining = TimeSpan.FromMinutes(60),
                        Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Lunch Break" } }
                    },
                    AfternoonSession = new Session()
                    {
                        Duration = TimeSpan.FromMinutes(240),
                        EndTime = new TimeSpan(hours: 17, minutes: 0, seconds: 0),
                        StartTime = new TimeSpan(hours: 13, minutes: 0, seconds: 0),
                        Filled = TimeSpan.FromMinutes(0),
                        Remaining = TimeSpan.FromMinutes(240),
                        Talks = new List<Talk>()
                    },
                    NetworkingSession = new Session()
                    {
                        Duration = TimeSpan.FromMinutes(60),
                        StartTime = new TimeSpan(hours: 17, minutes: 0, seconds: 0),
                        EndTime = new TimeSpan(hours: 18, minutes: 0, seconds: 0),
                        Filled = TimeSpan.FromMinutes(0),
                        Remaining = TimeSpan.FromMinutes(60),
                        Talks = new List<Talk>() { new Talk { Duration = 60, Title = "Networking" } }
                    }
                };

                tracks.Add(track);
            }

            return tracks;
        }
    }
}
