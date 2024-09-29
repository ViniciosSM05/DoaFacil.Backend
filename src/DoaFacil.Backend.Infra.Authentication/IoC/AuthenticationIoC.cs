using DoaFacil.Backend.Infra.Authentication.AuthProviders.User;
using DoaFacil.Backend.Infra.Authentication.AuthServices.Token;
using DoaFacil.Backend.Infra.Configuration.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace DoaFacil.Backend.Infra.Authentication.IoC
{
    public static class AuthenticationIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<ITokenAuthService, TokenAuthService>();
            services.AddScoped<IUserAuthProvider, UserAuthProvider>();

            var authConfig = services.BuildServiceProvider().GetService<IAuthConfig>();
            if (authConfig is null || string.IsNullOrWhiteSpace(authConfig.TokenEncryptKey))
                return;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authConfig.TokenEncryptKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                x.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.OnStarting(async () =>
                            await Task.FromResult(context.Response.StatusCode = (int)HttpStatusCode.Unauthorized)
                        );

                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void Start(IApplicationBuilder app)
        {
            var authConfig = app.ApplicationServices.GetService<IAuthConfig>();
            if (authConfig is null || string.IsNullOrWhiteSpace(authConfig.TokenEncryptKey))
                return;

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}