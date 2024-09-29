using Microsoft.OpenApi.Models;
using Asp.Versioning.ApiExplorer;

namespace DoaFacil.Backend.Api.EnvironmentConfigs
{
    public static class SwaggerEnvironmentConfig
    {
        public static void ConfigureApplication(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                foreach (var groupName in provider.ApiVersionDescriptions.Select(x => x.GroupName))
                {
                    x.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
                }
            });
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services
                 .AddApiVersioning((Asp.Versioning.ApiVersioningOptions config) =>
                 {
                     config.ReportApiVersions = true;
                     config.AssumeDefaultVersionWhenUnspecified = true;
                 })
                 .AddMvc()
                 .AddApiExplorer(p =>
                 {
                     p.GroupNameFormat = "'v'VVV";
                     p.SubstituteApiVersionInUrl = true;
                 });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Doa Facil - API", Version = "v1" });

                const string SECURITY_SCHEME_ID = "jwtAuth";

                c.AddSecurityDefinition(SECURITY_SCHEME_ID, new OpenApiSecurityScheme
                {
                    Description = @"
    Utilize a rota 'v1/auth/token/{userIntegrationId}' passando o header 'X_SECRET_KEY' para gerar o token.

    Para as rotas que necessitam de autenticação, passe no header 'Authorization' o token gerado no formato: 'Bearer SEU_TOKEN'.

    Caso utilize o campo abaixo para colocar o token, não é necessário a palavra 'Bearer', passar direto o token.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SECURITY_SCHEME_ID
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                c.CustomSchemaIds(type => type.ToString());
            });
        }
    }
}
