#nullable disable

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Postmark
{
    public partial class PostmarkMessage
    {
        [DataMember(IsRequired = true)]
        public string From { get; set; }

        [DataMember(IsRequired = true)]
        public string To { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Cc { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Subject { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Tag { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string HtmlBody { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string TextBody { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ReplyTo { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool TrackOpens { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<PostmarkHeader> Headers { get; set; } = new List<PostmarkHeader>();

        [DataMember(EmitDefaultValue = false)]
        public List<PostmarkAttachment> Attachments { get; set; } = new List<PostmarkAttachment>();
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
