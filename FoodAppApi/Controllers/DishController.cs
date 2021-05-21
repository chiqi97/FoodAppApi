using FoodAppApi.Entities;
using FoodAppApi.Models;
using FoodAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Controllers
{

    [Route("api/dish")]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            var dishes = _dishService
                .GetAllDishes()
                .ToList();

            return Ok(dishes);



            //dishes.Select(r => new RestaurantDto()
            //{
            //    //Name = r.Name,
            //    //Category=r.Category,
            //    //City=r.Address.City

            //}

        }
    }
}
