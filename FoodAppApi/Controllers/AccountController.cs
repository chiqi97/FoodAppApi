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
        //    var user=_d
        //}

        [HttpPost("Create")]
        public ActionResult CreateUser ([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = _userService.Create(dto);

            return Created($"/api/user/{id}", null);
        }


    }
}
