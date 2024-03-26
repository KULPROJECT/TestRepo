using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;
using System.Text.RegularExpressions;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ProjectdbContext _dbContext;

        public RegistrationController(ProjectdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("CheckUsername")]
        public IActionResult CheckUsername(string usernameWanted)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status404NotFound);
            var username = _dbContext.Clients
                .FromSql($"select * from dbo.Clients where user_name = {usernameWanted}").ToList();
            if (username.Count>0)
            {
                return StatusCode(StatusCodes.Status302Found);
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("CheckEmail")]
        public IActionResult CheckEmail(string emailWanted)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status404NotFound);
            var username = _dbContext.Clients
                .FromSql($"select * from dbo.Clients where email = {emailWanted}").ToList();
            if (username.Count > 0)
            {
                return StatusCode(StatusCodes.Status302Found);
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("AddUser")]
        public IActionResult AddUser(string username, string email, string phoneNumber, string pass)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status404NotFound);
            if (Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                _dbContext.Clients.FromSql(
                    $"insert into dbo.Clients (Email, Pass_hash, User_name, Phone_number) values ('{email}',Cast('{pass}' as binary(64)), '{username}', '{phoneNumber}');");
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}