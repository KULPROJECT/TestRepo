using System;
using System.Collections.Generic;

namespace ProjectApp.Server.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PassHash { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int RoleId { get; set; }
    public Client(string email, string? phoneNumber, string passHash, string userName)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        PassHash = passHash;
        UserName = userName;
        RoleId = 1;
    }
}
