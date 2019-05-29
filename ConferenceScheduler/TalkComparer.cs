using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceScheduler
{
    public class TalkComparer : IComparer<Talk>
    {
        public int Compare(Talk x, Talk y)
        {
            if (x.Duration == y.Duration)
                return 0;
            if (x.Duration > y.Duration)
                return 1;
            return -1;
        }
    }
}
