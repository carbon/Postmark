using System;

using Carbon.Json;

namespace Postmark
{
    public class PostmarkResponse
    {
        public string MessageId { get; set; }

        public string To { get; set; }

        public long ErrorCode { get; set; }

        public DateTime SubmittedAt { get; set; }

        public string Message { get; set; }

        public static PostmarkResponse Parse(string text) => JsonObject.Parse(text).As<PostmarkResponse>();
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