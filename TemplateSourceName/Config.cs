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
                    RedirectUris = {"http://mvc-implicit.website.com:5002/signin-oidc"},

                    // where to redirect to after logout
                    PostLogoutRedirectUris = {"http://mvc-implicit.website.com:5002/signout-callback-oidc"},

                    FrontChannelLogoutUri = "http://mvc-implicit.website.com:5002/home/logout",

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

                    RedirectUris           = { "http://mvc-hybrid.website.com:5003/signin-oidc" },
                    PostLogoutRedirectUris = { "http://mvc-hybrid.website.com:5003/signout-callback-oidc" },
                    FrontChannelLogoutUri = "http://mvc-hybrid.website.com:5003/home/logout",

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

                    RedirectUris =           { "http://js.website.com:5004/callback.html" },
                    PostLogoutRedirectUris = { "http://js.website.com:5004/index.html" },
                    AllowedCorsOrigins =     { "http://js.website.com:5004" },

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

                    RedirectUris =           { "http://react.website.com:5005/callback" },
                    PostLogoutRedirectUris = { "http://react.website.com:5005/" },
                    AllowedCorsOrigins =     { "http://react.website.com:5005" },

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