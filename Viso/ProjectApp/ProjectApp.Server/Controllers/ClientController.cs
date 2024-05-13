using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Server.Models;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ProjectdbContext _dbContext;

        public ClientController(ProjectdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetClients()
        {
            List<Client> clientList = _dbContext.Clients.ToList();
            return StatusCode(StatusCodes.Status200OK, clientList);
        }

        [HttpPost]
        [Route("ApplyForRestaurateur")]
        public IActionResult ApplyForRestaurateur(int clientID)
        {
            if (clientID!=null)
            {
                var client = _dbContext.Clients.FindAsync(clientID);
                if (client.Result == null)
                    return StatusCode(StatusCodes.Status406NotAcceptable, "No such client!");

                if (client.Result.RestaurateurApplication == 0)
                    return StatusCode(StatusCodes.Status403Forbidden,
                        "Request is being verified, please wait for a message");

                client.Result.RestaurateurApplication = 0;
                _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Application saved to database");
            }
            return StatusCode(StatusCodes.Status409Conflict, "Wrong id format!");
        }
    }
}