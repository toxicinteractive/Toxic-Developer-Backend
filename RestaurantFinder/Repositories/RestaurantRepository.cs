using Microsoft.EntityFrameworkCore;
using RestaurantFinder.Data;
using RestaurantFinder.Models;
using RestaurantFinder.Repositories.Interfaces;

namespace RestaurantFinder.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }
    }
}
