using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class OrderItem
{
    public int OrderId { get; set; }

    public int ItemId { get; set; }
}
