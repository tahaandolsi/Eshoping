// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace EShopping.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

       
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                //new ApiScope("scope1"),
                //new ApiScope("scope2"),
                new ApiScope("catalogapi"),
                new ApiScope("basketapi"),
                new ApiScope("basketapi.read"),
                new ApiScope("basketapi.write"),
                //new ApiScope("catalogapi.read"),
                //new ApiScope("catalogapi.write"),
                new ApiScope("eshoppinggateway")
            };
        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
               //new List of microservices can go here
               //List of Microservices can go here.
                new ApiResource("Catalog", "Catalog.API")
                {
                    Scopes = {"catalogapi"}
                },
                new ApiResource("Basket", "Basket.API")
                {
                    Scopes = { "basketapi"  }
                },
                //new ApiResource("Basket", "Basket.API")
                //{
                //    Scopes = { "basketapi.read" , "basketapi.write" }
                //},
                new ApiResource("EShoppingGateway", "EShopping Gateway")
                {
                    Scopes = {"eshoppinggateway"}
                }
           }; // this i added it 

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //m2m flow 
                new Client
                {
                    ClientName = "Catalog API Client",
                    ClientId = "CatalogApiClient",
                    ClientSecrets = {new Secret("5c6eb3b4-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"catalogapi"}
                },
                //new Client
                //{
                //    ClientName = "Basket API Client",
                //    ClientId = "BasketApiClient",
                //    ClientSecrets = {new Secret("5c6ec4c5-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    AllowedScopes = { "basketapi.read" , "basketapi.write" }
                //},
                new Client
                {
                    ClientName = "Basket API Client",
                    ClientId = "BasketApiClient",
                    ClientSecrets = {new Secret("5c6ec4c5-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "basketapi"}
                }
                ,

                new Client
                {
                    ClientName = "EShopping Gateway Client",
                    ClientId = "EShoppingGatewayClient",
                    ClientSecrets = {new Secret("5c7fd5c5-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "eshoppinggateway" , "basketapi" }
                }
                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    
                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
            };
    }
}