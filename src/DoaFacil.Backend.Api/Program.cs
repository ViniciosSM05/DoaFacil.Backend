using Asp.Versioning.ApiExplorer;
using DoaFacil.Backend.Api.EnvironmentConfigs;
using DoaFacil.Backend.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

SwaggerEnvironmentConfig.ConfigureServices(builder.Services);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
StartupIoC.Register(builder.Services);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    SwaggerEnvironmentConfig.ConfigureApplication(app, apiVersionDescriptionProvider);

}

StartupIoC.Start(app);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
