using RestaurantApp.Web.Entities;
using RestaurantApp.Web.Repositories;

namespace RestaurantApp.Web.Services
{
    public static class RestaurantService
    {
        // Create DONE , GetAll DONE, RandomRest(use getbyid from repo).

        public static void Create(Restaurant restaurant) => RestaurantRepository.Create(restaurant);
        public static IEnumerable<Restaurant> GetAll() => RestaurantRepository.GetAll();
        public static void GetRestaurantOfTheDay(int id) => RestaurantRepository.GetById(id);
    }
}
