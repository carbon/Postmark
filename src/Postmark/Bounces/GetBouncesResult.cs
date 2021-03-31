#nullable disable

using System.Collections.Generic;

namespace Postmark
{
    public sealed class GetBouncesResult
    {
        public int TotalCount { get; init; }

        public List<Bounce> Bounces { get; init; }
    }
}