// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
            new ApiResource("productdetail"){Scopes={"productdetail"}}
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
                new ApiScope("productdetail","ProductDetail API")
            };


        public static IEnumerable<Client> Clients => new Client[]
            {

                new Client
                {
                    ClientId = "restaurantclient",
                    ClientName = "Rastaurant Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("restaurant".Sha256()) },

                    AllowedScopes =
                    {
                        IdentityServerConstants.LocalApi.ScopeName,
                        "productdetail"
                    }
                },

                //password 
                new Client
                {

                },
            };
    }
}