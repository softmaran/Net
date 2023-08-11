using IdentityServer4.Models;

namespace IdentityServer.Configurations;

public partial class Config
{
    public static IEnumerable<Client> Clients => new List<Client>
    {
        new()
        {
            ClientId = "client",
            ClientName = "Client Credentials Client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes =
            {
                "api.read",
                "api.write"
            }
        }
    };
}
