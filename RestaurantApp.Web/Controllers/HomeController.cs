using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Web.Entities;
using RestaurantApp.Web.Models;
using RestaurantApp.Web.Services;
using System.Diagnostics;

namespace RestaurantApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new RestaurantViewModel();
            var restaurants = RestaurantService.GetAll();

            vm.Restaurants = restaurants;

            // Set the restaurant object in Viewmodel prop "Restaurant of the day".
            if (vm.Restaurants.Count() != 0)
            {
                vm.RestaurantOfTheDay = restaurants.SingleOrDefault(r => r.IsRestaurantOfTheDay == true);
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateRestaurant(string name, string foodType, string location, string openingHours)
        {
            var restaurant = new Restaurant { Name = name, FoodType = foodType, Location = location, OpeningHours = openingHours };

            RestaurantService.Create(restaurant);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetDailyRestaurant()
        {
            RestaurantService.GetAndSetRestaurantOfTheDay();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
