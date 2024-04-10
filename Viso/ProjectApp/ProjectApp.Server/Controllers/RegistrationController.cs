using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;
using System.Text;
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
        [Route("CheckUsernameExists")]
        public IActionResult CheckUsernameExists(string usernameWanted)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var username = _dbContext.Clients
                .FromSql($"select * from dbo.Clients where user_name = {usernameWanted}").ToList();
            if (username.Count>0)
            {
                return StatusCode(StatusCodes.Status302Found);
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("CheckEmailExists")]
        public IActionResult CheckEmailExists(string emailWanted)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
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
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            if (Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                var securePassword = EncryptionTool.EncryptData(pass);
                var newClient = new Client()
                {
                    Email = email, 
                    PhoneNumber = phoneNumber, 
                    PassHash = securePassword, 
                    UserName = username
                };
                _dbContext.Add(newClient);
                _dbContext.SaveChanges();
                var newClientRole = new ClientRole()
                {
                    ClientId = newClient.ClientId,
                    RoleId = 1
                };
                _dbContext.Add(newClientRole);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}