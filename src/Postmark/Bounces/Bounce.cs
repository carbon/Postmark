#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Postmark
{
    public sealed class Bounce
    {
        [JsonPropertyName("ID")]
        public long Id { get; init; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BounceType Type { get; init; }

        public string Email { get; init; }

        public DateTimeOffset BouncedAt { get; init; }

        public string Details { get; init; }

        public bool Inactive { get; init; }

        public bool CanActivate { get; init; }

        [JsonPropertyName("MessageID")]
        public string MessageId { get; init; }
    }
}
