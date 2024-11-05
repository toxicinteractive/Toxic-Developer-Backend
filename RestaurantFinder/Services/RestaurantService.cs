using RestaurantFinder.Models;
using RestaurantFinder.Repositories.Interfaces;
using RestaurantFinder.Services.Interfaces;

namespace RestaurantFinder.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public static int? _lastSelectedRestuarantId = null;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task<Restaurant> GetRandomRestaurant()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();
            if (!restaurants.Any()) return null;

            var random = new Random();

            Restaurant restaurant;

            do
            {
                var index = random.Next(restaurants.Count());
                restaurant = restaurants.ElementAt(index);
            } while (restaurant.Id == _lastSelectedRestuarantId);

            _lastSelectedRestuarantId = restaurant.Id;
        
            return restaurant;

        }

        public bool ValidateRestaurantValues(Restaurant restaurant)
        {
            if (string.IsNullOrEmpty(restaurant.Name) ||
                string.IsNullOrEmpty(restaurant.Food) ||
                string.IsNullOrEmpty(restaurant.Address) ||
                string.IsNullOrEmpty(restaurant.openingHours)) return false;
            return true;
        }
    }
}
