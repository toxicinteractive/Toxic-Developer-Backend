using Microsoft.EntityFrameworkCore;
using RestaurantFinder.Data;
using RestaurantFinder.Repositories;
using RestaurantFinder.Repositories.Interfaces;
using RestaurantFinder.Services;
using RestaurantFinder.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("RestaurantDb"));

builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddTransient<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
