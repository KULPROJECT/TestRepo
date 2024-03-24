using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;

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
            List<Client> clientList = _dbContext.Clients.ToList();
            if (clientList == null) return StatusCode(StatusCodes.Status404NotFound);
            foreach (var client in clientList)
            {
                if (client.UserName.Equals(usernameWanted))
                {
                    return StatusCode(StatusCodes.Status302Found);
                }
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("CheckEmail")]
        public IActionResult CheckEmail(string emailWanted)
        {
            List<Client> clientList = _dbContext.Clients.ToList();
            if (clientList == null)
                foreach (var client in clientList)
                {
                    if (client.UserName.Equals(emailWanted))
                    {
                        return StatusCode(StatusCodes.Status302Found);
                    }
                }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Route("AddUser")]
        public IActionResult AddUser(string username, string email, string phoneNumber, string pass)
        {
            return null;
        }
    }
}