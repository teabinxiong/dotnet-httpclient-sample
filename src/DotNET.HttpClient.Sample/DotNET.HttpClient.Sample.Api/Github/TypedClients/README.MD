# DotNET HttpClient Sample - Typed Clients

## Author
Tea Binxiong

## Description
The downside of using `named clients` is having to resolve an `HttpClient` by passing in a name every time.
There\'s a better way to achieve the same behavior by configuring a `typed client`. 
You can do this by calling the `AddClient<TClient>` method and configuring the service that will consume the `HttpClient`.

```C#
// Program.cs
services.AddHttpClient<GitHubService>((serviceProvider, client) =>
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
   public class GitHubService
  {
      private readonly HttpClient client;
  
      public GitHubService(HttpClient client)
      {
          _client = client;
      }
  
      public async Task<GitHubUser?> GetUserAsync(string username)
      {
          GitHubUser? user = await client
              .GetFromJsonAsync<GitHubUser>($"users/{username}");
  
          return user;
      }
  }
}
```


## Repository URL
[dotnet-httpclient-sample](https://github.com/teabinxiong/dotnet-httpclient-sample)





