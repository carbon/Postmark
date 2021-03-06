﻿namespace Postmark
{
    public enum BounceType
    {
        HardBounce              = 1,
        Transient               = 2,
        Unsubscribe             = 16,
        Subscribe               = 32,
        AutoResponder           = 64,
        AddressChange           = 128,
        DnsError                = 256,
        SpamNotification        = 512,
        OpenRelayTest           = 1024,
        Unknown                 = 2048,
        SoftBounce              = 4096,
        VirusNotification       = 8192,
        ChallengeVerification   = 16384,
        BadEmailAddress         = 100000,
        SpamComplaint           = 100001,
        ManuallyDeactivated     = 100002,
        Unconfirmed             = 100003,
        Blocked                 = 100006,
        SMTPApiError            = 100007,
        InboundError            = 100008,
        DMARCPolicy             = 100009,
        TemplateRenderingFailed = 100010
    }
}