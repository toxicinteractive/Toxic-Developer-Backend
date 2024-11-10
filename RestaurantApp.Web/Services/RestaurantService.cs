using RestaurantApp.Web.Entities;
using RestaurantApp.Web.Repositories;

namespace RestaurantApp.Web.Services
{
    public static class RestaurantService
    {
        private static int _setId = 1;

        public static void Create(Restaurant restaurant)
        {
            restaurant.Id = _setId;
            _setId++;

            RestaurantRepository.Create(restaurant);
        }
        public static IEnumerable<Restaurant> GetAll() => RestaurantRepository.GetAll();
        public static void GetAndSetRestaurantOfTheDay()
        {
            // Get a random restaurant that is currently not selected as Restaurant of the day.
            var restaurantToSet = RestaurantRepository.GetById(RandomRestaurantIdGenerator());

            // Set current daily restaurant to false.
            SetCurrentDailyRestaurantToFalse();

            // Set the prop of the new restaurant of the day.
            if (restaurantToSet != null)
            {
                restaurantToSet.IsRestaurantOfTheDay = true;
            }
            // Set the restaurant object in Viewmodel prop "Restaurant of the day".

        }
        private static void SetCurrentDailyRestaurantToFalse()
        {
            var restaurants = GetAll();
            var restaurant = restaurants.Where(restaurant => restaurant.IsRestaurantOfTheDay == true).SingleOrDefault();
            if (restaurant != null)
            {
                restaurant.IsRestaurantOfTheDay = false;
            }
        }
        private static int RandomRestaurantIdGenerator()
        {
            var restaurants = GetAll();
            var random = new Random();
            var randomId = restaurants.Where(restaurant => restaurant.IsRestaurantOfTheDay == false)
                        .OrderBy(r => random.Next())
                        .Select(r => r.Id)
                        .FirstOrDefault();

            return randomId;
        }
    }
}
