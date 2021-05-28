using FoodAppApi.Entities;
using FoodAppApi.Models;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        int Create(CreateUserDto dto);
        UserDto GetById(int id);
    }
}