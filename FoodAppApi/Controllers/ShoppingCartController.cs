using FoodAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("AddToShoppingCart/{userId}/{id}")]
        public string AddToShoppingCart([FromRoute] int userId, int id)
        {
            if (_shoppingCartService.AddToShoppingCart(userId, id))
            {
                return JsonConvert.SerializeObject("Added successfully.");
            }
            return JsonConvert.SerializeObject("Something went wrong.");

        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var items=_shoppingCartService.GetAll();
            return Ok(items);
        }

        [HttpGet("GetByUserId/{id}")]
        public ActionResult GetByUserId([FromRoute]int id)
        {
           var cartItems= _shoppingCartService.GetById(id);

            return Ok(cartItems);
        }

        [HttpPost("Delete/{userId}/{dishId}")]
        public string Delete([FromRoute]int userId, int dishId)
        {
            _shoppingCartService.Delete(userId,dishId);
            return JsonConvert.SerializeObject("Deleted Successfully!");
        }

        [HttpPost("Clear/{userId}")]
        public string Clear([FromRoute] int userId)
        {
            _shoppingCartService.Clear(userId);

            return JsonConvert.SerializeObject("Clear Successfully!");
        }


    }
}
