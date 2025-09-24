using Microsoft.AspNetCore.SignalR;
using Radzen;
using tarea_6.Client.Pages;
using tarea_6.Components;
using tarea_6.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(tarea_6.Client._Imports).Assembly);

app.MapHub<SensorHub>("temperatureSensor");

// curl http://localhost:5242/changeTemperature?temp=42
app.MapGet("/changeTemperature", (int temp, IHubContext<SensorHub> hubContext) =>
{
    hubContext.Clients.All.SendAsync("temperatureChange", temp);
    return Results.Ok($"Processed message: New Temperature = {temp}");
});

app.Run();
