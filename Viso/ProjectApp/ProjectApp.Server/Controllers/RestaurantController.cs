using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ProjectDbContext _dbContext;

        public RestaurantController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("GetRestaurantList")]
        public IActionResult GetRestaurantList()
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            List<Restaurant> restaurants = _dbContext.Restaurants.ToList();
            return StatusCode(StatusCodes.Status200OK, restaurants);
        }

        [HttpGet]
        [Route("GetRestaurantMenuCategories")]
        public IActionResult GetRestaurantMenuCategories(int restaurantId)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var categories =
                _dbContext.MenuCategories.FromSql(
                    $"select * from dbo.Menu_Categories where Restaurant_id = {restaurantId}");
            if (categories.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpGet]
        [Route("GetRestaurantMenuItemsFromCategory")]
        public IActionResult GetRestaurantMenuItemsFromCategory(int categoryId)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var items =
                _dbContext.MenuItems.FromSql(
                    $"select * from dbo.Menu_Items where Category_id = {categoryId}");
            if (items.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, items);
        }

        [HttpGet]
        [Route("GetRestaurantAllMenuItems")]
        public IActionResult GetRestaurantAllMenuItems(int restaurantId)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var items =
                _dbContext.MenuItems.FromSql(
                    $"select * from dbo.Menu_Items where Category_id in (select Category_id from dbo.Menu_Categories where Restaurant_id = {restaurantId})");
            if (items.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, items);
        }

        [HttpGet]
        [Route("GetAllRestaurantsWithCategory")]
        public IActionResult GetAllRestaurantsWithCategory(string categoryName)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var restaurants =
                _dbContext.Restaurants.FromSql(
                    $"select * from dbo.Restaurants where Restaurant_id in (select Restaurant_id from dbo.Menu_Categories where Name = {categoryName})");
            if (restaurants.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, restaurants);
        }
    }
}
