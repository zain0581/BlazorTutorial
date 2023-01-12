using BlazorTutorial.GUI.Data;
using BlazorTutorialConsole.Interfaces;
using BlazorTutorialConsole.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// n�r du m�der et interface s� map det til et repo...
builder.Services.AddScoped<IHorse, HorseRepository>();
builder.Services.AddScoped<ISamurai, SamuraiRepository>();


//builder.Services.AddScoped<ISamurai, SamuraiRepository>();

builder.Services.AddSingleton<WeatherForecastService>();



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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
