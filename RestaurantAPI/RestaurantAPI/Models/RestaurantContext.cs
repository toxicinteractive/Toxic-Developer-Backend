using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RestaurantAPI.Models;

namespace RestaurantAPI.Models;

public class RestaurantContext : DbContext
{
    public RestaurantContext(DbContextOptions<RestaurantContext> options)
    : base(options)
    {
    }

    public DbSet<RestaurantItem> RestaurantItems { get; set; } = null!;
    public DbSet<OpenHoursItem> OpenHoursItems { get; set; } = null!;
    public DbSet<UsedRandomRestaurantItem> UsedRandomRestaurantItems { get; set; } = null!;
}