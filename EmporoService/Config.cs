using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmporoService
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResource("emporoapiresourcescope", new[]{"apiManager"})
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("api", "My Api"){}
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AbsoluteRefreshTokenLifetime = 86400,
                    SlidingRefreshTokenLifetime = 43200,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api", "emporoapiresourcescope" }
                }
            };
    }
}
