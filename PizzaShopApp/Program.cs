using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PizzaShopApp.CRUD;
using PizzaShopApp.Data;
using PizzaShopApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<CustomerCRUD>();
builder.Services.AddScoped<OrderCRUD>();
builder.Services.AddScoped<OrderlineCRUD>();
builder.Services.AddScoped<PizzaCrud>();
builder.Services.AddDbContext<PizzaShopContext>(options => options.UseSqlite("Data Source=pizzaShop-2.db"));
builder.Services.AddHttpClient();

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
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
