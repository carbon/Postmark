#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Postmark
{
    public sealed class Bounce
    {
        [JsonPropertyName("ID")]
        public long Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BounceType Type { get; set; }

        public string Email { get; set; }

        public DateTimeOffset BouncedAt { get; set; }

        public string Details { get; set; }

        public bool Inactive { get; set; }

        public bool CanActivate { get; set; }

        [JsonPropertyName("MessageID")]
        public string MessageId { get; set; }
    }
}
