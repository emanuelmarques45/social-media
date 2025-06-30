using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SocialMedia.Front.Client.Middlewares;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Devlooped services
builder.Services.AddServices();

builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddHttpClient("Auth", options =>
{
    options.BaseAddress = new Uri(builder.Configuration["URL:ApiUrl"]!);
}).ConfigurePrimaryHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
