using DotNET.HttpClient.Sample.Api.Github.IHttpClientFactory;
using Microsoft.AspNetCore.Mvc;

namespace DotNET.HttpClient.Sample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoryController : ControllerBase
    {
        private readonly ILogger<RepositoryController> _logger;
        private readonly IGithubService _githubService;
        public RepositoryController(
            ILogger<RepositoryController> logger,
            IGithubService githubService
         )
        {
            _logger = logger;
            _githubService = githubService;
        }

        [HttpGet("ReadGithubUser/{userName}")]
        public async Task<IActionResult> ReadGithubUser([FromRoute]string userName)
        {
            var result = await _githubService.GetUserAsync("teabinxiong");

            return Ok(result);
        }
    }
}