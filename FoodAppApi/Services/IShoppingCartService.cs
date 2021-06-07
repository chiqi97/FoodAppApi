using FoodAppApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCart> GetAll();
        bool AddToShoppingCart(string userName, int id);
        List<ShoppingCart> GetById(int id);
    }
}
