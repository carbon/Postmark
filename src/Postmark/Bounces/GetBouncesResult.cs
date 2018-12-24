using System.Collections.Generic;

namespace Postmark
{
    public class GetBouncesResult
    {
        public int TotalCount { get; set; }

        public List<Bounce> Bounces { get; set; }
    }
}