# DotNET HttpClient Sample - HttpClient Factory

## Author
Tea Binxiong

## Description
Inject `IHttpClientFactory` into the Service class and create the `HttpClient` instance.
After that, simply call the `CreateClient` method and use the returned `HttpClient` instance to send your HTTP requests.

e.g. The following service class inside the project.
```C#
public class GitHubService
{
    private readonly GitHubSettings _settings;
    private readonly IHttpClientFactory _factory;

    public GitHubService(
        IOptions<GitHubSettings> settings,
        IHttpClientFactory factory)
    {
        _settings = settings.Value;
        _factory = factory;
    }

    public async Task<GitHubUser?> GetUserAsync(string username)
    {
        var client = _factory.CreateClient();

        client.DefaultRequestHeaders.Add("Authorization", _settings.GitHubToken);
        client.DefaultRequestHeaders.Add("User-Agent", _settings.UserAgent);
        client.BaseAddress = new Uri("https://api.github.com");

        GitHubUser? user = await client
            .GetFromJsonAsync<GitHubUser>($"users/{username}");

        return user;
    }
}
```


## Repository URL
[dotnet-httpclient-sample](https://github.com/teabinxiong/dotnet-httpclient-sample)





