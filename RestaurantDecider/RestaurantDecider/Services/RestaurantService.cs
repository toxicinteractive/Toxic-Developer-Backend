using System;
using RestaurantDecider.Interfaces;
using RestaurantDecider.Models;
using RestaurantDecider.Persistence;

namespace RestaurantDecider.Services
{
    public sealed class RestaurantService : IRestaurantService
    {
        public IFakeDataStore _db;

        public RestaurantService(IFakeDataStore db)
        {
            _db = db;
        }

        public void Add(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> Get()
        {
            return _db.GetAll();
        }
    }
}

