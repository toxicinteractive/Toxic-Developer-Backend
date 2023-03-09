using System;
using System.Collections.Generic;

namespace Find_Restaurant.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string DescriptionOfRestaurant { get; set; } = null!;

    public string OpeningHours { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public string ContactEmail { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public int DishTypeId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual CategoryDish DishType { get; set; } = null!;
}
