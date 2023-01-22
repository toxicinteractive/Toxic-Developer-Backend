using System;
using RestaurantDecider.Extensions;
using RestaurantDecider.Models;

namespace RestaurantDecider.Persistence
{
	public interface IFakeDataStore
	{
        public void Add(Restaurant restaurant);
        public List<Restaurant> GetAll();
        public void UpdatePicked(Restaurant restaurant);
    }
}

