using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Reservation
{
    public int RestaurantId { get; set; }

    public int TableNumber { get; set; }

    public string? Description { get; set; }

    public DateTime? Time { get; set; }

    public int? ClientId { get; set; }

    public bool IsOpen { get; set; }
}
