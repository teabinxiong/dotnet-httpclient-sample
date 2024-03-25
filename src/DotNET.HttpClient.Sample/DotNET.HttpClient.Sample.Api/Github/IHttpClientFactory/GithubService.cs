using DotNET.HttpClient.Sample.Api.Configs;
using DotNET.HttpClient.Sample.Api.Models;
using Microsoft.Extensions.Options;

namespace DotNET.HttpClient.Sample.Api.Github.IHttpClientFactory
{
    public class GithubService : IGithubService
    {
        private readonly GithubSettings _settings;
        private readonly System.Net.Http.IHttpClientFactory _factory;

        public GithubService(IOptions<GithubSettings> settings, System.Net.Http.IHttpClientFactory factory)
        {
            _settings = settings.Value;
            _factory = factory;
        }

        public async Task<GithubUser?> GetUserAsync(string username)
        {
           var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Add("Authorization", _settings.GithubToken);
            client.DefaultRequestHeaders.Add("User-Agent", _settings.UserAgent);
            client.BaseAddress = new Uri("https://api.github.com");

            GithubUser? user = await client
                .GetFromJsonAsync<GithubUser>($"users/{username}");

            return user;
        }
    }
}
