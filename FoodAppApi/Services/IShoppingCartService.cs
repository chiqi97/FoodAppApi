using FoodAppApi.Entities;
using FoodAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCart> GetAll();
        bool AddToShoppingCart(int userId, int dishId);
        List<ShoppingCartDto> GetById(int id);
        void Delete(int userId, int dishId);
        void Clear(int userId);
    }
}
