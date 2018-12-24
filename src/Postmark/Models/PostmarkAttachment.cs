namespace Postmark
{
    public class PostmarkAttachment
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }
    }
}