using System.Collections.Generic;

namespace ConferenceScheduler.Talk
{
    public class TalkComparer : IComparer<Conference.Talk>
    {
        public int Compare(Conference.Talk x, Conference.Talk y)
        {
            if (x.Duration == y.Duration)
                return 0;
            if (x.Duration > y.Duration)
                return 1;
            return -1;
        }
    }
}
