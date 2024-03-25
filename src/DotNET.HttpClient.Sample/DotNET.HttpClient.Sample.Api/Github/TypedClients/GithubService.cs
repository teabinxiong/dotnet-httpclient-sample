using DotNET.HttpClient.Sample.Api.Configs;
using DotNET.HttpClient.Sample.Api.Models;
using Microsoft.Extensions.Options;

namespace DotNET.HttpClient.Sample.Api.Github.TypedClients
{
    public class GithubService : IGithubService
    {
        private readonly System.Net.Http.HttpClient _client;

        public GithubService( System.Net.Http.HttpClient client)
        {
            _client = client;
        }

        public async Task<GithubUser?> GetUserAsync(string username)
        {
         
            GithubUser? user = await _client
                .GetFromJsonAsync<GithubUser>($"users/{username}");

            return user;
        }
    }
}
