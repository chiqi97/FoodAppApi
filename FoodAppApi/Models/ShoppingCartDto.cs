using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Models
{
    public class ShoppingCartDto
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfItems { get; set; }
        public double PriceOfOneDish { get; set; }
    }
}
