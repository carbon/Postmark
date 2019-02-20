using System.Runtime.Serialization;

namespace Postmark
{
    public class PostmarkAttachment
    {
        public PostmarkAttachment() { }

        public PostmarkAttachment(string name, byte[] content, string contentType)
        {
            Name = name;
            Content = content;
            ContentType = contentType;
        }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Content")]
        public byte[] Content { get; set; }

        [DataMember(Name = "ContentType")]
        public string ContentType { get; set; }
    }
}