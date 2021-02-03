using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models
{
    public class MealProduct
    {
        public int? Quantity { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
