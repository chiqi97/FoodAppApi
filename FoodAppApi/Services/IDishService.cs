﻿using FoodAppApi.Entities;
using FoodAppApi.Models;
using System.Collections.Generic;

namespace FoodAppApi.Services
{
    public interface IDishService
    {
        IEnumerable<Dish> GetAll();
        DishDto GetById(int id);
        int Create(CreateDishDto dto);
        IEnumerable<Dish> GetByCategory(string category);
        IEnumerable<Dish> Search(string name);
        void Delete(int id);
    }
}