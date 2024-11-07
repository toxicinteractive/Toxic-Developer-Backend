using RestaurantApp.Web.Entities;

namespace RestaurantApp.Web.Repositories
{
    public class RestaurantRepository
    {
        private List<Restaurant> _restaurants = [];
        
        public void Create(Restaurant restaurant) => _restaurants.Add(restaurant);
        public IEnumerable<Restaurant> GetAll() => _restaurants;
        public Restaurant GetById(int id) => _restaurants.Single(restaurant => restaurant.Id == id);
    }
}
