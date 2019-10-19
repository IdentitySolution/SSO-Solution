using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TemplateSourceName
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name="api1",
                    DisplayName="My API",
                    Scopes = { new Scope("api1", "My API")},
                    ApiSecrets = {new Secret("secret".Sha256())}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // Console client
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                // MVC Client Implicit
                new Client
                {
                    ClientId = "mvc_implicit",
                    ClientName = "MVC Client - Implicit",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    // where to redirect to after login
                    RedirectUris = {"https://mvc-implicit.website.com:5005/signin-oidc"},

                    // where to redirect to after logout
                    PostLogoutRedirectUris = {"https://mvc-implicit.website.com:5005/signout-callback-oidc"},

                    FrontChannelLogoutUri = "https://mvc-implicit.website.com:5005/home/logout",

                    AllowedScopes = new List<string>{
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                // MVC Client Hybrid
                new Client
                {
                    ClientId = "mvc_hybrid",
                    ClientName = "MVC Client - Hybrid",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AccessTokenType = AccessTokenType.Reference,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "https://mvc-hybrid.website.com:5007/signin-oidc" },
                    PostLogoutRedirectUris = { "https://mvc-hybrid.website.com:5007/signout-callback-oidc" },
                    FrontChannelLogoutUri = "https://mvc-hybrid.website.com:5007/home/logout",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },

                    AllowOfflineAccess = true
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://js.website.com:5009/callback.html" },
                    PostLogoutRedirectUris = { "https://js.website.com:5009/index.html" },
                    AllowedCorsOrigins =     { "https://js.website.com:5009" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                },
                // React Client
                new Client
                {
                    ClientId = "react",
                    ClientName = "React Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    AccessTokenType = AccessTokenType.Reference,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =           { "https://react.website.com:5011/callback" },
                    PostLogoutRedirectUris = { "https://react.website.com:5011/" },
                    AllowedCorsOrigins =     { "https://react.website.com:5011" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
        }
    }
}