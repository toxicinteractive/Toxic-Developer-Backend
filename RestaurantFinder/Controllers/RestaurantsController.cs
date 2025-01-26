using RestaurantFinder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantFinder.Repositories.Interfaces;
using RestaurantFinder.Models;
using RestaurantFinder.Services.Interfaces;

namespace RestaurantFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantService _restaurantService;
        public RestaurantsController(IRestaurantRepository restaurantRepository, IRestaurantService restaurantService)
        {
            _restaurantRepository = restaurantRepository;
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateRestaurant(Restaurant restaurant)
        {
            var isRestaurantValuesValid = _restaurantService.ValidateRestaurantValues(restaurant);
            if (!isRestaurantValuesValid) return BadRequest("Please enter empty fields");

            await _restaurantRepository.CreateRestaurant(restaurant);
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("random")]
        public async Task<ActionResult<Restaurant>> GetRandomRestaurant()
        {

            var randomRestaurant = await _restaurantService.GetRandomRestaurant();
            if (randomRestaurant == null) return NotFound("No restaurants was found, please create some!");

            return Ok(randomRestaurant);
        }
    }
}
