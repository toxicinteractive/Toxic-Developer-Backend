using System;
using RestaurantDecider.Models;

namespace RestaurantDecider.Interfaces
{
	public interface IRestaurantService
    {
		public void Add(Restaurant restaurant);
		public List<Restaurant> Get();
    }
}

