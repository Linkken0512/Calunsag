using CalunsagWebAssemblyIPT102CRUD;
using CalunsagWebAssemblyIPT102CRUD.Models;
using CalunsagWebAssemblyIPT102CRUD.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
{
    // You don't need to adjust the connection string here
    return new StudentService(sp.GetRequiredService<HttpClient>());
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
