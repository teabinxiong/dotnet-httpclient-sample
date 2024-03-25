using DotNET.HttpClient.Sample.Api.Configs;
using DotNET.HttpClient.Sample.Api.Models;
using Microsoft.Extensions.Options;

namespace DotNET.HttpClient.Sample.Api.Github.IHttpClientFactory
{
    public class GithubService : IGithubService
    {
        private readonly GithubSettings _settings;

        public GithubService(IOptions<GithubSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<GithubUser?> GetUserAsync(string username)
        {
            var client = new System.Net.Http.HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", _settings.GithubToken);
            client.DefaultRequestHeaders.Add("User-Agent", _settings.UserAgent);
            client.BaseAddress = new Uri("https://api.github.com");

            GithubUser? user = await client
                .GetFromJsonAsync<GithubUser>($"users/{username}");

            return user;
        }

    }
}
