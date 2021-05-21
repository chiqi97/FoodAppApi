using FoodAppApi.Entities;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
    }
}