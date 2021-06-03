using FoodAppApi.Entities;
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
   


        [HttpGet("GetByCategory/{category}")]
        public ActionResult<IEnumerable<Dish>> GetByCategory([FromRoute] string category)
        {
            var dishes = _dishService
                .GetByCategory(category)
                .ToList();

            return Ok(dishes);

        }


        [HttpGet("GetById/{id}")]
        public ActionResult<DishDto> GetById([FromRoute]int id)
        {
            var dishDto = _dishService.GetById(id);
            return Ok(dishDto);
        }

        [HttpPost("Create")]
        public string Create([FromBody]CreateDishDto dto)
        {
            if (ModelState.IsValid)
            {
                if (!_dishService.GetAll().Any(x => x.NameOfDish == dto.NameOfDish))
                {
                    int id = _dishService.Create(dto);
                    return JsonConvert.SerializeObject("Dish added successfully!");

                }

            }

            return JsonConvert.SerializeObject("Something went wrong!");
        }

        [HttpGet("Search/{name}")]
        public ActionResult Search(string name)
        {
            var output = _dishService.Search(name);
            return Ok(output);
        }


    }
}
