using System;
using RestaurantDecider.Interfaces;
using RestaurantDecider.Models;
using RestaurantDecider.Persistence;

namespace RestaurantDecider.Services
{
    public sealed class RestaurantService : IRestaurantService
    {

        private static Random _random = new Random();

        public IFakeDataStore _db;

        public RestaurantService(IFakeDataStore db)
        {
            _db = db;
        }

        public void Add(Restaurant restaurant)
        {
            _db.Add(restaurant);
        }

        public List<Restaurant> Get()
        {
            return _db.GetAll();
        }

        public Restaurant PickRandom()
        {
            List<Restaurant> restaurants =
                _db.GetAll()
                .OrderBy(x => x.TimesPicked)
                .ToList();

            int restaurantIndex = _random.Next(0, (restaurants.Count() / 2));
            Restaurant pickedRestaurant = restaurants.ElementAt(restaurantIndex);
            _db.UpdatePicked(pickedRestaurant);

            return pickedRestaurant;
        }
    }
}