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

        [HttpPost("AddToShoppingCart/{userName}/{id}")]
        public string AddToShoppingCart([FromRoute] string userName, int id)
        {
            if (_shoppingCartService.AddToShoppingCart(userName, id))
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
    }
}
