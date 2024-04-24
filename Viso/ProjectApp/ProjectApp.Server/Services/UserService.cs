using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectApp.Server.Models;

namespace ProjectApp.Server.Services
{
    public class UserService
    {
        public UserService()
        {
        }

        public static bool IsPermitted(int permitIdRequired, int client_id, ProjectdbContext dbContext)
        {
            var permits = dbContext.RolePermits.FromSql(
                $"select * from role_permits where role_id in (select role_id from client_roles where client_id = {client_id})");
            foreach (var permit in permits)
            {
                if (permit.PermitId == permitIdRequired) return true;
            }
            return false;
        }
    }
}