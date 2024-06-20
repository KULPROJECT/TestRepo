using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProjectApp.Server.Models;
using ProjectApp.Server.Services;
using ProjectApp.Server.Structures;

namespace ProjectApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ProjectdbContext _dbContext;
        private readonly string _apiAuthorizationKey = "eyJraWQiOiJjZWlkZyIsImFsZyI6IkhTNTEyIn0.eyJnaXZlbl9uYW1lIjoiS3J6eXN6dG9mIiwicGVzZWwiOiIwMTIxMDEwNDM3MSIsImlhdCI6MTcxODgwMjA0NywiZmFtaWx5X25hbWUiOiJUYXJrb3dza2kiLCJjbGllbnRfaWQiOiJVU0VSLTAxMjEwMTA0MzcxLUtSWllTWlRPRi1UQVJLT1dTS0kifQ.C6Lkll08GvSu3E23P2MlbDl4ITDxUkwMcGUQLmTXFfsjMrwbiSy-jdooh4kEzV8UX3vtmiVqFWwYmVuh3MaYSg";

        public RestaurantController(ProjectdbContext dbContext)
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
                    $"select * from dbo.Menu_Categories where Category_id in (select category_id from menu_items where restaurant_id= {restaurantId})");
            if (categories.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpGet]
        [Route("GetRestaurantMenuItemsFromCategory")]
        public IActionResult GetRestaurantMenuItemsFromCategory(int categoryId, int restaurantId)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var items =
                _dbContext.MenuItems.FromSql(
                    $"select * from dbo.Menu_Items where Category_id = {categoryId} and restaurant_id = {restaurantId}");
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
                    $"select * from dbo.Menu_Items where Restaurant_id = {restaurantId}");
            if (items.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, items);
        }

        [HttpGet]
        [Route("GetAllRestaurantsWithCategory")]
        public IActionResult GetAllRestaurantsWithCategory(int categoryId)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var restaurants =
                _dbContext.Restaurants.FromSql(
                    $"select * from dbo.Restaurants where Restaurant_id in (select Restaurant_id from dbo.Menu_Items where category_id = {categoryId})");
            if (restaurants.IsNullOrEmpty()) return StatusCode(StatusCodes.Status204NoContent);
            return StatusCode(StatusCodes.Status200OK, restaurants);
        }

        [HttpGet]
        [Route("GetBasicRestaurantInfoFromNIP")]
        public async Task<IActionResult> GetBasicRestaurantInfoFromNIP(string NIP)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _apiAuthorizationKey);
            try
            {
                var response =
                    await httpClient.GetAsync($"https://dane.biznes.gov.pl/api/ceidg/v2/firma?nip={NIP}");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Root deserializedResult = JsonConvert.DeserializeObject<Root>(result);
                    string name = deserializedResult.firma[0].nazwa;
                    string adress = ($"{deserializedResult.firma[0].adresDzialalnosci.kod} {deserializedResult.firma[0].adresDzialalnosci.miasto}, {deserializedResult.firma[0].adresDzialalnosci.ulica} {deserializedResult.firma[0].adresDzialalnosci.budynek}");
                    string[] basicRestaurantData =
                    [
                        name,
                        adress
                    ];
                    return StatusCode(StatusCodes.Status200OK, basicRestaurantData);
                }

                return StatusCode(StatusCodes.Status409Conflict, "No restaurant of this NIP found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateRestaurant")]
        public IActionResult CreateRestaurant(string[] creationData)
        {
            if (!_dbContext.Database.CanConnect()) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            var newRestaurant = new Restaurant()
            {
                Name = creationData[0],
                Address = creationData[1],
                ManagerId = int.Parse(creationData[2]),
                WorkingHours = creationData[3],
            };
            if (creationData.Length > 4)
            {
                newRestaurant.PhoneNumber = creationData[4];
                if (creationData.Length > 5)
                {
                    newRestaurant.Description = creationData[5];
                }
            }

            _dbContext.Add(newRestaurant);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Restaurant successfully created");
        }

        [HttpPost]
        [Route("CreateRestaurantWithNIP")]
        public async Task<IActionResult> GetBasicRestaurantInfoFromNIP(string[] creationData)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiAuthorizationKey);
            try
            {
                var response =
                    await httpClient.GetAsync($"https://dane.biznes.gov.pl/api/ceidg/v2/firma?nip={creationData[0]}");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Root deserializedResult = JsonConvert.DeserializeObject<Root>(result);
                    string name = deserializedResult.firma[0].nazwa;
                    string address = ($"{deserializedResult.firma[0].adresDzialalnosci.kod} {deserializedResult.firma[0].adresDzialalnosci.miasto}, {deserializedResult.firma[0].adresDzialalnosci.ulica} {deserializedResult.firma[0].adresDzialalnosci.budynek}");

                    var newRestaurant = new Restaurant()
                    {
                        Name = name,
                        Address = address,
                        ManagerId = int.Parse(creationData[1]),
                        WorkingHours = creationData[2],
                    };

                    if (creationData.Length > 3)
                    {
                        newRestaurant.PhoneNumber = creationData[3];
                        if (creationData.Length > 4)
                        {
                            newRestaurant.Description = creationData[4];
                        }
                    }
                    _dbContext.Add(newRestaurant);
                    _dbContext.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, "Restaurant created successfully");
                }

                return StatusCode(StatusCodes.Status409Conflict, "No restaurant of this NIP found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
