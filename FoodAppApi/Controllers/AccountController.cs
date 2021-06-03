using FoodAppApi.Entities;
using FoodAppApi.Models;
using FoodAppApi.Services;
using FoodAppApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
     

                if (!_userService.GetAll().Any(x => x.UserName == dto.UserName)&&
                    ModelState.IsValid)
                {
                    dto.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
                    dto.Password = Convert.ToBase64String(Common.SaltHashPassword(
                        Encoding.ASCII.GetBytes(dto.Password),
                        Convert.FromBase64String(dto.Salt)));

                    int id = _userService.Create(dto);
                    return JsonConvert.SerializeObject("Register successfully.");
                }
            


            return JsonConvert.SerializeObject("Username already exists!");
        }




        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var userDto = _userService.GetById(id);
            return Ok(userDto);  
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody]LoginUserDto dto)
        {
            if(_userService.GetAll().Any(u=>u.UserName == dto.UserName)&&
                ModelState.IsValid)
            {
                User user = _userService.GetAll().Where(u => u.UserName == dto.UserName).FirstOrDefault();

                var hashPassword = Convert.ToBase64String(
                    Common.SaltHashPassword(
                        Encoding.ASCII.GetBytes(dto.Password),
                        Convert.FromBase64String(user.Salt)));
                if (hashPassword == user.Password)
                {
                    return Ok(user);
                }
            }
            return BadRequest("Wrong username or password!");
        }




    }
}
