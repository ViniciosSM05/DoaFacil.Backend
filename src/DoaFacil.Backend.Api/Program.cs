using Asp.Versioning.ApiExplorer;
using DoaFacil.Backend.Api.EnvironmentConfigs;
using DoaFacil.Backend.Infra.IoC;

const string DEFAULT_POLICY_NAME = "default";
var builder = WebApplication.CreateBuilder(args);

SwaggerEnvironmentConfig.ConfigureServices(builder.Services);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DEFAULT_POLICY_NAME, policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});
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

app.UseCors(DEFAULT_POLICY_NAME);
StartupIoC.Start(app);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
