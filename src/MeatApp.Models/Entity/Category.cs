using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
