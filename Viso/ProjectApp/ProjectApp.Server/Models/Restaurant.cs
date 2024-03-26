using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int ManagerId { get; set; }

    public string WorkingHours { get; set; } = null!;

    public decimal? TotalGrade { get; set; }

    public string? Description { get; set; }
}
