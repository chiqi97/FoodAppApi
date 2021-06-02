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
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users =_userService
                .GetAll()
                .ToList();
            return Ok(users);
        }



        [HttpPost("Create")]
        public string Create ([FromBody] CreateUserDto dto)
        {
            if (ModelState.IsValid)
            {

                if (!_userService.GetAll().Any(x => x.UserName == dto.UserName))
                {
                    int id = _userService.Create(dto);
                    return JsonConvert.SerializeObject("Register successfully.");
                }
            }


            return JsonConvert.SerializeObject("Username already exists!");
        }




        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var userDto = _userService.GetById(id);
            return Ok(userDto);  
        }


    }
}
