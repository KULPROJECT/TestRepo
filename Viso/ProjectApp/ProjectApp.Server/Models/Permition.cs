using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Permition
{
    public int PermitId { get; set; }

    public string PermitName { get; set; } = null!;

    public int RoleId { get; set; }
}
