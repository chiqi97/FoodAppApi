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


        public Dish GetById(int id)
        {
   
            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == id);
            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }

            return dish;
        }

        public IEnumerable<Dish> GetByCategory(string category)
        {
            return _dbContext.Dishes.Where(x => x.Category == category);

        }

        public int Create(CreateDishDto dto)
        {
            var dish = _mapper.Map<Dish>(dto);
            _dbContext.Dishes.Add(dish);
            _dbContext.SaveChanges();

            return dish.Id;
        }

        public IEnumerable<Dish> Search(string name)
        {
            if (name != null)
            {
               return _dbContext.Dishes.Where(x => x.NameOfDish.Contains(name));
            }
            return _dbContext.Dishes;
        }

        public void Delete (int id)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Id == id);
            if(dish is null)
            {
                ; throw new NotFoundException("Dish not found");
            }
            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();
        }
    }
}
