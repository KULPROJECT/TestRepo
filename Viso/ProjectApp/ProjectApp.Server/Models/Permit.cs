using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Permit
{
    public int PermitId { get; set; }

    public string PermitName { get; set; } = null!;
}
