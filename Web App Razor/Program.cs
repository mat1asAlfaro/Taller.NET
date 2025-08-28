using tarea_4.Infrastructure.Data;
using tarea_4.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IExcursionRepository, ExcursionRepository>();
builder.Services.AddScoped<IBeachRepository, BeachRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
