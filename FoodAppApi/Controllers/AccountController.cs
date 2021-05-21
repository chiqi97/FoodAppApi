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
    [Route("api/Account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users =_userService
                .GetAllUsers()
                .ToList();
            return Ok(users);
        }

        [Route("CreateUser")]
        [HttpPost]
        public ActionResult CreateUser ([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = _userService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }


    }
}
