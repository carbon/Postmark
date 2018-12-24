using System;

namespace Postmark
{
    public class Bounce
    {
        public long Id { get; set; }

        public BounceType Type { get; set; }

        public string Email { get; set; }

        public DateTime BouncedAt { get; set; }

        public string Details { get; set; }

        public bool Inactive { get; set; }

        public bool CanActivate { get; set; }
    }
}
