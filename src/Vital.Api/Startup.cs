using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Vital.Api.Options;
using AuthorizationOptions = Microsoft.AspNetCore.Authorization.AuthorizationOptions;

namespace Vital.Api
{
    public class Startup
    {
        private SymmetricSecurityKey _signingKey;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(x =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); x.Filters.Add(new AuthorizeFilter(policy));

            });

            services.AddAuthorization(AuthorizationOptions);
            services.AddCors();

            services.Configure<Configuration.Configuration>(Configuration);

            var config = Configuration.Get<Configuration.Configuration>();
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.SecretKey));

            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions            
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(policyBuilder => {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyOrigin();
            });

            app.UseStaticFiles();

            app.UseMvc();
        }

        private void AuthorizationOptions(AuthorizationOptions options)
        {
            options.AddPolicy("doctoruser", policy => policy.RequireClaim("doctor", "true"));
        }
    }
}
