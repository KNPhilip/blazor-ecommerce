using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebUI.Client;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

Uri baseAddress = new(builder.HostEnvironment.BaseAddress);

builder.Services.AddServicesFromExtensionsClass(baseAddress);

await builder.Build().RunAsync();
