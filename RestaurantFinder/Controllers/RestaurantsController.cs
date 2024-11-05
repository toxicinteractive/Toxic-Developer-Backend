﻿using RestaurantFinder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantFinder.Repositories.Interfaces;
using RestaurantFinder.Models;

namespace RestaurantFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.CreateRestaurant(restaurant);
         
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();
            return Ok(restaurants);
        }
    }
}
