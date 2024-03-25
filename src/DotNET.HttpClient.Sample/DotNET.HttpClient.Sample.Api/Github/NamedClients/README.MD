# DotNET HttpClient Sample - Named Clients

## Author
Tea Binxiong

## Description
You can configure a `named client` by calling the `AddHttpClient` method and passing in the desired name. 
The `AddHttpClient` accepts a delegate that you can use to configure the default parameters on the `HttpClient` instance.

```C#
// Program.cs
services.AddHttpClient("github", (serviceProvider, client) =>
{
    var settings = serviceProvider
        .GetRequiredService<IOptions<GitHubSettings>>().Value;

    client.DefaultRequestHeaders.Add("Authorization", settings.GitHubToken);
    client.DefaultRequestHeaders.Add("User-Agent", settings.UserAgent);

    client.BaseAddress = new Uri("https://api.github.com");
});
```


```C#
// GithubService.cs
public class GitHubService
{
     private readonly IHttpClientFactory _factory;

    public GitHubService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<GitHubUser?> GetUserAsync(string username)
    {
        var client = _factory.CreateClient("github");

        GitHubUser? user = await client
            .GetFromJsonAsync<GitHubUser>($"users/{username}");

        return user;
    }
}
```


## Repository URL
[dotnet-httpclient-sample](https://github.com/teabinxiong/dotnet-httpclient-sample)





