using IdentityModel;
using System.Security.Claims;
using IdentityServer4.Test;

namespace IdentityServer.Configurations;

public partial class Config
{
    public static List<TestUser> TestUsers => new List<TestUser>
  {
        new TestUser
        {
            SubjectId = "123",
            Username = "Guru",
            Password = "Test@123",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "Guru K"),
                new Claim(JwtClaimTypes.GivenName, "Guru"),
                new Claim(JwtClaimTypes.FamilyName, "Kumar"),
            }
        }
    };
}
