using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectApp.Server.Models;
using ProjectApp.Server.Structures;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : Controller
    {
        private readonly ProjectdbContext _dbContext;

        public AdministratorController(ProjectdbContext dbContext)
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

        [HttpGet]
        [Route("GetClientsRequests")]
        public IActionResult GetClientsRequests()
        {
            var clientList = _dbContext.Clients
                .FromSql($"Select * from Clients where Restaurateur_application is not null").ToList();
            if (clientList.IsNullOrEmpty())
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    "No connection to the DB or no clients!");
            return StatusCode(StatusCodes.Status200OK, clientList);
        }

        [HttpPost]
        [Route("ChangeRequestStatus")]
        public IActionResult ChangeRequestStatus(string[] data)
        {
            var clientID = int.Parse(data[0]); 
            var newStatus = int.Parse(data[1]);

            var client = _dbContext.Clients.FindAsync(clientID);
            if (client.IsFaulted)
                return StatusCode(StatusCodes.Status406NotAcceptable, "No client of such id found!");
            client.Result.RestaurateurApplication = newStatus;
            if (newStatus==(int)ERestaurateurStatus.Accepted)
            {
                var clientRole =
                    _dbContext.ClientRoles.FromSql($"Select * from Client_Roles where Client_id = {clientID}");
                if (clientRole.IsNullOrEmpty())
                    return StatusCode(StatusCodes.Status409Conflict,
                        "Client found but it has no client role assigned!");
                clientRole.FirstOrDefault().RoleId = (int)ERoles.Restaurateur;
            }

            if (newStatus == (int)ERestaurateurStatus.ToCorrect)
            {
                var comment = data[2];
                if (!comment.IsNullOrEmpty())
                {
                    var applicationComment = new ApplicationComment()
                    {
                        ClientId = clientID,
                        Comment = comment
                    };
                    _dbContext.ApplicationComments.Add(applicationComment);
                } //should be prevented by frontend
            }

            {
                
            }
            _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Client's application status changed successfully!");
        }

        [HttpPost]
        [Route("SetRequestStatusResolved")]
        public IActionResult SetRequestStatusResolved(int clientID)
        {
            if (clientID==null) return StatusCode(StatusCodes.Status409Conflict, "Wrong id format!");
            var client = _dbContext.Clients.FindAsync(clientID);
            if (client.IsFaulted)
                return StatusCode(StatusCodes.Status406NotAcceptable, "No client of such id found!");
            client.Result.RestaurateurApplication = null;
            var clientComment = _dbContext.ApplicationComments.Find(clientID);
            if (clientComment!=null) _dbContext.ApplicationComments.Remove(clientComment);
            _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Client's application resolved successfully!");
        }
    }
}