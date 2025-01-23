using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace SocialMedia.Front.Client.Middlewares
{
    [Service(ServiceLifetime.Transient)]
    public class CookieHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _ = request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            request.Headers.Add("X-Requested-With", ["XMLHttpRequest"]);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
