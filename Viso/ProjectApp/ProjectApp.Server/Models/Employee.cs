using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Employee
{
    public int RestaurantId { get; set; }

    public int ClientId { get; set; }

    public DateTime? AddDate { get; set; }
}
