using WebUI.Server.Components;
using WebUI.Server.Components.Account;
using WebUI.Server.Extensions;
using UseCases;
using DataAccess;
using Gateways;
using Gateways.Options;
using WebUI.Server.Adapters;
using UseCases.Ports.Output;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

SetEnvironmentVariablesFrom(builder.Configuration);

builder.Services.AddAspNetCore(builder.Configuration);
builder.Services.AddBlazor();
builder.Services.AddSecurity();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddOptions<CloudinaryOptions>().Bind(builder.Configuration
    .GetSection(CloudinaryOptions.SectionName));

builder.Services.AddOptions<MailSettingsOptions>().Bind(builder.Configuration
    .GetSection(MailSettingsOptions.SectionName));

builder.Services.AddDataAccess();
builder.Services.AddGateways();
builder.Services.AddUseCases();
builder.Services.AddUIServices();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSecurity();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebUI.Client.Components._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

app.Run();

static void SetEnvironmentVariablesFrom(IConfiguration configuration)
{
    foreach (var section in configuration.AsEnumerable())
    {
        if (!string.IsNullOrEmpty(section.Key) && !string.IsNullOrEmpty(section.Value))
        {
            Environment.SetEnvironmentVariable(section.Key.Replace(":", "__"), section.Value);
        }
    }
}
