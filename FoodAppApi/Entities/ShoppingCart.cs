using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ShoppingCart()
        {
            this.NumberOfItems = 1;
        }
        public string Name { get; set; }
        public int DishId { get; set; }
        public int UserId { get; set; }
        public int NumberOfItems { get; set; }
        public double Price { get; set; }
        public double PriceOfOneDish { get; set; }
    }
}
