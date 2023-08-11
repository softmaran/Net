using IdentityServer.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();
builder.Services.AddControllers();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseIdentityServer();

app.Run();
