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


    [ApiController]
    [Route("[controller]")]
    public class DishController : Controller
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Dish>> GetAll()
        {
            var dishes = _dishService
                .GetAll()
                .ToList();

            return Ok(dishes);

        }

        [HttpGet("{id}")]
        public ActionResult<DishDto> Get([FromRoute]int id)
        {
            var dishDto = _dishService.GetById(id);
            return Ok(dishDto);
        }

    }
}
