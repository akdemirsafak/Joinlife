// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace AuthServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { 
        
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),
            new ApiResource("location_resource"){Scopes={"location_fullpermission"}},
            new ApiResource("event_resource"){Scopes={"event_fullpermission"}},
            new ApiResource("basket_resource"){Scopes={"basket_fullpermission"}},
            new ApiResource("ticket_resource"){Scopes={"ticket_fullpermission"}},
            new ApiResource("gateway_resource"){Scopes={"gateway_fullpermission"}},
            new ApiResource("fileapi_resource"){Scopes={"fileapi_fullpermission"}},
            new ApiResource("payment_resource"){Scopes={"payment_fullpermission"}},
            new ApiResource("order_resource"){Scopes={"order_fullpermission"}},
            new ApiResource("notification_resource"){Scopes={"notification_fullpermission"}}
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
                        new IdentityResources.Email(),
                        new IdentityResource(){ Name="roles",DisplayName="Roles" ,Description="Kullanıcı rolleri",UserClaims=new[]{ "role"} } 
                        //Kendi claim'imizi oluşturuyoruz yukarıdakiler hazır claimler
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName), //IdentityServer'a istek yapabilmemiz için kendi sabitidir.
                new ApiScope("location_fullpermission","Location'a request için full yetki."),
                new ApiScope("event_fullpermission","Event'a request için full yetki."),
                new ApiScope("ticket_fullpermission","Ticket'a request için full yetki."),
                new ApiScope("gateway_fullpermission","Gateway'e request için full yetki."),
                new ApiScope("fileapi_fullpermission","FileApi'a request için full yetki."),
                new ApiScope("payment_fullpermission","Payment'a request için full yetki."),
                new ApiScope("basket_fullpermission","Basket'e request için full yetki."),
                new ApiScope("order_fullpermission","Order'a request için full yetki."),
                new ApiScope("notification_fullpermission","Notification'a request için full yetki.")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "WebMvcClient",
                    ClientName = "Asp.Net Core MVC",
                    ClientSecrets = { new Secret("Secret-1234".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //Refresh token barındırmayan grant type'dır.
                    AllowedScopes = {
                        "location_fullpermission",
                        "event_fullpermission",
                        "gateway_fullpermission",
                        "fileapi_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName //Bu scope'da belirlediğimiz clientId ve Secret ile hangi api'lara istek yapılabileceğini burada belirtiyoruz.
                    },
                    AccessTokenLifetime=30*24*60*60 //30 gün
                },

                new Client()
                {
                    ClientId="WebMvcClientForUser",
                    ClientName="Asp.Net Core MVC",
                    ClientSecrets={new Secret("Secret-1234".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword, //ResourceOwnerPasswordAndClientCredentials kullanırsak refresh token kullanamayız.
                    AllowOfflineAccess=true, //**** OfflineAccess Kullanıcı offline olsa bile kullanıcı adına bir refresh token göndererek kullanıcı için yeni bir accesstoken almamıza olanak verir.
                    AllowedScopes={
                        "basket_fullpermission",
                        "ticket_fullpermission",
                        "gateway_fullpermission",
                        "fileapi_fullpermission",
                        "payment_fullpermission",
                        "order_fullpermission",
                        "notification_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName, //API'ın kendisine istek yapabilmek için
                        IdentityServerConstants.StandardScopes.OfflineAccess,//Refresh token dönebilmemiz için OfflineAccess'de ekledik.
                        "roles"
                    },
                    AccessTokenLifetime=60*60, //1 Saat
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute, 
                    //Refresh token'ın süresi dolduğunda süreyi uzatacak mıyız ayarıdır.Yaptığımız ayar sabite denk gelir.
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds, //60 gün
                   // ! Her accesstoken alımında yeni bir refresh token da alınacaktır!.
                },  

            };
    }
}