using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class COpinion
{
    public int OpinionIdClientIdGradeDescriptionRestaurantIdTimeOpinionId { get; set; }

    public int ClientId { get; set; }

    public DateTime Time { get; set; }

    public decimal Grade { get; set; }

    public string? Description { get; set; }

    public int RestaurantId { get; set; }
}
