using Microsoft.AspNetCore.SignalR;
using tarea3a.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Add SignalR service
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapHub<AuthHub>("/AuthHub");

app.MapGet("/verify/user/{userId}", (string userId,
    ILogger<AuthHub> logger,
    IHubContext<AuthHub> hubContext) =>
{
    logger.LogInformation($"The client with id {userId} will be notified.");

    hubContext.Clients.Client(userId).SendAsync("VerificationOk", userId);

    return Results.Content("<h1>Verification successful! You can close this tab.</h1>", "text/html");
});

app.Run();
