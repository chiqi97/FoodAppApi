using FoodAppApi.Entities;
using FoodAppApi.Models;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        int Create(CreateUserDto dto);
    }
}