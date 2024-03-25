using DotNET.HttpClient.Sample.Api.Models;

namespace DotNET.HttpClient.Sample.Api.Github.TypedClients
{
    public interface IGithubService
    {
       Task<GithubUser?> GetUserAsync(string username);
    }
}
