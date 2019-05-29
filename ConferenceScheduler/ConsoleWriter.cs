using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferenceScheduler
{
    public class ConsoleWriter
    {
        public void Write(IEnumerable<Track> tracks)
        {
            for (int i = 0; i < tracks.Count(); i++)
            {
                PrintTrack(tracks.ElementAt(i), i + 1);
            }
        }

        private void PrintTrack(Track track, int trackNumber)
        {
            Console.WriteLine("Track " + trackNumber + " :");

            PrintTalks(track.MorningSession.Talks);
            PrintTalks(track.LunchSession.Talks);
            PrintTalks(track.AfternoonSession.Talks);
            PrintTalks(track.NetworkingSession.Talks);

            Console.WriteLine();
        }

        private void PrintTalks(IEnumerable<Talk> talks)
        {
            foreach (var talk in talks)
            {
                Console.WriteLine(talk.Title);
            }
        }
    }
}
