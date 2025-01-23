using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Classes.Data;
using SocialMedia.Classes.Models;
using SocialMedia.Front.Client.Middlewares;
using SocialMedia.Front.Components;

var builder = WebApplication.CreateBuilder(args);

//Devlooped services
builder.Services.AddServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);

builder.Services.AddHttpClient("", options =>
{
    options.BaseAddress = new Uri(builder.Configuration["ApiUrl"]!);
}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    _ = options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/auth/login";
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
} else
{
    _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SocialMedia.Front.Client._Imports).Assembly);

app.Run();
