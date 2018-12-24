using Carbon.Json;

using Xunit;

namespace Postmark.Tests
{
    public class BounceTests
    {
        [Fact]
        public void CanParseSimple()
        {
            string json =
@"{
  ""ID"" : 42,
  ""Type"" : ""HardBounce"",
  ""Email"" : ""jim@test.com"",
  ""BouncedAt"" : ""2010-04-01"",
  ""Details"" : ""test bounce"",
  ""DumpAvailable"" : true,
  ""Inactive"" : true,
  ""CanActivate"" : true
}";
            var bounce = JsonObject.Parse(json).As<Bounce>();

            Assert.Equal(42L, bounce.Id);
            Assert.Equal(BounceType.HardBounce, bounce.Type);
            Assert.Equal("jim@test.com", bounce.Email);
            Assert.Equal("test bounce", bounce.Details);
            Assert.True(bounce.Inactive);
            Assert.True(bounce.CanActivate);
        }

        [Fact]
        public void CanParseComplex()
        {
            var json = @"{
  ""ID"": 692560173,
  ""Type"": ""HardBounce"",
  ""TypeCode"": 1,
  ""Name"": ""Hard bounce"",
  ""Tag"": ""Invitation"",
  ""MessageID"": ""2c1b63fe-43f2-4db5-91b0-8bdfa44a9316"",
  ""ServerID"": 23,
  ""Description"": ""The server was unable to deliver your message (ex: unknown user, mailbox not found)."",
  ""Details"": ""action: failed\r\n"",
  ""Email"": ""anything@blackhole.postmarkapp.com"",
  ""From"": ""sender@postmarkapp.com"",
  ""BouncedAt"": ""2014-01-15T16:09:19.6421112-05:00"",
  ""DumpAvailable"": false,
  ""Inactive"": false,
  ""CanActivate"": true,
  ""Subject"": ""SC API5 Test"",
  ""Content"": ""Return-Path: <>\r\nReceived: …""
}";

            var bounce = JsonObject.Parse(json).As<Bounce>();

            Assert.Equal(692560173, bounce.Id);
            Assert.Equal(BounceType.HardBounce, bounce.Type);
        }
    }
}
