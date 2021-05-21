using FoodAppApi.Entities;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IDishService
    {
        IEnumerable<Dish> GetAllDishes();
    }
}