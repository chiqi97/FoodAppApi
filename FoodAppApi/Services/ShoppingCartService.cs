using AutoMapper;
using FoodAppApi.Entities;
using FoodAppApi.Exceptions;
using FoodAppApi.Models;
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
        private readonly IMapper _mapper;

        public ShoppingCartService(AppDbContext appDbContext, 
            IUserService userService, 
            IDishService dishService,
            IMapper mapper)
        {
            _dbContext = appDbContext;
            _userService = userService;
            _dishService = dishService;
            _mapper = mapper;
        }
        public bool AddToShoppingCart(int userId, int dishId)
        {
            var dish = _dishService.GetById(dishId);
            if (dish == null)
            {
                return false;
            }
            ShoppingCart userDish = new ShoppingCart()
            {
                DishId = dishId,
                UserId = userId,
                Name=dish.NameOfDish,
                Price=dish.Price,
                NumberOfItems=1
            };

            if (!_dbContext.ShoppingCarts.Any(x => x.DishId == dishId && x.UserId == userId))
            {

                _dbContext.ShoppingCarts.Add(userDish);
            }
            else
            {
                userDish = _dbContext.ShoppingCarts.Where(x => x.UserId == userId && x.DishId == dishId).FirstOrDefault();
                userDish.NumberOfItems += 1;
                userDish.Price = userDish.NumberOfItems*dish.Price;
            }

            _dbContext.SaveChanges();

            return true;

        }

        public List<ShoppingCartDto> GetById(int id)
        {
            var cartItems = _dbContext.ShoppingCarts.Where(x => x.UserId == id).ToList();
            if (cartItems is null)
            {
                throw new NotFoundException("Items not found");
            }
            var result = _mapper.Map<List<ShoppingCartDto>>(cartItems);
            return result;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCarts;
        }

        public void Delete (int userId, int dishId)
        {
            var item = _dbContext.ShoppingCarts.FirstOrDefault(x => x.DishId == dishId && x.UserId==userId);

            if (item is null)
            {
                throw new NotFoundException("Dish not found");
            }
            _dbContext.ShoppingCarts.Remove(item);

            _dbContext.SaveChanges();

        }

        public void Clear(int userId)
        {
            _dbContext.ShoppingCarts
                .RemoveRange(_dbContext.ShoppingCarts.Where(x => x.UserId == userId));

            _dbContext.SaveChanges();
        }

        public void AddOne(int userId,int dishId)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == dishId);
            var dishShopping = _dbContext.ShoppingCarts
                .FirstOrDefault(x => x.UserId == userId && x.DishId == dishId);
            dishShopping.NumberOfItems += 1;
            dishShopping.Price = dishShopping.NumberOfItems * dish.Price;

            _dbContext.SaveChanges();
        }
        public void DeleteOne(int userId, int dishId)
        {
            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == dishId);
            var dishShopping = _dbContext.ShoppingCarts
                .FirstOrDefault(x => x.UserId == userId && x.DishId == dishId);
            dishShopping.NumberOfItems -= 1;
            dishShopping.Price = dishShopping.NumberOfItems * dish.Price;
            if (dishShopping.NumberOfItems <= 0)
            {
                _dbContext.ShoppingCarts.Remove(dishShopping);
            }
            _dbContext.SaveChanges();
        }


    }
}
