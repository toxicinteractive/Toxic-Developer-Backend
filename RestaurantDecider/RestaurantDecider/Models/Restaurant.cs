using System;
namespace RestaurantDecider.Models
{
	public class Restaurant
	{
		public string Name { get; set; }
		public string Food { get; set; }
		public string Address { get; set; }
		public DateTime OpenHour { get; set; }
		public DateTime CloseHour { get; set; }
		public int TimesPicked { get; set; }
	}
}

