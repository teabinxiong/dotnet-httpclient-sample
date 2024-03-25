using DotNET.HttpClient.Sample.Api.Models;

namespace DotNET.HttpClient.Sample.Api.Github.NamedClients
{
    public interface IGithubService
    {
       Task<GithubUser?> GetUserAsync(string username);
    }
}
