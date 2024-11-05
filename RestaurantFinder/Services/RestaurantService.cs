using RestaurantFinder.Models;
using RestaurantFinder.Repositories.Interfaces;
using RestaurantFinder.Services.Interfaces;

namespace RestaurantFinder.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<Restaurant> GetRandomRestaurant()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();
            if (!restaurants.Any()) return null;

            var random = new Random();

            var index = random.Next(restaurants.Count());
            var restaurant = restaurants.ElementAt(index);
            return restaurant;

        }
    }
}
