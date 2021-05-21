using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Entities
{
    public class FoodAppSeeder
    {
        private readonly AppDbContext _dbContext;

        public FoodAppSeeder(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Dishes.Any())
                {
                    var dishes = GetDishes();
                    _dbContext.Dishes.AddRange(dishes);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                  new User()
            {

                UserName = "chiqi",
                Password = "testowehaslo",
                Email = "Testowy email",
                Name = "Zenek",
                LastName = "Sztacheta"

            },
                   new User()
              {


                 UserName = "Taki2",
                 Password = "testowehaslo",
                 Email = "Testowy email",
                 Name = "Marcin",
                 LastName = "Wozek"

                }
            };

            return users;
        }

        private IEnumerable<Dish> GetDishes()
        {



            var dishes = new List<Dish>()
           {
               new Dish()
               {

                  NameOfDish="Burger z zurawina",
                  Price=3,
                  PhotoPath="Zrodlo fotki"

               },
               new Dish()
               {

                  NameOfDish="Burger z miechem",
                  Price=5,
                  PhotoPath="Zrodlo fotki"

               },

           };
            return dishes;
        }
    }
}
