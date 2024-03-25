using DotNET.HttpClient.Sample.Api.Configs;
using DotNET.HttpClient.Sample.Api.Github.IHttpClientFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<GithubSettings>(
    builder.Configuration.GetSection(nameof(GithubSettings))
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGithubService, GithubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
