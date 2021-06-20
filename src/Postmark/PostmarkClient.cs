using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Postmark
{
    public sealed class PostmarkClient
    {
        private const string endpoint = "https://api.postmarkapp.com";

        private readonly HttpClient _httpClient;

        private static readonly JsonSerializerOptions jso = new() {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public PostmarkClient(string apiKey)
        {
            if (apiKey is null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _httpClient = new HttpClient {
                DefaultRequestHeaders = {
                    { "Accept", MediaTypeNames.Application.Json },
                    { "X-Postmark-Server-Token", apiKey }
                }
            };
        }    

        public async Task<PostmarkResponse> SendMessageAsync(PostmarkMessage message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint + "/email");

            byte[] content = JsonSerializer.SerializeToUtf8Bytes(message, jso);

            request.Content = new ByteArrayContent(content) {
                Headers = {
                    { "Content-Type", MediaTypeNames.Application.Json }
                }
            };

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            return (await JsonSerializer.DeserializeAsync<PostmarkResponse>(responseStream).ConfigureAwait(false))!;
        }

        public async Task<GetBouncesResult> GetBouncesAsync(int skip, int take, BounceType? type)
        {
            var data = new Dictionary<string, string>(3) {
                { "offset", skip.ToString() },
                { "count", take.ToString() }
            };

            if (type is not null)
            {
                data["type"] = type.Value.ToString();
            }

            string url = endpoint + "/bounces?" + Serialize(data);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            return (await JsonSerializer.DeserializeAsync<GetBouncesResult>(responseStream).ConfigureAwait(false))!;
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