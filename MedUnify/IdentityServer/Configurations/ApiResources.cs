using IdentityServer4.Models;

namespace IdentityServer.Configurations;

public partial class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("MedUnify")
        {
            Scopes = new List<string>{ "api.read","api.write" },
            ApiSecrets = new List<Secret>{ new Secret("secret".Sha256()) }
        }
    };

}
