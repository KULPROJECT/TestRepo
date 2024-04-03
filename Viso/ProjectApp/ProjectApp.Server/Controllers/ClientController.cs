using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Server.Models;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        public ClientController(ProjectDbContext dbContext)
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

    }
}
