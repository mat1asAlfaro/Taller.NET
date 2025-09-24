using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add Radzen Service to the Client
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
