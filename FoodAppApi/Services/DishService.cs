using FoodAppApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _dbContext;

        public DishService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return _dbContext.Dishes;
        }
    }
}
