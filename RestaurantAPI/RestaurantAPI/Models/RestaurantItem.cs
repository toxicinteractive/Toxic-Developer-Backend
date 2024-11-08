using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using static System.Net.WebRequestMethods;

namespace RestaurantAPI.Models
{
    public class RestaurantItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("OpenHoursItem")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Food { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string GoogleMapsUrl
        {
            get
            {
                return "https://www.google.com/maps/dir/?api=1&destination=+" + Address + "+" + City;
            }
        }
        public List<OpenHoursItem> OpenHours { get; set; } = new();
    }

    [PrimaryKey(nameof(RestaurantId), nameof(Day))]
    public class OpenHoursItem
    {
        [Key]
        [Column(Order = 0)]
        public int RestaurantId { get; set; }
        [Key]
        [Column(Order = 1)]
        public DayOfWeek Day { get; set; }
        public string Open { get; set; }
        public string Close { get; set; }
    }


    public class UsedRandomRestaurantItem
    {
        [Key]
        public int Id { get; set; }
    }
}
