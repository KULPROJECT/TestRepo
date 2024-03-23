using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class ROpinion
{
    public int OpinionId { get; set; }

    public int RestaurantId { get; set; }

    public DateTime Time { get; set; }

    public decimal Grade { get; set; }

    public string Description { get; set; } = null!;

    public int ClientId { get; set; }
}
