using FoodAppApi.Models;
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

        [HttpPost("AddToShoppingCart/userid={userId}/dishid={dishId}")]
        public string AddToShoppingCart([FromRoute] int userId, int dishId)
        {
            if (_shoppingCartService.AddToShoppingCart(userId, dishId))
            {
                return JsonConvert.SerializeObject("Added successfully.");
            }
            return JsonConvert.SerializeObject("Something went wrong.");

        }

        //[HttpGet("GetAll")]
        //public ActionResult GetAll()
        //{
        //    var items=_shoppingCartService.GetAll();
        //    return Ok(items);
        //}

        [HttpGet("GetByUserId/{id}")]
        public ActionResult GetByUserId([FromRoute]int id)
        {
           var cartItems= _shoppingCartService.GetById(id);

            return Ok(cartItems);
        }

        [HttpPost("Delete/userid={userId}/dishid={dishId}")]
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

<<<<<<< HEAD
        [HttpPost("DeleteOne/userid={userId}/dishid={dishId}")]
        public string DeleteOne([FromRoute]int userId, int dishId)
        {
            _shoppingCartService.DeleteOne(userId,dishId);

            return JsonConvert.SerializeObject("Deleted Successfully!");
        }

        [HttpPost("AddOne/userid={userId}/dishid={dishId}")]
        public string AddOne([FromRoute] int userId, int dishId)
        {
            _shoppingCartService.AddOne(userId, dishId);

            return JsonConvert.SerializeObject("Added Successfully!");
        }

        [HttpGet("sum/{userId}")]
        public ActionResult Sum([FromRoute] int userId)
        {
            var dishes = _shoppingCartService.GetById(userId);
        
            double sum = dishes.Select(x => x.Price).Sum();
            SumShoppingCartDto result = new SumShoppingCartDto()
            {
                Price = sum
            };

            return Ok(result);
        }


=======
>>>>>>> parent of 6f22cb5 ( Added delete and add one functionality)

    }
}
