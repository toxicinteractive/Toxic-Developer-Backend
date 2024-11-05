using Microsoft.EntityFrameworkCore;
using RestaurantFinder.Models;

namespace RestaurantFinder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
