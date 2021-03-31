#nullable disable

using System;
using System.Text.Json.Serialization;

namespace Postmark
{
    public class PostmarkResponse
    {
        [JsonPropertyName("MessageID")]
        public string MessageId { get; init; }

        public string To { get; init; }

        public long ErrorCode { get; init; }

        public DateTimeOffset SubmittedAt { get; init; }

        public string Message { get; init; }
    }
}

/*
{
  "ErrorCode": 0,
  "Message": "OK",
  "MessageID": "b7bc2f4a-e38e-4336-af7d-e6c392c2f817",
  "SubmittedAt": "2010-11-26T12:01:05.1794748-05:00",
  "To": "receiver@example.com"
}
*/