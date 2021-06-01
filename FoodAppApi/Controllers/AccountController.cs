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

        //[HttpGet("{id}")]
        //public ActionResult<User> Get([FromRoute] int id)
        //{
        //    var user = _d
        //}

        [HttpPost("Create")]
        public string CreateUser ([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            int id = _userService.Create(dto);

            return JsonConvert.SerializeObject("Register successfully");
        }


        [HttpGet("CreateNaGecie")]
        public string CreateUserNaGecie([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest();
            }

            int id = _userService.Create(dto);

            return JsonConvert.SerializeObject("Register successfully");
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var userDto = _userService.GetById(id);
            return Ok(userDto);  
        }


    }
}
