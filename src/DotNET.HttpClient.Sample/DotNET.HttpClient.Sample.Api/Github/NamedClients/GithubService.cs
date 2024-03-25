using DotNET.HttpClient.Sample.Api.Configs;
using DotNET.HttpClient.Sample.Api.Models;
using Microsoft.Extensions.Options;

namespace DotNET.HttpClient.Sample.Api.Github.NamedClients
{
    public class GithubService : IGithubService
    {
        private readonly System.Net.Http.IHttpClientFactory _factory;

        public GithubService( System.Net.Http.IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<GithubUser?> GetUserAsync(string username)
        {
            var client = _factory.CreateClient("github");

            GithubUser? user = await client
                .GetFromJsonAsync<GithubUser>($"users/{username}");

            return user;
        }
    }
}
