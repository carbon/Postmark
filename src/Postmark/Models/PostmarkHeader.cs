using System;
using System.Runtime.Serialization;

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

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Value")]
        public string Value { get; set; }
    }
}