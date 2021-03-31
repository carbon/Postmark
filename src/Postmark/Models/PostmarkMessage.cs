#nullable disable

using System.Collections.Generic;

namespace Postmark
{
    public partial class PostmarkMessage
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Subject { get; set; }

#nullable enable

        public string? Tag { get; set; }

        public string? HtmlBody { get; set; }

        public string? TextBody { get; set; }

        public string? ReplyTo { get; set; }

        public bool TrackOpens { get; set; }

        public List<PostmarkHeader> Headers { get; set; } = new ();

        public List<PostmarkAttachment> Attachments { get; set; } = new ();
    }
}

/*
{
  "From" :     "sender@example.com",
  "To" :       "receiver@example.com",
  "Cc" :       "copied@example.com",
  "Subject" :  "Test",
  "Tag" :	   "Invitation",
  "HtmlBody" : "<b>Hello</b>",
  "TextBody" : "Hello",
  "ReplyTo" :  "reply@example.com",
  "Headers" :  [{ "Name" : "CUSTOM-HEADER", "Value" : "value" }]
}
*/
