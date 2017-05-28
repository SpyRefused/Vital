using System;

namespace Vital.Api.Options
{
    public class AuthorizationOptions
    {
        private static void NixAuthorizationOptions(Microsoft.AspNetCore.Authorization.AuthorizationOptions options)
        {          
            options.AddPolicy("NixSuperUser", policy => policy.RequireClaim("GodMode", "true"));
        }


        public static Action<Microsoft.AspNetCore.Authorization.AuthorizationOptions> NixAuthorizationOptions()
        {
            return NixAuthorizationOptions;
        }
    }
}