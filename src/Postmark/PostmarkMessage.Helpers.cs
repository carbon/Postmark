using System;
using System.IO;
using System.Net.Mail;

namespace Postmark
{
    public partial class PostmarkMessage
    {
        public static PostmarkMessage FromMailMessage(MailMessage message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            var doc = new PostmarkMessage {
                From = message.From.ToString(),
                To = message.To.ToString(),
                Subject = message.Subject
            };

#pragma warning disable CS0618 // Type or member is obsolete
            if (message.ReplyTo != null)
            {
                doc.ReplyTo = message.ReplyTo.ToString();
            }
#pragma warning restore CS0618 

            else if (message.ReplyToList.Count > 0)
            {
                doc.ReplyTo = message.ReplyToList.ToString();
            }

            if (message.IsBodyHtml)
            {
                doc.HtmlBody = message.Body;
            }
            else
            {
                doc.TextBody = message.Body;
            }

            // Alternate view support
            if (message.AlternateViews != null)
            {
                foreach (var view in message.AlternateViews)
                {
                    using (var streamReader = new StreamReader(view.ContentStream))
                    {
                        var text = streamReader.ReadToEnd();

                        switch (view.ContentType.MediaType)
                        {
                            case "text/plain": doc.TextBody = text; break;
                            case "text/html": doc.HtmlBody = text; break;
                        }
                    }
                }
            }

            if (message.Headers != null)
            {
                foreach (var key in message.Headers.AllKeys)
                {
                    if (key == "x-tag")
                    {
                        doc.Tag = message.Headers[key];
                    }
                    else
                    {
                        doc.Headers.Add(new PostmarkHeader(key, message.Headers[key]));
                    }
                }
            }

            return doc;
        }
    }
}