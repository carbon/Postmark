namespace Postmark
{
    public sealed class PostmarkAttachment
    {
#nullable disable
        public PostmarkAttachment() { }
#nullable enable

        public PostmarkAttachment(string name, byte[] content, string contentType)
        {
            Name = name;
            Content = content;
            ContentType = contentType;
        }

        public string Name { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }
    }
}