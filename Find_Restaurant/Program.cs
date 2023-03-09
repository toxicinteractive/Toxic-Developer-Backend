using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Find_Restaurant.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

var conn = "Data Source=EMRAN-2023\\MSSQLSERVER2022;Initial Catalog=Find-Restaurant-DB;Integrated Security=True;Trust Server Certificate=true;";
builder.Services.AddDbContext<FindRestaurantDbContext>(options => options.UseSqlServer(conn));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
