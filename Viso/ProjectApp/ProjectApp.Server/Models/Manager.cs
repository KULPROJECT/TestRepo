using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PassHash { get; set; } = null!;

    public int RoleId { get; set; }
}
