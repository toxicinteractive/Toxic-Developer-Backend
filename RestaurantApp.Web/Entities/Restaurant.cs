namespace RestaurantApp.Web.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FoodType { get; set; }
        public string Location { get; set; }
        public string OpeningHours { get; set; }
        public bool IsRestaurantOfTheDay { get; set; } = false;
    }
}
