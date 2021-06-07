using FoodAppApi.Entities;
using FoodAppApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly IDishService _dishService;

        public ShoppingCartService(AppDbContext appDbContext, 
            IUserService userService, 
            IDishService dishService)
        {
            _dbContext = appDbContext;
            _userService = userService;
            _dishService = dishService;
        }
        public bool AddToShoppingCart(string userName, int id)
        {
            var dish = _dishService.GetById(id);
            var user = _dbContext.Users
                .FirstOrDefault(x => x.UserName == userName);
            if (dish == null || user == null)
            {
                return false;
            }
            ShoppingCart userDish = new ShoppingCart()
            {
                DishId = id,
                UserId = user.Id,
                Name=dish.NameOfDish,
                Price=dish.Price,
                NumberOfItems=1
            };

            if (!_dbContext.ShoppingCarts.Any(x => x.DishId == id && x.UserId == user.Id))
            {

                _dbContext.ShoppingCarts.Add(userDish);
            }
            else
            {
                userDish = _dbContext.ShoppingCarts.Where(x => x.UserId == user.Id && x.DishId == id).FirstOrDefault();
                userDish.NumberOfItems += 1;
                userDish.Price *= userDish.NumberOfItems;
            }

            _dbContext.SaveChanges();

            return true;

        }

        public List<ShoppingCart> GetById(int id)
        {
            var cartItems = _dbContext.ShoppingCarts.Where(x => x.UserId == id).ToList();
            if (cartItems is null)
            {
                throw new NotFoundException("Items not found");
            }

            return cartItems;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCarts;
        }

    }
}
