using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Carbon.Json;

namespace Postmark
{
    public class PostmarkClient
    {
        const string endpoint = "https://api.postmarkapp.com";

        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public PostmarkClient(string apiKey)
        {
            this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

            this.httpClient = new HttpClient {
                DefaultRequestHeaders = {
                    { "Accept", "application/json" },
                    { "X-Postmark-Server-Token", apiKey }
                }
            };
        }

        public async Task<PostmarkResponse> SendMessageAsync(PostmarkMessage message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint + "/email");

            string content = JsonObject.FromObject(message).ToString(pretty: false);

            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return PostmarkResponse.Parse(responseText);
            }
        }

        public async Task<GetBouncesResult> GetBouncesAsync(int skip, int take, BounceType? type)
        {
            var data = new Dictionary<string, string> {
                { "offset", skip.ToString() },
                { "count", take.ToString() }
            };

            if (type != null)
            {
                data["type"] = type.ToString();
            }

            string url = endpoint + "/bounces?" + Serialize(data);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            using (var response = await httpClient.SendAsync(request).ConfigureAwait(false))
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonObject.Parse(responseText).As<GetBouncesResult>();
            }
        }


        private static string Serialize(Dictionary<string, string> data)
        {
            var sb = new StringBuilder();

            int i = 0;

            foreach (var entry in data)
            {
                if (i > 0)
                {
                    sb.Append('&');
                }

                sb.Append(entry.Key);
                sb.Append('=');
                sb.Append(entry.Value);

                i++;
            }

            return sb.ToString();
        }
    }
}