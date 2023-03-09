using Find_Restaurant.Models;

namespace Find_Restaurant.ViewModels
{
    public class RestaurantsViewModel
    {
        public List<Restaurant> RestaurantList { get; set; }

        public Restaurant restaurantInfo { get; set; }
        public List<CategoryDish> DishCategoryList { get; set; }

        public CategoryDish DishCategoryInfo { get; set; }
        public string SearchValue { get; set; }

        public RestaurantsViewModel()
        {
            RestaurantList = new List<Restaurant>();
            DishCategoryList = new List<CategoryDish>();
            restaurantInfo = new Restaurant();
        }

    }
}
