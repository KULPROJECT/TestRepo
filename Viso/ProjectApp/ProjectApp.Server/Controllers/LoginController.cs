using Microsoft.AspNetCore.Mvc;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ProjectdbContext _dbContext;

        public LoginController(ProjectdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CheckLoginCredentials")]
        public IActionResult CheckLoginCredentials(string[] credentials)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            List<Client> clientList = _dbContext.Clients.ToList();
            foreach (Client client in clientList)
            {
                if (client.UserName==credentials[0]||client.Email== credentials[0])
                {
                    if (EncryptionTool.ValidateEncryptedData(credentials[1], client.PassHash))
                        return StatusCode(StatusCodes.Status200OK, client.ClientId);
                }
            }
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
    }
}
