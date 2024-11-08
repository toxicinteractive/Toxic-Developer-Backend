using RestaurantApp.Web.Entities;

namespace RestaurantApp.Web.Models
{
    public class RestaurantViewModel
    {
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Location { get; set; }
        public string OpeningHours { get; set; }
        public Restaurant RestaurantOfTheDay { get; set; }
        public IEnumerable<Restaurant> Restaurants {get; set;}
    }
}
