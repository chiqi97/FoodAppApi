using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Models
{
    public class ShoppingCartDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int NumberOfItems { get; set; }
    }
}
