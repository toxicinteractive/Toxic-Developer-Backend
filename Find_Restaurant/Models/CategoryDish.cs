using System;
using System.Collections.Generic;

namespace Find_Restaurant.Models;

public partial class CategoryDish
{
    public CategoryDish()
    {
        Restaurants = new HashSet<Restaurant>();
    }
    public int DishTypeId { get; set; }

    public string DishName { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; } = new List<Restaurant>();
}
