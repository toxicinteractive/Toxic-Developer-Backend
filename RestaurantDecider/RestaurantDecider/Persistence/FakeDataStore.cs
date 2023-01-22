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
            newRestaurant.TimesPicked = 0;

            newRestaurant.OpenHour = DateTime.Now.SetTime(8, 0, 0, 0);
			newRestaurant.CloseHour = DateTime.Now.SetTime(18, 0, 0, 0);

            Restaurants.Add(newRestaurant);

            Restaurant newRestaurant2 = new Restaurant();
            newRestaurant2.Name = "KFC";
            newRestaurant2.Address = "Parkvägen 5";
            newRestaurant2.Food = "Chicken";
            newRestaurant2.TimesPicked = 0;

            newRestaurant2.OpenHour = DateTime.Now.SetTime(11, 0, 0, 0);
            newRestaurant2.CloseHour = DateTime.Now.SetTime(21, 0, 0, 0);

            Restaurants.Add(newRestaurant2);


            Restaurant newRestaurant3 = new Restaurant();
            newRestaurant3.Name = "Donken";
            newRestaurant3.Address = "Bredasten";
            newRestaurant3.Food = "Burgers";
            newRestaurant3.TimesPicked = 0;

            newRestaurant3.OpenHour = DateTime.Now.SetTime(1, 0, 0, 0);
            newRestaurant3.CloseHour = DateTime.Now.SetTime(23, 0, 0, 0);

            Restaurants.Add(newRestaurant3);

            Restaurant newRestaurant4 = new Restaurant();
            newRestaurant4.Name = "Max";
            newRestaurant4.Address = "Bredasten";
            newRestaurant4.Food = "Burgers";
            newRestaurant4.TimesPicked = 0;

            newRestaurant4.OpenHour = DateTime.Now.SetTime(12, 0, 0, 0);
            newRestaurant4.CloseHour = DateTime.Now.SetTime(18, 0, 0, 0);

            Restaurants.Add(newRestaurant4);
        }

		public void Add(Restaurant restaurant)
		{
			Restaurants.Add(restaurant);
		}

        public List<Restaurant> GetAll()
        {
			return Restaurants;
        }

        public void UpdatePicked(Restaurant restaurant)
        {
            Restaurants.Remove(restaurant);
            restaurant.TimesPicked++;
            Restaurants.Add(restaurant);
        }
    }
}

