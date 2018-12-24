using System.Net.Mail;
using System.Text;

using Xunit;

namespace Postmark.Tests
{
    public class MessageTests
    {
        [Fact]
        public void ParseResponse()
        {
            var json = @"{
	""To"": ""receiver @example.com"",
    ""SubmittedAt"": ""2014-02-17T07:25:01.4178645-05:00"",
	""MessageID"": ""0a129aee-e1cd-480d-b08d-4f48548ff48d"",
	""ErrorCode"": 0,
	""Message"": ""OK""
}";

            var response = PostmarkResponse.Parse(json);

            Assert.Equal("0a129aee-e1cd-480d-b08d-4f48548ff48d", response.MessageId);
            Assert.Equal(0, response.ErrorCode);
            Assert.Equal("OK", response.Message);
        }
 
        [Fact]
        public void CanConsructPostmarkMessageFromMailMessage()
        {
            var message = new MailMessage
            {
                From = new MailAddress("from@test.com", "Doc"),
                To = {
                    new MailAddress("to@test.com", "B")
                },
                ReplyToList = { new MailAddress("replyto@test.com", "C") },
                Subject = "Hello",
                Body = "TEST"
            };

            var plainView = AlternateView.CreateAlternateViewFromString("abc", Encoding.UTF8, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString("<p>abc</p>", Encoding.UTF8, "text/html");

            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);

            var doc = PostmarkMessage.FromMailMessage(message);

            Assert.Equal("Hello", doc.Subject);
            Assert.Equal("abc", doc.TextBody);
            Assert.Equal("<p>abc</p>", doc.HtmlBody);

            Assert.Equal(@"""Doc"" <from@test.com>", doc.From);
            Assert.Equal(@"""B"" <to@test.com>", doc.To);
        }
    }
}