using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectApp.Server.Models;
using ProjectApp.Server.Structures;

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


        [HttpPost]
        [Route("ApplyForRestaurateur")]
        public IActionResult ApplyForRestaurateur(int clientID)
        {
            if (clientID != null)
            {
                var client = _dbContext.Clients.FindAsync(clientID);
                if (client.Result == null)
                    return StatusCode(StatusCodes.Status406NotAcceptable, "No such client!");

                //if (client.Result.RestaurateurApplication == 0)
                //    return StatusCode(StatusCodes.Status403Forbidden,
                //        "Request is being verified, please wait for a message"); TODO: MOVE TO FRONTEND

                client.Result.RestaurateurApplication = (int)ERestaurateurStatus.Applied;
                _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Application saved to database");
            }

            return StatusCode(StatusCodes.Status409Conflict, "Wrong id format!");
        }

        [HttpPost]
        [Route("GetClientApplicationStatus")]
        public IActionResult GetClientApplicationStatus(int clientID)
        {
            if (clientID != null)
            {
                var client = _dbContext.Clients.FindAsync(clientID);
                if (client.Result == null)
                    return StatusCode(StatusCodes.Status406NotAcceptable, "No such client!");

                var restaurateurApplication = client.Result.RestaurateurApplication;
                if (restaurateurApplication == null)
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Client did not apply to become a restaurateur");

                var applicationStatus = (ERestaurateurStatus) restaurateurApplication;
                string[] response = [applicationStatus.ToString(), null];
                if (client.Result.RestaurateurApplication == (int)ERestaurateurStatus.ToCorrect)
                {
                    var applicationComment =
                        _dbContext.ApplicationComments.Find(clientID);
                    if (applicationComment!=null)
                    {
                        response[1] = applicationComment.Comment;
                    }
                }

                _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status409Conflict, "Wrong id format!");
        }
    }
}