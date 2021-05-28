using AutoMapper;
using FoodAppApi.Entities;
using FoodAppApi.Exceptions;
using FoodAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class DishService : IDishService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(AppDbContext dbContext,
                            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return _dbContext.Dishes;
        }

        [HttpGet("{id}")]
        public DishDto GetById(int id)
        {
   
            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == id);
            if (dish is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            var result = _mapper.Map<DishDto>(dish);
            return result;
        }


    }
}
