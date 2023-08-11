using IdentityServer4.Models;

namespace IdentityServer.Configurations;

public partial class Config
{
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };

}
