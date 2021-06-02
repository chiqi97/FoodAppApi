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
        public IEnumerable<Dish> GetAll()
        {
            return _dbContext.Dishes;
        }


        public DishDto GetById(int id)
        {
   
            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == id);
            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }
            var result = _mapper.Map<DishDto>(dish);
            return result;
        }

        public int Create(CreateDishDto dto)
        {
            var dish = _mapper.Map<Dish>(dto);
            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();

            return dish.Id;
        }


    }
}
