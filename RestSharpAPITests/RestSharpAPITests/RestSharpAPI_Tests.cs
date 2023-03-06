using RestSharp;
using System.Net;
using System.Text.Json;

namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {
        private RestClient client;
        private const string baseUrl = "https://shorturl.kameliaibowska.repl.co/api";

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient(baseUrl);
        }

        [Test]
        public void Test_GetAllUrls_CheckResponseIsNotEmpty()
        {
            // Arrange
            RestRequest request = new RestRequest("urls", Method.Get);

            // Act
            RestResponse response = this.client.Execute(request);
            List<Urls>? urls = JsonSerializer.Deserialize<List<Urls>>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(urls, Is.Not.Empty);
        }

        [Test]
        public void Test_GetUrl_BySortCode_Valid()
        {
            // Arrange
            RestRequest request = new RestRequest("urls/nak", Method.Get);

            // Act
            RestResponse response = this.client.Execute(request);
            Urls urls = JsonSerializer.Deserialize<Urls>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(urls.Url, Is.EqualTo("https://nakov.com"));
        }

        [Test]
        public void Test_GetUrl_BySortCode_Invalid()
        {
            // Arrange
            RestRequest request = new RestRequest("urls/kami", Method.Get);

            // Act
            RestResponse response = this.client.Execute(request);
            Urls urls = JsonSerializer.Deserialize<Urls>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Test_CreateNewUrl_Valid()
        {
            // Arrange
            RestRequest request = new RestRequest("urls", Method.Post);
            var newurl = "url" + DateTime.Now.Ticks;
            var urlBody = new
            {
                url = $"https://{newurl}.com",
                shortCode = newurl
            };

            // Act
            request.AddBody(urlBody);
            RestResponse response = this.client.Execute(request);
            UrlObject? urlObject = JsonSerializer.Deserialize<UrlObject>(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(urlObject.Msg, Is.EqualTo("Short code added."));
        }

        [Test]
        public void Test_CreateNewUrl_Dublicated_Inalid()
        {
            // Arrange
            RestRequest request = new RestRequest("urls", Method.Post);
            var urlBody = new
            {
                url = "https://nakov.com",
                shortCode = "nak"
            };

            // Act
            request.AddBody(urlBody);
            RestResponse response = this.client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Short code already exists!\"}"));
        }
    }
}