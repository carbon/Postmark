using System;

namespace Postmark
{
    public class PostmarkHeader
    {
#nullable disable
        public PostmarkHeader() { }
#nullable enable

        public PostmarkHeader(string name, string value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}