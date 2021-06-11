using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Models
{
    public class EditDishDto
    {
        public int Id { get; set; }
        public string NameOfDish { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
