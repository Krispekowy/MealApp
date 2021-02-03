using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Models
{
    public class ShoppingListDTO
    {
        public string Category { get; set; }
        public List<ProductsToBuyDTO> Products { get; set; }
    }
}
