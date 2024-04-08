using Microsoft.AspNetCore.Mvc;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ProjectDbContext _dbContext;

        public LoginController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("CheckLoginCredentials")]
        public IActionResult CheckLoginCredentials(string loginOrEmail, string pass)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            List<Client> clientList = _dbContext.Clients.ToList();
            foreach (Client client in clientList)
            {
                if (client.UserName==loginOrEmail||client.Email==loginOrEmail)
                {
                    if (EncryptionTool.ValidateEncryptedData(pass, client.PassHash))
                        return StatusCode(StatusCodes.Status200OK);
                }
            }
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}
