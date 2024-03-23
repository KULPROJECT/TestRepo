using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int RestaurantId { get; set; }

    public int ClientId { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public DateTime? TimeOfDelivery { get; set; }

    public bool? Successful { get; set; }
}
