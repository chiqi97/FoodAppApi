using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string NameOfDish { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
