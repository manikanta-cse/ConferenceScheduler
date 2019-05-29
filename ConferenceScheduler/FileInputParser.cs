using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConferenceScheduler
{
    public class FileInputParser
    {

        private const char SEPERATOR = ' ';
        public IEnumerable<Talk> Parse(string filename)
        {
            var lines = File.ReadAllLines(filename);

            var talks = new List<Talk>();

            foreach (var line in lines)
            {
                talks.Add(ParseTalk(line));
            }

            return talks;

        }

        private Talk ParseTalk(string line)
        {
            return new Talk()
            {
                Title = line,
                Duration = GetDuration(line)
            };
        }

        private int GetDuration(string line)
        {
            var index = line.LastIndexOf(SEPERATOR);
            var token = line.Substring(index, line.Length - index);
            return ExtractNumber(token.Trim());
        }

        private int ExtractNumber(string token)
        {
            return token.ToLower() == "lightning" ? 5 : Convert.ToInt16(Regex.Match(token, @"\d+").Value);
        }
    }
}
