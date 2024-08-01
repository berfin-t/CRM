using CRM.WebApp;
using CRM.WebApp.Infrastructure.Services;
using CRM.WebApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

const string ClientName = "WebApiClient";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(ClientName, client =>
{
    client.BaseAddress = new Uri("http://localhost:5001");
});
    //.AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IIdentityService, IdentityService>();

await builder.Build().RunAsync();
