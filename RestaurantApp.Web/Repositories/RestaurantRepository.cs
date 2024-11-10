using RestaurantApp.Web.Entities;

namespace RestaurantApp.Web.Repositories
{
    public static class RestaurantRepository
    {
        private static List<Restaurant> _restaurants = [];
        
        public static void Create(Restaurant restaurant) => _restaurants.Add(restaurant);
        public static IEnumerable<Restaurant> GetAll() => _restaurants.AsEnumerable();
        public static Restaurant GetById(int id) => _restaurants.SingleOrDefault(restaurant => restaurant.Id == id);
    }
}
