using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class ApplicationComment
{
    public int ClientId { get; set; }

    public string Comment { get; set; } = null!;
}
