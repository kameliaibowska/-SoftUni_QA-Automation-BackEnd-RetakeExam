using System.Text.Json.Serialization;

namespace RestSharpAPITests
{
    public class UrlObject
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        [JsonPropertyName("url")]
        public Urls Url { get; set; }
    }
}