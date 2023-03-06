using System.Text.Json.Serialization;

namespace RestSharpAPITests
{
    public class Urls
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("shortCode")]
        public string ShortCode { get; set; }

        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }

        [JsonPropertyName("dateCreated")]
        public string DateCreated { get; set; }

        [JsonPropertyName("visits")]
        public int Visits { get; set; }
    }
}