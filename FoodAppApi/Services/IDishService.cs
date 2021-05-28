using FoodAppApi.Entities;
using FoodAppApi.Models;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IDishService
    {
        IEnumerable<Dish> GetAllDishes();
        DishDto GetById(int id);
    }
}