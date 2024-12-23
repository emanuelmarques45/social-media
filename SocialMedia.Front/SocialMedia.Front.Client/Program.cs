using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Front.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["ApiUrl"] ?? "https://localhost:7210")
    });

builder.Services.AddScoped<IPostService, PostService>();

await builder.Build().RunAsync();
