using Find_Restaurant.Models;
using Find_Restaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Find_Restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private FindRestaurantDbContext _dbContext;
        public RestaurantController(FindRestaurantDbContext _context)
        {
            _dbContext = _context;
        }

        // Search Restaurants :

        [HttpGet]
        public IActionResult ViewRestaurantList()
        {
            RestaurantsViewModel model = new RestaurantsViewModel();

            model.DishCategoryList = _dbContext.CategoryDishes.ToList();

            model.RestaurantList = _dbContext.Restaurants.OrderByDescending(n => n.CreationDate).ToList();

            return View(model);
        }


        [HttpPost]
        public IActionResult ViewRestaurantList(RestaurantsViewModel values)
        {

            RestaurantsViewModel model = new RestaurantsViewModel();
            if (values.SearchValue == null)
            {
                model.RestaurantList = _dbContext.Restaurants.Where
                (n => n.DishTypeId == values.restaurantInfo.DishTypeId).OrderByDescending(n => n.CreationDate).ToList();
            }
            else
            {
                model.RestaurantList = _dbContext.Restaurants.Where(p => p.Name.Contains(values.SearchValue)
                && p.DishTypeId == values.restaurantInfo.DishTypeId).OrderByDescending(n => n.CreationDate).ToList();
            }

            model.DishCategoryList = _dbContext.CategoryDishes.ToList();
            return View(model);
        }

        public IActionResult ViewRestaurant(int id)
        {
            var model = _dbContext.Restaurants.SingleOrDefault(m => m.RestaurantId == id);

            return View(model);

        }



        //Create Restaurant 


        [HttpGet]
        public IActionResult CreateRestaurant()
        {
            RestaurantsViewModel model = new RestaurantsViewModel();
            model.DishCategoryList = _dbContext.CategoryDishes.ToList();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRestaurant( RestaurantsViewModel register)
        {
            
            if (ModelState.IsValid)

            {
                register.restaurantInfo.CreationDate = DateTime.Now;
                _dbContext.Restaurants.Add(register.restaurantInfo);
                _dbContext.SaveChanges();
                return RedirectToAction("ViewRestaurantList");
            }

            else
            {
                register.DishCategoryList = _dbContext.CategoryDishes.ToList();
                return View(register);
            }
        }

        public IActionResult Index()
        {
            var created = _dbContext.Restaurants.ToList();

            return View(created);
        }


        //Show list
        [HttpGet]
        public IActionResult RestaurantListShow()
        {
            RestaurantsViewModel model = new RestaurantsViewModel();
            model.RestaurantList = _dbContext.Restaurants.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditRestaurant(int id)
        {
            var model = new RestaurantsViewModel();
            model.restaurantInfo = _dbContext.Restaurants.SingleOrDefault(k => k.RestaurantId == id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRestaurant(RestaurantsViewModel model, int id)
        {

            var newRestaurant = _dbContext.Restaurants.SingleOrDefault(k => k.RestaurantId == id);

            newRestaurant.Name = model.restaurantInfo.Name;
            newRestaurant.DescriptionOfRestaurant = model.restaurantInfo.DescriptionOfRestaurant;
            newRestaurant.OpeningHours = model.restaurantInfo.OpeningHours;
            newRestaurant.ContactEmail = model.restaurantInfo.ContactEmail;
            newRestaurant.ContactNumber = model.restaurantInfo.ContactNumber;
            newRestaurant.Country = model.restaurantInfo.Country;
            newRestaurant.City = model.restaurantInfo.City;
            newRestaurant.Street = model.restaurantInfo.Street;
            newRestaurant.PostalCode = model.restaurantInfo.PostalCode;
            _dbContext.SaveChanges();
            return RedirectToAction("EditSuccess");
        }

        [HttpGet]
        public IActionResult EditSuccess()
        {
            return View();
        }

    }
}
