using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class MenuItem
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int RestaurantId { get; set; }
}
