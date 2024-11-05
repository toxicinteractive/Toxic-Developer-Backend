﻿using RestaurantFinder.Models;

namespace RestaurantFinder.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetRandomRestaurant();

        public bool ValidateRestaurantValues(Restaurant restaurant);
    }
}
