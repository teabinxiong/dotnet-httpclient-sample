using System.Text.Json.Serialization;


namespace DotNET.HttpClient.Sample.Api.Models
{
    public class GithubUser
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
    }
}
