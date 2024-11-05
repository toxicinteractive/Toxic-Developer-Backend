using RestaurantFinder.Models;

namespace RestaurantFinder.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task CreateRestaurant(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
    }
}
