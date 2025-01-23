using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SocialMedia.Front.Client.Middlewares;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Devlooped services
builder.Services.AddServices();

builder.Services.AddHttpClient("", options =>
{
    options.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!);
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();

await builder.Build().RunAsync();
