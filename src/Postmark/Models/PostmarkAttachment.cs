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

        public string Name { get; init; }

        public byte[] Content { get; init; }

        public string ContentType { get; init; }
    }
}