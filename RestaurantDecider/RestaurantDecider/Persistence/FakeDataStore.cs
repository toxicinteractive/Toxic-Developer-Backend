using System;
using RestaurantDecider.Extensions;
using RestaurantDecider.Models;

namespace RestaurantDecider.Persistence
{
	public sealed class FakeDataStore : IFakeDataStore
	{
		List<Restaurant> Restaurants = new List<Restaurant>();

		public FakeDataStore()
		{
			SetNewRestaurants();
		}

        private void SetNewRestaurants()
        {
			Restaurant newRestaurant = new Restaurant();
			newRestaurant.Name = "Lord of the Wings";
			newRestaurant.Address = "Sveavägen 10";
			newRestaurant.Food = "Chinese";

			newRestaurant.OpenHour = DateTime.Now.SetTime(8, 0, 0, 0);
			newRestaurant.CloseHour = DateTime.Now.SetTime(18, 0, 0, 0);

            Restaurants.Add(newRestaurant);

            Restaurant newRestaurant2 = new Restaurant();
            newRestaurant2.Name = "KFC";
            newRestaurant2.Address = "Parkvägen 5";
            newRestaurant2.Food = "Chicken";

            newRestaurant2.OpenHour = DateTime.Now.SetTime(11, 0, 0, 0);
            newRestaurant2.CloseHour = DateTime.Now.SetTime(21, 0, 0, 0);

            Restaurants.Add(newRestaurant2);
        }

		public void Add(Restaurant restaurant)
		{
			Restaurants.Add(restaurant);
		}

        public List<Restaurant> GetAll()
        {
			return Restaurants;
        }
    }
}

